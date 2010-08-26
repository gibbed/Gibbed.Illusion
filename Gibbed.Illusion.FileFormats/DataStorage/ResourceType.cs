using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class ResourceType
    {
        public uint Id { get; private set; }
        public string Name { get; private set; }
        public uint Parent { get; private set; }

        public void Deserialize(Stream input, bool littleEndian)
        {
            this.Id = input.ReadValueU32(littleEndian);
            uint length = input.ReadValueU32(littleEndian);
            if (length > 0x3FF)
            {
                throw new InvalidOperationException();
            }
            this.Name = input.ReadStringASCII(length);
            this.Parent = input.ReadValueU32(littleEndian);
        }
    }
}
