using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NorthwindAPI.ViewModels;
using NorthwindData.Models;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IConfiguration _config;
        private CustomersEfRepository _customersRepo;


        public CustomersController(ILogger<CustomersController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _customersRepo = new CustomersEfRepository(new NorthwindContext(config));
        }
        [HttpGet]
        public IActionResult Get()
        {
            var listCustomrers = _customersRepo.GetAllCustomers().Select(x => new CustomersViewModel { Address = x.Address, City = x.City });

            return Ok(listCustomrers);
        }

        [HttpGet]
        [Route("newest")]
        //customers/newest?limit=2
        public IActionResult GetNewest([Required, Range(1, 1000)] int limit)
            => Ok(_customersRepo.GetNewestCustomers(limit).Select(x => new CustomersViewModel { Address = x.Address, City = x.City }));

        [HttpPost]
        //public IActionResult SaveCustomer()
        public IActionResult SaveCustomer(Customer customer)
        {
            //var newcustomer = new Customer() { CustomerId = "John", CompanyName = "NewCompany" };


            //_customersRepo.AddCustomer(newcustomer);
            _customersRepo.AddCustomer(customer);
            _customersRepo.SaveChanges();
            _logger.LogInformation($"Customer: {customer.CustomerId} has been added!");
            return Ok();
        }
        [HttpPut]
        public IActionResult Edit(string id)
        {
            try
            {
                var customertoedit = _customersRepo.GetCustomersByName(id);
                if (customertoedit == null)
                {
                    _logger.LogError($"Customer: {id} doesn't exists!");
                    return NotFound();
                }
                _customersRepo.UpdateCustomer(id);
                _customersRepo.SaveChanges();
                _logger.LogInformation($"Customer: {id} has been edited!");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            try
            {
                var customertodelete = _customersRepo.GetCustomersByName(id);
                if (customertodelete == null)
                {
                    _logger.LogError($"Customer: {id} doesn't exists!");
                    return NotFound();
                }
                _customersRepo.DeleteCustomer(id);
                _customersRepo.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
