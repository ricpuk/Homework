using System.Security.Authentication;
using Configuration;

namespace Homework
{
    class Program
    {

        static void Main(string[] args)
        {
            //Load configuration files
            ConfigurationManager.AddConfiguration("Global_Config_Standard.txt");
            ConfigurationManager.AddConfiguration("Global_Config_ProjectSpecific.txt");
            ConfigurationManager.AddConfiguration("Global_Config_ExperimentSpecifix.txt");

            //Configure custom model
            var config = ConfigurationManager.Configure<CustomConfig>();
        }
    }
}
