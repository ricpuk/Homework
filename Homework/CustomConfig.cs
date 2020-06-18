using Configuration;
using Configuration.Interfaces;

namespace Homework
{
    class CustomConfig : AbstractConfiguration
    {
        public string Name { get; set; }
        public string PowerSupply { get; set; }
        public string OrdersPerHour { get; set; }
        public string OrderLinesPerOrder { get; set; }
        public string InboundStrategy { get; set; }
        public string ResultStartTime { get; set; }
        public string ResultInterval { get; set; }
    }
}
