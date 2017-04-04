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
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.XPath;
using Gibbed.Mafia2.FileFormats;

namespace Gibbed.Mafia2.ResourceExplorer
{
    public partial class ArchiveViewer : Form
    {
        private string _FilePath;
        private ArchiveFile _Archive;
        private List<string> _Descriptions;

        public ArchiveViewer()
        {
            this.InitializeComponent();
            this._HintLabel.Text = "";
        }

        public void LoadArchive(string path)
        {
            ArchiveFile archiveFile;
            using (var input = File.OpenRead(path))
            {
                using (Stream data = ArchiveEncryption.Unwrap(input))
                {
                    archiveFile = new ArchiveFile();
                    archiveFile.Deserialize(data ?? input);
                }
            }

            this._FilePath = path;
            this._Archive = archiveFile;
            this._Descriptions = LoadDescriptions(archiveFile.ResourceInfoXml);
            this.BuildEntryTree();
            this.Text += string.Format(": {0}", Path.GetFileName(path));
        }

        private static List<string> LoadDescriptions(string xml)
        {
            var items = new List<string>();
            if (string.IsNullOrEmpty(xml) == false)
            {
                using (var reader = new StringReader(xml))
                {
                    var doc = new XPathDocument(reader);
                    var nav = doc.CreateNavigator();
                    var nodes = nav.Select("/xml/ResourceInfo/SourceDataDescription");
                    while (nodes.MoveNext() == true)
                    {
                        items.Add(nodes.Current.Value);
                    }
                }
            }
            return items;
        }

        private void BuildEntryTree()
        {
            this._EntryTreeView.BeginUpdate();
            this._EntryTreeView.Nodes.Clear();

            var root = new TreeNode()
            {
                // ReSharper disable LocalizableElement
                Text = Path.GetFileName(this._FilePath) ?? "<unknown>",
                ImageKey = "SDS",
                SelectedImageKey = "SDS",
                // ReSharper restore LocalizableElement
            };

            var invalidParentNode = new TreeNode()
            {
                // ReSharper disable LocalizableElement
                Text = "(invalid parent)",
                // ReSharper restore LocalizableElement
            };

            var typeNodes = new Dictionary<string, TreeNode>();
            foreach (var type in this._Archive.ResourceTypes)
            {
                var hasImage = this._EntryTreeView.ImageList.Images.ContainsKey(type.Name);
                var node = new TreeNode()
                {
                    Text = type.Name,
                    ImageKey = hasImage == true ? type.Name : "",
                    SelectedImageKey = hasImage == true ? type.Name : "",
                };
                typeNodes.Add(type.Name, node);
            }

            foreach (var type in this._Archive.ResourceTypes)
            {
                var node = typeNodes[type.Name];
                if (type.Parent == 0)
                {
                    root.Nodes.Add(node);
                    continue;
                }

                TreeNode parentNode;
                var parent = this._Archive.ResourceTypes.SingleOrDefault(
                    r => r.Id == type.Id + type.Parent);
                if (parent != default(FileFormats.Archive.ResourceType) && parent == type)
                {
                    parentNode = typeNodes[parent.Name];
                }
                else
                {
                    parentNode = invalidParentNode;
                }

                if (parent == type)
                {
                    throw new InvalidOperationException();
                }

                parentNode.Nodes.Add(node);

                if (string.IsNullOrEmpty(node.ImageKey) == true)
                {
                    node.ImageKey = parentNode.ImageKey;
                    node.SelectedImageKey = parentNode.SelectedImageKey;
                }
            }

            for (int i = 0; i < this._Archive.ResourceEntries.Count; i++)
            {
                var resource = this._Archive.ResourceEntries[i];
                var description = i < this._Descriptions.Count &&
                                  this._Descriptions[i] != "not available"
                                      ? this._Descriptions[i]
                                      : "unknown #" + i;

                var type = this._Archive.ResourceTypes.SingleOrDefault(r => r.Id == resource.TypeId);
                if (type == default(FileFormats.Archive.ResourceType))
                {
                    throw new KeyNotFoundException();
                }

                var typeNode = typeNodes[type.Name];
                var node = new TreeNode(description)
                {
                    Tag = resource,
                    ImageKey = typeNode.ImageKey,
                    SelectedImageKey = typeNode.SelectedImageKey,
                };
                typeNode.Nodes.Add(node);
            }

            this._EntryTreeView.Nodes.Add(root);
            root.Expand();
            this._EntryTreeView.EndUpdate();
        }

        private void OnSelectEntry(object sender, TreeViewEventArgs e)
        {
            if (this._EntryTreeView.SelectedNode == null)
            {
                this._HintLabel.Text = "";
                return;
            }

            var entry = this._EntryTreeView.SelectedNode.Tag as FileFormats.Archive.ResourceEntry;
            if (entry == null)
            {
                this._HintLabel.Text = "";
                return;
            }

            this._HintLabel.Text = string.Format("Version {0}, {1} bytes", entry.Version, entry.Data.Length);
        }

        private void OpenResourceEntry(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            var resourceEntry = node.Tag as FileFormats.Archive.ResourceEntry;
            if (resourceEntry == null)
            {
                return;
            }

            var type = this._Archive.ResourceTypes.SingleOrDefault(r => r.Id == resourceEntry.TypeId);
            if (type == default(FileFormats.Archive.ResourceType))
            {
                throw new KeyNotFoundException();
            }

            var viewer = ResourceViewerFactory.Create(type.Name);
            viewer.MdiParent = this.MdiParent;
            viewer.LoadResource(resourceEntry, node.Text, this._Archive.Endian);
            viewer.Show();
        }

        private void OnOpenEntry1(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.OpenResourceEntry(e.Node);
        }

        private void OnOpenEntry2(object sender, EventArgs e)
        {
            this.OpenResourceEntry(this._EntryTreeView.SelectedNode);
        }

        private void OnSaveArchive(object sender, EventArgs e)
        {
            if (this._SaveArchiveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var output = File.Create(this._SaveArchiveDialog.FileName))
            {
                this._Archive.Serialize(output, ArchiveSerializeOptions.None);
            }
        }
    }
}
