using System;
using System.Linq;
using System.Reflection;
using Configuration.Interfaces;

namespace Configuration
{
    public class AbstractConfiguration : IConfiguration
    {
        public void SetValue(string key, string value)
        {
            GetProperty(key)?.SetValue(this, value);
        }

        public T GetValue<T>(string key)
        {
            var value = GetProperty(key)?.GetValue(this);
            return (T) value;
        }

        private PropertyInfo[] GetProperties()
        {
            var type = GetType();
            return type.GetProperties();
        }

        private PropertyInfo GetProperty(string key)
        {
            return GetProperties().SingleOrDefault(x =>
                string.Equals(x.Name, key, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
