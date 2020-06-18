
using System.Collections.Generic;
using Configuration.Interfaces;
using ConfigurationReader;
using ConfigurationReader.Interfaces;

namespace Configuration
{
    class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationReader _configReader;
        private readonly string _configDir = "Config";
        private readonly List<string> _configFilePrefixes = new List<string>{"Base_", "Project_"};

        public ConfigurationService(IConfigurationReader configReader)
        {
            _configReader = configReader;
        }


        public IConfiguration Configure()
        {
            _configReader.ReadFromFile(_configDir);
        }
    }
}
