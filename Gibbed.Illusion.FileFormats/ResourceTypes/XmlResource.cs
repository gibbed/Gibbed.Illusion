using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.ResourceTypes
{
    public class XmlResource : IResourceType
    {
        public string Tag;
        public bool Unk1;
        public string Name;
        public string Content;

        public void Deserialize(DataStorage.FileHeader header, Stream input)
        {
            this.Tag = input.ReadStringU32();
            this.Unk1 = (header.Version >= 3) ? (input.ReadValueU8() != 0) : true;
            this.Name = input.ReadStringU32();
            
            var unk3 = (header.Version >= 2) ? (input.ReadValueU8() != 0) : false;

            if (unk3 == false)
            {
                this.DeserializeMode0(input);
            }
            else
            {
                this.DeserializeMode1(input);
            }
        }

        private object DeserializeMode0Data(Stream input, uint offset)
        {
            input.Seek(offset, SeekOrigin.Begin);
            var type = input.ReadValueU32();

            switch (type)
            {
                case 1:
                case 4:
                {
                    var unk0 = input.ReadValueU32();
                    if (unk0 != 0)
                    {
                        throw new FormatException();
                    }

                    var value = input.ReadStringZ();
                    if (string.IsNullOrEmpty(value) == true)
                    {
                        return null;
                    }
                    return value;
                }

                default:
                {
                    throw new FormatException();
                }
            }
        }

        private void DeserializeMode0(Stream input)
        {
            if (input.ReadValueU8() != 4)
            {
                throw new FormatException();
            }

            var count = input.ReadValueU32();
            if (count > 0x3FFFFFFF)
            {
                throw new FormatException();
            }

            var dataSize = input.ReadValueU32();
            if (dataSize > 0x500000)
            {
                throw new FormatException();
            }
            var data = input.ReadToMemoryStream(dataSize);

            var nodes = new List<NodeEntry>();
            for (uint i = 0; i < count; i++)
            {
                var node = new NodeEntry()
                {
                    Name = DeserializeMode0Data(data, input.ReadValueU32()),
                    Value = DeserializeMode0Data(data, input.ReadValueU32()),
                    Id = input.ReadValueU32(),
                };
                
                var childCount = input.ReadValueU32();
                node.Children.Clear();
                for (uint j = 0; j < childCount; j++)
                {
                    node.Children.Add(input.ReadValueU32());
                }

                var attributeCount = input.ReadValueU32();
                node.Attributes.Clear();
                for (uint j = 0; j < attributeCount; j++)
                {
                    node.Attributes.Add(new AttributeEntry()
                        {
                            Name = DeserializeMode0Data(data, input.ReadValueU32()),
                            Value = DeserializeMode0Data(data, input.ReadValueU32()),
                        });
                }

                nodes.Add(node);
            }

            var settings = new XmlWriterSettings();
            settings.Indent = true;

            var output = new StringBuilder();
            var writer = XmlWriter.Create(output, settings);

            writer.WriteStartDocument();
            if (nodes.Count > 0)
            {
                var root = nodes.SingleOrDefault(n => n.Id == 0);
                if (root == null)
                {
                    throw new InvalidOperationException();
                }

                if (root.Children.Count != 1 ||
                    root.Attributes.Count > 0 ||
                    root.Value != null)
                {
                    throw new FormatException();
                }

                foreach (var childId in root.Children)
                {
                    var child = nodes.SingleOrDefault(n => n.Id == childId);
                    if (child == null)
                    {
                        throw new KeyNotFoundException();
                    }

                    this.WriteMode0Node(writer, nodes, child);
                }
            }
            writer.WriteEndDocument();
            writer.Flush();

            this.Content = output.ToString();
        }

        private void WriteMode0Node(XmlWriter writer, List<NodeEntry> nodes, NodeEntry node)
        {
            writer.WriteStartElement((string)node.Name);

            foreach (var attribute in node.Attributes)
            {
                writer.WriteStartAttribute((string)attribute.Name);
                writer.WriteValue(attribute.Value == null ? "" : attribute.Value);
                writer.WriteEndAttribute();
            }

            foreach (var childId in node.Children)
            {
                var child = nodes.SingleOrDefault(n => n.Id == childId);
                if (child == null)
                {
                    throw new KeyNotFoundException();
                }

                this.WriteMode0Node(writer, nodes, child);
            }

            if (node.Value != null)
            {
                writer.WriteValue(node.Value);
            }

            writer.WriteEndElement();
        }

        private void DeserializeMode1(Stream input)
        {
            throw new NotImplementedException();
        }

        private class NodeEntry
        {
            public object Name;
            public object Value;
            public uint Id;
            public List<uint> Children = new List<uint>();
            public List<AttributeEntry> Attributes = new List<AttributeEntry>();
        }

        private class AttributeEntry
        {
            public object Name;
            public object Value;
        }
    }
}
