using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Iris.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Iris.Client
{

    public partial class ViewPortForm : Form
    {
        private ViewPort viewPort;
        private UdpClient client;
        private Thread thread;
        private IPEndPoint endPoint;
        private bool _allowMovement = false;
        private delegate void SetImageCallback(Image aPicture);
        public Boolean NetworkErrorAlreadyReported = false;

 
        public ViewPortForm(ViewPort aViewPort)
        {
            this.KeyPreview = true;
            viewPort = aViewPort;
            InitializeComponent();

        }
        
        public bool Listening { get; set; }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.DataBindings.Add("Image", viewPort, "Image");
            StartListening();
        }

        public void StartListening()
        {
            if (!Listening)
            {
                try {
                    client = new UdpClient(viewPort.Port);
                    endPoint = new IPEndPoint(IPAddress.Any, 0);
                }
                catch (SocketException se)
                {
                    if (NetworkErrorAlreadyReported) // if we have seen one, there are probably others so we won't give an error
                    {
                        SocketErrorCodes errorCode = (SocketErrorCodes)se.ErrorCode;
                        switch (errorCode)
                        {

                            case SocketErrorCodes.HostNotFound:
                                MessageBox.Show(se.Message + ".  The hostname \"" + endPoint.ToString() + "\" you were trying to connect to was not found.  Please review your IRIS config file.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1
        , MessageBoxOptions.ServiceNotification);
                                break;
                            default:
                                MessageBox.Show(se.Message + " - A network Error has occurred communicating with \"" + endPoint.ToString() + "\":" + se.SocketErrorCode, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1
        , MessageBoxOptions.ServiceNotification);
                                break;
                        }
                        NetworkErrorAlreadyReported = true;
                   }
                    StopListening();
                    this.Close();
                }
                thread = new Thread(Poll);
                Listening = true;
                thread.Start();
            }
            else throw (new InvalidOperationException(viewPort.Name + " Is already listening"));
        }

        public void StopListening()
        {
            Listening = false;
            client.Close();
        }

        private void Poll()
        {
            while (Listening)
            {
                try
                {
                    byte[] message = client.Receive(ref endPoint);
                    SetImage(message.ToImage());
                }
                catch (SocketException)
                {
                    Listening = false;
                }
            }
        }

        private void SetImage(Image aPicture)
        {
            if (this.pictureBox1.InvokeRequired)
            {
                SetImageCallback d = new SetImageCallback(SetImage);
                this.Invoke(d, new object[] { aPicture });
            }
            else
            {
                this.viewPort.Image = (Bitmap)aPicture;
            }
        }

        private void toggleBorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
            else this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        }

        private void setWindowPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewPort.ScreenPositionX = this.Location.X;
            viewPort.ScreenPositionY = this.Location.Y;
        }

        private void ViewPortForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Listening == true)
            {
                StopListening();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.viewPort.Name == "Background")
            {
                // We want to keep the background in the background ;-)
                this.SendToBack();
            }

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_allowMovement)
            {
                switch (keyData)
                {
                    case Keys.Up:
                    case (Keys.Control | Keys.W):
                        this.Top -= this.Top > 0 ? 1 : 0;
                        return true;
                        break;
                    case Keys.Down:
                    case (Keys.Control | Keys.S):
                        this.Top++;
                        return true;
                        break;
                    case Keys.Left:
                    case (Keys.Control | Keys.A):
                        this.Left -= this.Left > 0 ? 1 : 0;
                        return true;
                        break;
                    case Keys.Right:
                    case (Keys.Control | Keys.D):
                        this.Left++;
                        return true;
                        break;
                    default:
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem textBox)
            {
                if (_allowMovement)
                {
                    switch (textBox.Tag)
                    {
                        case "UP":
                            this.Top -= this.Top > 0 ? 1 : 0;
                            break;
                        case "DOWN":
                            this.Top++;
                            break;
                        case "LEFT":
                            this.Left -= this.Left > 0 ? 1 : 0;
                            break;
                        case "RIGHT":
                            this.Left++;
                            break;
                        default:
                            break;
                    }
                }
                if(textBox.Tag.Equals("Move"))
                {
                    _allowMovement = !_allowMovement;
                    foreach(object o in textBox.Owner.Items)
                    {
                        if(o is ToolStripMenuItem menuItem) 
                        {
                            switch (menuItem.Tag)
                            {
                                case "Move":
                                    menuItem.Checked = !menuItem.Checked;
                                    break;
                                case "":
                                case null:
                                    break;
                                default:
                                    menuItem.Enabled = _allowMovement;
                                    break;
                            }
                            continue;
                        }
                    }
                }
            }
            return;
        }
    }
}
