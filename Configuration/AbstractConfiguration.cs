using System;
using System.Linq;
using System.Reflection;
using Configuration.Interfaces;

namespace Configuration
{
    /// <summary>
    /// Base class for configuration models, has base implementations for getting and setting values.
    /// All configuration models to be used with ConfigurationManager class have to be derived from this class
    /// </summary>
    public class AbstractConfiguration : IConfiguration
    {
        /// <summary>
        /// Sets the value of property with the specified name to specified value
        /// </summary>
        /// <param name="key">Property name</param>
        /// <param name="value">Property value</param>
        public void SetValue(string key, string value)
        {
            var property = GetProperty(key);
            if (property == null)
            {
                return;
            }
            property.SetValue(this, Convert.ChangeType(value, property.PropertyType));
        }

        /// <summary>
        /// Gets value of specified property as specified type
        /// </summary>
        /// <typeparam name="T">Property type</typeparam>
        /// <param name="key">Property name</param>
        /// <returns>Property value as type</returns>
        public T GetValue<T>(string key)
        {
            var value = GetProperty(key)?.GetValue(this);
            return (T) value;
        }

        /// <summary>
        /// Gets all properties for class type
        /// </summary>
        /// <returns>Array of PropertyInfo objects</returns>
        private PropertyInfo[] GetProperties()
        {
            var type = GetType();
            return type.GetProperties();
        }

        /// <summary>
        /// Gets one property with the specified name
        /// </summary>
        /// <param name="key">property name</param>
        /// <returns>Property info</returns>
        private PropertyInfo GetProperty(string key)
        {
            return GetProperties().SingleOrDefault(x =>
                string.Equals(x.Name, key, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
