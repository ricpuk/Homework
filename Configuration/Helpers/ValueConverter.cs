using System;

namespace Configuration.Helpers
{
    /// <summary>
    /// Helper class - handles value converting from string to variable types
    /// </summary>
    public static class ValueConverter
    {
        /// <summary>
        /// Convert from string to variable type
        /// </summary>
        /// <typeparam name="T">Type to convert to</typeparam>
        /// <param name="value">Initial value</param>
        /// <returns>Converted value</returns>
        public static T ConvertTo<T>(string value)
        {
            return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}
