using System;
using System.IO;
using Gibbed.IO;

namespace Gibbed.Illusion.FileFormats.ResourceTypes
{
    public class TextureResource : IResourceType
    {
        public ulong NameHash;
        public byte Unknown8;
        public byte Unknown9;
        public byte[] Data;

        public void Serialize(DataStorage.FileHeader header, Stream output)
        {
            output.WriteValueU64(this.NameHash);
            output.WriteValueU8(this.Unknown8);
            if (header.Version == 2)
            {
                output.WriteValueU8(this.Unknown9);
            }
            output.Write(this.Data, 0, this.Data.Length);
        }

        public void Deserialize(DataStorage.FileHeader header, Stream input)
        {
            this.NameHash = input.ReadValueU64();
            this.Unknown8 = input.ReadValueU8();
            this.Unknown9 = header.Version == 2 ? input.ReadValueU8() : (byte)0;

            if (this.Unknown9 != 0 && this.Unknown9 != 1)
            {
                throw new InvalidOperationException();
            }

            this.Data = new byte[input.Length - input.Position];
            input.Read(this.Data, 0, this.Data.Length);
        }
    }
}
