using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConfigurationReader.Interfaces;

namespace ConfigurationReader
{
    public class DefaultConfigurationReader : IConfigurationReader
    {
        private readonly string _configDirectory = $"{Environment.CurrentDirectory}/Config";

        public List<ConfigurationEntry> ReadFromFile(string file)
        {
            var filePath = $"{_configDirectory}/{file}";
            var configurationLines = File.ReadAllLines(filePath)
                .Where(x => !x.StartsWith('-') &&
                            !x.StartsWith("===") &&
                            !string.IsNullOrWhiteSpace(x) &&
                            x.Contains(":\t"))
                .ToList();
            var configurationEntries = new List<ConfigurationEntry>();
            foreach (var line in configurationLines)
            {
                var parts = line.Split(":\t");
                if (parts.Length < 2)
                {
                    continue;
                }
                configurationEntries.Add(new ConfigurationEntry
                {
                    Key = parts[0].TrimEnd('\t'), 
                    Value = parts[1].Split('\t', StringSplitOptions.RemoveEmptyEntries)[0].Trim('\t')
                });

            }

            return configurationEntries;
        }
    }
}
