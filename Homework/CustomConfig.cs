using System;
using Configuration;
using Configuration.Interfaces;

namespace Homework
{
    class CustomConfig : AbstractConfiguration
    {
        public string Name { get; set; }
        public string PowerSupply { get; set; }
        public int OrdersPerHour { get; set; }
        public int OrderLinesPerOrder { get; set; }
        public string InboundStrategy { get; set; }
        public DateTime ResultStartTime { get; set; }
        public int ResultInterval { get; set; }
    }
}
