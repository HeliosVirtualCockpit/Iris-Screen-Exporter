using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using common;

namespace client
{

    public partial class ViewPortForm : Form
    {
        private ViewPort viewPort;
        private UdpClient client;
        private Thread thread;
        private IPEndPoint endPoint;
        private delegate void SetImageCallback(Image aPicture);

        public ViewPortForm(ViewPort aViewPort)
        {
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
                client = new UdpClient(viewPort.Port);
                endPoint = new IPEndPoint(IPAddress.Any, 0);
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
    }
}
