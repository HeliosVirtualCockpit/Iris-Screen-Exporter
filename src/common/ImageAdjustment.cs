using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml.Serialization;

namespace common
{
    public class ImageAdjustment
    {
        private ImageAttributes _imageAttributes;
        private float _redBrightness = 1.0f;
        private float _greenBrightness = 1.0f;
        private float _blueBrightness = 1.0f;
        private float _alphaBrightness = 1.0f;
        private float _brightness = 1.0f;
        private float _contrast = 1.0f;
        private float _gamma = 1.0f; 

        public event PropertyChangedEventHandler PropertyChanged;

        public float Brightness
        {
            get => _brightness;
            set
            {
                float oldValue = _brightness;
                if (value != oldValue)
                {
                    _brightness = value;
                    _redBrightness = value;_greenBrightness = value;_blueBrightness = value;
                    MakeImageAdjustments();
                }
            }
        }
        public float RedBrightness
        {
            get => _redBrightness;
            set
            {
                float oldValue = _redBrightness;
                if (value != oldValue)
                {
                    _redBrightness = value;
                    MakeImageAdjustments();
                }
            }
        }
        public float GreenBrightness
        {
            get => _greenBrightness;
            set
            {
                float oldValue = _greenBrightness;
                if (value != oldValue)
                {
                    _redBrightness = value;
                    MakeImageAdjustments();
                }
            }
        }
        public float BlueBrightness
        {
            get => _blueBrightness;
            set
            {
                float oldValue = _blueBrightness;
                if (value != oldValue)
                {
                    _blueBrightness = value;
                    MakeImageAdjustments();
                }
            }
        }
        public float AlphaBrightness
        {
            get => _alphaBrightness;
            set
            {
                float oldValue = _alphaBrightness;
                if (value != oldValue)
                {
                    _alphaBrightness = value;
                    MakeImageAdjustments();
                }
            }
        }
        public float Gamma
        {
            get => _gamma;
            set
            {
                float oldValue = _gamma;
                if (value != oldValue)
                {
                    _gamma = value;
                    MakeImageAdjustments();
                }
            }
        }
        public float Contrast
        {
            get => _contrast;
            set
            {
                float oldValue = _contrast;
                if (value != oldValue)
                {
                    _contrast = value;
                    MakeImageAdjustments();
                }
            }
        }
        public ImageAttributes ImageAdjustments
        {
            get => _imageAttributes;
        }

        private void MakeImageAdjustments()
        {
            if (_imageAttributes == null) { _imageAttributes = new ImageAttributes(); }
            // create matrix to adjust the image
            float[][] ptsArray ={
                new float[] {_contrast, 0, 0, 0, 0}, // scale red
                new float[] {0, _contrast, 0, 0, 0}, // scale green
                new float[] {0, 0, _contrast, 0, 0}, // scale blue
                new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
                new float[] { _redBrightness - 1.0f, _greenBrightness - 1.0f, _redBrightness - 1.0f, 0, 1}};
            _imageAttributes.ClearColorMatrix();
            _imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            _imageAttributes.SetGamma(_gamma, ColorAdjustType.Bitmap);
            NotifyPropertyChanged("ImageAdjustment");
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
