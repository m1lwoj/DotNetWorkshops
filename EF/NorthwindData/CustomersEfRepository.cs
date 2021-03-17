using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NorthwindData.Models
{
    public class CustomersEfRepository : ICustomersRepository
    {
        private NorthwindContext _dbContext;

        public CustomersEfRepository(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(string id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomersByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(string id, Customer customer)
        {
            throw new NotImplementedException();
        }

        public void GetEmployeesNPlus1()
        {
            //lazy loading (potential N+1 problem)
            var employees = _dbContext.Employees.ToList();

            foreach (var employee in employees)
            {
                foreach (var order in employee.Orders)
                {
                    //Console.WriteLine($"{typeof(order)_
                }
            }

            //eager loading
            var employees2 = _dbContext.Employees.Include(e => e.Orders).ToList();

            foreach (var employee in employees)
            {
                foreach (var order in employee.Orders)
                {
                    //Console.WriteLine($"{typeof(order)_
                }
            }
        }

        public void ToListVsIQueryable()
        {
            //in memory processing
            var orders = _dbContext.Employees.ToList()
                .Where(e => e.Orders.Sum(o => o.OrderDetails.Sum(s => s.UnitPrice * s.Quantity)) > 100000);

            //Exception
            //var orders3 = _dbContext.Employees
            //    .Where(e => e.Orders.Sum(o => o.OrderDetails.Sum(s => s.UnitPrice * s.Quantity)) > 12)
            //    .ToList();

            //db processing
            var orders2 = _dbContext.Orders
                .Where(o => o.OrderDetails.Sum(s => s.UnitPrice * s.Quantity) > 12)
                .ToList();

            //Complex query with workaround using SelectMany
            var employeeOrderDetails = _dbContext.Employees.Select(e => new
            {
                e.EmployeeId,
                e.Orders,
                orderdetails = e.Orders.SelectMany(o => o.OrderDetails)
            });

            var employeeOrdersSum = employeeOrderDetails.Select(e => new
            {
                e.EmployeeId,
                Suma = e.orderdetails.Sum(s => s.Quantity * s.UnitPrice)
            });

            var employeesWithBugTotalValueOrders = employeeOrdersSum.Where(o => o.Suma > 100000).ToList();
        }
    }
}
