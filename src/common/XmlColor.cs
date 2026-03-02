using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Iris.Common
{
    public class XmlColor
    {
        private Color m_color;

        public XmlColor() { }
        public XmlColor(Color c) { m_color = c; }

        public static implicit operator Color(XmlColor x)
        {
            return x.m_color;
        }

        public static implicit operator XmlColor(Color c)
        {
            return new XmlColor(c);
        }

        [XmlText]
        public string Default
        {
            get {
                TypeConverter colorConverter = TypeDescriptor.GetConverter(typeof(Color));
                return colorConverter.ConvertToInvariantString(m_color); }
            set {
                TypeConverter colorConverter = TypeDescriptor.GetConverter(typeof(Color));
                m_color = (Color)colorConverter.ConvertFromInvariantString(value); }
        }
    }
}
