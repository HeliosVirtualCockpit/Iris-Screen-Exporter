using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using common;
using System.Reflection;

namespace server
{
    public partial class IrisServer : Form
    {
        private BindingSource viewPorts;
        private UdpClient conn;
        private string configFile = "iris.xml";

        public IrisServer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            viewPorts = new BindingSource();
            conn = new UdpClient();
            viewPorts.DataSource = typeof(ViewPort);
            if (File.Exists(configFile))
            {
                LoadConfig(configFile);
                //generateTestData();
                generateViewPorts();
            }
            else
            {
                MessageBox.Show(configFile + " not found! Please create a config File", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1
                    , MessageBoxOptions.ServiceNotification);
                this.Close();
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            captureViewPorts();
        }

        private void startCapturingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableCapturing(true);
        }

        private void stopCapturingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableCapturing(false);
        }

        private void captureOnceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            captureViewPorts();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            System.Diagnostics.FileVersionInfo fileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            MessageBox.Show("Iris Version:\n" + fileVersion.ProductVersion, "About Iris");
        }

        private void IrisServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            enableCapturing(false);
        }

        private void generateViewPorts()
        {
            foreach (ViewPort vp in viewPorts)
            {
                // create a new tab page and add it to the tabcontroller
                vp.capture();
                PictureBox pBox = new PictureBox();
                pBox.MaximumSize = new Size(600, 600);
                pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                pBox.DataBindings.Add("Image", vp, "Image");
                TabPage tPage = new TabPage(vp.Name);
                tPage.Controls.Add(pBox);
                tabControl1.TabPages.Add(tPage);
            }
        }
       
        private void captureViewPorts()
        {
            foreach (ViewPort vp in viewPorts)
            {
                Byte[] imageByteArray;
                vp.capture();
                imageByteArray = vp.Image.ToByteArray(System.Drawing.Imaging.ImageFormat.Jpeg);
                conn.Send(imageByteArray, imageByteArray.Length, vp.Host, vp.Port);
            }
        }

        private void LoadConfig(string fileName)
        {
            IrisConfig loader = Helpers.LoadConfig(fileName);
            timer1.Interval = loader.PollingInterval;
            viewPorts.DataSource = (BindingList<ViewPort>)loader.ViewPorts;

        }

        //private void SaveConfig(string fileName)
        //{
        //    IrisConfig saver = new IrisConfig();
        //    saver.PollingInterval = timer1.Interval;
        //    saver.ViewPorts = (BindingList<ViewPort>)viewPorts.List;
        //    MessageBox.Show("Items Saved");
        //}

        private void enableCapturing(bool enabled)
        {
            captureOnceToolStripMenuItem.Enabled = !enabled;
            startCapturingToolStripMenuItem.Enabled = !enabled;
            stopCapturingToolStripMenuItem.Enabled = enabled;
            timer1.Enabled = enabled;
            if (enabled) this.Text = "Iris - Server (CAPTURING)";
            else this.Text = "Iris - Server";
           
        }

        private void generateTestData()
        {
            ViewPort testView, testView1;
            testView = new ViewPort();
            testView.Name = "My Test View";
            testView.ScreenCaptureX = 1;
            testView.ScreenCaptureY = 1;
            testView.SizeX = 300;
            testView.SizeY = 300;
            testView.Host = "localhost";
            testView.Port = 12001;
            testView1 = new ViewPort();
            testView1.Name = "TestView1";
            testView1.ScreenCaptureX = 301;
            testView1.ScreenCaptureY = 1;
            testView1.SizeX = 300;
            testView1.SizeY = 300;
            testView1.Host = "localhost";
            testView1.Port = 12002;
            viewPorts.Add(testView);
            viewPorts.Add(testView1);
        }

    }
}
