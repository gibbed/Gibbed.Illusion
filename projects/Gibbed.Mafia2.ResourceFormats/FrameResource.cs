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
using System.Collections.Generic;

namespace Gibbed.Mafia2.ResourceFormats
{
    public class FrameResource : IResourceType
    {
        public Frame.SceneData Scene;
        public readonly List<ResourceReference> Directories;

        public FrameResource()
        {
            this.Directories = new List<ResourceReference>();
        }

        public void Serialize(ushort version, Stream output, Endian endian)
        {
            throw new NotImplementedException();
        }

        public void Deserialize(ushort version, Stream input, Endian endian)
        {
            var isScene = input.ReadValueB8();
            var directoryCount = input.ReadValueU32(endian);
            var meshCount = input.ReadValueU32(endian);
            var materialCount = input.ReadValueU32(endian);
            var blendCount = input.ReadValueU32(endian);
            var skeletonCount = input.ReadValueU32(endian);
            var hierarchyCount = input.ReadValueU32(endian);
            var objectCount = input.ReadValueU32(endian);

            if (isScene == true)
            {
                this.Scene = new Frame.SceneData();
                this.Scene.Deserialize(version, input, endian);
            }

            this.Directories.Clear();
            for (uint i = 0; i < directoryCount; i++)
            {
                this.Directories.Add(ResourceReference.Read(input, endian));
            }

            for (uint i = 0; i < meshCount; i++)
            {
                var meshData = new Frame.MeshData();
                meshData.Deserialize(version, input, endian);
            }

            throw new NotImplementedException();
        }
    }
}
