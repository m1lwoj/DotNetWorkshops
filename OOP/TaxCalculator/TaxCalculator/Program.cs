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
        decimal cena = 0;
        decimal import = 0.1M;
        decimal lekarstwa = 0.05M;
        decimal owoce = 0.08M;
        decimal meble = 0.12M;
        decimal elektornika = 0.23M;
        decimal totalImport = 0;

        if (isImported)
        {
            totalImport = productPrice * import;
        }
        
        if (product == "ibuprom")
        {
            cena = quantity * (productPrice + (productPrice * lekarstwa) + totalImport);            
        }
        if (product == "watermelon")
        {
            cena = quantity * (productPrice + (productPrice * owoce) + totalImport);
        }
        if (product == "chair")
        {
            cena = quantity * (productPrice + (productPrice * meble) + totalImport);
        }
        if (product == "laptop")
        {
            cena = quantity * (productPrice + (productPrice * elektornika) + totalImport);
        }

        return Math.Round(cena, 2);
    }
}
