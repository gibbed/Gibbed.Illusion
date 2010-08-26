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
            this.resourceTypeImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.saveUncompressedDataButton = new System.Windows.Forms.ToolStripButton();
            this.saveRawEntryButton = new System.Windows.Forms.ToolStripButton();
            this.saveRawDialog = new System.Windows.Forms.SaveFileDialog();
            this.entryMenuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
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
            this.entryTreeView.Size = new System.Drawing.Size(480, 215);
            this.entryTreeView.TabIndex = 0;
            // 
            // entryMenuStrip
            // 
            this.entryMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveRawToolStripMenuItem});
            this.entryMenuStrip.Name = "entryMenuStrip";
            this.entryMenuStrip.Size = new System.Drawing.Size(124, 26);
            // 
            // saveRawToolStripMenuItem
            // 
            this.saveRawToolStripMenuItem.Name = "saveRawToolStripMenuItem";
            this.saveRawToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveRawToolStripMenuItem.Text = "Save &Raw";
            this.saveRawToolStripMenuItem.Click += new System.EventHandler(this.OnSaveRawEntry);
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
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveUncompressedDataButton,
            this.saveRawEntryButton});
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
            // saveRawEntryButton
            // 
            this.saveRawEntryButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveRawEntryButton.Image = ((System.Drawing.Image)(resources.GetObject("saveRawEntryButton.Image")));
            this.saveRawEntryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveRawEntryButton.Name = "saveRawEntryButton";
            this.saveRawEntryButton.Size = new System.Drawing.Size(23, 22);
            this.saveRawEntryButton.Text = "Save Raw Data";
            this.saveRawEntryButton.Click += new System.EventHandler(this.OnSaveRawEntry);
            // 
            // saveRawDialog
            // 
            this.saveRawDialog.Filter = "All Files (*.*)|*.*";
            // 
            // ArchiveViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 240);
            this.Controls.Add(this.entryTreeView);
            this.Controls.Add(this.toolStrip);
            this.Name = "ArchiveViewer";
            this.Text = "Archive";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            this.entryMenuStrip.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView entryTreeView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton saveUncompressedDataButton;
        private System.Windows.Forms.ImageList resourceTypeImageList;
        private System.Windows.Forms.ToolStripButton saveRawEntryButton;
        private System.Windows.Forms.ContextMenuStrip entryMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveRawToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveRawDialog;
    }
}