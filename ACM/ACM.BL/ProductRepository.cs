using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public  class ProductRepository
    {
        /// <summary>
        /// Retrieve one product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product Retrieve(int productId)
        {
            Product product = new Product(productId);

            if (productId == 2)
            {
                product.ProductName = "Sunflowers";
                product.ProductDescription = "Assorted Size Set of 4 Bright Yellow Sunflowers";
                product.CurrentPrice = 15.96M;
            }
            Console.WriteLine($"Object: {product.ToString()}");
            return product;
        }

        /// <summary>
        /// Saves the current product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Save(Product product)
        {
            var success = true;

            if (product.HasChanges)
            {
                if (product.IsValid)
                {
                    if (product.IsNew)
                    {
                        // Call store
                    }
                    else
                    {
                        // Call update
                    }
                }
                else
                {
                    success = false;
                }
            
            }

            return success;
        }
    }
}
