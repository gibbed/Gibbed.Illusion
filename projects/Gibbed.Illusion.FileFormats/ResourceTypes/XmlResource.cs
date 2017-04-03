using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Gibbed.IO;

namespace Gibbed.Illusion.FileFormats.ResourceTypes
{
    public class XmlResource : IResourceType
    {
        public string Tag;
        public bool Unk1;
        public string Name;
        public bool Unk3;

        public string Content;

        public void Serialize(DataStorage.FileHeader header, Stream output)
        {
            output.WriteStringU32(this.Tag);

            if (header.Version >= 3)
            {
                output.WriteValueU8((byte)(this.Unk1 ? 1 : 0));
            }

            output.WriteStringU32(this.Name);

            if (header.Version >= 2)
            {
                output.WriteValueU8((byte)(this.Unk3 ? 1 : 0));
            }

            if (this.Unk3 == false)
            {
                XmlResource0.Serialize(output, this.Content);
            }
            else
            {
                XmlResource1.Serialize(output, this.Content);
            }
        }

        public void Deserialize(DataStorage.FileHeader header, Stream input)
        {
            this.Tag = input.ReadStringU32();
            this.Unk1 = (header.Version >= 3) ? (input.ReadValueU8() != 0) : true;
            this.Name = input.ReadStringU32();
            this.Unk3 = (header.Version >= 2) ? (input.ReadValueU8() != 0) : false;

            if (this.Unk3 == false)
            {
                this.Content = XmlResource0.Deserialize(input);
            }
            else
            {
                this.Content = XmlResource1.Deserialize(input);
            }
        }
    }
}
