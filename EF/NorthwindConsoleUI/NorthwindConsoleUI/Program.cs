using Microsoft.Extensions.Configuration;
using NorthwindData;
using NorthwindData.Models;
using System;
using System.IO;
using System.Linq;

namespace NorthwindConsoleUI
{
    class Program
    {
        private static IConfiguration _iconfiguration;

        static void Main(string[] args)
        {
            GetAppSettingsFile();
        
            using(var dbContext = new NorthwindContext(_iconfiguration))
            {
                var customersRepo = new CustomersEfRepository(dbContext);
                var allCustomers = customersRepo.GetAllCustomers();
            }

            Console.ReadLine();
        }

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }
    }
}
