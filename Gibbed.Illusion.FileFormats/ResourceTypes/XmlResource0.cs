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

            var children = nav.SelectChildren(XPathNodeType.Element);
            if (children.Count != 1 ||
                children.MoveNext() == false)
            {
                throw new InvalidOperationException();
            }

            var root = new NodeEntry()
            {
                Name = null,
                Value = null,
                Id = 0,
            };
            nodes.Add(root);

            ReadXmlNode(nodes, root, children.Current);

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

        private static uint SerializeData(Stream output, DataValue data)
        {
            uint position = (uint)output.Position;

            if (data == null)
            {
                return 0;
            }

            switch (data.Type)
            {
                case DataType.Special:
                {
                    output.WriteValueU32(1);
                    output.WriteValueU32(0);
                    output.WriteStringZ((string)data.Value, Encoding.UTF8);
                    break;
                }

                case DataType.Boolean:
                {
                    output.WriteValueU32(2);
                    output.WriteValueU32(0);

                    if (data.Value is bool)
                    {
                        output.WriteValueU8((bool)data.Value == true ? (byte)1 : (byte)0);
                    }
                    else
                    {
                        output.WriteValueU8(bool.Parse((string)data.Value) == true ? (byte)1 : (byte)0);
                    }

                    break;
                }

                case DataType.Float:
                {
                    output.WriteValueU32(3);
                    output.WriteValueU32(0);

                    if (data.Value is float)
                    {
                        output.WriteValueF32((float)data.Value);
                    }
                    else
                    {
                        output.WriteValueF32(float.Parse((string)data.Value));
                    }

                    break;
                }

                case DataType.String:
                {
                    output.WriteValueU32(4);
                    output.WriteValueU32(0);
                    output.WriteStringZ((string)data.Value, Encoding.UTF8);
                    break;
                }

                case DataType.Integer:
                {
                    output.WriteValueU32(5);
                    output.WriteValueU32(0);

                    if (data.Value is int)
                    {
                        output.WriteValueS32((int)data.Value);
                    }
                    else
                    {
                        output.WriteValueS32(int.Parse((string)data.Value));
                    }

                    break;
                }

                default:
                {
                    throw new InvalidOperationException();
                }
            }

            return position;
        }

        private static void ReadXmlNode(List<NodeEntry> nodes, NodeEntry parent, XPathNavigator nav)
        {
            var node = new NodeEntry()
            {
                Name = new DataValue(DataType.String, nav.Name),
                Value = null,
                Id = (uint)nodes.Count,
            };
            parent.Children.Add(node.Id);
            nodes.Add(node);

            DataType type = DataType.String;

            if (nav.MoveToFirstAttribute() == true)
            {
                do
                {
                    if (nav.Name == "__type")
                    {
                        type = DataTypeFromString(nav.Value);
                        continue;
                    }

                    node.Attributes.Add(new AttributeEntry()
                        {
                            Name = new DataValue(DataType.String, nav.Name),
                            Value = new DataValue(DataType.String, nav.Value),
                        });
                }
                while (nav.MoveToNextAttribute() == true);
                nav.MoveToParent();
            }

            var children = nav.SelectChildren(XPathNodeType.Element);
            if (children.Count > 0)
            {
                while (children.MoveNext() == true)
                {
                    ReadXmlNode(nodes, node, children.Current);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(nav.Value) == false)
                {
                    node.Value = new DataValue(type, nav.Value);
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
                    var attribute = new AttributeEntry()
                    {
                        Name = DeserializeData(data, input.ReadValueU32()),
                        Value = DeserializeData(data, input.ReadValueU32()),
                    };
                    if (attribute.Name.Value == "__type")
                    {
                        throw new FormatException("someone used __type?");
                    }
                    node.Attributes.Add(attribute);
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

        private static DataValue DeserializeData(Stream input, uint offset)
        {
            input.Seek(offset, SeekOrigin.Begin);
            
            var type = (DataType)input.ReadValueU32();
            switch (type)
            {
                case DataType.Special:
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

                    return new DataValue(type, value);
                }

                case DataType.Boolean:
                {
                    var unk0 = input.ReadValueU32();
                    if (unk0 != 0)
                    {
                        throw new FormatException();
                    }

                    var value = input.ReadValueU8() != 0;
                    return new DataValue(type, value);
                }

                case DataType.Float:
                {
                    var unk0 = input.ReadValueU32();
                    if (unk0 != 0)
                    {
                        throw new FormatException();
                    }

                    var value = input.ReadValueF32();
                    return new DataValue(type, value);
                }

                case DataType.String:
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

                    return new DataValue(type, value);
                }

                case DataType.Integer:
                {
                    var unk0 = input.ReadValueU32();
                    if (unk0 != 0)
                    {
                        throw new FormatException();
                    }

                    var value = input.ReadValueS32();
                    return new DataValue(type, value);
                }

                default:
                {
                    throw new FormatException();
                }
            }
        }

        private static void WriteXmlNode(XmlWriter writer, List<NodeEntry> nodes, NodeEntry node)
        {
            writer.WriteStartElement(node.Name.ToString());

            foreach (var attribute in node.Attributes)
            {
                writer.WriteStartAttribute(attribute.Name.ToString());
                writer.WriteValue(
                    attribute.Value == null ?
                    "" : attribute.Value.ToString());
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
                if (node.Value.Type != DataType.String)
                {
                    writer.WriteAttributeString("__type", DataTypeToString(node.Value.Type));
                }

                writer.WriteValue(node.Value.ToString());
            }

            writer.WriteEndElement();
        }

        private class NodeEntry
        {
            public DataValue Name;
            public DataValue Value;
            public uint Id;
            public List<uint> Children = new List<uint>();
            public List<AttributeEntry> Attributes = new List<AttributeEntry>();
        }

        private class DataValue
        {
            public DataType Type;
            public object Value;

            public DataValue(DataType type, object value)
            {
                this.Type = type;
                this.Value = value;
            }

            public override string ToString()
            {
                return this.Value.ToString();
            }
        }

        private static string DataTypeToString(DataType type)
        {
            switch (type)
            {
                case DataType.Special: return "x";
                case DataType.Boolean: return "b";
                case DataType.Float: return "f";
                case DataType.String: return "s";
                case DataType.Integer: return "i";
                default:
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private static DataType DataTypeFromString(string type)
        {
            switch (type)
            {
                case "x": return DataType.Special;
                case "b": return DataType.Boolean;
                case "f": return DataType.Float;
                case "s": return DataType.String;
                case "i": return DataType.Integer;
                default:
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private enum DataType
        {
            Special = 1,
            Boolean = 2,
            Float = 3,
            String = 4,
            Integer = 5,
        }

        private class AttributeEntry
        {
            public DataValue Name;
            public DataValue Value;
        }
    }
}
