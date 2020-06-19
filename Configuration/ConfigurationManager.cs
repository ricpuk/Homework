
using System;
using System.Collections.Generic;
using System.Linq;
using Configuration.Helpers;
using ConfigurationReader;
using ConfigurationReader.Interfaces;

namespace Configuration
{
    public static class ConfigurationManager
    {
        /// <summary>
        /// ConfigurationReader - contains specific logic to parse configuration files
        /// </summary>
        private static IConfigurationReader ConfigReader = new DefaultConfigurationReader();

        /// <summary>
        /// Currently loaded configuration params
        /// </summary>
        private static List<ConfigurationEntry> _configEntries = new List<ConfigurationEntry>();

        static ConfigurationManager()
        {

        }

        /// <summary>
        /// Default configuration reader
        /// </summary>
        /// <param name="reader">Reader to use</param>
        public static void SetDefaultConfigurationReader(IConfigurationReader reader)
        {
            ConfigReader = reader;
        }

        /// <summary>
        /// Reads entries in the specified configuration file
        /// concatenates with existing _configEntries list
        /// </summary>
        /// <param name="file">file name to read</param>
        public static void AddConfiguration(string file)
        {
            _configEntries = _configEntries.Concat(ConfigReader.ReadFromFile(file)).ToList();
        }

        /// <summary>
        /// Configures the provided model with values available.
        /// </summary>
        /// <typeparam name="T">Model to configure</typeparam>
        /// <returns>Instance of configured model</returns>
        public static T Configure<T>() where T : AbstractConfiguration, new()
        {
            
            var config = new T();

            foreach (var entry in _configEntries)
            {
                config.SetValue(entry.Key, entry.Value);
            }

            return config;
        }

        /// <summary>
        /// Get Value by key and type
        /// </summary>
        /// <typeparam name="T">Requested variable type</typeparam>
        /// <param name="key">Requested variable name(key)</param>
        /// <returns>Configured variable casted to type</returns>
        static T GetValue<T>(string key)
        {
            var entry = _configEntries.SingleOrDefault(x => string.Equals(x.Key, key, StringComparison.CurrentCultureIgnoreCase));
            //Treat as configuration error if entry does not exist
            if (entry == null)
            {
                throw new ConfigurationException();
            }
            //Cast to required value type
            return ValueConverter.ConvertTo<T>(entry.Value);
        }

        /// <summary>
        /// Gets currently read configuration entries
        /// </summary>
        /// <returns>A list of currently configured values</returns>
        static List<ConfigurationEntry> GetAll()
        {
            return _configEntries;
        }
    }
}
