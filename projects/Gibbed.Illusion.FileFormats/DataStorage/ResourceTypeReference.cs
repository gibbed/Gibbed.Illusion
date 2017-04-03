using System;
using System.IO;
using Gibbed.IO;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class ResourceTypeReference : ICloneable
    {
        public uint Id { get; private set; }
        public string Name { get; private set; }
        public uint Parent { get; private set; }

        public void Serialize(Stream output, Endian endian)
        {
            output.WriteValueU32(this.Id, endian);
            output.WriteStringU32(this.Name, endian);
            output.WriteValueU32(this.Parent, endian);
        }

        public void Deserialize(Stream input, Endian endian)
        {
            this.Id = input.ReadValueU32(endian);
            this.Name = input.ReadStringU32(endian);
            this.Parent = input.ReadValueU32(endian);
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
