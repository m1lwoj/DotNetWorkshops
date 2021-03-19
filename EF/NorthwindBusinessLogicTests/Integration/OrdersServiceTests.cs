using Moq;
using NorthwindData;
using NorthwindData.Models;
using NortwindBusinessLogic;
using NortwindBusinessLogic.ViewModels;
using NUnit.Framework;
using System.Collections.Generic;

namespace NorthwindBusinessLogicTests.Integration
{
    public class OrdersServiceTests
    {
        //private Mock<IProductsRepository> _productsRepoMock;
        //private Mock<IOrdersRepository> _ordersRepoMock;
        private OrderService _orderService;

        [SetUp]
        public void Setup()
        {
            //var dbContextOptions = new DbContextOptionsBuilder<NorthwindContext>().UseInMemoryDatabase("Northwind");
            //_dbContext = new NorthwindContext(dbContextOptions.Options);
            //_dbContext.Database.EnsureCreated();

            //_customersRepo = new CustomersEfRepository(new NorthwindContext(TestContext))
            //_orderService = new OrderService(_productsRepoMock.Object, _ordersRepoMock.Object);
        }

        [Test]
        public void CanCreateOrder()
        {
            //_orderService.CreateOrder(new CreateOrderViewModel()
            //{
            //    CustomerId = "AAA",
            //    Products = new List<ProductQuantityViewModel>()
            //    {
            //        new ProductQuantityViewModel()
            //        {
            //            ProductId = 1,
            //            Quantity = 1
            //        }, 
            //        new ProductQuantityViewModel()
            //        {
            //            ProductId = 2,
            //            Quantity = 1
            //        }
            //    }
            //});

            //_ordersRepoMock.Verify(mock => mock.AddOrder(It.IsAny<Order>()), Times.Once());
            //_ordersRepoMock.Verify(mock => mock.SaveChanges(), Times.Once());
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
