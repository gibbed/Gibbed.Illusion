using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats
{
    public class SdsStream
    {
        private Stream Stream;
        public bool LittleEndian { get; private set; }

        public SdsStream(Stream stream, bool littleEndian)
        {
            this.Stream = stream;
            this.LittleEndian = littleEndian;
        }

        public byte ReadValueU8()
        {
            return this.Stream.ReadValueU8();
        }

        public ushort ReadValueU16()
        {
            return this.Stream.ReadValueU16(this.LittleEndian);
        }

        public uint ReadValueU32()
        {
            return this.Stream.ReadValueU32(this.LittleEndian);
        }

        public float ReadValueF32()
        {
            return this.Stream.ReadValueF32(this.LittleEndian);
        }

        public string ReadString(uint size)
        {
            return this.Stream.ReadStringASCII(size, true);
        }

        public byte[] ReadBuffer(int count)
        {
            var buffer = new byte[count];
            int read = this.Stream.Read(buffer, 0, count);
            if (read != count)
            {
                throw new InvalidOperationException();
            }
            return buffer;
        }

        public byte[] ReadSafeBuffer(int count)
        {
            byte[] buffer = new byte[count];
            int read = this.Stream.Read(buffer, 0, count);
            if (read != count)
            {
                throw new InvalidOperationException();
            }

            var hash = this.Stream.ReadValueU32(this.LittleEndian);
            if (FNV32.Hash(buffer, 0, count) != hash)
            {
                throw new InvalidOperationException("FNV32 hash failure");
            }

            return buffer;
        }

        public SdsStream ReadStream(int count)
        {
            var buffer = this.ReadBuffer(count);
            var memory = new MemoryStream();
            memory.Write(buffer, 0, buffer.Length);
            memory.Position = 0;
            return new SdsStream(memory, this.LittleEndian);
        }

        public SdsStream ReadSafeStream(int count)
        {
            var buffer = this.ReadSafeBuffer(count);
            var memory = new MemoryStream();
            memory.Write(buffer, 0, buffer.Length);
            memory.Position = 0;
            return new SdsStream(memory, this.LittleEndian);
        }
    }
}
