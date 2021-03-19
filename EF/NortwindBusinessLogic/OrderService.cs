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
            //var productsOnStock = _productsRepo.GetProdutct(p => p.ProductId).UnitsInStock;
                
            Order order = new Order();
            order.CustomerId = viewOrder.CustomerId;
            var products = viewOrder.Products.Select
                (p => new OrderDetail()
                {
                    ProductId = p.ProductId,
                    UnitPrice = _productsRepo.GetProdutct(p.ProductId).UnitPrice ?? 0M,
                    Quantity = p.Quantity,
                }).ToList();

            _ordersRepo.AddOrder(order);
            _ordersRepo.SaveChanges();

            return new CreateOrderResults() { result = order.OrderId };
        }

        //private decimal AddDiscount(decimal price, short quantity)
        //{
        //    if (quantity )
        //    {

        //    }
        //}
    }
}
