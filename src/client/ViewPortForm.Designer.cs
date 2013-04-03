namespace client
{
    partial class ViewPortForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toggleBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setWindowPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveWindowUPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveWindowDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveWindowRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveWindowLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.toggleBorderToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleBorderToolStripMenuItem,
            this.setWindowPositionToolStripMenuItem,
            this.moveWindowUPToolStripMenuItem,
            this.moveWindowDownToolStripMenuItem,
            this.moveWindowRightToolStripMenuItem,
            this.moveWindowLeftToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(221, 158);
            // 
            // toggleBorderToolStripMenuItem
            // 
            this.toggleBorderToolStripMenuItem.Name = "toggleBorderToolStripMenuItem";
            this.toggleBorderToolStripMenuItem.ShortcutKeyDisplayString = " Double Click";
            this.toggleBorderToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.toggleBorderToolStripMenuItem.Text = "Toggle Border";
            this.toggleBorderToolStripMenuItem.Click += new System.EventHandler(this.toggleBorderToolStripMenuItem_Click);
            // 
            // setWindowPositionToolStripMenuItem
            // 
            this.setWindowPositionToolStripMenuItem.Name = "setWindowPositionToolStripMenuItem";
            this.setWindowPositionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.setWindowPositionToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.setWindowPositionToolStripMenuItem.Text = "Set Window Position";
            this.setWindowPositionToolStripMenuItem.Click += new System.EventHandler(this.setWindowPositionToolStripMenuItem_Click);
            // 
            // moveWindowUPToolStripMenuItem
            // 
            this.moveWindowUPToolStripMenuItem.Name = "moveWindowUPToolStripMenuItem";
            this.moveWindowUPToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.moveWindowUPToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.moveWindowUPToolStripMenuItem.Text = "Move Window UP";
            this.moveWindowUPToolStripMenuItem.Click += new System.EventHandler(this.moveWindowUPToolStripMenuItem_Click);
            // 
            // moveWindowDownToolStripMenuItem
            // 
            this.moveWindowDownToolStripMenuItem.Name = "moveWindowDownToolStripMenuItem";
            this.moveWindowDownToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.moveWindowDownToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.moveWindowDownToolStripMenuItem.Text = "Move Window Down";
            this.moveWindowDownToolStripMenuItem.Click += new System.EventHandler(this.moveWindowDownToolStripMenuItem_Click);
            // 
            // moveWindowRightToolStripMenuItem
            // 
            this.moveWindowRightToolStripMenuItem.Name = "moveWindowRightToolStripMenuItem";
            this.moveWindowRightToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.moveWindowRightToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.moveWindowRightToolStripMenuItem.Text = "Move Window Right";
            this.moveWindowRightToolStripMenuItem.Click += new System.EventHandler(this.moveWindowRightToolStripMenuItem_Click);
            // 
            // moveWindowLeftToolStripMenuItem
            // 
            this.moveWindowLeftToolStripMenuItem.Name = "moveWindowLeftToolStripMenuItem";
            this.moveWindowLeftToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.moveWindowLeftToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.moveWindowLeftToolStripMenuItem.Text = "Move Window Left";
            this.moveWindowLeftToolStripMenuItem.Click += new System.EventHandler(this.moveWindowLeftToolStripMenuItem_Click);
            // 
            // ViewPortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ViewPortForm";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewPortForm_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toggleBorderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setWindowPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveWindowUPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveWindowDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveWindowRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveWindowLeftToolStripMenuItem;
    }
}