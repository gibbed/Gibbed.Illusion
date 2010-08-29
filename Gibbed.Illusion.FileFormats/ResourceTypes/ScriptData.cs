using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.ResourceTypes
{
    public class ScriptData : IResourceType
    {
        public ulong NameHash;
        public ulong DataHash;
        public string Name;
        public byte[] Data;

        public void Serialize(DataStorage.FileHeader header, Stream output)
        {
            if (header.Version == 2)
            {
                this.NameHash = FNV.Hash64(this.Name);
                this.DataHash = FNV.Hash64(this.Data, 0, this.Data.Length);
                output.WriteValueU64(this.NameHash);
                output.WriteValueU64(this.DataHash);
            }

            output.WriteStringU16(this.Name);
            output.WriteValueS32(this.Data.Length);
            output.Write(this.Data, 0, this.Data.Length);
        }

        public void Deserialize(DataStorage.FileHeader header, Stream input)
        {
            if (header.Version == 2)
            {
                this.NameHash = input.ReadValueU64();
                this.DataHash = input.ReadValueU64();
            }

            this.Name = input.ReadStringU16();
            var size = input.ReadValueU32();
            this.Data = new byte[size];
            input.Read(this.Data, 0, this.Data.Length);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
