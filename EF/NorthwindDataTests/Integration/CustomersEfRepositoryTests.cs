using NorthwindData;
using NorthwindData.Models;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace NorthwindDataTests.Integration
{
    public class CustomersEfRepositoryTests
    {
        private CustomersEfRepository _customersRepo;
        private List<Customer> _allCustomers = new List<Customer>();
        private string _customerID = "_TPIT";

        [SetUp]
        public void Setup()
        {
            _customersRepo = new CustomersEfRepository(new NorthwindContext(TestContext.Parameters["ConnectionString"].ToString()));
            //var _allCustomers = _customersRepo.GetAllCustomers();
        }

        [Test]
        public void WhenAddCustomerWithIDThenSuccess()
        {
            //arrange, act
            var customer = new Customer { CustomerId = _customerID, CompanyName = "Nazwa Firmy" };
            _customersRepo.AddCustomer(customer);
            _customersRepo.SaveChanges();

            //assert
            var allCustomers = _customersRepo.GetAllCustomers();

            allCustomers.ShouldNotBeNull();
            //allCustomers.Count.ShouldBe(_allCustomers.Count + 1);
            Assert.IsTrue(allCustomers.Contains(customer));
        }

        [TearDown]
        public void TearDown()
        {
            _customersRepo.DeleteCustomer(_customerID);
            _customersRepo.SaveChanges();
        }
    }
}
