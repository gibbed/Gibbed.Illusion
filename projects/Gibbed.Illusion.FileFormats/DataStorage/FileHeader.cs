using System;
using System.IO;
using Gibbed.IO;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class FileHeader : ICloneable
    {
        public uint TypeId;
        public uint Size; // includes headers (such as the first 30 bytes)
        public ushort Version;
        public uint SlotRamRequired;
        public uint SlotVramRequired;
        public uint OtherRamRequired;
        public uint OtherVramRequired;

        public void Serialize(Stream output, Endian endian)
        {
            output.WriteValueU32(this.TypeId, endian);
            output.WriteValueU32(this.Size, endian);
            output.WriteValueU16(this.Version, endian);
            output.WriteValueU32(this.SlotRamRequired, endian);
            output.WriteValueU32(this.SlotVramRequired, endian);
            output.WriteValueU32(this.OtherRamRequired, endian);
            output.WriteValueU32(this.OtherVramRequired, endian);
        }

        public void Deserialize(Stream input, Endian endian)
        {
            this.TypeId = input.ReadValueU32(endian);
            this.Size = input.ReadValueU32(endian);
            this.Version = input.ReadValueU16(endian);
            this.SlotRamRequired = input.ReadValueU32(endian);
            this.SlotVramRequired = input.ReadValueU32(endian);
            this.OtherRamRequired = input.ReadValueU32(endian);
            this.OtherVramRequired = input.ReadValueU32(endian);
        }

        public object Clone()
        {
            return new FileHeader()
            {
                TypeId = this.TypeId,
                Size = this.Size,
                Version = this.Version,
                SlotRamRequired = this.SlotRamRequired,
                SlotVramRequired = this.SlotVramRequired,
                OtherRamRequired = this.OtherRamRequired,
                OtherVramRequired = this.OtherVramRequired,
            };
        }
    }
}
