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

namespace Gibbed.Mafia2.ResourceFormats
{
    public class MemFileResource : IResourceType
    {
        public string Name;
        public uint Unk1;
        public byte[] Data;

        public void Serialize(ushort version, Stream output)
        {
            output.WriteStringU32(this.Name);
            output.WriteValueU32(this.Unk1);
            output.WriteValueS32(this.Data.Length);
            output.Write(this.Data, 0, this.Data.Length);
        }

        public void Deserialize(ushort version, Stream input)
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
