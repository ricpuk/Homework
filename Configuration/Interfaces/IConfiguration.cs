namespace Configuration.Interfaces
{
    public interface IConfiguration
    {
        /// <summary>
        /// Value setter
        /// </summary>
        /// <param name="key">Property name</param>
        /// <param name="value">Property value</param>
        void SetValue(string key, string value);
        /// <summary>
        /// Value getter
        /// </summary>
        /// <typeparam name="T">Property type</typeparam>
        /// <param name="key">property name</param>
        /// <returns></returns>
        T GetValue<T>(string key);
    }
}
