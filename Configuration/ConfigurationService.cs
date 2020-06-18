
using System;
using System.Collections.Generic;
using System.Linq;
using Configuration.Interfaces;
using ConfigurationReader;
using ConfigurationReader.Interfaces;

namespace Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationReader _configReader = new DefaultConfigurationReader();
        private readonly string _configDir = "Config";
        private readonly List<string> _configFiles = new List<string>();

        public ConfigurationService()
        {
        }
        public ConfigurationService(IConfigurationReader configReader)
        {
            _configReader = configReader;
        }

        public void AddConfigurationFile(string file)
        {
            _configFiles.Add(file);
        }

        public T Configure<T>() where T : AbstractConfiguration, new()
        {
            var configurationEntries = new List<ConfigurationEntry>();
            foreach (var configFile in _configFiles)
            {
                configurationEntries = configurationEntries.Concat(_configReader.ReadFromFile(configFile)).ToList();
            }
            

            var config = new T();

            foreach (var entry in configurationEntries)
            {
                config.SetValue(entry.Key, entry.Value);
            }

            return config;
        }

    }
}
