using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Iris.Common;

namespace Iris.Client
{

    public partial class ViewPortForm : Form
    {
        private ViewPort viewPort;
        private UdpClient client;
        private Thread thread;
        private IPEndPoint endPoint;
        private delegate void SetImageCallback(Image aPicture);
        public Boolean NetworkErrorAlreadyReported = false;

        public enum SocketErrorCodes
        {
            InterruptedFunctionCall = 10004,
            PermissionDenied = 10013,
            BadAddress = 10014,
            InvalidArgument = 10022,
            TooManyOpenFiles = 10024,
            ResourceTemporarilyUnavailable = 10035,
            OperationNowInProgress = 10036,
            OperationAlreadyInProgress = 10037,
            SocketOperationOnNonSocket = 10038,
            DestinationAddressRequired = 10039,
            MessgeTooLong = 10040,
            WrongProtocolType = 10041,
            BadProtocolOption = 10042,
            ProtocolNotSupported = 10043,
            SocketTypeNotSupported = 10044,
            OperationNotSupported = 10045,
            ProtocolFamilyNotSupported = 10046,
            AddressFamilyNotSupported = 10047,
            AddressInUse = 10048,
            AddressNotAvailable = 10049,
            NetworkIsDown = 10050,
            NetworkIsUnreachable = 10051,
            NetworkReset = 10052,
            ConnectionAborted = 10053,
            ConnectionResetByPeer = 10054,
            NoBufferSpaceAvailable = 10055,
            AlreadyConnected = 10056,
            NotConnected = 10057,
            CannotSendAfterShutdown = 10058,
            ConnectionTimedOut = 10060,
            ConnectionRefused = 10061,
            HostIsDown = 10064,
            HostUnreachable = 10065,
            TooManyProcesses = 10067,
            NetworkSubsystemIsUnavailable = 10091,
            UnsupportedVersion = 10092,
            NotInitialized = 10093,
            ShutdownInProgress = 10101,
            ClassTypeNotFound = 10109,
            HostNotFound = 11001,
            HostNotFoundTryAgain = 11002,
            NonRecoverableError = 11003,
            NoDataOfRequestedType = 11004
        }



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
    }
}
