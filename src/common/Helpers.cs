using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Serialization;

namespace common
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
            using (var stream = File.OpenRead(fileName))
            {
                loader = (IrisConfig)ser.Deserialize(stream);
            }
            return loader;
        }

        public static void SaveConfig(IrisConfig config, string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(IrisConfig), new Type[] { typeof(ViewPort) });

            using (var stream = File.Create(fileName))
            {
                ser.Serialize(stream, config);
            }
        }

    }
}
