using Microsoft.Extensions.Configuration;
using NorthwindData;
using NorthwindData.Models;
using System;
using System.IO;

namespace NorthwindConsoleUI
{
    class Program
    {
        private static IConfiguration _iconfiguration;

        static void Main(string[] args)
        {
            GetAppSettingsFile();
            var customersRepo = new CustomersADONETRepository(_iconfiguration);

            customersRepo.GetCustomersByName("Fran");
            //var customersRepo2 = new CustomersEfRepository(new NorthwindContext(_iconfiguration));
            //customersRepo2.GetEmployeesNPlus1();
            //customersRepo2.ToListVsIQueryable();

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
