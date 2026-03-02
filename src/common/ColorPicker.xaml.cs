using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace Iris.Common
{
    public partial class ColorPickerDialog : Window
    {
        public Color SelectedColor { get; private set; }

        public ColorPickerDialog(Color initialColor)
        {
            InitializeComponent();

            colorPicker.SelectedColor = initialColor;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (colorPicker.SelectedColor.HasValue)
            {
                SelectedColor = colorPicker.SelectedColor.Value;
            }

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}