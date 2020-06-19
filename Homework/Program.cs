using System;
using Configuration;

namespace Homework
{
    class Program
    {

        static void Main(string[] args)
        {
            //Load configuration files - configuration files are loaded general -> specific.
            //Files that are loaded later overwrite the ones that are loaded earlier
            ConfigurationManager.AddConfiguration("Global_Config_Standard.txt"); //Layer 0
            ConfigurationManager.AddConfiguration("Global_Config_ProjectSpecific.txt"); //Layer 1
            ConfigurationManager.AddConfiguration("Global_Config_ExperimentSpecifix.txt"); //Layer 2

            //Configure custom model
            var config = ConfigurationManager.Configure<CustomConfig>();

            //When using Configure method options can be access via property accessors example
            Console.WriteLine($"Number of systems: {config.NumberOfSystems}");


            Console.WriteLine("Get all loaded configuration entries");
            foreach (var entry in ConfigurationManager.GetAll())
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            Console.WriteLine("Get specific entry as string");
            Console.WriteLine($"OrdersPerHour: {ConfigurationManager.GetValueAsString("OrdersPerHour")}");
            Console.WriteLine($"OrderLinesPerOrder: {ConfigurationManager.GetValueAsString("OrderLinesPerOrder")}");

            Console.WriteLine("Get specific entry casted");
            Console.WriteLine($"OrdersPerHour: {ConfigurationManager.GetValue<int>("OrdersPerHour")}");

            //Throws exception if wrong cast
            //Console.WriteLine($"{ConfigurationManager.GetValue<bool>("OrdersPerHour")}");
            Console.Read();

        }
    }
}
