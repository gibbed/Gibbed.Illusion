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
using Gibbed.Illusion.FileFormats;
using Gibbed.IO;

namespace Gibbed.Mafia2.ResourceFormats.Frame
{
    public class SceneData : IResourceType
    {
        public uint Unknown10;
        public float Unknown14;
        public ulong Unknown8_0;
        public string Unknown8_1;
        public float Unknown18;
        public float Unknown1C;
        public Vector3 Unknown24;
        public uint Unknown20;
        public float Unknown30;
        public float Unknown34;
        public float Unknown38;
        public float Unknown3C;
        public float Unknown40;
        public float Unknown44;
        public byte Unknown48;

        public void Serialize(ushort version, Stream output, Endian endian)
        {
            throw new NotImplementedException();
        }

        public void Deserialize(ushort version, Stream input, Endian endian)
        {
            this.Unknown10 = input.ReadValueU32(endian);
            this.Unknown14 = input.ReadValueF32(endian);
            this.Unknown8_0 = input.ReadValueU64(endian);
            this.Unknown8_1 = input.ReadStringU16(endian);
            this.Unknown18 = input.ReadValueF32(endian);
            this.Unknown1C = input.ReadValueF32(endian);
            this.Unknown24 = Vector3.Read(input, endian);

            if (version >= 24)
            {
                this.Unknown20 = input.ReadValueU32(endian);
                this.Unknown30 = input.ReadValueF32(endian);
                this.Unknown34 = input.ReadValueF32(endian);
                this.Unknown38 = input.ReadValueF32(endian);
                this.Unknown3C = input.ReadValueF32(endian);
                this.Unknown40 = input.ReadValueF32(endian);
                this.Unknown44 = input.ReadValueF32(endian);
                this.Unknown48 = input.ReadValueU8();
            }
        }
    }
}
