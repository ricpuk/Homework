using System;
using Configuration;

namespace Homework
{
    class CustomConfig : AbstractConfiguration
    {
        public int NumberOfSystems { get; set; }
        public int OrdersPerHour { get; set; }
        public int OrderLinesPerOrder { get; set; }
        public DateTime ResultStartTime { get; set; } //Date portion will be ignored
    }
}
