using NUnit.Framework;
using System;
using System.Collections.Generic;
using Shouldly;
using Microsoft.EntityFrameworkCore;
using NorthwindData.Models;
using System.Threading.Tasks;

namespace NorthwindDataTests.Unit
{
    public class CustomersSearchTests
    {
        private NorthwindContext _dbContext;

        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<NorthwindContext>().UseInMemoryDatabase("Northwind");
            _dbContext = new NorthwindContext(dbContextOptions.Options);
            _dbContext.Database.EnsureCreated();

            
            _dbContext.Add(new Customer { CustomerId = "PIOTR" });
            _dbContext.SaveChanges();
        }

        [Test]
        public async Task When()
        {

        }
    }
}
