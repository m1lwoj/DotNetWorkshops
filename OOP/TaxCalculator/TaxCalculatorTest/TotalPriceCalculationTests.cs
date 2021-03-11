using NUnit.Framework;

namespace TaxCalculatorTest
{
    public class TotalPriceCalculator
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(33.48, "ibuprom", 3, 10.12)]
        [TestCase(4.97, "watermelon", 1, 4.21, true)]
        [TestCase(5.56, "watermelon", 1, 5.15)]
        [TestCase(1550.08, "chair", 2, 692.12)]
        [TestCase(1228.61, "chair", 2, 503.53, true)]
        [TestCase(35238.35, "laptop", 5, 5299.0, true)]
        public void TestTotalPriceCalculation(double expectedTotalPrice, string product, int quantity, double productPrice, bool isImported = false)
        {
            var totalPrice = Program.CalculateTotalPrice(product, quantity, (decimal)productPrice, isImported);

            Assert.AreEqual(
                (decimal)expectedTotalPrice,
                totalPrice,
                $"Invalid total price for '{product}', it should be {expectedTotalPrice}, but was {totalPrice}");
        }
    }
}


