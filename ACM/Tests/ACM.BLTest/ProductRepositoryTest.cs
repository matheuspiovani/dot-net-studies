using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACM.BLTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            //-- Arrange
            var productRepository = new ProductRepository();
            var expected = new Product(2)
            {
                CurrentPrice = 15.96M,
                ProductDescription = "Assorted Size Set of 4 Bright Yellow Sunflowers",
                ProductName = "Sunflowers"
            };

            //-- Act
            var actual = productRepository.Retrieve(2);

            //-- Assert
            Assert.AreEqual(expected.CurrentPrice, actual.CurrentPrice);
            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
            Assert.AreEqual(expected.ProductName, actual.ProductName);
        }

        [TestMethod]
        public void SaveTestMissingPrice()
        {
            //-- Arrange
            var productRepository = new ProductRepository();
            var expected = new Product(2)
            {
                ProductDescription = "Assorted Size Set of 4 Bright Yellow Sunflowers",
                ProductName = "Sunflowers",
                HasChanges = true
            };

            //-- Act
            var actual = productRepository.Save(expected);

            //-- Assert
            Assert.AreEqual(false, actual);
        }
    }
}
