using System.Collections.Generic;

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
