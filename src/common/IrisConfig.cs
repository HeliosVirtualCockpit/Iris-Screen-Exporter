
using System.ComponentModel;

namespace common
{
    public class IrisConfig
    {
        public BindingList<ViewPort> ViewPorts { get; set; }

        public int PollingInterval { get; set; }

    }
}
