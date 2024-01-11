namespace Iris.Server
{
    partial class IrisServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IrisServer));
            this.toolTipAdjustment = new System.Windows.Forms.ToolTip(this.components);
            this.numericUpDownBrightness = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownGamma = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownContrast = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.labelGamma = new System.Windows.Forms.Label();
            this.labelContrast = new System.Windows.Forms.Label();
            this.labelBrightness = new System.Windows.Forms.Label();
            this.labelAdjustmentTitle = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addViewportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownContrast)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTipAdjustment
            // 
            this.toolTipAdjustment.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipAdjustment.ToolTipTitle = "Adjustment";
            // 
            // numericUpDownBrightness
            // 
            this.numericUpDownBrightness.DecimalPlaces = 2;
            this.numericUpDownBrightness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownBrightness.Location = new System.Drawing.Point(126, 226);
            this.numericUpDownBrightness.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownBrightness.Name = "numericUpDownBrightness";
            this.numericUpDownBrightness.Size = new System.Drawing.Size(72, 22);
            this.numericUpDownBrightness.TabIndex = 2;
            this.numericUpDownBrightness.Tag = "Brightness";
            this.toolTipAdjustment.SetToolTip(this.numericUpDownBrightness, resources.GetString("numericUpDownBrightness.ToolTip"));
            this.numericUpDownBrightness.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDownBrightness.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // numericUpDownGamma
            // 
            this.numericUpDownGamma.DecimalPlaces = 2;
            this.numericUpDownGamma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownGamma.Location = new System.Drawing.Point(128, 306);
            this.numericUpDownGamma.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownGamma.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownGamma.Name = "numericUpDownGamma";
            this.numericUpDownGamma.Size = new System.Drawing.Size(72, 22);
            this.numericUpDownGamma.TabIndex = 4;
            this.numericUpDownGamma.Tag = "Gamma";
            this.toolTipAdjustment.SetToolTip(this.numericUpDownGamma, resources.GetString("numericUpDownGamma.ToolTip"));
            this.numericUpDownGamma.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDownGamma.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // numericUpDownContrast
            // 
            this.numericUpDownContrast.DecimalPlaces = 2;
            this.numericUpDownContrast.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownContrast.Location = new System.Drawing.Point(128, 266);
            this.numericUpDownContrast.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownContrast.Name = "numericUpDownContrast";
            this.numericUpDownContrast.Size = new System.Drawing.Size(72, 22);
            this.numericUpDownContrast.TabIndex = 3;
            this.numericUpDownContrast.Tag = "Contrast";
            this.toolTipAdjustment.SetToolTip(this.numericUpDownContrast, resources.GetString("numericUpDownContrast.ToolTip"));
            this.numericUpDownContrast.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDownContrast.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonOpen);
            this.tabPage1.Controls.Add(this.numericUpDownGamma);
            this.tabPage1.Controls.Add(this.numericUpDownContrast);
            this.tabPage1.Controls.Add(this.labelGamma);
            this.tabPage1.Controls.Add(this.labelContrast);
            this.tabPage1.Controls.Add(this.labelBrightness);
            this.tabPage1.Controls.Add(this.labelAdjustmentTitle);
            this.tabPage1.Controls.Add(this.buttonSave);
            this.tabPage1.Controls.Add(this.numericUpDownBrightness);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.trackBar1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(915, 750);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Config";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(36, 699);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonOpen.Size = new System.Drawing.Size(161, 28);
            this.buttonOpen.TabIndex = 5;
            this.buttonOpen.Text = "Open Config";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // labelGamma
            // 
            this.labelGamma.AutoSize = true;
            this.labelGamma.Location = new System.Drawing.Point(36, 306);
            this.labelGamma.Name = "labelGamma";
            this.labelGamma.Size = new System.Drawing.Size(55, 16);
            this.labelGamma.TabIndex = 10;
            this.labelGamma.Text = "Gamma";
            // 
            // labelContrast
            // 
            this.labelContrast.AutoSize = true;
            this.labelContrast.Location = new System.Drawing.Point(36, 266);
            this.labelContrast.Name = "labelContrast";
            this.labelContrast.Size = new System.Drawing.Size(56, 16);
            this.labelContrast.TabIndex = 9;
            this.labelContrast.Text = "Contrast";
            // 
            // labelBrightness
            // 
            this.labelBrightness.AutoSize = true;
            this.labelBrightness.Location = new System.Drawing.Point(36, 226);
            this.labelBrightness.Name = "labelBrightness";
            this.labelBrightness.Size = new System.Drawing.Size(70, 16);
            this.labelBrightness.TabIndex = 8;
            this.labelBrightness.Text = "Brightness";
            // 
            // labelAdjustmentTitle
            // 
            this.labelAdjustmentTitle.AutoSize = true;
            this.labelAdjustmentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdjustmentTitle.Location = new System.Drawing.Point(36, 182);
            this.labelAdjustmentTitle.Name = "labelAdjustmentTitle";
            this.labelAdjustmentTitle.Size = new System.Drawing.Size(180, 16);
            this.labelAdjustmentTitle.TabIndex = 7;
            this.labelAdjustmentTitle.Text = "Global Image Adjustment";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(220, 699);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonSave.Size = new System.Drawing.Size(161, 28);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save Config";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(49, 11);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 3;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(47, 57);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(139, 56);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickFrequency = 2;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 135);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Enable Capture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 30);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(923, 779);
            this.tabControl1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(923, 30);
            this.menuStrip1.TabIndex = 6;
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
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addViewportToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Visible = false;
            // 
            // addViewportToolStripMenuItem
            // 
            this.addViewportToolStripMenuItem.Name = "addViewportToolStripMenuItem";
            this.addViewportToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.addViewportToolStripMenuItem.Text = "Add Viewport";
            this.addViewportToolStripMenuItem.Click += new System.EventHandler(this.addViewportToolStripMenuItem_Click);
            // 
            // IrisServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 828);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IrisServer";
            this.Text = "Iris Screen Exporter - Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IrisServer_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownContrast)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.NumericUpDown numericUpDownBrightness;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelAdjustmentTitle;
        private System.Windows.Forms.Label labelBrightness;
        private System.Windows.Forms.Label labelGamma;
        private System.Windows.Forms.Label labelContrast;
        private System.Windows.Forms.NumericUpDown numericUpDownGamma;
        private System.Windows.Forms.NumericUpDown numericUpDownContrast;
        private System.Windows.Forms.ToolTip toolTipAdjustment;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addViewportToolStripMenuItem;
    }
}

