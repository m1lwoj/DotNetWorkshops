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
using NortwindBusinessLogic;

namespace NorthwindAPI.Controllers 
{
    [Route("[controller]")]
    [ApiController]
    //Dependency inversion
    //[D] SOLI[D]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IConfiguration _config;
        private readonly IProductsRepository _productsRepo;
        private readonly IOrdersRepository _ordersRepo;
        private readonly IOrderService _orderService;

        public OrdersController(
            ILogger<CustomersController> logger,
            IConfiguration config, 
            IProductsRepository productsRepo,
            IOrdersRepository ordersRepository,
            IOrderService orderService)
        {
            _logger = logger;
            _config = config;
            _ordersRepo = ordersRepository;
            _productsRepo = productsRepo;
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get(int limit)
            => Ok(_ordersRepo.GetNewestOrders(limit));

        [HttpPost]
        public IActionResult Add(NortwindBusinessLogic.ViewModels.CreateOrderViewModel viewOrder)
        {
            var result = _orderService.CreateOrder(viewOrder);

            return Created($"/orders/{result}", result.result);
        }

    }
}
