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
using Gibbed.IO;
using ResourceEntry = Gibbed.Mafia2.FileFormats.Archive.ResourceEntry;

namespace Gibbed.Mafia2.ResourceExplorer
{
    public partial class RawViewer : Form, IResourceViewer
    {
        private ResourceEntry _ResourceEntry;
        private Endian _Endian;
        private string _Description;

        public RawViewer()
        {
            this.InitializeComponent();
            this._HexBox.ReadOnly = true;
        }

        public void LoadResource(ResourceEntry resourceEntry, string description, Endian endian)
        {
            this._ResourceEntry = resourceEntry;
            this._Endian = endian;
            this._Description = description;
            this.UpdatePreview();
            // ReSharper disable LocalizableElement
            this.Text += ": " + this._Description;
            // ReSharper restore LocalizableElement
        }

        private void UpdatePreview()
        {
            this._HexBox.ByteProvider = new DynamicByteProvider(this._ResourceEntry.Data);
        }

        private void OnSaveToFile(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this._SaveFileDialog.FileName) == true)
            {
                var name = this._Description;
                if (name.StartsWith("/") == true)
                {
                    name = name.Substring(1);
                }
                name = name.Replace("/", "\\");
                this._SaveFileDialog.FileName = name;
            }

            if (this._SaveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            File.WriteAllBytes(this._SaveFileDialog.FileName, this._ResourceEntry.Data);
        }

        private void OnLoadFromFile(object sender, EventArgs e)
        {
            if (this._OpenFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this._ResourceEntry.Data = File.ReadAllBytes(this._OpenFileDialog.FileName);
            this.UpdatePreview();
        }
    }
}
