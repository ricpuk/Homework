
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
        private static readonly IConfigurationReader ConfigReader = new DefaultConfigurationReader();
        private static List<ConfigurationEntry> _configEntries = new List<ConfigurationEntry>();

        static ConfigurationManager()
        {

        }

        public static void AddConfiguration(string file)
        {
            _configEntries = _configEntries.Concat(ConfigReader.ReadFromFile(file)).ToList();
        }

        public static T Configure<T>() where T : AbstractConfiguration, new()
        {
            
            var config = new T();

            foreach (var entry in _configEntries)
            {
                config.SetValue(entry.Key, entry.Value);
            }

            return config;
        }

        static T GetValue<T>(string key)
        {
            var entry = _configEntries.SingleOrDefault(x => string.Equals(x.Key, key, StringComparison.CurrentCultureIgnoreCase));
            //Treat as configuration error if entry does not exist
            if (entry == null)
            {
                throw new ConfigurationException();
            }
            return ValueConverter.ConvertTo<T>(entry.Value);
        }

        static List<ConfigurationEntry> GetAll()
        {
            return _configEntries;
        }
    }
}
