using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using Iris.Common;

namespace Iris.Server
{
    public partial class IrisServer : Form
    {
        private BindingSource viewPorts;
        private UdpClient conn;
        private string configFile = "iris.xml";
        private ImageAdjustment _imageAdjustmentGlobal;
        public Boolean NetworkErrorAlreadyReported = false;
        private Icon icon;

        public IrisServer(string[] args)
        {
            if(args.Length > 0) configFile = args[0];
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            icon = Common.Properties.Resources.iris;
            this.Icon = icon;
            viewPorts = new BindingSource();
            conn = new UdpClient();
            viewPorts.DataSource = typeof(ViewPort);

            if (File.Exists(configFile))
            {
                LoadConfig(configFile);

                textBox1.Text = trackBar1.Value.ToString();
                generateViewPorts();
            }
            else
            {
#if DEBUG
                generateTestData();
                textBox1.Text = trackBar1.Value.ToString();
                generateViewPorts();
#else 
                MessageBox.Show(configFile+" not found! Please create a config File", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1
                    , MessageBoxOptions.ServiceNotification);
                this.Close();
#endif
            }


        }

        private void generateViewPorts()
        {
            foreach (ViewPort vp in viewPorts)
            {
                if (vp.Name != "Background")
                {
                    // create a new tab page and add it to the tabcontroller
                    vp.Capture();
                    PictureBox pBox = new PictureBox()
                    {
                        MaximumSize = new Size(600, 600),
                        SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize,
                    };
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
            testView1.ImageAdjustment = new ImageAdjustment()
            {
                Brightness = 1.5f,
                Gamma = 1.0f,
                Contrast = 1.0f
            };
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
                    vp.Capture(_imageAdjustmentGlobal);
                    imageByteArray = vp.Image.ToByteArray(System.Drawing.Imaging.ImageFormat.Jpeg);
                    try
                    {
                        conn.Send(imageByteArray, imageByteArray.Length, vp.Host, vp.Port);
                    }
                    catch (SocketException se)
                    {
                        if (!NetworkErrorAlreadyReported)  // if there is one, there are likely to be more so only report the first
                        {
                            SocketErrorCodes errorCode = (SocketErrorCodes)se.ErrorCode;
                            switch (errorCode)
                            {
                                case SocketErrorCodes.HostNotFound:
                                    MessageBox.Show($"{se.Message}.  The hostname \"{vp.Host}\" you were trying to connect to was not found.  Please review your IRIS config file.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1
            , MessageBoxOptions.ServiceNotification);
                                    break;
                                case SocketErrorCodes.MessgeTooLong:
                                    MessageBox.Show($"Send to hostname \"{vp.Host}\" for item \"{vp.Name}\" was too large at {imageByteArray.Length} bytes.  {se.Message}.  Please review your IRIS config file.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1
            , MessageBoxOptions.ServiceNotification);
                                    break;
                                default:
                                    MessageBox.Show($"{se.Message} - A network Error has occurred when communicatiing with \"{vp.Host}\":{se.SocketErrorCode}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1
            , MessageBoxOptions.ServiceNotification);
                                    break;
                            }
                        }
                        NetworkErrorAlreadyReported = true;
                        disableTimer();
                        this.Close();
                    }
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
            fileName = fileName.Equals("") ? "TestData.xml" : fileName;
            IrisConfig saver = new IrisConfig();
            saver.PollingInterval = timer1.Interval;
            saver.ViewPorts = (BindingList<ViewPort>)viewPorts.List;
            saver.GlobalImageAdjustment = _imageAdjustmentGlobal;

            Helpers.SaveConfig(saver, fileName);
            MessageBox.Show($"{viewPorts.Count} viewports Saved in {fileName}");
        }

        private void IrisServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            disableTimer();
        }

        private void toolStripStatusPolling_DoubleClick(object sender, EventArgs e)
        {
            toggleTimer();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveConfig(configFile);
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown control = (NumericUpDown)sender;
            float value = (float)Convert.ToDouble(control.Value);
            _imageAdjustmentGlobal = _imageAdjustmentGlobal ?? new ImageAdjustment();
            switch (control.Tag)
            {
                case "Brightness":
                    _imageAdjustmentGlobal.Brightness = value;
                    break;
                case "Contrast":
                    _imageAdjustmentGlobal.Contrast = value;
                    break;
                case "Gamma":
                    _imageAdjustmentGlobal.Gamma = value;
                    break;
                default: break;
            }
            _imageAdjustmentGlobal = IsReset(_imageAdjustmentGlobal);
        }
        private ImageAdjustment IsReset(ImageAdjustment iA)
        {
            return (iA.Brightness != 1.0f || iA.Contrast != 1.0f || iA.Gamma != 1.0f)? iA : null;
        }
    }
}
