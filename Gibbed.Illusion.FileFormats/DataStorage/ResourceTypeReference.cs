using System;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class ResourceTypeReference
    {
        public uint Id { get; private set; }
        public string Name { get; private set; }
        public uint Parent { get; private set; }

        public void Serialize(Stream output, bool littleEndian)
        {
            output.WriteValueU32(this.Id, littleEndian);
            output.WriteValueS32(this.Name.Length, littleEndian);
            output.WriteStringASCII(this.Name);
            output.WriteValueU32(this.Parent, littleEndian);
        }

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
