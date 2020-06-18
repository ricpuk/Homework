namespace Configuration.Interfaces
{
    public interface IConfiguration
    {
        void SetValue(string key, string value);
        T GetValue<T>(string key);
    }
}
