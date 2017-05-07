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

namespace Gibbed.Mafia2.ResourceFormats.Frame
{
    public class MeshLodData : IResourceType
    {
        public float Unknown08;
        public ResourceReference Unknown58;

        public void Serialize(ushort version, Stream output, Endian endian)
        {
            throw new NotImplementedException();
        }

        public void Deserialize(ushort version, Stream input, Endian endian)
        {
            this.Unknown08 = input.ReadValueF32(endian);
            this.Unknown58 = ResourceReference.Read(input, endian);
            for (int i = 0; i < 2; i++)
            {
                var unknown68 = input.ReadValueU32(endian);
                if (unknown68 != 0)
                {
                    var unknown10 = ResourceReference.Read(input, endian);
                    var unknown24 = input.ReadValueU32(endian);
                    var unknown20 = input.ReadValueU32(endian);
                    var unknownValue22 = input.ReadValueU32(endian);
                    if (unknownValue22 != 0)
                    {
                        var unknownValue24 = input.ReadValueU32(endian);
                        throw new NotImplementedException();
                    }
                    var unknownValue25 = input.ReadValueU32(endian);
                    if (unknownValue25 != 0)
                    {
                        var unknownValue26 = new MeshLodDataSub0();
                        unknownValue26.Deserialize(version, input, endian);
                    }
                }
            }
        }
    }
}
