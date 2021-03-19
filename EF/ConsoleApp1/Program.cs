using ServiceReference1;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var klient = new ServiceReference1.Service1Client();

            //var wynik = klient.GetAllCustomersAsync();

            var wynik = Task.Run(() => new Service1Client().GetAllCustomersAsync()).GetAwaiter().GetResult();

            Console.WriteLine("Hello World!");
        }
    }
}
