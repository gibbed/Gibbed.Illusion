using System;
using System.Collections.Generic;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.ResourceTypes
{
    public class TableData : IResourceType
    {
        public ulong NameHash;
        public string Name;

        public List<RowData> Rows =
            new List<RowData>();
        public List<ColumnDefinition> Columns =
            new List<ColumnDefinition>();

        public override string ToString()
        {
            return this.Name;
        }

        public void Serialize(DataStorage.FileHeader header, Stream input)
        {
            throw new NotImplementedException();
        }

        public void Deserialize(DataStorage.FileHeader header, Stream input)
        {
            this.NameHash = input.ReadValueU64();
            this.Name = input.ReadStringU16();

            if (header.Version >= 2)
            {
                throw new NotSupportedException();
            }
            else
            {
                var columnCount = input.ReadValueU16();
                
                var unk1 = input.ReadValueU32();
                var unk2 = input.ReadValueU32();
                
                var rowSize = input.ReadValueU32();
                var rowCount = input.ReadValueU32();
                var data = input.ReadToMemoryStream(rowSize * rowCount);

                this.Columns = new List<ColumnDefinition>();
                for (uint i = 0; i < columnCount; i++)
                {
                    this.Columns.Add(new ColumnDefinition()
                        {
                            NameHash = input.ReadValueU32(),
                            Type = (ColumnType)input.ReadValueU8(),
                            Unknown2 = input.ReadValueU8(),
                            Unknown3 = input.ReadValueU16(),
                        });
                }

                input = null;

                this.Rows.Clear();
                for (uint i = 0; i < rowCount; i++)
                {
                    var row = new RowData();

                    data.Seek(i * rowSize, SeekOrigin.Begin);
                    foreach (var column in this.Columns)
                    {
                        if ((byte)column.Type > 163)
                        {
                            throw new FormatException();
                        }

                        switch (column.Type)
                        {
                            case ColumnType.Boolean:
                            {
                                var value = data.ReadValueU32();
                                if (value != 0 && value != 1)
                                {
                                    throw new FormatException();
                                }
                                row.Columns.Add(value != 0);
                                break;
                            }

                            case ColumnType.Float32:
                            {
                                var value = data.ReadValueF32();
                                row.Columns.Add(value);
                                break;
                            }

                            case ColumnType.Signed32:
                            {
                                var value = data.ReadValueS32();
                                row.Columns.Add(value);
                                break;
                            }

                            case ColumnType.Unsigned32:
                            {
                                var value = data.ReadValueU32();
                                row.Columns.Add(value);
                                break;
                            }

                            case ColumnType.Hash32:
                            {
                                var value = data.ReadValueU32();
                                row.Columns.Add(value);
                                break;
                            }

                            case ColumnType.Hash64:
                            {
                                var value = data.ReadValueU64();
                                row.Columns.Add(value);
                                break;
                            }

                            case ColumnType.String8:
                            {
                                string value = data.ReadString(8, true);
                                row.Columns.Add(value);
                                break;
                            }

                            case ColumnType.String16:
                            {
                                string value = data.ReadString(16, true);
                                row.Columns.Add(value);
                                break;
                            }

                            case ColumnType.String32:
                            {
                                string value = data.ReadString(32, true);
                                row.Columns.Add(value);
                                break;
                            }

                            case ColumnType.String64:
                            {
                                string value = data.ReadString(64, true);
                                row.Columns.Add(value);
                                break;
                            }

                            case ColumnType.Color:
                            {
                                float r = data.ReadValueF32();
                                float g = data.ReadValueF32();
                                float b = data.ReadValueF32();
                                // TODO: de-stupidize this
                                row.Columns.Add(string.Format("{0}, {1}, {2}", r, g, b));
                                break;
                            }

                            case ColumnType.Hash64AndString32:
                            {
                                var hash = data.ReadValueU64();
                                string value = data.ReadString(32, true);
                                row.Columns.Add(value);
                                break;
                            }

                            default:
                            {
                                throw new FormatException();
                            }
                        }
                    }

                    this.Rows.Add(row);
                }
            }
        }

        public class ColumnDefinition
        {
            public uint NameHash;
            public ColumnType Type;
            public byte Unknown2;
            public ushort Unknown3;

            public override string ToString()
            {
                return string.Format("{0:X8} : {1} ({2}, {3})",
                    this.NameHash,
                    this.Type,
                    this.Unknown2,
                    this.Unknown3);
            }
        }

        public class RowData
        {
            public List<object> Columns = new List<object>();

            public override string ToString()
            {
                var values = new string[this.Columns.Count];
                for (int i = 0; i < this.Columns.Count; i++)
                {
                    values[i] = this.Columns[i].ToString();
                }
                return string.Join(", ", values);
            }
        }

        public enum ColumnType : byte
        {
            Boolean = 1,
            Float32 = 2,
            Signed32 = 3,
            Unsigned32 = 4,
            Hash32 = 5,
            Hash64 = 6,
            String8 = 8,
            String16 = 16,
            String32 = 32,
            String64 = 64,
            Color = 66,
            Hash64AndString32 = 132,
        }
    }
}
