using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.ResourceTypes
{
    public class XmlResource0
    {
        public static void Serialize(Stream output, string content)
        {
            var nodes = new List<NodeEntry>();

            var xml = new XPathDocument(new StringReader(content));
            var nav = xml.CreateNavigator();

            nav.MoveToRoot();
            
            var roots = nav.SelectChildren(XPathNodeType.Element);
            if (roots.Count != 1 ||
                roots.MoveNext() == false ||
                roots.Current.HasAttributes == true ||
                string.IsNullOrEmpty(roots.Current.Value) == false)
            {
                throw new InvalidOperationException();
            }

            var super = new NodeEntry()
            {
                Name = null,
                Value = null,
                Id = 0,
            };
            super.Children.Add(1);
            nodes.Add(super);

            var root = new NodeEntry()
            {
                Name = new Value4() { Value = roots.Current.Name },
                Value = null,
                Id = 1,
            };
            nodes.Add(root);

            var children = roots.Current.SelectChildren(XPathNodeType.Element);
            while (children.MoveNext() == true)
            {
                ReadXmlNode(nodes, root, children.Current);
            }

            var valueData = new MemoryStream();
            valueData.WriteValueU32(4);
            valueData.WriteValueU32(0);
            valueData.WriteValueU8(0);

            var nodeData = new MemoryStream();

            foreach (var node in nodes)
            {
                nodeData.WriteValueU32(SerializeData(valueData, node.Name));
                nodeData.WriteValueU32(SerializeData(valueData, node.Value));
                nodeData.WriteValueU32(node.Id);

                nodeData.WriteValueS32(node.Children.Count);
                foreach (var child in node.Children)
                {
                    nodeData.WriteValueU32(child);
                }

                nodeData.WriteValueS32(node.Attributes.Count);
                foreach (var attribute in node.Attributes)
                {
                    nodeData.WriteValueU32(SerializeData(valueData, attribute.Name));
                    nodeData.WriteValueU32(SerializeData(valueData, attribute.Value));
                }
            }

            valueData.Position = 0;
            nodeData.Position = 0;

            output.WriteValueU8(4);
            output.WriteValueS32(nodes.Count);
            output.WriteValueU32((uint)valueData.Length);
            output.WriteFromStream(valueData, (uint)valueData.Length);
            output.WriteFromStream(nodeData, nodeData.Length);
        }

        private static uint SerializeData(Stream output, object value)
        {
            uint position = (uint)output.Position;
            if (value is Value1)
            {
                output.WriteValueU32(1);
                output.WriteValueU32(0);
                output.WriteStringZ(((Value1)value).Value, Encoding.UTF8);
            }
            else if (value is Value4)
            {
                output.WriteValueU32(4);
                output.WriteValueU32(0);
                output.WriteStringZ(((Value4)value).Value, Encoding.UTF8);
            }
            else if (value == null)
            {
                return 0;
            }
            else
            {
                throw new InvalidOperationException();
            }
            return position;
        }

        private static void ReadXmlNode(List<NodeEntry> nodes, NodeEntry parent, XPathNavigator nav)
        {
            var node = new NodeEntry()
            {
                Name = new Value4() { Value = nav.Name },
                Value = null,
                Id = (uint)nodes.Count,
            };
            parent.Children.Add(node.Id);
            nodes.Add(node);

            bool type1 = false;

            if (nav.MoveToFirstAttribute() == true)
            {
                do
                {
                    if (nav.Name == "__type")
                    {
                        if (nav.Value == "1")
                        {
                            type1 = true;
                        }
                        else if (nav.Value == "4")
                        {
                            type1 = false;
                        }
                        else
                        {
                            throw new InvalidOperationException();
                        }

                        continue;
                    }

                    node.Attributes.Add(new AttributeEntry()
                        {
                            Name = new Value4() { Value = nav.Name },
                            Value = new Value4() { Value = nav.Value },
                        });
                }
                while (nav.MoveToNextAttribute() == true);
                nav.MoveToParent();
            }

            var children = nav.SelectChildren(XPathNodeType.Element);
            while (children.MoveNext() == true)
            {
                ReadXmlNode(nodes, node, children.Current);
            }

            if (string.IsNullOrEmpty(nav.Value) == false)
            {
                if (type1 == true)
                {
                    node.Value = new Value1() { Value = nav.Value };
                }
                else
                {
                    node.Value = new Value4() { Value = nav.Value };
                }
            }
        }

        public static string Deserialize(Stream input)
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
                    Name = DeserializeData(data, input.ReadValueU32()),
                    Value = DeserializeData(data, input.ReadValueU32()),
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
                        Name = DeserializeData(data, input.ReadValueU32()),
                        Value = DeserializeData(data, input.ReadValueU32()),
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

                    WriteXmlNode(writer, nodes, child);
                }
            }
            writer.WriteEndDocument();
            writer.Flush();

            return output.ToString();
        }

        private static object DeserializeData(Stream input, uint offset)
        {
            input.Seek(offset, SeekOrigin.Begin);
            var type = input.ReadValueU32();

            switch (type)
            {
                case 1:
                {
                    var unk0 = input.ReadValueU32();
                    if (unk0 != 0)
                    {
                        throw new FormatException();
                    }

                    var value = input.ReadStringZ(Encoding.UTF8);
                    if (string.IsNullOrEmpty(value) == true)
                    {
                        return null;
                    }

                    return new Value1()
                    {
                        Value = value,
                    };
                }

                case 4:
                {
                    var unk0 = input.ReadValueU32();
                    if (unk0 != 0)
                    {
                        throw new FormatException();
                    }

                    var value = input.ReadStringZ(Encoding.UTF8);
                    if (string.IsNullOrEmpty(value) == true)
                    {
                        return null;
                    }

                    return new Value4()
                    {
                        Value = value,
                    };
                }

                default:
                {
                    throw new FormatException();
                }
            }
        }

        private static void WriteXmlNode(XmlWriter writer, List<NodeEntry> nodes, NodeEntry node)
        {
            writer.WriteStartElement(((Value4)node.Name).Value);

            foreach (var attribute in node.Attributes)
            {
                writer.WriteStartAttribute(((Value4)attribute.Name).Value);
                writer.WriteValue(attribute.Value == null ? "" : ((Value4)attribute.Value).Value);
                writer.WriteEndAttribute();
            }

            foreach (var childId in node.Children)
            {
                var child = nodes.SingleOrDefault(n => n.Id == childId);
                if (child == null)
                {
                    throw new KeyNotFoundException();
                }

                WriteXmlNode(writer, nodes, child);
            }

            if (node.Value != null)
            {
                if (node.Value is Value1)
                {
                    writer.WriteAttributeString("__type", "1");
                    writer.WriteValue(((Value1)node.Value).Value);
                }
                else if (node.Value is Value4)
                {
                    writer.WriteValue(((Value4)node.Value).Value);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            writer.WriteEndElement();
        }

        private class NodeEntry
        {
            public object Name;
            public object Value;
            public uint Id;
            public List<uint> Children = new List<uint>();
            public List<AttributeEntry> Attributes = new List<AttributeEntry>();
        }

        public class Value1
        {
            public string Value;
        }

        public class Value4
        {
            public string Value;
        }

        private class AttributeEntry
        {
            public object Name;
            public object Value;
        }
    }
}
