using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using common;

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
                textBox1.Text = trackBar1.Value.ToString();
                generateViewPorts();
            }
            else
            {
                MessageBox.Show(configFile+" not found! Please create a config File", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1
                    , MessageBoxOptions.ServiceNotification);
                this.Close();
            }


        }

        private void generateViewPorts()
        {
            foreach (ViewPort vp in viewPorts)
            {
                if (vp.Name != "Background")
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
            // Make sure that we start up and send data as the default
            timer1.Enabled = false;
            toggleTimer();
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 1000 / trackBar1.Value;
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (ViewPort vp in viewPorts)
            {
                if (vp.Name != "Background")
                {
                    Byte[] imageByteArray;
                    vp.capture();
                    imageByteArray = vp.Image.ToByteArray(System.Drawing.Imaging.ImageFormat.Jpeg);
                    conn.Send(imageByteArray, imageByteArray.Length, vp.Host, vp.Port);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            toggleTimer();
        }

        private void toggleTimer()
        {
            if (timer1.Enabled)
            {
                disableTimer();
            }
            else
            {
                enableTimer();
            }
            return;
        }

        private void disableTimer()
        {
            timer1.Enabled = false;
            button1.Text = "Enable Capture";
            //toolStripStatusPolling.Text = "Polling:Off";
        }

        private void enableTimer()
        {
            timer1.Enabled = true;
            button1.Text = "Disable Capture";
            //toolStripStatusPolling.Text = "Polling:On";
        }

        private void LoadConfig(string fileName)
        {
            IrisConfig loader = Helpers.LoadConfig(fileName);
            timer1.Interval = loader.PollingInterval;
            viewPorts.DataSource = (BindingList<ViewPort>)loader.ViewPorts;

        }

        private void SaveConfig(string fileName)
        {
            IrisConfig saver = new IrisConfig();
            saver.PollingInterval = timer1.Interval;
            saver.ViewPorts = (BindingList<ViewPort>)viewPorts.List;
            MessageBox.Show("Items Saved");
        }

        private void IrisServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            disableTimer();
        }

        private void toolStripStatusPolling_DoubleClick(object sender, EventArgs e)
        {
            toggleTimer();
        }

       
    }
}
