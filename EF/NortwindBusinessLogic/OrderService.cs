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
    public class OrderService : IOrderService
    {
        private readonly IProductsRepository _productsRepo;
        private readonly IOrdersRepository _ordersRepo;

        //SOLI [D] - 
        //
        // Dependecy Inversion - IoC
        // 

        public OrderService(IProductsRepository productsRepo, IOrdersRepository ordersRepo)
        {
            _ordersRepo = ordersRepo;
            _productsRepo = productsRepo;
        }

        public CreateOrderResults CreateOrder(CreateOrderViewModel viewOrder)
        {
            var dbProducts = _productsRepo.GetProducts(viewOrder.Products.Select(p => p.ProductId));

            new ProductsOnStockValidator().Validate(dbProducts, viewOrder.Products);

            Order order = new Order();

            order.CustomerId = viewOrder.CustomerId;
            var products = viewOrder.Products.Select
                (p => new OrderDetail()
                {
                    ProductId = p.ProductId,
                    UnitPrice = dbProducts.Single(dbp => dbp.ProductId == p.ProductId).UnitPrice ?? 0M,
                    Quantity = p.Quantity,
                    Discount = new OrderDiscountCalculator(1).SetDiscount(viewOrder.Products.Sum(p => p.Quantity))
                }).ToList();

            _ordersRepo.AddOrder(order);
            //_ordersRepo.SaveChanges();

            return new CreateOrderResults() { result = order.OrderId.ToString() };
        }
    }
}
