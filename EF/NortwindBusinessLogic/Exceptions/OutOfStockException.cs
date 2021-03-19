using System;

public class OutOfStockException : Exception
{
    const string message = "Brak w magazynie takiej ilości produktu";

    public OutOfStockException(string productName) : base($"{message} {productName}")
    {
    }
}