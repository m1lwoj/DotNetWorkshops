using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World!");
    }

    // lekarstwa 5%
    // owoce 8%
    // meble 12%
    // elektronika 23%
    // import 10%
    public static decimal CalculateTotalPrice(string product, int quantity, decimal productPrice, bool isImported)
    {

        decimal totalprice = 0;
        decimal lekarstwa = 0.05M;
        decimal owoce = 0.08M;
        decimal meble = 0.12M;
        decimal elektronika = 0.23M;
        decimal import = 0.1M;
        decimal importtax = 0;
        
        if (isImported)
        {
            importtax = productPrice * import;
        }


        if (product == "ibuprom")
        {
            totalprice = quantity * (productPrice + (productPrice * lekarstwa) + importtax);

        }
        if (product == "watermelon")
        {
            totalprice = quantity * (productPrice + (productPrice * owoce) + importtax);

        }
        if (product == "chair")
        {
            totalprice = quantity * (productPrice + (productPrice * meble) + importtax);

        }
        if (product == "laptop")
        {
            totalprice = quantity * (productPrice + (productPrice * elektronika) + importtax);

        }

        return (totalprice);
    }
}
