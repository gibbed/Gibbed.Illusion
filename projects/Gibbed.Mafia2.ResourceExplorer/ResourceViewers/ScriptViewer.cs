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
using System.Windows.Forms;
using Be.Windows.Forms;
using ResourceEntry = Gibbed.Mafia2.FileFormats.Archive.ResourceEntry;

namespace Gibbed.Mafia2.ResourceExplorer
{
    public partial class ScriptViewer : Form, IResourceViewer
    {
        private ResourceEntry _ResourceEntry;
        private string _Description;
        private ResourceFormats.ScriptResource _Resource;

        public ScriptViewer()
        {
            this.InitializeComponent();
            this._HexBox.ReadOnly = true;
        }

        public void LoadResource(ResourceEntry resourceEntry, string description)
        {
            var resource = new ResourceFormats.ScriptResource();
            using (var data = new MemoryStream(resourceEntry.Data, false))
            {
                resource.Deserialize(resourceEntry.Version, data);
            }

            this._ResourceEntry = resourceEntry;
            this._Description = description;
            this._Resource = resource;

            // ReSharper disable LocalizableElement
            this.Text += ": " + resource.Path;
            // ReSharper restore LocalizableElement
            this._ScriptComboBox.Items.Clear();
            foreach (var script in resource.Scripts)
            {
                this._ScriptComboBox.Items.Add(script);
            }
            if (this._ScriptComboBox.Items.Count > 0)
            {
                this._ScriptComboBox.SelectedIndex = 0;
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            using (var data = new MemoryStream())
            {
                this._Resource.Serialize(this._ResourceEntry.Version, data);
                data.Flush();
                this._ResourceEntry.Data = data.ToArray();
            }
        }

        private void OnSelectScript(object sender, EventArgs e)
        {
            var script = this._ScriptComboBox.SelectedItem as ResourceFormats.ScriptData;
            if (script == null)
            {
                return;
            }
            this._HexBox.ByteProvider = new DynamicByteProvider(script.Data);
        }

        private void OnLoadFromFile(object sender, EventArgs e)
        {
            var script = this._ScriptComboBox.SelectedItem as ResourceFormats.ScriptData;
            if (script == null)
            {
                return;
            }

            if (this._OpenFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            script.Data = File.ReadAllBytes(this._OpenFileDialog.FileName);
            this._HexBox.ByteProvider = new DynamicByteProvider(script.Data);
        }

        private void OnSaveToFile(object sender, EventArgs e)
        {
            var script = this._ScriptComboBox.SelectedItem as ResourceFormats.ScriptData;
            if (script == null)
            {
                return;
            }

            if (this._SaveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            File.WriteAllBytes(this._SaveFileDialog.FileName, script.Data);
        }
    }
}
