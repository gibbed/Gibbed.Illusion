using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.XPath;
using Gibbed.IO;

namespace Gibbed.Illusion.FileFormats
{
    // SDS = SluttyDataStorage :D?
    public class SdsReader
    {
        public DataStorage.ArchiveHeader Header;
        private string Platform;
        private Stream FileStream;
        private Stream DataStream;
        private BlockStream BlockStream;

        public List<DataStorage.ResourceTypeReference> ResourceTypes =
            new List<DataStorage.ResourceTypeReference>();

        public string Xml;

        public List<Entry> Entries =
            new List<Entry>();

        public SdsReader()
        {
            this.FileStream = null;
            this.DataStream = null;
            this.BlockStream = null;
        }

        public bool Open(string path)
        {
            if (this.BlockStream != null)
            {
                this.BlockStream.FreeLoadedBlocks();
            }

            if (this.DataStream != null)
            {
                if (this.FileStream != this.DataStream)
                {
                    this.DataStream.Close();
                }
            }

            if (this.FileStream != null)
            {
                this.FileStream.Close();
            }

            var input = File.Open(
                path,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite);

            this.Initialize(input);

            return true;
        }

        public void Close()
        {
            this.BlockStream.FreeLoadedBlocks();
            this.FileStream.Close();
        }

        private void Initialize(Stream input)
        {
            Stream data = input;

            if (input.Length >= (0x90 + 15))
            {
                input.Seek(0x90, SeekOrigin.Begin);
                byte[] fsfh = new byte[15];
                input.Read(fsfh, 0, fsfh.Length);

                // "tables/fsfh.bin"
                if (FNV.Hash64(fsfh, 0, fsfh.Length) == 0x39DD22E69C74EC6F)
                {
                    input.Seek(0x10000, SeekOrigin.Begin);

                    FileFormats.TEA.Setup setup = null;

                    byte[] encryptedHeader = new byte[8];
                    input.Read(encryptedHeader, 0, encryptedHeader.Length);

                    byte[] decryptedHeader = new byte[8];
                    foreach (var current in FileFormats.TEA.Mafia2.Setups)
                    {
                        Array.Copy(
                            encryptedHeader,
                            decryptedHeader,
                            encryptedHeader.Length);

                        FileFormats.TEA.Decrypt(
                            decryptedHeader,
                            0,
                            8,
                            FileFormats.TEA.Mafia2.Keys,
                            current.Sum,
                            current.Delta,
                            current.Rounds);

                        if (BitConverter.ToUInt32(decryptedHeader, 0) == 0x00534453)
                        {
                            setup = current;
                            break;
                        }
                    }

                    if (setup == null)
                    {
                        throw new InvalidOperationException();
                    }

                    input.Seek(0x10000, SeekOrigin.Begin);

                    data = new MemoryStream();

                    long left = input.Length - input.Position;
                    byte[] buffer = new byte[0x4000];
                    while (left > 0)
                    {
                        int block = (int)(Math.Min(left, buffer.Length));
                        input.Read(buffer, 0, block);
                        FileFormats.TEA.Decrypt(buffer, 0, block, FileFormats.TEA.Mafia2.Keys, setup.Sum, setup.Delta, setup.Rounds);
                        data.Write(buffer, 0, block);
                        left -= block;
                    }

                    data.Position = 0;
                }
            }

            Endian endian;
            {
                data.Seek(8, SeekOrigin.Begin);
                var platform = data.ReadString(4, true, Encoding.ASCII);

                endian = platform != "XBOX" && platform != "PS3"
                             ? Endian.Little
                             : Endian.Big;
            }

            // header
            data.Seek(0, SeekOrigin.Begin);
            {
                var memory = data.ReadToMemoryStreamSafe(
                    12, endian);
                var magic = memory.ReadString(4, true, Encoding.ASCII);
                var version = memory.ReadValueU32(endian);
                var platform = memory.ReadString(4, true, Encoding.ASCII);

                if (magic != "SDS")
                {
                    throw new FormatException("not an SDS archive");
                }

                if (version != 19)
                {
                    throw new FormatException("unsupported SDS archive version");
                }

                this.Platform = platform;
            }

            var archiveHeader = new DataStorage.ArchiveHeader();
            archiveHeader.Deserialize(
                data.ReadToMemoryStreamSafe(52, endian),
                endian);

            // data types
            data.Seek(archiveHeader.ResourceTypeTableOffset, SeekOrigin.Begin);
            {
                uint count = data.ReadValueU32(endian);
                this.ResourceTypes.Clear();
                for (uint i = 0; i < count; i++)
                {
                    var type = new DataStorage.ResourceTypeReference();
                    type.Deserialize(data, endian);
                    this.ResourceTypes.Add(type);
                }
            }

            // xml
            data.Seek(archiveHeader.XmlOffset, SeekOrigin.Begin);
            {
                var buffer = new byte[data.Length - archiveHeader.XmlOffset];
                data.Read(buffer, 0, buffer.Length);
                this.Xml = Encoding.ASCII.GetString(buffer);
            }

            List<string> descriptions = null;
            if (this.Xml != null)
            {
                descriptions = new List<string>();
                var doc = new XPathDocument(new StringReader(this.Xml));
                var nav = doc.CreateNavigator();
                var nodes = nav.Select("/xml/ResourceInfo/SourceDataDescription");
                while (nodes.MoveNext() == true)
                {
                    descriptions.Add(nodes.Current.Value);
                }
            }

            // data blocks
            var blockStream = new BlockStream(data);
            data.Seek(archiveHeader.BlockTableOffset, SeekOrigin.Begin);
            {
                uint magic = data.ReadValueU32(endian);
                uint alignment = data.ReadValueU32(endian);
                byte flags = data.ReadValueU8();
                // if flags != 4 : see note 1

                if (magic != 0x6C7A4555 || /*alignment != 0x4000 ||*/ flags != 4)
                {
                    throw new InvalidOperationException();
                }

                long virtualOffset = 0;
                while (true)
                {
                    uint size = data.ReadValueU32(endian);
                    bool compressed = data.ReadValueU8() != 0;

                    if (size == 0)
                    {
                        break;
                    }

                    if (compressed == true)
                    {
                        var compressionInfo = new DataStorage.CompressedBlockHeader();
                        compressionInfo.Deserialize(data, endian);

                        if (compressionInfo.Unknown04 != 32 ||
                            compressionInfo.Unknown08 != 81920 ||
                            compressionInfo.Unknown0C != 135200769)
                        {
                            throw new InvalidOperationException();
                        }

                        if (size - 32 != compressionInfo.CompressedSize)
                        {
                            throw new InvalidOperationException();
                        }

                        blockStream.AddCompressedBlock(
                            virtualOffset,
                            compressionInfo.UncompressedSize,
                            data.Position,
                            compressionInfo.CompressedSize);

                        data.Seek(compressionInfo.CompressedSize, SeekOrigin.Current);
                    }
                    else
                    {
                        blockStream.AddUncompressedBlock(
                            virtualOffset,
                            size,
                            data.Position);

                        data.Seek(size, SeekOrigin.Current);
                    }

                    virtualOffset += alignment;
                }
            }

            // file info
            blockStream.Seek(0, SeekOrigin.Begin);
            {
                this.Entries.Clear();
                for (uint i = 0; i < archiveHeader.FileCount; i++)
                {
                    var position = blockStream.Position;
                    var memory = blockStream.ReadToMemoryStreamSafe(26, endian);

                    var fileHeader = new DataStorage.FileHeader();
                    fileHeader.Deserialize(memory, endian);

                    string description = descriptions == null ? null : descriptions[(int)i];
                    if (string.IsNullOrEmpty(description) == true ||
                        description == "not available")
                    {
                        description = string.Format("{0:X8}", position);
                    }

                    this.Entries.Add(new Entry()
                        {
                            Header = fileHeader,
                            Description = description,
                            Offset = blockStream.Position,
                            Size = fileHeader.Size - 30,
                        });

                    blockStream.Seek(position + fileHeader.Size, SeekOrigin.Begin);
                }
            }

            this.Header = archiveHeader;
            this.BlockStream = blockStream;
            this.DataStream = data;
            this.FileStream = input;

            this.BlockStream.FreeLoadedBlocks();
        }

