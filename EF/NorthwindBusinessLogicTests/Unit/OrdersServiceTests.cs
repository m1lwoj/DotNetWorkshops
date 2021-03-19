using Moq;
using NorthwindData;
using NorthwindData.Models;
using NortwindBusinessLogic;
using NortwindBusinessLogic.ViewModels;
using NUnit.Framework;
using System.Collections.Generic;

namespace NorthwindBusinessLogicTests.Unit
{
    public class OrdersServiceTests
    {
        private Mock<IProductsRepository> _productsRepoMock;
        private Mock<IOrdersRepository> _ordersRepoMock;
        private OrderService _orderService;

        [SetUp]
        public void Setup()
        {
            //_customersRepo = new CustomersEfRepository(new NorthwindContext(TestContext.Parameters["ConnectionString"].ToString()));

            _productsRepoMock = new Mock<IProductsRepository>();
            _productsRepoMock.Setup(x => x.GetProducts(It.IsAny<IEnumerable<int>>())).Returns(new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    UnitPrice = 100
                },
                 new Product()
                {
                    ProductId = 2,
                    UnitPrice = 100
                }
            });

            _ordersRepoMock = new Mock<IOrdersRepository>();
            //mock.Setup(x => x.AddOrder()).Returns(lUnauthorizedUser);

            //var _allCustomers = _customersRepo.GetAllCustomers();
            _orderService = new OrderService(_productsRepoMock.Object, _ordersRepoMock.Object);
        }

        [Test]
        public void CanCreateOrder()
        {
            _orderService.CreateOrder(new CreateOrderViewModel()
            {
                CustomerId = "AAA",
                Products = new List<ProductQuantityViewModel>()
                {
                    new ProductQuantityViewModel()
                    {
                        ProductId = 1,
                        Quantity = 1
                    }, 
                    new ProductQuantityViewModel()
                    {
                        ProductId = 2,
                        Quantity = 1
                    }
                }
            });

            _ordersRepoMock.Verify(mock => mock.AddOrder(It.IsAny<Order>()), Times.Once());
            _ordersRepoMock.Verify(mock => mock.SaveChanges(), Times.Once());
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
