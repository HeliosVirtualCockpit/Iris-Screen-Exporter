
using System.ComponentModel;
using System.Xml.Serialization;

namespace Iris.Common
{
    public class IrisConfig
    {
        public BindingList<ViewPort> ViewPorts { get; set; }

        public int PollingInterval { get; set; }

        [XmlElement(IsNullable = false)]
        public ImageAdjustment GlobalImageAdjustment { get; set;}
    }
}
