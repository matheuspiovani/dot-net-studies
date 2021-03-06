using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        #region Constructors
        public Product()
        {
            /*
            var colorOptions = new List<string>();
            colorOptions.Add("Red");
            colorOptions.Add("Expresso");
            colorOptions.Add("White");
            colorOptions.Add("Navy");
            colorOptions.Insert(2, "Purple");
            colorOptions.Remove("White");
            */

            var colorOptions = new List<string> { "Red", "Espresso", "White", "Navy" };

            foreach (var colorOption in colorOptions) {
                Console.WriteLine(colorOption);
            }

            /*
            var states = new Dictionary<string, string>();
            states.Add("CA", "California");
            states.Add("WA", "Washington");
            states.Add("NY", "Hawaii");
            */

            var states = new Dictionary<string, string>() {
                {"CA", "California" },
                {"WA", "Washington" },
                {"NY", "New York" },
            };
            Console.WriteLine(states);

        }
        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
        }
        #endregion

        #region Properties
        public DateTime? AvailabilityDate { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        private string productName;
        public string ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";

                }
                else
                {
                    productName = value;

                }
            }
        }

        private Vendor productVendor;
        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        #endregion

        /// <summary>
        /// Calculates the suggested retail price
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        public OperationResultDecimal CalculateSuggestedPrice(decimal markupPercent) {
            var message = "";
            if (markupPercent <= 0m) {
                message = "Invalid markup percentage";
            }
            else if (markupPercent < 10) {
                message = "Below recommended markup percentage";
            }
            var value = this.Cost + (this.Cost * markupPercent / 100);

            var operationResult = new OperationResultDecimal(value, message);

            return operationResult;
        }

        public override string ToString()
        {
            return this.ProductName + " (" + this.ProductId + ")";
        }
    }
}
