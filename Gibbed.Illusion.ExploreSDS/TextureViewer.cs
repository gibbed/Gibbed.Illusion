using System;
using System.IO;
using System.Windows.Forms;

namespace Gibbed.Illusion.ExploreSDS
{
    public partial class TextureViewer : Form
    {
        public FileFormats.SdsMemory.Entry Entry;
        public FileFormats.ResourceTypes.TextureResource Resource;

        public TextureViewer()
        {
            this.InitializeComponent();
        }

        public void LoadFile(FileFormats.SdsMemory.Entry entry)
        {
            var resource = new FileFormats.ResourceTypes.TextureResource();
            resource.Deserialize(entry.Header, entry.Data);

            this.Text += ": " + entry.Description;

            this.Entry = entry;
            this.Resource = resource;

            this.UpdatePreview();
        }

        private void OnSave(object sender, System.EventArgs e)
        {
            var data = new MemoryStream();
            this.Resource.Serialize(this.Entry.Header, data);
            this.Entry.Data = data;
        }

        private void UpdatePreview()
        {
            var memory = new MemoryStream();
            memory.Write(this.Resource.Data, 0, this.Resource.Data.Length);
            memory.Position = 0;

            var dds = new Gibbed.Squish.DdsFile();
            dds.Load(memory);

            var image = dds.Image(true, true, true, this.toggleAlphaButton.Checked);

            this.previewPictureBox.Image = image;
            this.previewPictureBox.Width = image.Width;
            this.previewPictureBox.Height = image.Height;
            this.previewPictureBox.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void OnToggleAlpha(object sender, EventArgs e)
        {
            this.UpdatePreview();
        }

        private void OnSaveToFile(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(this.saveFileDialog.FileName) == true)
            {
                this.saveFileDialog.FileName = this.Entry.Description;
            }

            if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var output = File.Open(this.saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                output.Write(this.Resource.Data, 0, this.Resource.Data.Length);
            }
        }

        private void OnLoadFromFile(object sender, System.EventArgs e)
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
                this.Resource.Data = new byte[input.Length];
                input.Read(this.Resource.Data, 0, this.Resource.Data.Length);
                this.UpdatePreview();
            }
        }
    }
}
