using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            //-- Arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins",
                Adresses = new List<Address> ()
                {
                    new Address()
                    {
                        AddressType = 1,
                        StreetLine1 = "Bag End",
                        StreetLine2 = "Bagshot row",
                        City = "Hobbiton",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "144"
                    },
                    new Address()
                        {
                            AddressType = 2,
                            StreetLine1 = "Green Dragon",
                            City = "Bywater",
                            State = "Shire",
                            Country = "Middle Earth",
                            PostalCode = "144"
                        }
                    }
            };

            //-- Act
            var actual = customerRepository.Retrieve(1);

            //-- Assert
            Assert.AreEqual(expected.CustomerId, actual.CustomerId);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);

            for (int i = 0; i < 1; i++)
            {
                Assert.AreEqual(expected.Adresses[i].AddressType, actual.Adresses[i].AddressType);
                Assert.AreEqual(expected.Adresses[i].StreetLine1, actual.Adresses[i].StreetLine1);
                Assert.AreEqual(expected.Adresses[i].City, actual.Adresses[i].City);
                Assert.AreEqual(expected.Adresses[i].State, actual.Adresses[i].State);
                Assert.AreEqual(expected.Adresses[i].Country, actual.Adresses[i].Country);
                Assert.AreEqual(expected.Adresses[i].PostalCode, actual.Adresses[i].PostalCode);
            }
        }
    }
}
