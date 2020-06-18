using Configuration;

namespace Homework
{
    class Program
    {

        static void Main(string[] args)
        {
            var configurationService = new ConfigurationService();
            var config = configurationService.Configure<CustomConfig>();
        }
    }
}
