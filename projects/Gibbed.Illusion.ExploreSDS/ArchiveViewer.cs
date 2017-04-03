using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gibbed.IO;
using Gibbed.Illusion.FileFormats;

namespace Gibbed.Illusion.ExploreSDS
{
    public partial class ArchiveViewer : Form
    {
        private string FilePath;
        private FileFormats.SdsMemory Archive;

        public ArchiveViewer()
        {
            this.InitializeComponent();
            this.hintLabel.Text = "";
        }

        public void LoadArchive(string path)
        {
            this.Text += string.Format(": {0}", Path.GetFileName(path));

            this.FilePath = path;

            var reader = new FileFormats.SdsReader();
            reader.Open(path);
            this.Archive = reader.LoadToMemory();
            reader.Close();

            this.BuildEntryTree();
        }

        private void BuildEntryTree()
        {
            this.entryTreeView.BeginUpdate();
            this.entryTreeView.Nodes.Clear();

            var root = new TreeNode(Path.GetFileName(this.FilePath));
            root.ImageKey = "SDS";
            root.SelectedImageKey = "SDS";

            var typeNodes = new Dictionary<string, TreeNode>();
            foreach (var type in this.Archive.ResourceTypes)
            {
                var node = new TreeNode(type.Name);
                
                if (this.entryTreeView.ImageList.Images.ContainsKey(type.Name) == true)
                {
                    node.ImageKey = type.Name;
                    node.SelectedImageKey = type.Name;
                }
                else
                {
                    node.ImageKey = "";
                    node.SelectedImageKey = "";
                }

                typeNodes.Add(type.Name, node);
            }

            foreach (var type in this.Archive.ResourceTypes)
            {
                if (type.Parent == 0)
                {
                    root.Nodes.Add(typeNodes[type.Name]);
                }
                else
                {
                    var parent = this.Archive.ResourceTypes.SingleOrDefault(
                        r => r.Id == type.Id + type.Parent);
                    
                    if (parent == null)
                    {
                        throw new KeyNotFoundException();
                    }

                    if (parent == type)
                    {
                        throw new InvalidOperationException();
                    }

                    typeNodes[parent.Name].Nodes.Add(typeNodes[type.Name]);

                    if (string.IsNullOrEmpty(typeNodes[type.Name].ImageKey) == true)
                    {
                        typeNodes[type.Name].ImageKey = typeNodes[parent.Name].ImageKey;
                        typeNodes[type.Name].SelectedImageKey = typeNodes[parent.Name].SelectedImageKey;
                    }
                }
            }

            foreach (var entry in this.Archive.Entries)
            {
                var type = this.Archive.ResourceTypes.SingleOrDefault(
                    r => r.Id == entry.TypeId);
                if (type == null)
                {
                    throw new KeyNotFoundException();
                }

                var typeNode = typeNodes[type.Name];
                
                var node = new TreeNode(entry.Description);
                node.Tag = entry;
                node.ImageKey = typeNode.ImageKey;
                node.SelectedImageKey = typeNode.SelectedImageKey;
                typeNode.Nodes.Add(node);
            }

            this.entryTreeView.Nodes.Add(root);
            root.Expand();
            this.entryTreeView.EndUpdate();
        }

        private void OnSelectEntry(object sender, TreeViewEventArgs e)
        {
            if (this.entryTreeView.SelectedNode == null)
            {
                this.hintLabel.Text = "";
                return;
            }

            var entry = this.entryTreeView.SelectedNode.Tag as
                FileFormats.SdsMemory.Entry;
            if (entry == null)
            {
                this.hintLabel.Text = "";
                return;
            }

            this.hintLabel.Text = string.Format("Version {0}, {1} bytes",
                entry.Header.Version,
                entry.Data.Length);
        }

