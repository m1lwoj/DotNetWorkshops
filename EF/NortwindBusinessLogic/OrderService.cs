using Microsoft.Extensions.Configuration;
using NorthwindData;
using NorthwindData.Models;
using NortwindBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NortwindBusinessLogic
{
    public class OrderService
    {
        private readonly ProductsEfRepository _productsRepo;
        private readonly OrdersEfRepository _ordersRepo;
        public OrderService(IConfiguration config)
        {
            _ordersRepo = new OrdersEfRepository(new NorthwindContext(config));
            _productsRepo = new ProductsEfRepository(new NorthwindContext(config));
        }

        public CreateOrderResults CreateOrder(CreateOrderViewModel viewOrder)
        {
            var dbProducts = _productsRepo.GetProducts(viewOrder.Products.Select(p => p.ProductId));

            ValidateProductsOnStock(dbProducts, viewOrder.Products);

            Order order = new Order();
                       
            order.CustomerId = viewOrder.CustomerId;
            var products = viewOrder.Products.Select
                (p => new OrderDetail()
                {
                    ProductId = p.ProductId,
                    UnitPrice = dbProducts.Single(dbp => dbp.ProductId == p.ProductId).UnitPrice ?? 0M,
                    Quantity = p.Quantity,
                    Discount = SetDiscount(viewOrder.Products.Sum(p => p.Quantity))
                }).ToList();

            _ordersRepo.AddOrder(order);
            _ordersRepo.SaveChanges();

            return new CreateOrderResults() { result = order.OrderId.ToString() };
        }

        private float SetDiscount(int quantity)
        {
            if (quantity > 100)
            {
                return 0.1f;
            }

            return 0;
        }

        private void ValidateProductsOnStock(IEnumerable<Product> dbProducts, IEnumerable<ProductQuantityViewModel> productsToValidate)
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
}
