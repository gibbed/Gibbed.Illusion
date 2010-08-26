namespace Gibbed.Illusion.ExploreSDS
{
    partial class ArchiveViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveViewer));
            this.entryTreeView = new System.Windows.Forms.TreeView();
            this.entryMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveRawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourceTypeImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.saveUncompressedDataButton = new System.Windows.Forms.ToolStripButton();
            this.saveEntryButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openEntryButton = new System.Windows.Forms.ToolStripButton();
            this.saveRawDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.hintLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.entryMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // entryTreeView
            // 
            this.entryTreeView.ContextMenuStrip = this.entryMenuStrip;
            this.entryTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entryTreeView.ImageIndex = 0;
            this.entryTreeView.ImageList = this.resourceTypeImageList;
            this.entryTreeView.Location = new System.Drawing.Point(0, 25);
            this.entryTreeView.Name = "entryTreeView";
            this.entryTreeView.SelectedImageIndex = 0;
            this.entryTreeView.Size = new System.Drawing.Size(480, 193);
            this.entryTreeView.TabIndex = 0;
            this.entryTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnOpenEntry1);
            this.entryTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnSelectEntry);
            // 
            // entryMenuStrip
            // 
            this.entryMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawToolStripMenuItem,
            this.toolStripMenuItem1,
            this.openToolStripMenuItem});
            this.entryMenuStrip.Name = "entryMenuStrip";
            this.entryMenuStrip.Size = new System.Drawing.Size(124, 54);
            // 
            // saveRawToolStripMenuItem
            // 
            this.saveRawToolStripMenuItem.Name = "saveRawToolStripMenuItem";
            this.saveRawToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveRawToolStripMenuItem.Text = "Save &Raw";
            this.saveRawToolStripMenuItem.Click += new System.EventHandler(this.OnSaveRawEntry);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OnOpenEntry2);
            // 
            // resourceTypeImageList
            // 
            this.resourceTypeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("resourceTypeImageList.ImageStream")));
            this.resourceTypeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.resourceTypeImageList.Images.SetKeyName(0, "Unknown");
            this.resourceTypeImageList.Images.SetKeyName(1, "SDS");
            this.resourceTypeImageList.Images.SetKeyName(2, "MemFile");
            this.resourceTypeImageList.Images.SetKeyName(3, "XML");
            this.resourceTypeImageList.Images.SetKeyName(4, "Table");
            this.resourceTypeImageList.Images.SetKeyName(5, "Script");
            this.resourceTypeImageList.Images.SetKeyName(6, "Texture");
            this.resourceTypeImageList.Images.SetKeyName(7, "Sound");
            this.resourceTypeImageList.Images.SetKeyName(8, "Cutscene");
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveUncompressedDataButton,
            this.saveEntryButton,
            this.toolStripSeparator1,
            this.openEntryButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(480, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // saveUncompressedDataButton
            // 
            this.saveUncompressedDataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveUncompressedDataButton.Image = ((System.Drawing.Image)(resources.GetObject("saveUncompressedDataButton.Image")));
            this.saveUncompressedDataButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveUncompressedDataButton.Name = "saveUncompressedDataButton";
            this.saveUncompressedDataButton.Size = new System.Drawing.Size(23, 22);
            this.saveUncompressedDataButton.Text = "Save Archive Data";
            this.saveUncompressedDataButton.Click += new System.EventHandler(this.OnSaveRawArchive);
            // 
            // saveEntryButton
            // 
            this.saveEntryButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveEntryButton.Image = ((System.Drawing.Image)(resources.GetObject("saveEntryButton.Image")));
            this.saveEntryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveEntryButton.Name = "saveEntryButton";
            this.saveEntryButton.Size = new System.Drawing.Size(23, 22);
            this.saveEntryButton.Text = "Save Raw Data";
            this.saveEntryButton.Click += new System.EventHandler(this.OnSaveRawEntry);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // openEntryButton
            // 
            this.openEntryButton.Image = ((System.Drawing.Image)(resources.GetObject("openEntryButton.Image")));
            this.openEntryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openEntryButton.Name = "openEntryButton";
            this.openEntryButton.Size = new System.Drawing.Size(83, 22);
            this.openEntryButton.Text = "Open Data";
            this.openEntryButton.Click += new System.EventHandler(this.OnOpenEntry2);
            // 
            // saveRawDialog
            // 
            this.saveRawDialog.Filter = "All Files (*.*)|*.*";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hintLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 218);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(480, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // hintLabel
            // 
            this.hintLabel.Name = "hintLabel";
            this.hintLabel.Size = new System.Drawing.Size(30, 17);
            this.hintLabel.Text = "Hint";
            // 
            // ArchiveViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 240);
            this.Controls.Add(this.entryTreeView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Name = "ArchiveViewer";
            this.Text = "Archive";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            this.entryMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView entryTreeView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton saveUncompressedDataButton;
        private System.Windows.Forms.ImageList resourceTypeImageList;
        private System.Windows.Forms.ContextMenuStrip entryMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveRawToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveRawDialog;
        private System.Windows.Forms.ToolStripButton saveEntryButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel hintLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton openEntryButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    }
}