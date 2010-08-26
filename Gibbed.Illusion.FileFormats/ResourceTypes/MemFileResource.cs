using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.ResourceTypes
{
    public class MemFileResource : IResourceType
    {
        public string Name;
        public uint Unk1;
        public byte[] Data;

        public void Deserialize(DataStorage.FileHeader header, Stream input)
        {
            this.Name = input.ReadStringASCIIU32();
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
