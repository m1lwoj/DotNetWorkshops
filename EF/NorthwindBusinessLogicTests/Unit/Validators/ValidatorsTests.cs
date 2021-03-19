using NUnit.Framework;
using System;
using System.Collections.Generic;
using Shouldly;
using Microsoft.EntityFrameworkCore;
using NorthwindData.Models;
using System.Threading.Tasks;
using NortwindBusinessLogic.ViewModels;

namespace NorthwindBusinessLogicTests.Unit
{
    public class ValidatorsTests
    {
        private ProductsOnStockValidator _validator;
        private List<Product> _dbProducts;

        [SetUp]
        public void Setup()
        {
            _validator = new ProductsOnStockValidator();
            _dbProducts = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    ProductName = "pierwszy",
                    UnitsInStock = (short)1
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "drugi",
                    UnitsInStock = (short)2
                },
                new Product()
                {
                    ProductId = 3,
                    ProductName = "trzeci",
                    UnitsInStock = (short)3
                }
            };
        }

        [Test]
        public void WhenProducOutOfStockthenThrowsException()
        {
            //arrange
            var productsToValidate = CreateOutOfStockProducts();

            //act & assert
            Should.Throw<OutOfStockException>(() =>  _validator.Validate(_dbProducts, productsToValidate))
                .Message.ShouldContain("trzeci");
        }

        [Test]
        public void WhenEnoughProductsThenOk()
        {
            //arrange
            var productsToValidate = CreateProducts();

            //act & assert
            Should.NotThrow(() =>
            {
                _validator.Validate(_dbProducts, productsToValidate);
            });
        }

        private List<ProductQuantityViewModel> CreateOutOfStockProducts()
        {
           return new List<ProductQuantityViewModel>()
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
                },
                new ProductQuantityViewModel()
                {
                    ProductId = 3,
                    Quantity = 4
                }
            };
        }

        private List<ProductQuantityViewModel> CreateProducts()
        {
            return new List<ProductQuantityViewModel>()
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
                },
                new ProductQuantityViewModel()
                {
                    ProductId = 3,
                    Quantity = 2
                }
            };
        }
    }
}
