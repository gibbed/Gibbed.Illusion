using System;
using System.IO;
using Gibbed.IO;

namespace Gibbed.Illusion.FileFormats.ResourceTypes
{
    public class MemFileResource : IResourceType
    {
        public string Name;
        public uint Unk1;
        public byte[] Data;

        public void Serialize(DataStorage.FileHeader header, Stream output)
        {
            output.WriteStringU32(this.Name);
            output.WriteValueU32(this.Unk1);
            output.WriteValueS32(this.Data.Length);
            output.Write(this.Data, 0, this.Data.Length);
        }

        public void Deserialize(DataStorage.FileHeader header, Stream input)
        {
            this.Name = input.ReadStringU32();
            this.Unk1 = input.ReadValueU32();
            if (this.Unk1 != 1)
            {
                throw new InvalidOperationException();
            }
            uint size = input.ReadValueU32();
            this.Data = new byte[size];
            input.Read(this.Data, 0, this.Data.Length);
        }
    }
}
