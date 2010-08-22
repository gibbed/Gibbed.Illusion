using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats
{
    // SluttyDataStorage :D?
    public class SdsFile
    {
        public uint DataAlignment;

        public List<DataStorage.DataType> DataTypes =
            new List<DataStorage.DataType>();
        
        public List<DataStorage.BlockInfo> DataBlocks =
            new List<DataStorage.BlockInfo>();

        public void Deserialize(Stream input)
        {
            bool littleEndian;
            {
                input.Seek(8, SeekOrigin.Begin);
                var platform = input.ReadStringASCII(4, true);

                littleEndian =
                    platform != "XBOX" &&
                    platform != "PS3";
            }

            input.Seek(0, SeekOrigin.Begin);

            var stream = new SdsStream(input, littleEndian);

            var header = new DataStorage.Header();
            header.Deserialize(stream.ReadSafeStream(12));

            var info = new DataStorage.ArchiveInfo();
            info.Deserialize(stream.ReadSafeStream(52));

            // data types
            input.Seek(info.TypeTableOffset, SeekOrigin.Begin);
            {
                uint count = stream.ReadValueU32();
                this.DataTypes.Clear();
                for (uint i = 0; i < count; i++)
                {
                    var dataType = new DataStorage.DataType();
                    dataType.Deserialize(stream);
                    this.DataTypes.Add(dataType);
                }
            }

            // data blocks
            input.Seek(info.BlockTableOffset, SeekOrigin.Begin);
            {
                uint magic = stream.ReadValueU32(); // magic
                uint alignment = stream.ReadValueU32(); // blocksize
                byte flags = stream.ReadValueU8(); // if unk6 != 4 : see note 1

                if (magic != 0x6C7A4555 || alignment != 0x4000 || flags != 4)
                {
                    throw new InvalidOperationException();
                }

                this.DataAlignment = alignment;
                this.DataBlocks.Clear();
                while (true)
                {
                    uint size = stream.ReadValueU32();
                    bool compressed = stream.ReadValueU8() != 0;

                    if (size == 0)
                    {
                        break;
                    }

                    if (compressed == true)
                    {
                        var compressionInfo = new DataStorage.BlockCompressionInfo();
                        compressionInfo.Deserialize(stream);

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

                        this.DataBlocks.Add(
                            new DataStorage.BlockInfo()
                            {
                                Compressed = true,
                                Offset = input.Position,
                                UncompressedSize = compressionInfo.UncompressedSize,
                                CompressedSize = compressionInfo.CompressedSize,
                            });

                        input.Seek(compressionInfo.CompressedSize, SeekOrigin.Current);
                    }
                    else
                    {
                        this.DataBlocks.Add(
                            new DataStorage.BlockInfo()
                            {
                                Compressed = false,
                                Offset = input.Position,
                                UncompressedSize = size,
                                CompressedSize = size,
                            });

                        input.Seek(size, SeekOrigin.Current);
                    }
                }
            }

            var blockStream = new BlockStream(input);
            {
                long offset = 0;
                foreach (var block in this.DataBlocks)
                {
                    if (block.Compressed == true)
                    {
                        blockStream.AddCompressedBlock(
                            offset,
                            block.UncompressedSize,
                            block.Offset,
                            block.CompressedSize);
                    }
                    else
                    {
                        blockStream.AddUncompressedBlock(
                            offset,
                            block.UncompressedSize,
                            block.Offset);
                    }
                    offset += this.DataAlignment;
                }
            }

            using (var output = File.Create("bob.out"))
            {
                blockStream.SaveUncompressed(output);
            }

            /*
            blockStream.Seek(0, SeekOrigin.Begin);
            for (uint i = 0; i < info.FileCount; i++)
            {
                var fileInfo = new DataStorage.FileInfo();
                fileInfo.Deserialize(new SdsStream(blockStream, littleEndian));
                input.Seek(
            }
            */
        }
    }
}
