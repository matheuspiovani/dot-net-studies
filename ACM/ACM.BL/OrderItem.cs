using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderItem
    {
        public OrderItem()
        {

        }

        public OrderItem(int orderItemId)
        {
            OrderItemId = orderItemId;
        }

        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int Quantity { get; set; }


        public DateTimeOffset? OrderItemDate{ get; set; }

        /// <summary>
        /// Validates the orderItem data
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            var isValid = true;

            if (Quantity <= 0) isValid = false;
            if (ProductId <= 0) isValid = false;
            if (PurchasePrice <= 0) isValid = false;

            return isValid;
        }

        /// <summary>
        /// Retrieve one orderItem.
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <returns></returns>
        public OrderItem Retrieve(int orderItemId)
        {
            // 
            return new OrderItem();
        }

        public List<OrderItem> Retrieve()
        {
            //
            return new List<OrderItem>();
        }

        /// <summary>
        /// Saves the current orderItem.
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            //

            return true;
        }
    }
}
