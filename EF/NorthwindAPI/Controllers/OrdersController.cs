using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NorthwindAPI.ViewModels;
using NorthwindData;
using NorthwindData.Models;

namespace NorthwindAPI.Controllers 
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IConfiguration _config;
        private readonly ProductsEfRepository _productsRepo;
        private readonly OrdersEfRepository _ordersRepo;

        public OrdersController(ILogger<CustomersController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _ordersRepo = new OrdersEfRepository(new NorthwindContext(config));
            _productsRepo = new ProductsEfRepository(new NorthwindContext(config));
        }
        
        [HttpGet]
        public IActionResult Get(int limit)
            => Ok(_ordersRepo.GetNewestOrders(limit));

        [HttpPost]
        public IActionResult Add(CreateOrderViewModel viewOrder)
        {
            Order order = new Order();
            order.CustomerId = viewOrder.CustomerId;
            var products = viewOrder.Products.Select
                (p => new OrderDetail()
                {
                    ProductId = p.ProductId,
                    Quantity = p.Quantity,
                    UnitPrice = _productsRepo.GetProdutct(p.ProductId).UnitPrice ?? 0M
                }).ToList();
                        
            _ordersRepo.AddOrder(order);
            _ordersRepo.SaveChanges();

            return Created($"/orders/{order.OrderId}", order.OrderId);
        }

    }
}
