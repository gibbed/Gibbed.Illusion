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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gibbed.IO;
using ColumnType = Gibbed.Mafia2.ResourceFormats.TableData.ColumnType;
using ResourceEntry = Gibbed.Mafia2.FileFormats.Archive.ResourceEntry;

namespace Gibbed.Mafia2.ResourceExplorer
{
    public partial class TableViewer : Form, IResourceViewer
    {
        private Dictionary<uint, string> ColumnNames = new Dictionary<uint, string>();

        public TableViewer()
        {
            this.InitializeComponent();
            this._HintLabel.Text = "";

            // TODO: move this big list to an external file
            // I am lazy :effort:
            this.AddColumnName("0", "1", "2", "3", "4", "5", "6");
            this.AddColumnName("Id", "ID");
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

        private void AddColumnName(params string[] names)
        {
            if (names != null)
            {
                foreach (var name in names)
                {
                    var hash = Illusion.FileFormats.Hashing.FNV32.Hash(name);
                    this.ColumnNames.Add(hash, name);
                }
            }
        }

        private string GetColumnName(uint hash)
        {
            if (this.ColumnNames.ContainsKey(hash) == true)
            {
                return this.ColumnNames[hash];
            }

            return hash.ToString("X8");
        }

        public void LoadResource(ResourceEntry resourceEntry, string description, Endian endian)
        {
            var tables = new ResourceFormats.TableResource();
            using (var data = new MemoryStream(resourceEntry.Data, false))
            {
                tables.Deserialize(resourceEntry.Version, data, endian);
            }

            this._TableComboBox.Items.Clear();
            foreach (var table in tables.Tables)
            {
                this._TableComboBox.Items.Add(table);
            }
            if (this._TableComboBox.Items.Count > 0)
            {
                this._TableComboBox.SelectedIndex = 0;
            }
        }

        private void UpdateDisplay()
        {
            var table = this._TableComboBox.SelectedItem as ResourceFormats.TableData;

            this._DataGrid.Columns.Clear();
            this._DataGrid.Rows.Clear();

            if (table == null)
            {
                return;
            }

            //System.Data.DataTable tb;

            // build columns
            {
                foreach (var def in table.Columns)
                {
                    var column = new DataGridViewTextBoxColumn()
                    {
                        ValueType = ResourceFormats.TableData.GetValueTypeForColumnType(def.Type),
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
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            break;
                        }
                    }

                    this._DataGrid.Columns.Add(column);
                }

                var row = new DataGridViewRow();
                row.CreateCells(this._DataGrid, table.Columns.Select(c => (object)c.Type).ToArray());
                row.ReadOnly = true;
                row.Frozen = true;
                row.DefaultCellStyle.BackColor = SystemColors.ControlLight;
                row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.DefaultCellStyle.Format = "";
                this._DataGrid.Rows.Add(row);
            }

            foreach (var row in table.Rows)
            {
                //var cells = new DataGridViewCell[row.Values.Count];
                this._DataGrid.Rows.Add(row.Values.ToArray());
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
            var column = this._DataGrid.Columns[e.ColumnIndex];
            var def = column.Tag as ResourceFormats.TableData.Column;
            if (def == null)
            {
                this._DataGrid.Rows[e.RowIndex].ErrorText = "null column definition?";
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

            foreach (ResourceFormats.TableData table in this._TableComboBox.Items)
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
                this._DataGrid.Rows[e.RowIndex].ErrorText = e.Exception.Message;
            }
        }
    }
}
