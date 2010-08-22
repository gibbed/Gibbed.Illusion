using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats
{
    // SDS = SluttyDataStorage :D?
    public class SdsReader
    {
        private string Platform;
        private Stream FileStream;
        private BlockStream BlockStream;

        private List<DataStorage.DataType> DataTypes =
            new List<DataStorage.DataType>();

        public SdsReader()
        {
            this.FileStream = null;
            this.BlockStream = null;
        }

        public bool Open(string path)
        {
            if (this.BlockStream != null)
            {
                this.BlockStream.FreeLoadedBlocks();
                this.BlockStream = null;
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

            bool littleEndian;
            {
                input.Seek(8, SeekOrigin.Begin);
                var platform = input.ReadStringASCII(4, true);

                littleEndian =
                    platform != "XBOX" &&
                    platform != "PS3";
            }

            // header
            input.Seek(0, SeekOrigin.Begin);
            {
                var header = input.ReadToMemoryStreamSafe(
                    12, littleEndian);
                var magic = header.ReadStringASCII(4, true);
                var version = header.ReadValueU32(littleEndian);
                var platform = header.ReadStringASCII(4, true);

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

            var info = new DataStorage.ArchiveInfo();
            info.Deserialize(
                input.ReadToMemoryStreamSafe(52, littleEndian),
                littleEndian);

            // data types
            input.Seek(info.TypeTableOffset, SeekOrigin.Begin);
            {
                uint count = input.ReadValueU32(littleEndian);
                this.DataTypes.Clear();
                for (uint i = 0; i < count; i++)
                {
                    var dataType = new DataStorage.DataType();
                    dataType.Deserialize(input, littleEndian);
                    this.DataTypes.Add(dataType);
                }
            }

            // data blocks
            var blockStream = new BlockStream(input);
            input.Seek(info.BlockTableOffset, SeekOrigin.Begin);
            {
                uint magic = input.ReadValueU32(littleEndian);
                uint alignment = input.ReadValueU32(littleEndian);
                byte flags = input.ReadValueU8();
                // if flags != 4 : see note 1

                if (magic != 0x6C7A4555 || alignment != 0x4000 || flags != 4)
                {
                    throw new InvalidOperationException();
                }

                long virtualOffset = 0;
                while (true)
                {
                    uint size = input.ReadValueU32(littleEndian);
                    bool compressed = input.ReadValueU8() != 0;

                    if (size == 0)
                    {
                        break;
                    }

                    if (compressed == true)
                    {
                        var compressionInfo = new DataStorage.CompressedBlockInfo();
                        compressionInfo.Deserialize(input, littleEndian);

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
                            input.Position,
                            compressionInfo.CompressedSize);

                        input.Seek(compressionInfo.CompressedSize, SeekOrigin.Current);
                    }
                    else
                    {
                        blockStream.AddUncompressedBlock(
                            virtualOffset,
                            size,
                            input.Position);

                        input.Seek(size, SeekOrigin.Current);
                    }

                    virtualOffset += alignment;
                }
            }

            // file info
            List<long> fileOffsets = new List<long>();
            blockStream.Seek(0, SeekOrigin.Begin);

            for (uint i = 0; i < info.FileCount; i++)
            {
                var position = blockStream.Position;
                fileOffsets.Add(position);
                var memory = blockStream.ReadToMemoryStreamSafe(26, littleEndian);

                var fileInfo = new DataStorage.FileInfo();
                fileInfo.Deserialize(memory, littleEndian);

                blockStream.Seek(position + fileInfo.Unknown04, SeekOrigin.Begin);
            }
        }
    }
}
