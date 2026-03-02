using System.ComponentModel;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Iris.Common
{
    public class Background : INotifyPropertyChanged
    {
        private int _sizeX, _sizeY, _posX, _posY;
        private Color _color;
        private bool _visible;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                NotifyPropertyChanged("Visible");
            }
        }
        [XmlElement(Type = typeof(XmlColor))]
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                NotifyPropertyChanged("Color");
            }
        }
        public int SizeX
        {
            get { return _sizeX; }
            set
            {
                _sizeX = value;
                NotifyPropertyChanged("SizeX");
            }
        }

        public int SizeY
        {
            get { return _sizeY; }
            set
            {
                _sizeY = value;
                NotifyPropertyChanged("SizeY");
            }
        }

        public int ScreenPositionX
        {
            get { return _posX; }
            set
            {
                _posX = value;
                NotifyPropertyChanged("ScreenPositionX");
            }
        }

        public int ScreenPositionY
        {
            get { return _posY; }
            set
            {
                _posY = value;
                NotifyPropertyChanged("ScreenPositionY");
            }
        }
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
