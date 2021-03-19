using NorthwindData.Models;
using System.Collections.Generic;

namespace NorthwindData
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetProducts(IEnumerable<int> productIds);
        Product GetProdutct(int productId);
    }
}