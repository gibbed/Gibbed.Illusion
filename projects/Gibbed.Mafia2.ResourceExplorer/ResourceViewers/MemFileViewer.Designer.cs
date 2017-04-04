namespace Gibbed.Mafia2.ResourceExplorer
{
    partial class MemFileViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemFileViewer));
            System.Windows.Forms.ToolStripSeparator _ToolStripSeparator1;
            System.Windows.Forms.ToolStripButton _LoadFromFileButton;
            System.Windows.Forms.ToolStripButton _SaveToFileButton;
            this._HexBox = new Be.Windows.Forms.HexBox();
            this._SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            _ToolStrip = new System.Windows.Forms.ToolStrip();
            _SaveButton = new System.Windows.Forms.ToolStripButton();
            _ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            _LoadFromFileButton = new System.Windows.Forms.ToolStripButton();
            _SaveToFileButton = new System.Windows.Forms.ToolStripButton();
            _ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _HexBox
            // 
            this._HexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._HexBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._HexBox.InfoForeColor = System.Drawing.Color.Empty;
            this._HexBox.LineInfoVisible = true;
            this._HexBox.Location = new System.Drawing.Point(0, 25);
            this._HexBox.Name = "_HexBox";
            this._HexBox.ReadOnly = true;
            this._HexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this._HexBox.Size = new System.Drawing.Size(640, 215);
            this._HexBox.StringViewVisible = true;
            this._HexBox.TabIndex = 0;
            this._HexBox.UseFixedBytesPerLine = true;
            this._HexBox.VScrollBarVisible = true;
            // 
            // _SaveFileDialog
            // 
            this._SaveFileDialog.Filter = "All Files (*.*)|*.*";
            // 
            // _ToolStrip
            // 
            _ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            _SaveButton,
            _ToolStripSeparator1,
            _LoadFromFileButton,
            _SaveToFileButton});
            _ToolStrip.Location = new System.Drawing.Point(0, 0);
            _ToolStrip.Name = "_ToolStrip";
            _ToolStrip.Size = new System.Drawing.Size(640, 25);
            _ToolStrip.TabIndex = 4;
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
            _SaveToFileButton.Image = ((System.Drawing.Image)(resources.GetObject("_SaveToFileButton.Image")));
            _SaveToFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _SaveToFileButton.Name = "_SaveToFileButton";
            _SaveToFileButton.Size = new System.Drawing.Size(89, 22);
            _SaveToFileButton.Text = "Save To File";
            _SaveToFileButton.Click += new System.EventHandler(this.OnSaveToFile);
            // 
            // _OpenFileDialog
            // 
            this._OpenFileDialog.Filter = "All Files (*.*)|*.*";
            // 
            // MemFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 240);
            this.Controls.Add(this._HexBox);
            this.Controls.Add(_ToolStrip);
            this.Name = "MemFileViewer";
            this.Text = "MemFile";
            _ToolStrip.ResumeLayout(false);
            _ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Be.Windows.Forms.HexBox _HexBox;
        private System.Windows.Forms.SaveFileDialog _SaveFileDialog;
        private System.Windows.Forms.OpenFileDialog _OpenFileDialog;

    }
}