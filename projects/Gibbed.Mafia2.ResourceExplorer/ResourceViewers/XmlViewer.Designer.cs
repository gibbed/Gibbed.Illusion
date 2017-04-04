namespace Gibbed.Mafia2.ResourceExplorer
{
    partial class XmlViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XmlViewer));
            System.Windows.Forms.ToolStripSeparator _ToolStripSeparator1;
            System.Windows.Forms.ToolStripButton _LoadFromFileButton;
            System.Windows.Forms.ToolStripButton _SaveToFileButton;
            this._ContentTextBox = new System.Windows.Forms.TextBox();
            this._SaveButton = new System.Windows.Forms.ToolStripButton();
            this._SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            _ToolStrip = new System.Windows.Forms.ToolStrip();
            _ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            _LoadFromFileButton = new System.Windows.Forms.ToolStripButton();
            _SaveToFileButton = new System.Windows.Forms.ToolStripButton();
            _ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ContentTextBox
            // 
            this._ContentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._ContentTextBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ContentTextBox.Location = new System.Drawing.Point(0, 25);
            this._ContentTextBox.MaxLength = 2147483647;
            this._ContentTextBox.Multiline = true;
            this._ContentTextBox.Name = "_ContentTextBox";
            this._ContentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._ContentTextBox.Size = new System.Drawing.Size(640, 295);
            this._ContentTextBox.TabIndex = 0;
            this._ContentTextBox.WordWrap = false;
            // 
            // _ToolStrip
            // 
            _ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._SaveButton,
            _ToolStripSeparator1,
            _LoadFromFileButton,
            _SaveToFileButton});
            _ToolStrip.Location = new System.Drawing.Point(0, 0);
            _ToolStrip.Name = "_ToolStrip";
            _ToolStrip.Size = new System.Drawing.Size(640, 25);
            _ToolStrip.TabIndex = 1;
            _ToolStrip.Text = "toolStrip1";
            // 
            // _SaveButton
            // 
            this._SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("_SaveButton.Image")));
            this._SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._SaveButton.Name = "_SaveButton";
            this._SaveButton.Size = new System.Drawing.Size(51, 22);
            this._SaveButton.Text = "Save";
            this._SaveButton.Click += new System.EventHandler(this.OnSave);
            // 
            // _ToolStripSeparator1
            // 
            _ToolStripSeparator1.Name = "_ToolStripSeparator1";
            _ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _LoadFromFileButton
            // 
            _LoadFromFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            _LoadFromFileButton.Image = ((System.Drawing.Image)(resources.GetObject("_LoadFromFileButton.Image")));
            _LoadFromFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _LoadFromFileButton.Name = "_LoadFromFileButton";
            _LoadFromFileButton.Size = new System.Drawing.Size(23, 22);
            _LoadFromFileButton.Text = "Load From File";
            _LoadFromFileButton.Click += new System.EventHandler(this.OnLoadFromFile);
            // 
            // _SaveToFileButton
            // 
            _SaveToFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            _SaveToFileButton.Image = ((System.Drawing.Image)(resources.GetObject("_SaveToFileButton.Image")));
            _SaveToFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            _SaveToFileButton.Name = "_SaveToFileButton";
            _SaveToFileButton.Size = new System.Drawing.Size(23, 22);
            _SaveToFileButton.Text = "Save To File";
            _SaveToFileButton.Click += new System.EventHandler(this.OnSaveToFile);
            // 
            // _SaveFileDialog
            // 
            this._SaveFileDialog.DefaultExt = "xml";
            this._SaveFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            // 
            // _OpenFileDialog
            // 
            this._OpenFileDialog.DefaultExt = "xml";
            this._OpenFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            // 
            // XmlViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 320);
            this.Controls.Add(this._ContentTextBox);
            this.Controls.Add(_ToolStrip);
            this.Name = "XmlViewer";
            this.Text = "XML";
            _ToolStrip.ResumeLayout(false);
            _ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _ContentTextBox;
        private System.Windows.Forms.SaveFileDialog _SaveFileDialog;
        private System.Windows.Forms.ToolStripButton _SaveButton;
        private System.Windows.Forms.OpenFileDialog _OpenFileDialog;
    }
}