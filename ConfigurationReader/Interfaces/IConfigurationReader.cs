using System.Collections.Generic;

namespace ConfigurationReader.Interfaces
{
    public interface IConfigurationReader
    {
        public List<ConfigurationEntry> ReadFromFile(string file);
    }
}
