
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Configuration.Interfaces;
using ConfigurationReader;
using ConfigurationReader.Interfaces;
using static System.String;

namespace Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationReader _configReader = new DefaultConfigurationReader();
        private readonly string _configDir = "Config";
        private readonly List<string> _configFilePrefixes = new List<string>{"Base_", "Project_"};

        public ConfigurationService()
        {
        }
        public ConfigurationService(IConfigurationReader configReader)
        {
            _configReader = configReader;
        }

        public T Configure<T>() where T : AbstractConfiguration, new()
        {
            var configEntries = _configReader.ReadFromFile("Base_Config.txt");

            var config = new T();

            foreach (var entry in configEntries)
            {
                config.SetValue(entry.Key, entry.Value);
            }

            return config;
        }

    }
}
