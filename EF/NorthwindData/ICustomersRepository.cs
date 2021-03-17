using NorthwindData.Models;
using System.Collections.Generic;

namespace NorthwindData
{
    public interface ICustomersRepository
    {
        List<Customer> GetAllCustomers();
        List<Customer> GetCustomersByName(string name);
        void AddCustomer(Customer customer);
        void UpdateCustomer(string id, Customer customer);
        void DeleteCustomer(string id);
        void GetEmployeesNPlus1();
    }
}