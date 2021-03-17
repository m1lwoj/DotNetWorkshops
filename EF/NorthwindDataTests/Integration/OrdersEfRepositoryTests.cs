using NorthwindData;
using NorthwindData.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindDataTests.Integration
{
    public class OrdersEfRepositoryTests
    {
        private OrdersEfRepository _ordersRepo;

        [SetUp]
        public void Setup()
        {
            _ordersRepo = new OrdersEfRepository(new NorthwindContext(TestContext.Parameters["ConnectionString"].ToString()));
        }

        [Test]
        public void Test()
        {
           _ordersRepo.GetStatisticsForCurrentMonth();
        }
    }
}
