using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {
        private List<Vendor> vendors;

        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        public T RetrieveValue<T>(string sql, T defaultValue) {
            T value = defaultValue;

            return value;
        }

        public ICollection<Vendor> Retrieve() {
            if (vendors == null) {
                vendors = new List<Vendor>();

                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "A", Email = "mlp@mlp.com.br" });
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "B", Email = "mlp@mlp.com.br" });
            }
            Console.WriteLine(vendors[1]);


            return vendors;
        }
        /*
        public Vendor[] RetrieveArray() {
            var vendors = new Vendor[] {
                new Vendor() { VendorId = 1, CompanyName = "A", Email = "mlp@mlp.com.br" },
                new Vendor() { VendorId = 2, CompanyName = "B", Email = "mlp@mlp.com.br" }
            };

            return vendors;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Vendor> RetrieveWithKeys() {
            var vendors = new Dictionary<string, Vendor>() {
                { "ABC Corp", new Vendor() {
                    VendorId = 5, CompanyName = "ABC Corp", Email = "Abc@abc.com"
                } },
                { "QWE Corp", new Vendor() {
                    VendorId = 5, CompanyName = "QWE Corp", Email = "QWE@abc.com"
                } }
            };
            Console.WriteLine(vendors);
            Console.WriteLine(vendors["ABC Corp"]);
            Vendor vendor;
            if(vendors.TryGetValue("BLABLA", out vendor)) {
                Console.WriteLine(vendor);

            }
            else {
                Console.WriteLine("Nope!");
            }

            foreach (var companyName in vendors.Keys) {
                Console.WriteLine(companyName);
                Console.WriteLine(vendors[companyName]);
            }

            foreach (var vend in vendors.Values) {
                Console.WriteLine(vend);
            }

            foreach(var element in vendors) {
                var vend = element.Value;
                var key = element.Key;
                Console.WriteLine($"{key} {vend}");
            }

            return vendors;
        }*/

        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }

        public IEnumerable<Vendor> RetrieveWithIterator() {
            this.Retrieve();

            foreach(var vendor in vendors) {
                Console.WriteLine($"Vendo id: {vendor.VendorId}");
                yield return vendor;
            }
        }


        public IEnumerable<Vendor> RetrieveAll() {
            var vendors = new List<Vendor>() {
                { new Vendor() { VendorId = 1, CompanyName = "A", Email = "a@a.com"} },
                { new Vendor() { VendorId = 2, CompanyName = "B Toy", Email = "a@a.com"} },
                { new Vendor() { VendorId = 3, CompanyName = "Toy C", Email = "a@a.com"} },
                { new Vendor() { VendorId = 4, CompanyName = "D Toy", Email = "a@a.com"} },
                { new Vendor() { VendorId = 5, CompanyName = "E", Email = "a@a.com"} },
                { new Vendor() { VendorId = 6, CompanyName = "F", Email = "a@a.com"} },
                { new Vendor() { VendorId = 7, CompanyName = "B", Email = "a@a.com"} }
            };

            return vendors;
        }
    }
}
