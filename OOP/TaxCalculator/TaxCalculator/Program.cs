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

    public static Dictionary<string, TaxBase> Taxes = new Dictionary<string, TaxBase>
    {
         { "laptop", new ElectronicTax() },
         { "watermelon", new FruitTax() },
         { "chair", new ChairTax() },
         { "ibuprom", new MedicineTax() },
    };

 
    public static decimal CalculateTotalPrice(string product, int quantity, decimal productPrice, bool isImported)
    {
        //if(product == "laptop")
        //{
        //    return quantity * (productPrice + (0.14M * productPrice));
        //}
        //if (product == "watermelon")
        //{
        //    return quantity * (productPrice + (0.12M * productPrice));
        //}
        //if (product == "chair")
        //{
        //    return quantity * (productPrice + (0.11M * productPrice));
        //}

        return Taxes[product].CalculatePrice(quantity, productPrice, isImported);
    }
}

public abstract class TaxBase
{
    public decimal ImportedTax => 0.1M;
    public decimal Tax { get; }

    public TaxBase(decimal tax)
    {
        Tax = tax;
    }

    public decimal CalculatePrice(int productCount, decimal productNetPrice, bool isImported)
    {
        var result = productCount * (productNetPrice + (Tax * productNetPrice));

        if (isImported)
        {
            result = result + (productCount * ImportedTax * productNetPrice);
        }

        return Math.Round(result, 2);
    }
}

public class ElectronicTax : TaxBase
{
    public ElectronicTax() : base(0.23M)
    {
    }
}

public class FruitTax : TaxBase
{
    public FruitTax() : base(0.08M)
    {
    }
}

public class ChairTax : TaxBase
{
    public ChairTax() : base(0.12M)
    {
    }
}

public class MedicineTax : TaxBase
{
    public MedicineTax() : base(0.05M)
    {
    }
}
