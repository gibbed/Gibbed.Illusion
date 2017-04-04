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
using Gibbed.IO;
using DDSFile = Gibbed.Squish.DDSFile;
using ResourceEntry = Gibbed.Mafia2.FileFormats.Archive.ResourceEntry;

namespace Gibbed.Mafia2.ResourceExplorer
{
    public partial class TextureViewer : Form, IResourceViewer
    {
        private ResourceEntry _ResourceEntry;
        private Endian _Endian;
        private string _Description;
        private ResourceFormats.TextureResource _Resource;

        public TextureViewer()
        {
            this.InitializeComponent();
        }

        public void LoadResource(ResourceEntry resourceEntry, string description, Endian endian)
        {
            var resource = new ResourceFormats.TextureResource();
            using (var data = new MemoryStream(resourceEntry.Data, false))
            {
                resource.Deserialize(resourceEntry.Version, data, endian);
            }

            this._ResourceEntry = resourceEntry;
            this._Endian = endian;
            this._Description = description;
            this._Resource = resource;

            // ReSharper disable LocalizableElement
            this.Text += ": " + description;
            // ReSharper restore LocalizableElement
            this.UpdatePreview();
        }

        private void OnSave(object sender, EventArgs e)
        {
            using (var data = new MemoryStream())
            {
                this._Resource.Serialize(this._ResourceEntry.Version, data, this._Endian);
                data.Flush();
                this._ResourceEntry.Data = data.ToArray();
            }
        }

        private void UpdatePreview()
        {
            var memory = new MemoryStream();
            memory.Write(this._Resource.Data, 0, this._Resource.Data.Length);
            memory.Position = 0;

            var dds = new DDSFile();
            dds.Deserialize(memory);

            var image = dds.Image(true, true, true, this._ToggleAlphaButton.Checked);

            if (this._ZoomButton.Checked == true)
            {
                this._PreviewPictureBox.Dock = DockStyle.Fill;
                this._PreviewPictureBox.Image = image;
                this._PreviewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                this._PreviewPictureBox.Dock = DockStyle.None;
                this._PreviewPictureBox.Image = image;
                this._PreviewPictureBox.Width = image.Width;
                this._PreviewPictureBox.Height = image.Height;
                this._PreviewPictureBox.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void OnZoom(object sender, EventArgs e)
        {
            this.UpdatePreview();
        }

        private void OnToggleAlpha(object sender, EventArgs e)
        {
            this.UpdatePreview();
        }

        private void OnSaveToFile(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this._SaveFileDialog.FileName) == true)
            {
                this._SaveFileDialog.FileName = this._Description;
            }

            if (this._SaveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            File.WriteAllBytes(this._SaveFileDialog.FileName, this._Resource.Data);
        }

        private void OnLoadFromFile(object sender, EventArgs e)
        {
            if (this._OpenFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this._Resource.Data = File.ReadAllBytes(this._OpenFileDialog.FileName);
            this.UpdatePreview();
        }
    }
}
