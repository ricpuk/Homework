using System.Collections.Generic;

namespace ConfigurationReader
{
    public interface IConfigurationReader
    {
        public List<ConfigurationEntry> ReadFromFile(string file);
    }
}
