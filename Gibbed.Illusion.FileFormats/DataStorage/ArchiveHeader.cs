using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class ArchiveHeader
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

        public void Serialize(Stream output, bool littleEndian)
        {
            output.WriteValueU32(this.ResourceTypeTableOffset, littleEndian);
            output.WriteValueU32(this.BlockTableOffset, littleEndian);
            output.WriteValueU32(this.XmlOffset, littleEndian);
            output.WriteValueU32(this.SlotRamRequired, littleEndian);
            output.WriteValueU32(this.SlotVramRequired, littleEndian);
            output.WriteValueU32(this.OtherRamRequired, littleEndian);
            output.WriteValueU32(this.OtherVramRequired, littleEndian);
            output.WriteValueU32(this.Unknown1C, littleEndian);
            output.Write(this.Unknown20, 0, this.Unknown20.Length);
            output.WriteValueU32(this.FileCount, littleEndian);
        }

        public void Deserialize(Stream input, bool littleEndian)
        {
            this.ResourceTypeTableOffset = input.ReadValueU32(littleEndian);
            this.BlockTableOffset = input.ReadValueU32(littleEndian);
            this.XmlOffset = input.ReadValueU32(littleEndian);
            this.SlotRamRequired = input.ReadValueU32(littleEndian);
            this.SlotVramRequired = input.ReadValueU32(littleEndian);
            this.OtherRamRequired = input.ReadValueU32(littleEndian);
            this.OtherVramRequired = input.ReadValueU32(littleEndian);
            this.Unknown1C = input.ReadValueU32(littleEndian);
            this.Unknown20 = new byte[16];
            input.Read(this.Unknown20, 0, this.Unknown20.Length);
            this.FileCount = input.ReadValueU32(littleEndian);
        }
    }
}
