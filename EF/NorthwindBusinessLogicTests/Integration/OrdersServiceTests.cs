using Moq;
using NorthwindData;
using NorthwindData.Models;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace NorthwindBusinessLogicTests.Integration
{
    public class OrdersServiceTests
    {
        [SetUp]
        public void Setup()
        {
            //_customersRepo = new CustomersEfRepository(new NorthwindContext(TestContext.Parameters["ConnectionString"].ToString()));

            var productsRepoMock = new Mock<IProductsRepository>();
            productsRepoMock.Setup(x => x.GetProducts(It.IsAny<IEnumerable<int>())).Returns(new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                }
            }); 

            var ordersRepoMock = new Mock<IOrdersRepository>();
            mock.Setup(x => x.GetCurrentUser()).Returns(lUnauthorizedUser);

            //var _allCustomers = _customersRepo.GetAllCustomers();
        }

        [Test]
        public void CanCreateOrder()
        {
           
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
