using System;
using System.IO;
using Gibbed.IO;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class ArchiveHeader : ICloneable
    {
        public uint ResourceTypeTableOffset;
        public uint BlockTableOffset;
        public uint XmlOffset;
        public uint SlotRamRequired;
        public uint SlotVramRequired;
        public uint OtherRamRequired;
        public uint OtherVramRequired;
        public uint Unknown1C; // flags of some sort : see note 2
        public byte[] Unknown20;
        public uint FileCount;

        public void Serialize(Stream output, Endian endian)
        {
            output.WriteValueU32(this.ResourceTypeTableOffset, endian);
            output.WriteValueU32(this.BlockTableOffset, endian);
            output.WriteValueU32(this.XmlOffset, endian);
            output.WriteValueU32(this.SlotRamRequired, endian);
            output.WriteValueU32(this.SlotVramRequired, endian);
            output.WriteValueU32(this.OtherRamRequired, endian);
            output.WriteValueU32(this.OtherVramRequired, endian);
            output.WriteValueU32(this.Unknown1C, endian);
            output.Write(this.Unknown20, 0, this.Unknown20.Length);
            output.WriteValueU32(this.FileCount, endian);
        }

        public void Deserialize(Stream input, Endian endian)
        {
            this.ResourceTypeTableOffset = input.ReadValueU32(endian);
            this.BlockTableOffset = input.ReadValueU32(endian);
            this.XmlOffset = input.ReadValueU32(endian);
            this.SlotRamRequired = input.ReadValueU32(endian);
            this.SlotVramRequired = input.ReadValueU32(endian);
            this.OtherRamRequired = input.ReadValueU32(endian);
            this.OtherVramRequired = input.ReadValueU32(endian);
            this.Unknown1C = input.ReadValueU32(endian);
            this.Unknown20 = new byte[16];
            input.Read(this.Unknown20, 0, this.Unknown20.Length);
            this.FileCount = input.ReadValueU32(endian);
        }

        public object Clone()
        {
            return new ArchiveHeader()
            {
                ResourceTypeTableOffset = this.ResourceTypeTableOffset,
                BlockTableOffset = this.BlockTableOffset,
                XmlOffset = this.XmlOffset,
                SlotRamRequired = this.SlotRamRequired,
                SlotVramRequired = this.SlotVramRequired,
                OtherRamRequired = this.OtherRamRequired,
                OtherVramRequired = this.OtherVramRequired,
                Unknown1C = this.Unknown1C,
                Unknown20 = (byte[])this.Unknown20.Clone(),
                FileCount = this.FileCount,
            };
        }
    }
}
