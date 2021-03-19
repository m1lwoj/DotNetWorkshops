using NorthwindData.Models;
using NortwindBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

public class ProductsOnStockValidator 
{
    public ProductsOnStockValidator() 
    {
    }

    public void Validate(IEnumerable<Product> dbProducts, IEnumerable<ProductQuantityViewModel> productsToValidate)
    {
        foreach (var dbProduct in dbProducts)
        {
            var productToValidate = productsToValidate.Single(ptv => ptv.ProductId == dbProduct.ProductId);

            if (dbProduct.UnitsInStock < productToValidate.Quantity)
            {
                throw new OutOfStockException(dbProduct.ProductName);
            }
        }
    }
}