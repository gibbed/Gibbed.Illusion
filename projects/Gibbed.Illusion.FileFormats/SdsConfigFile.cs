using System;
using System.IO;
using Gibbed.IO;

namespace Gibbed.Illusion.FileFormats
{
    public class SdsConfigFile
    {
        public void Deserialize(Stream input)
        {
            if (input.ReadValueU32() != 0x73647370)
            {
                throw new FormatException("not an SDS config file");
            }

            if (input.ReadValueU32() != 2)
            {
                throw new FormatException("unsupported SDS config version");
            }

            uint stringTableSize = input.ReadValueU32();
            byte[] stringTable = new byte[stringTableSize];
            input.Read(stringTable, 0, stringTable.Length);

            // "encryption"
            for (int i = 0; i < stringTable.Length; i++)
            {
                stringTable[i] = (byte)(~stringTable[i]);
            }

            using (var output = File.Create("sdsconfig.strings"))
            {
                output.Write(stringTable, 0, stringTable.Length);
            }

            // fucking nested much? jeezus christ

            var unk0 = input.ReadValueU16();
            for (ushort i = 0; i < unk0; i++)
            {
                var unk1 = input.ReadValueU16();
                //var name1 = stringTable.ToStringUTF8Z(unk1);

                var unk2 = input.ReadValueU16();
                for (ushort j = 0; j < unk2; j++)
                {
                    var unk3 = input.ReadValueU16();
                    //var name2 = stringTable.ToStringUTF8Z(unk3);
                    //Console.WriteLine(name2);
                    var unk4 = input.ReadValueU16();
                    var unk5 = input.ReadValueU16();
                    var unk6 = input.ReadValueU16();
                    var unk7 = input.ReadValueU32();
                    var unk8 = input.ReadValueU32();
                }

                var unk9 = input.ReadValueU16();
                for (ushort k = 0; k < unk9; k++)
                {
                    var unk10 = input.ReadValueU16();
                    //var name3 = stringTable.ToStringUTF8Z(unk10);
                    var unk11 = input.ReadValueU32();
                    var unk12 = input.ReadValueU32();

                    var unk13 = input.ReadValueU16();
                    for (ushort l = 0; l < unk13; l++)
                    {
                        var unk14 = input.ReadValueU16();
                        //var name4 = stringTable.ToStringUTF8Z(unk14);

                        var unk15 = input.ReadValueU32();
                        var unk16 = input.ReadValueU32();
                        var unk17 = input.ReadValueU8();

                        var unk18 = input.ReadValueU16();
                        for (ushort m = 0; m < unk18; m++)
                        {
                            var unk19 = input.ReadValueU16();
                            var unk20 = input.ReadValueU16();
                            var unk21 = input.ReadValueU16();
                            var unk22 = input.ReadValueU16();
                            var unk23 = input.ReadValueU32();
                            var unk24 = input.ReadValueU32();
                        }
                    }
                }
            }
        }
    }
}
