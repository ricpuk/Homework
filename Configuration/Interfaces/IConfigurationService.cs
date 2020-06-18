﻿
namespace Configuration.Interfaces
{
    public interface IConfigurationService
    {
        T Configure<T>() where T : AbstractConfiguration, new();
        public void AddConfigurationFile(string file);
    }
}
