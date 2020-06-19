using System;

namespace Configuration
{
    /// <summary>
    /// Exception to be thrown if an error occurs while reading configuration
    /// </summary>
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
