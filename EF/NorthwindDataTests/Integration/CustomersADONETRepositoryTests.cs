using NUnit.Framework;
using System;
using System.Collections.Generic;
using Shouldly;

namespace NorthwindDataTests
{
    public class CustomersADONETRepositoryTests
    {
        private object _connectionString;

        [SetUp]
        public void Setup()
        {
             _connectionString = TestContext.Parameters["ConnectionString"];
        }

        [Test]
        public void Test()
        {
            _connectionString.ShouldNotBeNull();
        }
    }
}