        public void ExportData(Stream output)
        {
            this.BlockStream.SaveUncompressed(output);
        }

        public void ExportData(string outputPath)
        {
            using (var output = File.Create(outputPath))
            {
                this.BlockStream.SaveUncompressed(output);
            }

            this.BlockStream.FreeLoadedBlocks();
        }

        public class Entry
        {
            public DataStorage.FileHeader Header;
            public long Offset;
            public uint Size;
            public uint TypeId { get { return this.Header.TypeId; } }
            public string Description { get; internal set; }
        }

        public void ExportEntry(Entry entry, string outputPath)
        {
            using (var output = File.Create(outputPath))
            {
                this.BlockStream.Seek(entry.Offset, SeekOrigin.Begin);
                long left = entry.Size;
                byte[] buffer = new byte[0x4000];
                while (left > 0)
                {
                    int block = (int)(Math.Min(left, buffer.Length));
                    this.BlockStream.Read(buffer, 0, block);
                    output.Write(buffer, 0, block);
                    left -= block;
                }
            }

            this.BlockStream.FreeLoadedBlocks();
        }

        public MemoryStream GetEntry(Entry entry)
        {
            this.BlockStream.Seek(entry.Offset, SeekOrigin.Begin);
            
            var memory = new MemoryStream();
            {
                long left = entry.Size;
                byte[] buffer = new byte[0x4000];
                while (left > 0)
                {
                    int block = (int)(Math.Min(left, buffer.Length));
                    this.BlockStream.Read(buffer, 0, block);
                    memory.Write(buffer, 0, block);
                    left -= block;
                }
                memory.Position = 0;
            }

            //this.BlockStream.FreeLoadedBlocks();
            return memory;
        }

        public SdsMemory LoadToMemory()
        {
            var memory = new SdsMemory();
            
            memory.Header = (DataStorage.ArchiveHeader)this.Header.Clone();
            
            memory.ResourceTypes.Clear();
            foreach (var resourceType in this.ResourceTypes)
            {
                memory.ResourceTypes.Add((DataStorage.ResourceTypeReference)resourceType.Clone());
            }

            memory.Entries.Clear();
            foreach (var entry in this.Entries)
            {
                memory.Entries.Add(new SdsMemory.Entry()
                    {
                        Header = (DataStorage.FileHeader)entry.Header.Clone(),
                        Description = entry.Description,
                        Data = this.GetEntry(entry),
                    });
            }

            memory.Xml = this.Xml;

            return memory;
        }
    }
}
