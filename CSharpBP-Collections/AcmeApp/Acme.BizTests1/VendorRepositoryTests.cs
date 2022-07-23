using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void RetrieveWithIteratorTest() {
            // Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>() {
                { new Vendor() { VendorId = 1, CompanyName = "A", Email = "mlp@mlp.com.br" } },
                { new Vendor() { VendorId = 2, CompanyName = "B", Email = "mlp@mlp.com.br" } }
            };

            // Act
            var vendorIterator = repository.RetrieveWithIterator();
            foreach (var item in vendorIterator) {
                Console.WriteLine(item);
            }

            var actual = vendorIterator.ToList();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveAllTest() {
            // Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>() {
                { new Vendor() { VendorId = 2, CompanyName = "B Toy", Email = "a@a.com"} },
                { new Vendor() { VendorId = 4, CompanyName = "D Toy", Email = "a@a.com"} },
                { new Vendor() { VendorId = 3, CompanyName = "Toy C", Email = "a@a.com"} }
            };

            // Act
            var vendors = repository.RetrieveAll();
            /*            var vendorQuery = from v in vendors
                                          where v.CompanyName.Contains("Toy")
                                          orderby v.CompanyName
                                          select v;*/
            /*var vendorQuery = vendors.Where(FilterCompanies)
                                    .OrderBy(OrderCompaniesByName);*/
            var vendorQuery = vendors.Where(v => v.CompanyName.Contains("Toy"))
                                     .OrderBy(v => v.CompanyName);

            // Assert
            CollectionAssert.AreEqual(expected, vendorQuery.ToList());
        }

        private bool FilterCompanies(Vendor v) {
            return v.CompanyName.Contains("Toy");
        }

        private string OrderCompaniesByName(Vendor v) => v.CompanyName;
    }
}