using System.Collections.Generic;

namespace ConfigurationReader.Interfaces
{
    public interface IConfigurationReader
    {
        /// <summary>
        /// File specific logic for reading configuration, should vary depending on implementation
        /// </summary>
        /// <param name="file">file to read</param>
        /// <returns>read configuration entries</returns>
        public List<ConfigurationEntry> ReadFromFile(string file);
    }
}
