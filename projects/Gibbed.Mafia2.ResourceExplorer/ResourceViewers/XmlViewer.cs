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

using System.IO;
using System.Windows.Forms;
using ResourceEntry = Gibbed.Mafia2.FileFormats.Archive.ResourceEntry;

namespace Gibbed.Mafia2.ResourceExplorer
{
    public partial class XmlViewer : Form, IResourceViewer
    {
        private ResourceEntry _ResourceEntry;
        private string _Description;
        private ResourceFormats.XmlResource _Resource;

        public XmlViewer()
        {
            this.InitializeComponent();
        }

        public void LoadResource(ResourceEntry resourceEntry, string description)
        {
            var resource = new ResourceFormats.XmlResource();
            using (var data = new MemoryStream(resourceEntry.Data, false))
            {
                resource.Deserialize(resourceEntry.Version, data);
            }

            this._ResourceEntry = resourceEntry;
            this._Description = description;
            this._Resource = resource;

            if (this._Resource.Unk3 == true)
            {
                this._SaveButton.Enabled = false;
            }

            // ReSharper disable LocalizableElement
            this.Text += ": " + resource.Name + " (" + resource.Tag + ")";
            // ReSharper restore LocalizableElement

            this._ContentTextBox.Text = resource.Content;
            this._ContentTextBox.Select(0, 0);
        }

        private void OnSave(object sender, System.EventArgs e)
        {
            this._Resource.Content = this._ContentTextBox.Text;
            using (var data = new MemoryStream())
            {
                this._Resource.Serialize(this._ResourceEntry.Version, data);
                data.Flush();
                this._ResourceEntry.Data = data.ToArray();
            }
        }

        private void OnSaveToFile(object sender, System.EventArgs e)
        {
            var name = this._Resource.Name;
            if (name.StartsWith("/") == true)
            {
                name = name.Substring(1);
            }
            name = name.Replace("/", "\\");
            name = Path.ChangeExtension(name, ".xml");

            this._SaveFileDialog.FileName = name;
            if (this._SaveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            File.WriteAllText(this._SaveFileDialog.FileName, this._ContentTextBox.Text);
        }

        private void OnLoadFromFile(object sender, System.EventArgs e)
        {
            if (this._OpenFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this._ContentTextBox.Text = File.ReadAllText(this._OpenFileDialog.FileName);
        }
    }
}
