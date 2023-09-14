using System;
using System.Reflection;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Iris.Common;

namespace Iris.Client
{
    public partial class IrisClient : Form
    {
        private BindingSource viewPorts;
        private BindingSource windows;
        private IrisConfig loadedCfg;
        private string configFile = "iris.xml";

        public IrisClient(string[] args)
        {
            if (args.Length > 0) configFile = args[0];
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            viewPorts = new BindingSource();
            windows = new BindingSource();
            viewPorts.DataSource = typeof(ViewPort);
            windows.DataSource = typeof(ViewPortForm);
            Icon icon = Common.Properties.Resources.iris;
            this.Icon = icon;

            loadedCfg = Helpers.LoadConfig(configFile);
            if(loadedCfg != null)
            {
                viewPorts.DataSource = (BindingList<ViewPort>)loadedCfg.ViewPorts;
            }
            else
            {
                this.Close();
            }

            foreach (ViewPort vp in viewPorts)
            {
                ViewPortForm vpWindow = new ViewPortForm(vp);
                vpWindow.Icon = icon;
                vpWindow.MinimumSize = new Size(16, 16);
                vpWindow.Size = new Size(vp.SizeX, vp.SizeY);
                vpWindow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                vpWindow.Text = vp.Name;
                vpWindow.Show();
                vpWindow.DesktopLocation = new Point(vp.ScreenPositionX, vp.ScreenPositionY);
                if (vp.Name == "Background")
                {
                    // This is the special case viewport used for the background to avoid us 
                    // having to set a desktop background and remove all of the icons
                    vpWindow.SendToBack();
                    vpWindow.BackColor = System.Drawing.Color.FromArgb(0x5b, 0x7e, 0x96);
                }
                windows.Add(vpWindow);
            }
            // Minimize the parent form.
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IrisConfig saveConfig = new IrisConfig();
            saveConfig.ViewPorts = (BindingList<ViewPort>)viewPorts.List;
            saveConfig.PollingInterval = loadedCfg.PollingInterval;
            saveConfig.GlobalImageAdjustment = loadedCfg.GlobalImageAdjustment;
            if (Helpers.SaveConfig(saveConfig, configFile))
            {
                MessageBox.Show($"{viewPorts.Count} viewports Saved in {configFile}");
            }
        }

        private void IrisClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (ViewPortForm vpf in windows)
            {
                vpf.StopListening();
            }
        }

    }
}