        private void OpenEntry(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            var entry = node.Tag as
                FileFormats.SdsMemory.Entry;
            if (entry == null)
            {
                return;
            }

            var type = this.Archive.ResourceTypes.SingleOrDefault(
                r => r.Id == entry.TypeId);
            if (type == null)
            {
                throw new KeyNotFoundException();
            }

            entry.Data.Position = 0;

            if (type.Name == "XML")
            {
                var viewer = new XmlViewer()
                {
                    MdiParent = this.MdiParent,
                };
                viewer.LoadFile(entry);
                viewer.Show();
            }
            else if (type.Name == "MemFile")
            {
                var viewer = new MemFileViewer()
                {
                    MdiParent = this.MdiParent,
                };
                viewer.LoadFile(entry);
                viewer.Show();
            }
            else if (type.Name == "Table")
            {
                var viewer = new TableViewer()
                {
                    MdiParent = this.MdiParent,
                };
                viewer.LoadFile(entry);
                viewer.Show();
            }
            else if (type.Name == "Script")
            {
                var viewer = new ScriptViewer()
                {
                    MdiParent = this.MdiParent,
                };
                viewer.LoadFile(entry);
                viewer.Show();
            }
            else if (type.Name == "Texture")
            {
                var viewer = new TextureViewer()
                {
                    MdiParent = this.MdiParent,
                };
                viewer.LoadFile(entry);
                viewer.Show();
            }
            else
            {
                var viewer = new RawViewer()
                {
                    MdiParent = this.MdiParent,
                };
                viewer.LoadFile(entry);
                viewer.Show();
            }
        }

        private void OnOpenEntry1(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.OpenEntry(e.Node);
        }

        private void OnOpenEntry2(object sender, EventArgs e)
        {
            this.OpenEntry(this.entryTreeView.SelectedNode);
        }

        private void OnSaveArchive(object sender, EventArgs e)
        {
            if (this.saveArchiveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var output = File.Open(
                this.saveArchiveDialog.FileName,
                FileMode.Create,
                FileAccess.Write,
                FileShare.ReadWrite))
            {
                var data = new MemoryStream();
                foreach (var entry in this.Archive.Entries)
                {
                    var entryHeaderData = new MemoryStream();
                    entry.Header.Size = (uint)(30 + entry.Data.Length);
                    entry.Header.Serialize(entryHeaderData, Endian.Little);
                    data.WriteFromMemoryStreamSafe(entryHeaderData, Endian.Little);
                    entry.Data.Position = 0;
                    data.WriteFromStream(entry.Data, entry.Data.Length);
                }
                data.Position = 0;

                output.WriteString("SDS\0", Encoding.ASCII);
                output.WriteValueU32(19);
                output.WriteString("PC\0\0", Encoding.ASCII);
                output.WriteValueU32(0x5FFB74F3);

                output.Seek(72, SeekOrigin.Begin);
                {
                    this.Archive.Header.ResourceTypeTableOffset = (uint)output.Position;
                    output.WriteValueS32(this.Archive.ResourceTypes.Count);
                    foreach (var resourceType in this.Archive.ResourceTypes)
                    {
                        resourceType.Serialize(output, Endian.Little);
                    }
                }

                this.Archive.Header.BlockTableOffset = (uint)output.Position;

                output.WriteValueU32(0x6C7A4555);
                output.WriteValueU32((uint)data.Length);
                output.WriteValueU8(4);

                output.WriteValueU32((uint)data.Length);
                output.WriteValueU8(0);
                output.WriteFromStream(data, (uint)data.Length);

                output.WriteValueU32(0);
                output.WriteValueU8(0);

                this.Archive.Header.XmlOffset = (uint)output.Position;
                output.WriteString(this.Archive.Xml);

                output.Seek(16, SeekOrigin.Begin);

                var headerData = new MemoryStream();
                this.Archive.Header.Serialize(headerData, Endian.Little);
                output.WriteFromMemoryStreamSafe(headerData, Endian.Little);
            }
        }
    }
}
