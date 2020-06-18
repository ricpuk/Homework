using System.Collections.Generic;
using ConfigurationReader.Interfaces;

namespace ConfigurationReader
{
    public class DefaultConfigurationReader : IConfigurationReader
    {
        public List<ConfigurationEntry> ReadFromFile(string file)
        {
            return new List<ConfigurationEntry>();
        }
    }
}
