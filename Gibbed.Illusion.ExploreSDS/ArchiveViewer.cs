using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Gibbed.Illusion.ExploreSDS
{
    public partial class ArchiveViewer : Form
    {
        private string FilePath;
        private FileFormats.SdsReader Reader;

        public ArchiveViewer()
        {
            this.InitializeComponent();
            this.hintLabel.Text = "";
        }

        public void LoadArchive(string path)
        {
            this.Text += string.Format(": {0}", Path.GetFileName(path));

            var reader = new FileFormats.SdsReader();
            reader.Open(path);

            this.FilePath = path;
            this.Reader = reader;

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
            foreach (var type in this.Reader.ResourceTypes)
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

            foreach (var type in this.Reader.ResourceTypes)
            {
                if (type.Parent == 0)
                {
                    root.Nodes.Add(typeNodes[type.Name]);
                }
                else
                {
                    var parent = this.Reader.ResourceTypes.SingleOrDefault(
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

            foreach (var entry in this.Reader.Entries)
            {
                var type = this.Reader.ResourceTypes.SingleOrDefault(
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

        private void OnSaveRawArchive(object sender, EventArgs e)
        {
            this.saveRawDialog.FileName = Path.ChangeExtension(Path.GetFileName(this.FilePath), ".data");
            if (this.saveRawDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.Reader.ExportData(this.saveRawDialog.FileName);
        }

        private void OnSaveRawEntry(object sender, EventArgs e)
        {
            if (this.entryTreeView.SelectedNode == null)
            {
                return;
            }

            var entry = this.entryTreeView.SelectedNode.Tag as
                FileFormats.SdsReader.Entry;
            if (entry == null)
            {
                return;
            }

            var type = this.Reader.ResourceTypes.SingleOrDefault(
                r => r.Id == entry.TypeId);
            if (type == null)
            {
                throw new KeyNotFoundException();
            }

            var name = entry.Description;
            if (name.StartsWith("/") == true)
            {
                name = name.Substring(1);
            }
            name = name.Replace("/", "\\");

            this.saveRawDialog.FileName = Path.ChangeExtension(Path.GetFileName(name), "." + type.Name);
            if (this.saveRawDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.Reader.ExportEntry(entry, this.saveRawDialog.FileName);
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Reader != null)
            {
                this.Reader.Close();
            }
        }

        private void OnSelectEntry(object sender, TreeViewEventArgs e)
        {
            if (this.entryTreeView.SelectedNode == null)
            {
                this.hintLabel.Text = "";
                return;
            }

            var entry = this.entryTreeView.SelectedNode.Tag as
                FileFormats.SdsReader.Entry;
            if (entry == null)
            {
                this.hintLabel.Text = "";
                return;
            }

            this.hintLabel.Text = string.Format("Version {0}, @ 0x{1:X8}, {2} bytes",
                entry.Header.Version,
                entry.Offset,
                entry.Size);
        }

        private void OpenEntry(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            var entry = node.Tag as
                FileFormats.SdsReader.Entry;
            if (entry == null)
            {
                return;
            }

            var type = this.Reader.ResourceTypes.SingleOrDefault(
                r => r.Id == entry.TypeId);
            if (type == null)
            {
                throw new KeyNotFoundException();
            }

            if (type.Name == "XML")
            {
                var viewer = new XmlViewer()
                {
                    MdiParent = this.MdiParent,
                };
                viewer.LoadFile(entry.Header, this.Reader.GetEntry(entry));
                viewer.Show();
            }
            else if (type.Name == "MemFile")
            {
                var viewer = new MemFileViewer()
                {
                    MdiParent = this.MdiParent,
                };
                viewer.LoadFile(entry.Header, this.Reader.GetEntry(entry));
                viewer.Show();
            }
            else if (type.Name == "Table")
            {
                var viewer = new TableViewer()
                {
                    MdiParent = this.MdiParent,
                };
                viewer.LoadFile(entry.Header, this.Reader.GetEntry(entry));
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
    }
}
