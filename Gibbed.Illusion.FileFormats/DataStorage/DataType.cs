using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class DataType
    {
        public uint Id;
        public string Name;
        public uint Unknown2;

        public void Deserialize(Stream input, bool littleEndian)
        {
            this.Id = input.ReadValueU32(littleEndian);
            uint length = input.ReadValueU32(littleEndian);
            if (length > 0x3FF)
            {
                throw new InvalidOperationException();
            }
            this.Name = input.ReadStringASCII(length);
            this.Unknown2 = input.ReadValueU32(littleEndian);
        }
    }
}
