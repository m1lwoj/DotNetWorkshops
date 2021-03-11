using System;
using System.Collections.Generic;
using System.Text;

namespace UglyProject
{
    public class UglyClass
    {
        public void UglyMethooood()
        {
            int a = 2;

            int @int = a * 2 / 2; //zbędny komentarz
            int wynik = a / 2;

            Console.WriteLine(@int);
            Console.WriteLine(wynik);
        }
    }
}
