using System;
using System.IO;
using System.Windows.Forms;
using Be.Windows.Forms;

namespace Gibbed.Illusion.ExploreSDS
{
    public partial class ScriptViewer : Form
    {
        public FileFormats.SdsMemory.Entry Entry;
        public FileFormats.ResourceTypes.ScriptResource Resource;

        public ScriptViewer()
        {
            this.InitializeComponent();
            this.hexBox.ReadOnly = true;
        }

        public void LoadFile(FileFormats.DataStorage.FileHeader header, FileFormats.SdsMemory.Entry entry)
        {
            var resource = new FileFormats.ResourceTypes.ScriptResource();
            resource.Deserialize(header, entry.Data);

            this.Text += ": " + resource.Path;

            this.comboBox.Items.Clear();
            foreach (var script in resource.Scripts)
            {
                this.comboBox.Items.Add(script);
            }

            this.Entry = entry;
            this.Resource = resource;

            if (this.comboBox.Items.Count > 0)
            {
                this.comboBox.SelectedIndex = 0;
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            var data = new MemoryStream();
            this.Resource.Serialize(this.Entry.Header, data);
            this.Entry.Data = data;
        }

        private void OnSelectScript(object sender, EventArgs e)
        {
            var script = this.comboBox.SelectedItem as FileFormats.ResourceTypes.ScriptData;
            if (script == null)
            {
                return;
            }
            this.hexBox.ByteProvider = new DynamicByteProvider(script.Data);
        }

        private void OnLoadFromFile(object sender, EventArgs e)
        {
            var script = this.comboBox.SelectedItem as FileFormats.ResourceTypes.ScriptData;
            if (script == null)
            {
                return;
            }

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
                script.Data = new byte[input.Length];
                input.Read(script.Data, 0, script.Data.Length);
                this.hexBox.ByteProvider = new DynamicByteProvider(script.Data);
            }
        }

        private void OnSaveToFile(object sender, EventArgs e)
        {
            var script = this.comboBox.SelectedItem as FileFormats.ResourceTypes.ScriptData;
            if (script == null)
            {
                return;
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
                output.Write(script.Data, 0, script.Data.Length);
            }
        }
    }
}
