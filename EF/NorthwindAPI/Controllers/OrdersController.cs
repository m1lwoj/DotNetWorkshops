using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private OrdersEfRepository _ordersRepo;
        public OrdersController(ILogger<CustomersController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _ordersRepo = new OrdersEfRepository(new NorthwindContext(config));
        }
        
        [HttpGet]
        public IActionResult Get(int limit)
            => Ok(_ordersRepo.GetNewestOrders(limit));

        [HttpPost]
        public IActionResult Add(Order order)
        {
            _ordersRepo.AddOrder(order);
            _ordersRepo.SaveChanges();

            return CreatedAtAction(nameof(Order), new { OrderId = order.OrderId }, order);
        }
    }
}
