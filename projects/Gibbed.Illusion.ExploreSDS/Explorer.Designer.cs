namespace Gibbed.Illusion.ExploreSDS
{
    partial class Explorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            this.openArchiveDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.openArchiveButton = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cascadeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // openArchiveDialog
            // 
            this.openArchiveDialog.DefaultExt = "sds";
            this.openArchiveDialog.Filter = "Illusion SDS archives (*.sds)|*.sds|All Files (*.*)|*.*";
            this.openArchiveDialog.Multiselect = true;
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openArchiveButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 24);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(800, 25);
            this.mainToolStrip.TabIndex = 3;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // openArchiveButton
            // 
            this.openArchiveButton.Image = ((System.Drawing.Image)(resources.GetObject("openArchiveButton.Image")));
            this.openArchiveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openArchiveButton.Name = "openArchiveButton";
            this.openArchiveButton.Size = new System.Drawing.Size(79, 22);
            this.openArchiveButton.Text = "Open SDS";
            this.openArchiveButton.Click += new System.EventHandler(this.OnOpen);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.windowsMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.toolStripSeparator3,
            this.exitMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "&File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openMenuItem.Image")));
            this.openMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openMenuItem.Text = "&Open";
            this.openMenuItem.Click += new System.EventHandler(this.OnOpen);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(143, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += new System.EventHandler(this.OnExit);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeAllMenuItem,
            this.toolStripSeparator1,
            this.cascadeMenuItem,
            this.tileVerticalMenuItem,
            this.tileHorizontalMenuItem,
            this.arrangeIconsMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(68, 20);
            this.windowsMenu.Text = "&Windows";
            // 
            // closeAllMenuItem
            // 
            this.closeAllMenuItem.Name = "closeAllMenuItem";
            this.closeAllMenuItem.Size = new System.Drawing.Size(151, 22);
            this.closeAllMenuItem.Text = "C&lose All";
            this.closeAllMenuItem.Click += new System.EventHandler(this.OnWindowCloseAll);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // cascadeMenuItem
            // 
            this.cascadeMenuItem.Name = "cascadeMenuItem";
            this.cascadeMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cascadeMenuItem.Text = "&Cascade";
            this.cascadeMenuItem.Click += new System.EventHandler(this.OnWindowCascade);
            // 
            // tileVerticalMenuItem
            // 
            this.tileVerticalMenuItem.Name = "tileVerticalMenuItem";
            this.tileVerticalMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileVerticalMenuItem.Text = "Tile &Vertical";
            this.tileVerticalMenuItem.Click += new System.EventHandler(this.OnWindowTileVertical);
            // 
            // tileHorizontalMenuItem
            // 
            this.tileHorizontalMenuItem.Name = "tileHorizontalMenuItem";
            this.tileHorizontalMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileHorizontalMenuItem.Text = "Tile &Horizontal";
            this.tileHorizontalMenuItem.Click += new System.EventHandler(this.OnWindowTileHorizontal);
            // 
            // arrangeIconsMenuItem
            // 
            this.arrangeIconsMenuItem.Name = "arrangeIconsMenuItem";
            this.arrangeIconsMenuItem.Size = new System.Drawing.Size(151, 22);
            this.arrangeIconsMenuItem.Text = "&Arrange Icons";
            this.arrangeIconsMenuItem.Click += new System.EventHandler(this.OnWindowArrangeIcons);
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.mainToolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.Name = "Explorer";
            this.Text = "SDS Explorer";
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openArchiveDialog;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton openArchiveButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

