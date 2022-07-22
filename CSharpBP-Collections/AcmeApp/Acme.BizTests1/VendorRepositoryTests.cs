﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests {
    [TestClass()]
    public class VendorRepositoryTests {
        [TestMethod()]
        public void RetrieveValueTest() {
            var repository = new VendorRepository();
            var expected = 42;

            var actual = repository.RetrieveValue<int>("Delete from vendors where true;", 42);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueStringTest() {
            var repository = new VendorRepository();
            var expected = "Hi";

            var actual = repository.RetrieveValue<string>("Delete from vendors where true;", "Hi");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueObjectTest() {
            var repository = new VendorRepository();
            var vendor = new Vendor();
            var expected = vendor;

            var actual = repository.RetrieveValue<Vendor>("Delete from vendors where true;", vendor);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTest() {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();
            expected.Add(new Vendor() { VendorId = 1, CompanyName = "A", Email = "mlp@mlp.com.br" });
            expected.Add(new Vendor() { VendorId = 2, CompanyName = "B", Email = "mlp@mlp.com.br" });


            //Act
            var actual = repository.Retrieve();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}