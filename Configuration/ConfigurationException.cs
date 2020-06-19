using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    class ConfigurationException : Exception
    {
        public ConfigurationException()
        {
            
        }
        public ConfigurationException(string name)
            : base($"No configuration found for: {name}")
        {

        }
    }


}
