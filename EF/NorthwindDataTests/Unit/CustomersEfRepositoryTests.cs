using NUnit.Framework;
using System;
using System.Collections.Generic;
using Shouldly;
using Microsoft.EntityFrameworkCore;
using NorthwindData.Models;
using System.Threading.Tasks;

namespace NorthwindDataTests.Unit
{
    public class CustomersEfRepositoryTests
    {
        private NorthwindContext _dbContext;

        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<NorthwindContext>().UseInMemoryDatabase("Northwind");
            _dbContext = new NorthwindContext(dbContextOptions.Options);
            _dbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task Test()
        {
            _dbContext.Add(new Category());
            _dbContext.SaveChanges();

            var allCategories = await _dbContext.Set<Category>().ToListAsync();
            allCategories.ShouldNotBeNull();
            allCategories.Count.ShouldBe(1);
        }

        [Test]
        public async Task WhenAddCustomerWithIDThenSuccess()
        {
            //arrange, act
            _dbContext.Add(new Customer { CustomerId = "PIOTR", CompanyName = "Nazwa Firmy" });
            _dbContext.SaveChanges();

            //assert
            var allCustomers = await _dbContext.Set<Customer>().ToListAsync();
            
            allCustomers.ShouldNotBeNull();
            allCustomers.Count.ShouldBe(1);
            allCustomers.TrueForAll(a => a.CustomerId == "PIOTR");
        }

        public async Task WhenAddCustomerWithoutIDThenFail()
        {
            //arrange, act
            _dbContext.Add(new Customer());
            _dbContext.SaveChanges();
            
            //assert
            var allCustomers = await _dbContext.Set<Customer>().ToListAsync();
            allCustomers.ShouldBeNull();
            allCustomers.Count.ShouldBe(0);
        }

        //[Test]
        //public async Task DeleteCustomerTest()
        //{

        //}
    }
}
