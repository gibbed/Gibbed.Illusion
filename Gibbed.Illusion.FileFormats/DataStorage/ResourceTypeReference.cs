using System;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class ResourceTypeReference : ICloneable
    {
        public uint Id { get; private set; }
        public string Name { get; private set; }
        public uint Parent { get; private set; }

        public void Serialize(Stream output, bool littleEndian)
        {
            output.WriteValueU32(this.Id, littleEndian);
            output.WriteStringU32(this.Name, littleEndian);
            output.WriteValueU32(this.Parent, littleEndian);
        }

        public void Deserialize(Stream input, bool littleEndian)
        {
            this.Id = input.ReadValueU32(littleEndian);
            this.Name = input.ReadStringU32(littleEndian);
            this.Parent = input.ReadValueU32(littleEndian);
        }

        public object Clone()
        {
            return new ResourceTypeReference()
            {
                Id = this.Id,
                Name = this.Name,
                Parent = this.Parent,
            };
        }
    }
}
