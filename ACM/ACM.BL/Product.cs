using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Product : EntityBase, ILoggable
    {
        public Product()
        {

        }

        public Product(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; set; }
        public decimal? CurrentPrice { get; set; }
        public string ProductDescription { get; set; }
        private string _productName;
        public string ProductName {
            get
            {
                return StringHandler.InsertSpaces(_productName);
            }
            set
            {
                _productName = value;
            }
        }

        /// <summary>
        /// Validates the product data
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(ProductName)) isValid = false;
            if (CurrentPrice == null) isValid = false;

            return isValid;
        }

        public override string ToString() => ProductName;

        public List<Product> Retrieve()
        {
            //
            return new List<Product>();
        }

        public string Log() => $"{ProductName} - {ProductDescription}";
    }
}
