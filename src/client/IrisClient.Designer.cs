namespace Iris.Client
{
    partial class IrisClient
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.butColor = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.labelLeft = new System.Windows.Forms.Label();
            this.tBLeft = new System.Windows.Forms.TextBox();
            this.tBTop = new System.Windows.Forms.TextBox();
            this.labelTop = new System.Windows.Forms.Label();
            this.tBHeight = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.tBWidth = new System.Windows.Forms.TextBox();
            this.labelWidth = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 190);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save Config";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 190);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Load Config";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(562, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // butColor
            // 
            this.butColor.BackColor = System.Drawing.Color.Black;
            this.butColor.Location = new System.Drawing.Point(309, 72);
            this.butColor.MaximumSize = new System.Drawing.Size(48, 48);
            this.butColor.MinimumSize = new System.Drawing.Size(48, 48);
            this.butColor.Name = "butColor";
            this.butColor.Size = new System.Drawing.Size(48, 48);
            this.butColor.TabIndex = 3;
            this.butColor.Tag = "SelectColor";
            this.butColor.UseVisualStyleBackColor = false;
            this.butColor.Visible = false;
            this.butColor.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(26, 44);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 20);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Background";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // labelLeft
            // 
            this.labelLeft.AutoSize = true;
            this.labelLeft.Location = new System.Drawing.Point(26, 71);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(28, 16);
            this.labelLeft.TabIndex = 5;
            this.labelLeft.Tag = "labelLeft";
            this.labelLeft.Text = "Left";
            this.labelLeft.Visible = false;
            // 
            // tBLeft
            // 
            this.tBLeft.Location = new System.Drawing.Point(81, 68);
            this.tBLeft.Name = "tBLeft";
            this.tBLeft.Size = new System.Drawing.Size(68, 22);
            this.tBLeft.TabIndex = 6;
            this.tBLeft.Tag = "tBLeft";
            this.tBLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBLeft.Visible = false;
            this.tBLeft.WordWrap = false;
            this.tBLeft.TextChanged += new System.EventHandler(this.tBLeft_TextChanged);
            // 
            // tBTop
            // 
            this.tBTop.Location = new System.Drawing.Point(207, 69);
            this.tBTop.Name = "tBTop";
            this.tBTop.Size = new System.Drawing.Size(68, 22);
            this.tBTop.TabIndex = 8;
            this.tBTop.Tag = "tBTop";
            this.tBTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBTop.Visible = false;
            this.tBTop.WordWrap = false;
            this.tBTop.TextChanged += new System.EventHandler(this.tBTop_TextChanged);
            // 
            // labelTop
            // 
            this.labelTop.AutoSize = true;
            this.labelTop.Location = new System.Drawing.Point(155, 72);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(32, 16);
            this.labelTop.TabIndex = 7;
            this.labelTop.Tag = "labelTop";
            this.labelTop.Text = "Top";
            this.labelTop.Visible = false;
            // 
            // tBHeight
            // 
            this.tBHeight.Location = new System.Drawing.Point(207, 97);
            this.tBHeight.Name = "tBHeight";
            this.tBHeight.Size = new System.Drawing.Size(68, 22);
            this.tBHeight.TabIndex = 12;
            this.tBHeight.Tag = "tBHeight";
            this.tBHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBHeight.Visible = false;
            this.tBHeight.WordWrap = false;
            this.tBHeight.TextChanged += new System.EventHandler(this.tBHeight_TextChanged);
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(155, 100);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(46, 16);
            this.labelHeight.TabIndex = 11;
            this.labelHeight.Tag = "labelHeight";
            this.labelHeight.Text = "Height";
            this.labelHeight.Visible = false;
            // 
            // tBWidth
            // 
            this.tBWidth.Location = new System.Drawing.Point(81, 96);
            this.tBWidth.Name = "tBWidth";
            this.tBWidth.Size = new System.Drawing.Size(68, 22);
            this.tBWidth.TabIndex = 10;
            this.tBWidth.Tag = "tBWidth";
            this.tBWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tBWidth.Visible = false;
            this.tBWidth.WordWrap = false;
            this.tBWidth.TextChanged += new System.EventHandler(this.tBWidth_TextChanged);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(26, 99);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(41, 16);
            this.labelWidth.TabIndex = 9;
            this.labelWidth.Tag = "labelWidth";
            this.labelWidth.Text = "Width";
            this.labelWidth.Visible = false;
            // 
            // IrisClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 233);
            this.Controls.Add(this.tBHeight);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.tBWidth);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.tBTop);
            this.Controls.Add(this.labelTop);
            this.Controls.Add(this.tBLeft);
            this.Controls.Add(this.labelLeft);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.butColor);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IrisClient";
            this.Tag = "s";
            this.Text = "Iris Screen Exporter - Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IrisClient_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button butColor;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.TextBox tBLeft;
        private System.Windows.Forms.TextBox tBTop;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.TextBox tBHeight;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.TextBox tBWidth;
        private System.Windows.Forms.Label labelWidth;
    }
}

