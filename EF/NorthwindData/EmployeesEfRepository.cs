using Microsoft.EntityFrameworkCore;
using NorthwindData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindData
{
    public class EmployeesEfRepository
    {
        private NorthwindContext _dbContext;

        public EmployeesEfRepository(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCustomer(Customer customer)
        {
            _dbContext.Add(customer);
        }

        public void DeleteCustomer(string id)
        {
            _dbContext.Remove(_dbContext.Customers
                .Single(c => c.CustomerId == id));
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _dbContext.Customers.AsEnumerable();
        }

        public IEnumerable<Customer> GetCustomersByName(string name)
        {
            return _dbContext.Customers
                .Where(c => c.ContactName == name).AsEnumerable();
        }

        public void UpdateCustomer(string id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
