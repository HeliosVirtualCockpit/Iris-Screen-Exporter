using System;
using System.Reflection;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Iris.Common;
using System.Collections.Generic;

namespace Iris.Client
{
    public partial class IrisClient : Form
    {
        private BindingSource viewPorts;
        private BindingSource windows;
        private IrisConfig loadedCfg;
        private string configFile = "iris.xml";
        private static readonly string heliosPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Helios");
        private static readonly string irisPath = Path.Combine(heliosPath, "IRIS");
        private string _defaultFormTitle = "IRIS Screen Exporter - Client";

        public IrisClient(string[] args)
        {
            if (!Directory.Exists(heliosPath)) { Directory.CreateDirectory(heliosPath); }
            if (!Directory.Exists(irisPath)) { Directory.CreateDirectory(irisPath); }
            if (!File.Exists(Path.Combine(irisPath, configFile)))
            {
                File.Copy("iris.xml", Path.Combine(irisPath, configFile), false);
            }
            configFile = Path.Combine(irisPath, configFile);

            if (args.Length > 0 && args[0] != null) configFile = args[0];
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            viewPorts = new BindingSource();
            windows = new BindingSource();
            viewPorts.DataSource = typeof(ViewPort);
            windows.DataSource = typeof(ViewPortForm);
            this.Icon = Common.Properties.Resources.iris;

            ProcessLoadedConfig(Helpers.LoadConfig(configFile));
            // Minimize the parent form.
            this.WindowState = FormWindowState.Minimized;
        }
        private void ProcessLoadedConfig(IrisConfig loadedCfg)
        {
            if (loadedCfg != null)
            {
                this.Text = $"{_defaultFormTitle} - {Path.GetFileNameWithoutExtension(configFile)}";

                viewPorts.DataSource = (BindingList<ViewPort>)loadedCfg.ViewPorts;
            }
            else
            {
                this.Close();
            }
            AddViewports(viewPorts);
        }
        private void AddViewports( BindingSource viewPorts)
        {
            foreach (ViewPort vp in viewPorts)
            {
                ViewPortForm vpWindow = new ViewPortForm(vp);
                vpWindow.Icon = Common.Properties.Resources.iris;
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
        }
        private void IrisClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (ViewPortForm vpf in windows)
            {
                vpf.StopListening();
            }
        }
        private void OpenConfig()
        {
            List<ViewPortForm> vpRemoval = new List<ViewPortForm>();
            foreach (ViewPortForm vpf in windows)
            {
                vpf.StopListening();
                vpRemoval.Add(vpf);
            }
            foreach(ViewPortForm vpf in vpRemoval)
            {
                vpf.Dispose();
                windows.Remove(vpf);
            }
            vpRemoval.Clear();  
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Iris XML files (*.xml)|*.xml|Iris files (*.iris)|*.iris",
                InitialDirectory = irisPath
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                configFile = openFileDialog.FileName;
            }
            ProcessLoadedConfig(Helpers.LoadConfig(configFile));
        }
        private void SaveConfig()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Iris XML files (*.xml)|*.xml|Iris files (*.iris)|*.iris",
                InitialDirectory = irisPath,
                FileName = configFile
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                configFile = saveFileDialog.FileName;
                IrisConfig saveConfig = new IrisConfig();
                saveConfig.ViewPorts = (BindingList<ViewPort>)viewPorts.List;
                saveConfig.PollingInterval = loadedCfg.PollingInterval;
                saveConfig.GlobalImageAdjustment = loadedCfg.GlobalImageAdjustment;
                if (Helpers.SaveConfig(saveConfig, configFile))
                {
                    MessageBox.Show($"{viewPorts.Count} viewports Saved in {configFile}");
                    this.Text = $"{_defaultFormTitle} - {Path.GetFileNameWithoutExtension(configFile)}";
                }
                else
                {
                    MessageBox.Show($"Zero viewports Saved to File: {configFile}");
                }
            }
            else
            {
                MessageBox.Show($"Zero viewports Saved to File: {configFile}");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenConfig();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenConfig();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

    }
}
