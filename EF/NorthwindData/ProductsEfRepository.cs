using Microsoft.EntityFrameworkCore;
using NorthwindData.Dto;
using NorthwindData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindData
{
    public class ProductsEfRepository : EfRepository
    {
        public ProductsEfRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public Product GetProdutct(int productId)
        {
            return _dbContext.Products.Single(p => p.ProductId == productId);
        }
    }
}
