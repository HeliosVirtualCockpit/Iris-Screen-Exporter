using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media;
using Iris.Common;
using System.Collections.Generic;
using System.Reflection;

namespace Iris.Client
{
    public partial class IrisClient : Form
    {
        private BindingSource _backgroundSource;
        private Form _backgroundForm;
        private Background _background;
        private BindingSource _viewPorts;
        private BindingSource _windows;
        private IrisConfig _loadedCfg;
        private string _configFile = "iris.xml";
        private static readonly string heliosPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Helios");
        private static readonly string irisPath = Path.Combine(heliosPath, "IRIS");
        private string _defaultFormTitle = "IRIS Screen Exporter - Client";

        public IrisClient(string[] args)
        {
            if (!Directory.Exists(heliosPath)) { Directory.CreateDirectory(heliosPath); }
            if (!Directory.Exists(irisPath)) { Directory.CreateDirectory(irisPath); }
            if (!File.Exists(Path.Combine(irisPath, _configFile)))
            {
                File.Copy("iris.xml", Path.Combine(irisPath, _configFile), false);
            }
            _configFile = Path.Combine(irisPath, _configFile);

            if (args.Length > 0 && args[0] != null) _configFile = args[0];
            InitializeComponent();
            _defaultFormTitle += " " + AssemblyName.GetAssemblyName(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Version.dll")).Version.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _backgroundSource = new BindingSource();
            _viewPorts = new BindingSource();
            _windows = new BindingSource();
            _backgroundSource.DataSource = typeof(Background);
            _viewPorts.DataSource = typeof(ViewPort);
            _windows.DataSource = typeof(ViewPortForm);
            this.Icon = Common.Properties.Resources.iris;


            _loadedCfg = Helpers.LoadConfig(_configFile);
            ProcessLoadedConfig(_loadedCfg);
            // Minimize the parent form.
            this.WindowState = FormWindowState.Minimized;
        }
        private void ProcessLoadedConfig(IrisConfig loadedCfg)
        {
            if (loadedCfg != null)
            {
                this.Text = $"{_defaultFormTitle} - {Path.GetFileNameWithoutExtension(_configFile)}";

                _viewPorts.DataSource = loadedCfg.ViewPorts;
                if(loadedCfg.Background != null)
                {
                    _background = loadedCfg.Background;
                    checkBox1.Checked = _background.Visible;
                    AddBackground();
                    butColor.BackColor = _backgroundForm.BackColor;
                    tBLeft.Text = _background.ScreenPositionX.ToString();
                    tBTop.Text = _background.ScreenPositionY.ToString();
                    tBWidth.Text = _background.SizeX.ToString();
                    tBHeight.Text = _background.SizeY.ToString();

                } else
                {
                    tBTop.Text = tBLeft.Text = "0";
                    tBHeight.Text = "1080";
                    tBWidth.Text = "1920";
                    butColor.BackColor = System.Drawing.Color.FromArgb(0xff, 0x00, 0x00, 0x00);
                }
            }
            else
            {
                this.Close();
            }
            AddViewports(_viewPorts);
            if (_background != null) AddBackground();
        }
        private void AddViewports( BindingSource _viewPorts)
        {
            ViewPort tempVP = null;
            foreach (ViewPort vp in _viewPorts)
            {
                if (vp.Name == "Background")
                {
                    tempVP = vp;
                    if (_background == null)
                    {
                        // The Background Viewport has been logically replaced by the Background Element 
                        // so we convert the viewport to a Background if one was not in the Iris Config.
                        _background = new Background()
                        {
                            Color = Colors.Black,
                            ScreenPositionX = vp.ScreenPositionX,
                            ScreenPositionY = vp.ScreenPositionY,
                            SizeX = vp.SizeX,
                            SizeY = vp.SizeY,
                            Visible = true
                        };
                    }
                }
                else
                {
                    ViewPortForm vpWindow = new ViewPortForm(vp);
                    vpWindow.Icon = Common.Properties.Resources.iris;
                    vpWindow.MinimumSize = new Size(16, 16);
                    vpWindow.Size = new Size(vp.SizeX, vp.SizeY);
                    vpWindow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    vpWindow.Text = vp.Name;
                    vpWindow.Show();
                    vpWindow.DesktopLocation = new Point(vp.ScreenPositionX, vp.ScreenPositionY);
                    _windows.Add(vpWindow);
                }
            }
            if(tempVP != null) _viewPorts.Remove(tempVP);
            tempVP = null;
        }
        private void AddBackground()
        {
            if (_backgroundForm == null || _backgroundForm.IsDisposed)
            {
                _backgroundForm = new Form()
                {
                    Icon = Common.Properties.Resources.iris,
                    MinimumSize = new Size(16, 16),
                    Size = new Size(_background.SizeX, _background.SizeY),
                    DesktopLocation = new Point(_background.ScreenPositionX, _background.ScreenPositionY),
                    StartPosition = FormStartPosition.Manual,
                    Location = new Point(_background.ScreenPositionX, _background.ScreenPositionY),
                    BackColor = System.Drawing.Color.FromArgb(_background.Color.A, _background.Color.R, _background.Color.G, _background.Color.B),
                    FormBorderStyle = FormBorderStyle.None,
                    Text = "Background",
                    Name = "Background"
                };
            }
            if (_background.Visible)
            {
                _backgroundForm.Visible = true;
                _backgroundForm.Show();
                _backgroundForm.SendToBack();
                timerBackground.Enabled = true;
            }
            else
            {
                _backgroundForm.Visible = false;
                timerBackground.Enabled = false;
            }
        }
        private void IrisClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (ViewPortForm vpf in _windows)
            {
                vpf.StopListening();
            }
            _backgroundForm?.Close();
        }
        private void OpenConfig()
        {
            bool timerEnabled = false;
            if (_backgroundForm != null)
            {
                _backgroundForm.Visible = false;
                timerEnabled = timerBackground.Enabled;
                timerBackground.Enabled = false;
            }

            List<ViewPortForm> vpRemoval = new List<ViewPortForm>();
            if(_backgroundForm != null)
            {
                _backgroundForm.Close();
                _backgroundForm.Dispose();
            }
            foreach (ViewPortForm vpf in _windows)
            {
                vpf.StopListening();
                vpRemoval.Add(vpf);
            }
            foreach(ViewPortForm vpf in vpRemoval)
            {
                vpf.Dispose();
                _windows.Remove(vpf);
            }
            vpRemoval.Clear();  
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Iris XML files (*.xml)|*.xml|Iris files (*.iris)|*.iris",
                InitialDirectory = irisPath
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _configFile = openFileDialog.FileName;
            }
            ProcessLoadedConfig(Helpers.LoadConfig(_configFile));
            if (_backgroundForm != null && _background != null)
            {
                _backgroundForm.Visible = _background.Visible;
                timerBackground.Enabled = timerEnabled;
            }

        }
        private void SaveConfig()
        {
            bool timerEnabled = false;
            if (_backgroundForm != null)
            {
                _backgroundForm.Visible = false;
                timerEnabled = timerBackground.Enabled;
                timerBackground.Enabled = false;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Iris XML files (*.xml)|*.xml|Iris files (*.iris)|*.iris",
                InitialDirectory = irisPath,
                FileName = _configFile
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _configFile = saveFileDialog.FileName;
                IrisConfig saveConfig = new IrisConfig();
                saveConfig.Background = _background;
                saveConfig.ViewPorts = (BindingList<ViewPort>)_viewPorts.List;
                saveConfig.PollingInterval = _loadedCfg.PollingInterval;
                saveConfig.GlobalImageAdjustment = _loadedCfg.GlobalImageAdjustment;
                if (Helpers.SaveConfig(saveConfig, _configFile))
                {
                    System.Windows.Forms.MessageBox.Show($"{_viewPorts.Count} viewports Saved in {_configFile}");
                    this.Text = $"{_defaultFormTitle} - {Path.GetFileNameWithoutExtension(_configFile)}";
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show($"Zero viewports Saved to File: {_configFile}");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show($"Zero viewports Saved to File: {_configFile}");
            }
            if (_backgroundForm != null && _background != null)
            {
                _backgroundForm.Visible = _background.Visible;
                timerBackground.Enabled = timerEnabled;
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

        private void button3_Click(object sender, EventArgs e)
        {
            var dialog = new ColorPickerDialog(_background != null ? _background.Color : Colors.SteelBlue)
            {
                //Owner = this
            };

            if (dialog.ShowDialog() == true)
            {
                System.Windows.Media.Color selected = dialog.SelectedColor;
                _background.Color = selected;
                butColor.BackColor = System.Drawing.Color.FromArgb(_background.Color.A, _background.Color.R, _background.Color.G, _background.Color.B);
                if (_backgroundForm != null)
                {
                    _backgroundForm.BackColor = butColor.BackColor;
                    if (_background.Visible)
                    {
                        _backgroundForm.Show();
                        _backgroundForm.SendToBack();
                    }
                    else
                    {
                        _backgroundForm.Visible = _background.Visible;
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(sender is CheckBox cB) {
                if (cB.Checked == true)
                {
                    if (_background == null) newBackground();
                    _background.Visible = true;
                    tBLeft.Text = _background.ScreenPositionX.ToString();
                    tBTop.Text = _background.ScreenPositionY.ToString();
                    tBWidth.Text = _background.SizeX.ToString();
                    tBHeight.Text = _background.SizeY.ToString();
                    butColor.BackColor = System.Drawing.Color.FromArgb(_background.Color.A, _background.Color.R, _background.Color.G, _background.Color.B);
                    if (_backgroundForm != null)
                    {
                        
                        _backgroundForm.BackColor = butColor.BackColor;
                        _backgroundForm.Show();
                        _backgroundForm.SendToBack();
                        timerBackground.Enabled = true;
                    }

                    foreach (Control c in this.Controls)
                    {
                        switch (c.Tag)
                        {
                            case "SelectColor":
                            case "labelTop":
                            case "labelLeft":
                            case "labelWidth":
                            case "labelHeight":
                            case "tBTop":
                            case "tBLeft":
                            case "tBWidth":
                            case "tBHeight":
                                c.Visible = true;
                                break;
                        }
                    }
                } else
                {
                    if (_backgroundForm != null)
                    {
                        _backgroundForm.Visible = false;
                        timerBackground.Enabled = false;
                    }

                    if (_background != null) _background.Visible = false;
                    foreach (Control c in this.Controls)
                    {
                        switch (c.Tag)
                        {
                            case "SelectColor":
                            case "labelTop":
                            case "labelLeft":
                            case "labelWidth":
                            case "labelHeight":
                            case "tBTop":
                            case "tBLeft":
                            case "tBWidth":
                            case "tBHeight":
                                c.Visible = false;
                                break;
                        }
                    }

                }
            }
        }

        private void tBLeft_TextChanged(object sender, EventArgs e)
        {
            if (_background == null) newBackground();

            Control c = sender as Control;
            if(Int32.TryParse(c.Text, out int x))
            {
                _background.ScreenPositionX = x;
                if (_backgroundForm != null) _backgroundForm.Location = new Point(_background.ScreenPositionX, _background.ScreenPositionY);
            }
            else
            {
                c.Text = "0";
            }
        }

        private void tBTop_TextChanged(object sender, EventArgs e)
        {
            if (_background == null) newBackground();
            Control c = sender as Control;
            if (Int32.TryParse(c.Text, out int y))
            {
                _background.ScreenPositionY = y;
                if (_backgroundForm != null) _backgroundForm.Location = new Point(_background.ScreenPositionX, _background.ScreenPositionY);
            }
            else
            {
                c.Text = "0";
            }

        }

        private void tBWidth_TextChanged(object sender, EventArgs e)
        {
            if (_background == null) newBackground();
            Control c = sender as Control;
            if (Int32.TryParse(c.Text, out int w))
            {
                _background.SizeX = w;
                if (_backgroundForm != null) _backgroundForm.Width = _background.SizeX;
            }
            else
            {
                c.Text = "1920";
            }
        }

        private void tBHeight_TextChanged(object sender, EventArgs e)
        {
            if (_background == null) newBackground();
            Control c = sender as Control;
            if (Int32.TryParse(c.Text, out int h))
            {
                _background.SizeY = h;
                if (_backgroundForm != null) _backgroundForm.Height = _background.SizeY;
            }
            else
            {
                c.Text = "1080";
            }
        }
        private void newBackground() {
            _background = new Background()
            {
                Color = Colors.Black,
                ScreenPositionX = 0,
                ScreenPositionY = 0,
                SizeX = 1920,
                SizeY = 1080,
                Visible = false
            };
        }

        private void timerBackground_Tick(object sender, EventArgs e)
        {
            _backgroundForm?.SendToBack();
        }
    }
}
