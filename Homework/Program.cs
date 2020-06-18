using Configuration;

namespace Homework
{
    class Program
    {

        static void Main(string[] args)
        {
            var configurationService = new ConfigurationService();
            configurationService.AddConfigurationFile("Base_Config.txt");
            configurationService.AddConfigurationFile("Project_Config.txt");
            var config = configurationService.Configure<CustomConfig>();
        }
    }
}
