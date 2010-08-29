namespace Gibbed.Illusion.ExploreSDS
{
    partial class ScriptViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptViewer));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.hexBox = new Be.Windows.Forms.HexBox();
            this.scriptToolStrip = new System.Windows.Forms.ToolStrip();
            this.loadFromFileButton = new System.Windows.Forms.ToolStripButton();
            this.saveToFileButton = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainToolStrip.SuspendLayout();
            this.scriptToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(640, 25);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton1.Text = "Save";
            this.toolStripButton1.Click += new System.EventHandler(this.OnSave);
            // 
            // comboBox
            // 
            this.comboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(0, 25);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(640, 21);
            this.comboBox.TabIndex = 1;
            this.comboBox.SelectedValueChanged += new System.EventHandler(this.OnSelectScript);
            // 
            // hexBox
            // 
            this.hexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexBox.LineInfoForeColor = System.Drawing.Color.Empty;
            this.hexBox.Location = new System.Drawing.Point(0, 71);
            this.hexBox.Name = "hexBox";
            this.hexBox.ReadOnly = true;
            this.hexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox.Size = new System.Drawing.Size(640, 169);
            this.hexBox.StringViewVisible = true;
            this.hexBox.TabIndex = 2;
            this.hexBox.UseFixedBytesPerLine = true;
            this.hexBox.VScrollBarVisible = true;
            // 
            // scriptToolStrip
            // 
            this.scriptToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromFileButton,
            this.saveToFileButton});
            this.scriptToolStrip.Location = new System.Drawing.Point(0, 46);
            this.scriptToolStrip.Name = "scriptToolStrip";
            this.scriptToolStrip.Size = new System.Drawing.Size(640, 25);
            this.scriptToolStrip.TabIndex = 3;
            this.scriptToolStrip.Text = "toolStrip2";
            // 
            // loadFromFileButton
            // 
            this.loadFromFileButton.Image = ((System.Drawing.Image)(resources.GetObject("loadFromFileButton.Image")));
            this.loadFromFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadFromFileButton.Name = "loadFromFileButton";
            this.loadFromFileButton.Size = new System.Drawing.Size(105, 22);
            this.loadFromFileButton.Text = "Load From File";
            this.loadFromFileButton.Click += new System.EventHandler(this.OnLoadFromFile);
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToFileButton.Image")));
            this.saveToFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(89, 22);
            this.saveToFileButton.Text = "Save To File";
            this.saveToFileButton.Click += new System.EventHandler(this.OnSaveToFile);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "lua";
            this.saveFileDialog.Filter = "Lua Scripts (*.lua)|*.lua|All Files (*.*)|*.*";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "lua";
            this.openFileDialog.Filter = "Lua Scripts (*.lua)|*.lua|All Files (*.*)|*.*";
            // 
            // ScriptViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 240);
            this.Controls.Add(this.hexBox);
            this.Controls.Add(this.scriptToolStrip);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.mainToolStrip);
            this.Name = "ScriptViewer";
            this.Text = "Script";
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.scriptToolStrip.ResumeLayout(false);
            this.scriptToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ComboBox comboBox;
        private Be.Windows.Forms.HexBox hexBox;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip scriptToolStrip;
        private System.Windows.Forms.ToolStripButton loadFromFileButton;
        private System.Windows.Forms.ToolStripButton saveToFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}