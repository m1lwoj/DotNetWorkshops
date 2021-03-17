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
    }
}
