using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace Gibbed.Illusion.FileFormats
{
    public class BlockStream : Stream
    {
        private Stream BaseStream;
        private List<Block> Blocks;
        private Block CurrentBlock;
        private long CurrentOffset;

        public BlockStream(Stream baseStream)
        {
            if (baseStream == null)
            {
                throw new ArgumentNullException("baseStream");
            }

            this.BaseStream = baseStream;
            this.Blocks = new List<Block>();
            this.CurrentOffset = 0;
        }

        public void FreeLoadedBlocks()
        {
            foreach (var block in this.Blocks)
            {
                block.FreeLoadedData();
            }
        }

        public void AddUncompressedBlock(
            long virtualOffset,
            uint virtualSize,
            long dataOffset)
        {
            this.Blocks.Add(
                new UncompressedBlock(
                    virtualOffset,
                    virtualSize,
                    dataOffset));
        }

        public void AddCompressedBlock(
            long virtualOffset,
            uint virtualSize,
            long dataOffset,
            uint dataCompressedSize)
        {
            this.Blocks.Add(
                new CompressedBlock(
                    virtualOffset,
                    virtualSize,
                    dataOffset,
                    dataCompressedSize));
        }

        private bool LoadBlock(long offset)
        {
            if (this.CurrentBlock == null ||
                this.CurrentBlock.IsValidOffset(offset) == false)
            {
                Block block = this.Blocks.SingleOrDefault(
                    candidate => candidate.IsValidOffset(offset));

                if (block == null)
                {
                    this.CurrentBlock = null;
                    return false;
                }

                this.CurrentBlock = block;
            }

            return this.CurrentBlock.Load(this.BaseStream);
        }

        public void SaveUncompressed(Stream output)
        {
            byte[] data = new byte[1024];

            long totalSize = this.Blocks.Max(
                candidate =>
                    candidate.Offset +
                    candidate.Size);

            output.SetLength(totalSize);

            foreach (Block block in this.Blocks)
            {
                output.Seek(block.Offset, SeekOrigin.Begin);
                this.Seek(block.Offset, SeekOrigin.Begin);

                long total = block.Size;
                while (total > 0)
                {
                    int read = this.Read(data, 0, (int)Math.Min(total, data.Length));
                    output.Write(data, 0, read);
                    total -= read;
                }
            }

            output.Flush();
        }

        #region Stream
        public override bool CanRead
        {
            get { return this.BaseStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return this.BaseStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void Flush()
        {
            this.BaseStream.Flush();
        }

        public override long Length
        {
            get { throw new NotImplementedException(); }
        }

        public override long Position
        {
            get
            {
                return this.CurrentOffset;
            }

            set
            {
                this.Seek(value, SeekOrigin.Begin);
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalRead = 0;

            while (totalRead < count)
            {
                if (this.LoadBlock(this.CurrentOffset) == false)
                {
                    throw new InvalidOperationException();
                }

                int read = this.CurrentBlock.Read(
                    this.BaseStream,
                    this.CurrentOffset,
                    buffer,
                    offset + totalRead,
                    count - totalRead);

                totalRead += read;
                this.CurrentOffset += read;
            }

            return totalRead;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (origin == SeekOrigin.End)
            {
                throw new NotSupportedException();
            }

            if (origin == SeekOrigin.Current)
            {
                if (offset == 0)
                {
                    return this.CurrentOffset;
                }

                offset = this.CurrentOffset + offset;
            }

            /*
            :effort: in fixing seeks that hit the end of data instead of over it
            if (this.LoadBlock(offset) == false)
            {
                throw new InvalidOperationException();
            }
            */

            this.CurrentOffset = offset;
            return this.CurrentOffset;
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
        #endregion

        private abstract class Block
        {
            public long Offset { get; protected set; }
            public uint Size { get; protected set; }

            public Block(long offset, uint size)
            {
                this.Offset = offset;
                this.Size = size;
            }

            public bool IsValidOffset(long offset)
            {
                return
                    offset >= this.Offset &&
                    offset < this.Offset + this.Size;
            }

            public abstract bool Load(Stream input);
            public abstract void FreeLoadedData();
            public abstract int Read(Stream input, long baseOffset, byte[] buffer, int offset, int count);

        }

        private class UncompressedBlock : Block
        {
            public long DataOffset { get; private set; }
            
            private bool Loaded;
            private byte[] Data;

            public UncompressedBlock(
                long virtualOffset,
                uint virtualSize,
                long dataOffset)
                : base(virtualOffset, virtualSize)
            {
                this.DataOffset = dataOffset;
                this.Loaded = false;
                this.Data = null;
            }

            public override void FreeLoadedData()
            {
                this.Loaded = false;
                this.Data = null;
            }

            public override bool Load(Stream input)
            {
                if (this.Loaded == true)
                {
                    return true;
                }

                input.Seek(this.DataOffset, SeekOrigin.Begin);
                this.Data = new byte[this.Size];
                if (input.Read(this.Data, 0, this.Data.Length) != this.Data.Length)
                {
                    throw new InvalidOperationException();
                }

                this.Loaded = true;
                return true;
            }

            public override int Read(Stream input, long baseOffset, byte[] buffer, int offset, int count)
            {
                if (baseOffset >= this.Offset + this.Size)
                {
                    return 0;
                }

                this.Load(input);

                int relativeOffset = (int)(baseOffset - this.Offset);
                int read = (int)Math.Min(this.Size - relativeOffset, count);

                Array.ConstrainedCopy(
                    this.Data,
                    relativeOffset,
                    buffer,
                    offset,
                    read);

                return read;
            }
        }

        private class CompressedBlock : Block
        {
            public long DataOffset { get; private set; }
            public uint DataCompressedSize { get; private set; }
            private bool Loaded;
            private byte[] Data;

            public CompressedBlock(
                long virtualOffset,
                uint virtualSize,
                long dataOffset,
                uint dataCompressedSize)
                : base(virtualOffset, virtualSize)
            {
                this.DataOffset = dataOffset;
                this.DataCompressedSize = dataCompressedSize;

                this.Loaded = false;
                this.Data = null;
            }

            public override void FreeLoadedData()
            {
                this.Loaded = false;
                this.Data = null;
            }

            public override bool Load(Stream input)
            {
                if (this.Loaded == true)
                {
                    return true;
                }

                input.Seek(this.DataOffset, SeekOrigin.Begin);
                this.Data = new byte[this.Size];
                var inflater = new InflaterInputStream(input);
                if (inflater.Read(this.Data, 0, this.Data.Length) != this.Data.Length)
                {
                    throw new InvalidOperationException();
                }

                this.Loaded = true;
                return true;
            }

            public override int Read(Stream input, long baseOffset, byte[] buffer, int offset, int count)
            {
                if (baseOffset >= this.Offset + this.Size)
                {
                    return 0;
                }

                this.Load(input);

                int relativeOffset = (int)(baseOffset - this.Offset);
                int read = (int)Math.Min(this.Size - relativeOffset, count);

                Array.ConstrainedCopy(
                    this.Data,
                    relativeOffset,
                    buffer,
                    offset,
                    read);

                return read;
            }
        }
    }
}
