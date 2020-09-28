using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SparseArraysLib;
using SparseArraysLib.Helpers.Extensions;
using SparseArraysLib.Models;
using SparseArraysLib.Modules.Business;
using SparseArraysLib.Modules.Business.Interfaces;
using SparseArraysLib.Modules.CRUD;
using SparseArraysLib.Modules.CRUD.Interfaces;

namespace SparseArrays
{
    class SparseArraysProgram
    {
        static async Task Main(string[] args)
        {
            try
            {
                await Init();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await Main(args);
            }
        }

        private static async Task Init()
        {
            var services = new ServiceCollection();

            InitializeApplication(services);
            StartApplication();

            var provider = services.BuildServiceProvider();
            var luncher = provider.GetRequiredService<ISparseArrayLuncher>();

            await luncher.LunchSparseArray();
        }

        private static void StartApplication()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Press any button to start.");
            Console.ReadKey();
            Console.Clear();
        }

        private static void InitializeApplication(ServiceCollection services)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Loading...");
       
            services.ConfigureSparseArraysLibServices();
            services.ConfigureSparseArraysServices();

            Console.WriteLine("Loading complete.");
        }
    }
}
