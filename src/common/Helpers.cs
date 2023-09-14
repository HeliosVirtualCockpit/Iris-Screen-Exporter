using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Iris.Common
{
    public static class Helpers
    {
        public static byte[] ToByteArray(this Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                ms.Flush();
                return ms.ToArray();
            }
        }

        public static Image ToImage(this byte[] byteArray)
        {
            Image img;
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                img = Image.FromStream(ms);
            }
            return img;
        }

        public static IrisConfig LoadConfig(string fileName)
        {
            IrisConfig loader;
            XmlSerializer ser = new XmlSerializer(typeof(IrisConfig), new Type[] { typeof(ViewPort) });
            try
            {
                using (var stream = File.OpenRead(fileName))
                {
                    loader = (IrisConfig)ser.Deserialize(stream);
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Iris configuration could not be loaded from the file: {fileName}.{Environment.NewLine}{ex.Message}", 
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop, 
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                loader = null;
            }
            return loader;
        }

        public static bool SaveConfig(IrisConfig config, string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(IrisConfig), new Type[] { typeof(ViewPort) });
            try
            {
                using (var stream = File.Create(fileName))
                {
                    ser.Serialize(stream, config);
                    return true;
                }

            }
            catch (UnauthorizedAccessException ex) {
                Exception _ = ex;
                MessageBox.Show($"Iris configuration could not save to the file: {fileName} because there was insufficient access. {Environment.NewLine}It is recommended that you store Iris configurations in directories where you have access, such as your user profile.{Environment.NewLine}{ex.Message}",
                 "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Iris configuration could not save to the file: {fileName}.{Environment.NewLine}{ex.Message}",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
            return false;
        }

    }
}
