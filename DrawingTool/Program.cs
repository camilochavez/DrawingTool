using Microsoft.Extensions.DependencyInjection;
using System;

namespace DrawingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var services = new ServiceCollection();
                services.RegisterAppServices();
                var serviceProvider = services.BuildServiceProvider();
                string fileInputPath;
                string fileOutputPath;
                if (args.Length == 0)
                {
                    Console.WriteLine("Please enter the file path with the parameters");
                    fileInputPath = Console.ReadLine();
                    Console.WriteLine("Please enter the file path to save results");
                    fileOutputPath = Console.ReadLine();
                }
                else
                {
                    fileInputPath = args[0];
                    fileOutputPath = args[1];
                }
                if (serviceProvider.GetService<IFileProcessor>().ProcessFile(fileInputPath, fileOutputPath))
                {
                    Console.WriteLine("File Generated Successfully");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("File has not been processed");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ups! something went wrong with the process");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }


    }
}
