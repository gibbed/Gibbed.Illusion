namespace Gibbed.Mafia2.ResourceExplorer
{
    partial class TextureViewer
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
            System.Windows.Forms.ToolStrip _ToolStrip;
            System.Windows.Forms.ToolStripButton _SaveButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextureViewer));
            System.Windows.Forms.ToolStripSeparator _ToolStripSeparator1;
            System.Windows.Forms.ToolStripButton _LoadFromFileButton;
            System.Windows.Forms.ToolStripSeparator _ToolStripSeparator2;
            System.Windows.Forms.Panel _PreviewPanel;
            this._SaveToFileButton = new System.Windows.Forms.ToolStripButton();
            this._ZoomButton = new System.Windows.Forms.ToolStripButton();
            this._ToggleAlphaButton = new System.Windows.Forms.ToolStripButton();
            this._PreviewPictureBox = new System.Windows.Forms.PictureBox();
            this._SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            _ToolStrip = new System.Windows.Forms.ToolStrip();
            _SaveButton = new System.Windows.Forms.ToolStripButton();
            _ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            _LoadFromFileButton = new System.Windows.Forms.ToolStripButton();
            _ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            _PreviewPanel = new System.Windows.Forms.Panel();
            _ToolStrip.SuspendLayout();
            _PreviewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PreviewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _ToolStrip
            // 
            _ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _SaveButton,
            _ToolStripSeparator1,
            _LoadFromFileButton,
            this._SaveToFileButton,
            _ToolStripSeparator2,
            this._ZoomButton,
            this._ToggleAlphaButton});
            _ToolStrip.Location = new System.Drawing.Point(0, 0);
            _ToolStrip.Name = "_ToolStrip";
            _ToolStrip.Size = new System.Drawing.Size(480, 25);
            _ToolStrip.TabIndex = 5;
            _ToolStrip.Text = "toolStrip1";
            // 
            // _SaveButton
            // 
            _SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("_SaveButton.Image")));
            _SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _SaveButton.Name = "_SaveButton";
            _SaveButton.Size = new System.Drawing.Size(51, 22);
            _SaveButton.Text = "Save";
            _SaveButton.Click += new System.EventHandler(this.OnSave);
            // 
            // _ToolStripSeparator1
            // 
            _ToolStripSeparator1.Name = "_ToolStripSeparator1";
            _ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _LoadFromFileButton
            // 
            _LoadFromFileButton.Image = ((System.Drawing.Image)(resources.GetObject("_LoadFromFileButton.Image")));
            _LoadFromFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _LoadFromFileButton.Name = "_LoadFromFileButton";
            _LoadFromFileButton.Size = new System.Drawing.Size(105, 22);
            _LoadFromFileButton.Text = "Load From File";
            _LoadFromFileButton.Click += new System.EventHandler(this.OnLoadFromFile);
            // 
            // _SaveToFileButton
            // 
            this._SaveToFileButton.Image = ((System.Drawing.Image)(resources.GetObject("_SaveToFileButton.Image")));
            this._SaveToFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._SaveToFileButton.Name = "_SaveToFileButton";
            this._SaveToFileButton.Size = new System.Drawing.Size(89, 22);
            this._SaveToFileButton.Text = "Save To File";
            this._SaveToFileButton.Click += new System.EventHandler(this.OnSaveToFile);
            // 
            // _ToolStripSeparator2
            // 
            _ToolStripSeparator2.Name = "_ToolStripSeparator2";
            _ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _ZoomButton
            // 
            this._ZoomButton.Checked = true;
            this._ZoomButton.CheckOnClick = true;
            this._ZoomButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this._ZoomButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ZoomButton.Image = ((System.Drawing.Image)(resources.GetObject("_ZoomButton.Image")));
            this._ZoomButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ZoomButton.Name = "_ZoomButton";
            this._ZoomButton.Size = new System.Drawing.Size(23, 22);
            this._ZoomButton.Text = "Toggle Zoom";
            this._ZoomButton.Click += new System.EventHandler(this.OnZoom);
            // 
            // _ToggleAlphaButton
            // 
            this._ToggleAlphaButton.Checked = true;
            this._ToggleAlphaButton.CheckOnClick = true;
            this._ToggleAlphaButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this._ToggleAlphaButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ToggleAlphaButton.Image = ((System.Drawing.Image)(resources.GetObject("_ToggleAlphaButton.Image")));
            this._ToggleAlphaButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ToggleAlphaButton.Name = "_ToggleAlphaButton";
            this._ToggleAlphaButton.Size = new System.Drawing.Size(23, 22);
            this._ToggleAlphaButton.Text = "Toggle Alpha";
            this._ToggleAlphaButton.CheckedChanged += new System.EventHandler(this.OnToggleAlpha);
            // 
            // _PreviewPanel
            // 
            _PreviewPanel.AutoScroll = true;
            _PreviewPanel.Controls.Add(this._PreviewPictureBox);
            _PreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            _PreviewPanel.Location = new System.Drawing.Point(0, 25);
            _PreviewPanel.Name = "_PreviewPanel";
            _PreviewPanel.Size = new System.Drawing.Size(480, 295);
            _PreviewPanel.TabIndex = 6;
            // 
            // _PreviewPictureBox
            // 
            this._PreviewPictureBox.Location = new System.Drawing.Point(0, 0);
            this._PreviewPictureBox.Name = "_PreviewPictureBox";
            this._PreviewPictureBox.Size = new System.Drawing.Size(64, 64);
            this._PreviewPictureBox.TabIndex = 0;
            this._PreviewPictureBox.TabStop = false;
            // 
            // _SaveFileDialog
            // 
            this._SaveFileDialog.DefaultExt = "dds";
            this._SaveFileDialog.Filter = "DDS Textures (*.dds)|*.lua|All Files (*.*)|*.*";
            // 
            // _OpenFileDialog
            // 
            this._OpenFileDialog.DefaultExt = "dds";
            this._OpenFileDialog.Filter = "DDS Textures (*.dds)|*.lua|All Files (*.*)|*.*";
            // 
            // TextureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 320);
            this.Controls.Add(_PreviewPanel);
            this.Controls.Add(_ToolStrip);
            this.Name = "TextureViewer";
            this.Text = "Texture";
            _ToolStrip.ResumeLayout(false);
            _ToolStrip.PerformLayout();
            _PreviewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._PreviewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton _SaveToFileButton;
        private System.Windows.Forms.PictureBox _PreviewPictureBox;
        private System.Windows.Forms.SaveFileDialog _SaveFileDialog;
        private System.Windows.Forms.OpenFileDialog _OpenFileDialog;
        private System.Windows.Forms.ToolStripButton _ZoomButton;
        private System.Windows.Forms.ToolStripButton _ToggleAlphaButton;
    }
}