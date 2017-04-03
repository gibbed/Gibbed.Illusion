using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ColumnType = Gibbed.Illusion.FileFormats.ResourceTypes.TableData.ColumnType;

namespace Gibbed.Illusion.ExploreSDS
{
    public partial class TableViewer : Form
    {
        private Dictionary<uint, string> ColumnNames = new Dictionary<uint, string>();

        public TableViewer()
        {
            this.InitializeComponent();
            this.hintLabel.Text = "";

            // TODO: move this big list to an external file
            // I am lazy :effort:
            this.AddColumnName("0");
            this.AddColumnName("1");
            this.AddColumnName("2");
            this.AddColumnName("3");
            this.AddColumnName("4");
            this.AddColumnName("5");
            this.AddColumnName("6");
            this.AddColumnName("Id");
            this.AddColumnName("ID");
            this.AddColumnName("Top");
            this.AddColumnName("Max");
            this.AddColumnName("flag");
            this.AddColumnName("guid");
            this.AddColumnName("HP");
            this.AddColumnName("CO");
            this.AddColumnName("Type");
            this.AddColumnName("Left");
            this.AddColumnName("name");
            this.AddColumnName("Name");
            this.AddColumnName("Flags");
            this.AddColumnName("Speed");
            this.AddColumnName("Weight");
            this.AddColumnName("model");
            this.AddColumnName("scale");
            this.AddColumnName("speed");
            this.AddColumnName("Descr");
            this.AddColumnName("Group");
            this.AddColumnName("Notes");
            this.AddColumnName("Price");
            this.AddColumnName("Range");
            this.AddColumnName("Right");
            this.AddColumnName("Sound");
            this.AddColumnName("Value");
            this.AddColumnName("Water");
            this.AddColumnName("Bottom");
            this.AddColumnName("Default");
            this.AddColumnName("Defence");
            this.AddColumnName("Description");
            this.AddColumnName("impact");
            this.AddColumnName("Material");
            this.AddColumnName("Possibility");
            this.AddColumnName("Reaction");
            this.AddColumnName("Visibility");
            this.AddColumnName("restitution");
            this.AddColumnName("FadeIn");
            this.AddColumnName("FadeOut");
            this.AddColumnName("fragtex");
            this.AddColumnName("Impact");
            this.AddColumnName("SlipId");
            this.AddColumnName("TexCols");
            this.AddColumnName("TexEnd");
            this.AddColumnName("TexRows");
            this.AddColumnName("TexStart");
            this.AddColumnName("TypeName");
            this.AddColumnName("BlockId");
            this.AddColumnName("CrashId");
            this.AddColumnName("MaterialId");
            this.AddColumnName("RideId");
            this.AddColumnName("SlideId");
            this.AddColumnName("MaterialName");
            this.AddColumnName("CrossType");
            this.AddColumnName("affector");
            this.AddColumnName("MaxDistance");
            this.AddColumnName("BlockingTime");
        }

        private void AddColumnName(string name)
        {
            this.ColumnNames.Add(FileFormats.FNV.Hash32(name), name);
        }

        private string GetColumnName(uint hash)
        {
            if (this.ColumnNames.ContainsKey(hash) == true)
            {
                return this.ColumnNames[hash];
            }

            return hash.ToString("X8");
        }

        public void LoadFile(FileFormats.SdsMemory.Entry entry)
        {
            var tables = new FileFormats.ResourceTypes.TableResource();
            tables.Deserialize(entry.Header, entry.Data);

            this.comboBox.Items.Clear();
            foreach (var table in tables.Tables)
            {
                this.comboBox.Items.Add(table);
            }
            if (this.comboBox.Items.Count > 0)
            {
                this.comboBox.SelectedIndex = 0;
            }
        }

        private void UpdateDisplay()
        {
            var table = this.comboBox.SelectedItem as FileFormats.ResourceTypes.TableData;

            this.dataGrid.Columns.Clear();
            this.dataGrid.Rows.Clear();

            if (table == null)
            {
                return;
            }

            System.Data.DataTable tb;

            // build columns
            {
                foreach (var def in table.Columns)
                {
                    var column = new DataGridViewTextBoxColumn()
                    {
                        ValueType = FileFormats.ResourceTypes.TableData.GetValueTypeForColumnType(def.Type),
                        Name = def.NameHash.ToString("X8"),
                        HeaderText = GetColumnName(def.NameHash),
                        Tag = def,
                    };

                    switch (def.Type)
                    {
                        case ColumnType.String8:
                        case ColumnType.String16:
                        case ColumnType.String32:
                        case ColumnType.String64:
                        case ColumnType.Hash64AndString32:
                        {
                            break;
                        }

                        case ColumnType.Flags32:
                        case ColumnType.Hash64:
                        {
                            break;
                        }

                        default:
                        {
                            column.DefaultCellStyle.Alignment =
                                DataGridViewContentAlignment.MiddleRight;
                            break;
                        }
                    }

                    this.dataGrid.Columns.Add(column);
                }

                var row = new DataGridViewRow();
                row.CreateCells(this.dataGrid, table.Columns.Select(c => (object)c.Type).ToArray());
                row.ReadOnly = true;
                row.Frozen = true;
                row.DefaultCellStyle.BackColor = SystemColors.ControlLight;
                row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.DefaultCellStyle.Format = "";
                this.dataGrid.Rows.Add(row);
            }

            foreach (var row in table.Rows)
            {
                var cells = new DataGridViewCell[row.Values.Count];
                //cells[0].
                

                this.dataGrid.Rows.Add(row.Values.ToArray());
            }

        }

        private void OnSelectTable(object sender, EventArgs e)
        {
            this.UpdateDisplay();
        }

        private void OnLoadFromFile(object sender, EventArgs e)
        {
        }


        private void OnSaveToFile(object sender, EventArgs e)
        {
        }

        private void OnCellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

        }

        private void OnCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var column = this.dataGrid.Columns[e.ColumnIndex];
            var def = column.Tag as FileFormats.ResourceTypes.TableData.Column;
            if (def == null)
            {
                this.dataGrid.Rows[e.RowIndex].ErrorText = "null column definition?";
                return;
            }

            //this.dataGrid[e.ColumnIndex, e.RowIndex].
        }

        private void OnCurrentCellChanged(object sender, EventArgs e)
        {
            /*
            if (this.dataGrid.CurrentCell == null)
            {
                this.hintLabel.Text = "";
                return;
            }

            var column = this.dataGrid.Columns[this.dataGrid.CurrentCell.ColumnIndex];
            if (column == null)
            {
                this.hintLabel.Text = "";
                return;
            }

            var def = column.Tag as FileFormats.ResourceTypes.TableData.Column;
            if (def == null)
            {
                this.hintLabel.Text = "";
                return;
            }
            */
        }

        private void OnCopyHashes(object sender, EventArgs e)
        {
            var hashes = new List<uint>();

            foreach (FileFormats.ResourceTypes.TableData table in this.comboBox.Items)
            {
                foreach (var hash in table.Columns.Select(c => c.NameHash))
                {
                    if (hashes.Contains(hash) == false)
                    {
                        hashes.Add(hash);
                    }
                }
            }

            hashes.Sort();

            var text = new StringBuilder();
            foreach (var hash in hashes)
            {
                text.AppendLine(hash.ToString("X8"));
            }

            Clipboard.SetText(text.ToString());
        }

        private void OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == DataGridViewDataErrorContexts.Parsing)
            {
                e.ThrowException = false;
                this.dataGrid.Rows[e.RowIndex].ErrorText =
                    e.Exception.Message;
            }
        }
    }
}
