/* Copyright (c) 2017 Rick (rick 'at' gibbed 'dot' us)
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 * 
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 * 
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using System.IO;
using Gibbed.IO;

namespace Gibbed.Illusion.FileFormats
{
    public class SdsConfigFile
    {
        public const uint Signature = 0x73647370; // 'sdsp'

        public void Deserialize(Stream input)
        {
            var magic = input.ReadValueU32(Endian.Little);
            if (magic != Signature && magic.Swap() != Signature)
            {
                throw new FormatException("not an SDS config file");
            }
            var endian = magic == Signature ? Endian.Little : Endian.Big;

            var version = input.ReadValueU32(endian);
            if (version != 2)
            {
                throw new FormatException("unsupported SDS config version");
            }

            var stringTableSize = input.ReadValueU32(endian);
            var stringTableBytes = input.ReadBytes(stringTableSize);
            for (int i = 0; i < stringTableBytes.Length; i++)
            {
                stringTableBytes[i] = (byte)(~stringTableBytes[i]);
            }

            var unk0 = input.ReadValueU16(endian);
            for (ushort i = 0; i < unk0; i++)
            {
                var unk1 = input.ReadValueU16(endian);
                //var name1 = stringTable.ToStringUTF8Z(unk1);

                var unk2 = input.ReadValueU16(endian);
                for (ushort j = 0; j < unk2; j++)
                {
                    var unk3 = input.ReadValueU16(endian);
                    //var name2 = stringTable.ToStringUTF8Z(unk3);
                    //Console.WriteLine(name2);
                    var unk4 = input.ReadValueU16(endian);
                    var unk5 = input.ReadValueU16(endian);
                    var unk6 = input.ReadValueU16(endian);
                    var unk7 = input.ReadValueU32(endian);
                    var unk8 = input.ReadValueU32(endian);
                }

                var unk9 = input.ReadValueU16(endian);
                for (ushort k = 0; k < unk9; k++)
                {
                    var unk10 = input.ReadValueU16(endian);
                    //var name3 = stringTable.ToStringUTF8Z(unk10);
                    var unk11 = input.ReadValueU32(endian);
                    var unk12 = input.ReadValueU32(endian);

                    var unk13 = input.ReadValueU16(endian);
                    for (ushort l = 0; l < unk13; l++)
                    {
                        var unk14 = input.ReadValueU16(endian);
                        //var name4 = stringTable.ToStringUTF8Z(unk14);

                        var unk15 = input.ReadValueU32(endian);
                        var unk16 = input.ReadValueU32(endian);
                        var unk17 = input.ReadValueU8();

                        var unk18 = input.ReadValueU16(endian);
                        for (ushort m = 0; m < unk18; m++)
                        {
                            var unk19 = input.ReadValueU16(endian);
                            var unk20 = input.ReadValueU16(endian);
                            var unk21 = input.ReadValueU16(endian);
                            var unk22 = input.ReadValueU16(endian);
                            var unk23 = input.ReadValueU32(endian);
                            var unk24 = input.ReadValueU32(endian);
                        }
                    }
                }
            }
        }
    }
}
