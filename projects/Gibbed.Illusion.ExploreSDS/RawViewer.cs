using System;
using System.IO;
using System.Windows.Forms;
using Be.Windows.Forms;
using Gibbed.IO;

namespace Gibbed.Illusion.ExploreSDS
{
    public partial class RawViewer : Form
    {
        public FileFormats.SdsMemory.Entry Entry;

        public RawViewer()
        {
            this.InitializeComponent();
            this.hexBox.ReadOnly = true;
        }

        public void LoadFile(FileFormats.SdsMemory.Entry entry)
        {
            this.Text += ": " + entry.Description;
            this.Entry = entry;

            this.UpdatePreview();
        }

        private void UpdatePreview()
        {
            this.Entry.Data.Position = 0;
            byte[] data = new byte[this.Entry.Data.Length];
            this.Entry.Data.Read(data, 0, data.Length);
            this.hexBox.ByteProvider = new DynamicByteProvider(data);
        }

        private void OnSaveToFile(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.saveFileDialog.FileName) == true)
            {
                var name = this.Entry.Description;
                if (name.StartsWith("/") == true)
                {
                    name = name.Substring(1);
                }
                name = name.Replace("/", "\\");

                this.saveFileDialog.FileName = name;
            }

            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var output = File.Open(
                this.saveFileDialog.FileName,
                FileMode.Create,
                FileAccess.Write,
                FileShare.ReadWrite))
            {
                this.Entry.Data.Position = 0;
                output.WriteFromStream(this.Entry.Data, this.Entry.Data.Length);
            }
        }

        private void OnLoadFromFile(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var input = File.Open(
                this.openFileDialog.FileName,
                FileMode.Open,
                FileAccess.Read,
                FileShare.ReadWrite))
            {
                this.Entry.Data = new MemoryStream();
                this.Entry.Data.WriteFromStream(input, input.Length);
                this.UpdatePreview();
                this.Entry.Data.Position = 0;
            }
        }
    }
}
