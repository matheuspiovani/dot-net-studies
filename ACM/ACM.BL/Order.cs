using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Order : EntityBase
    {
        public Order()
        {
            OrdemItems = new List<OrderItem>();
        }

        public Order(int orderId) : this()
        {
            OrderId = orderId;
        }

        public int CustomerId { get; set; }
        public List<OrderItem> OrdemItems { get; set; }
        public int ShippingAddressId { get; set; }
        public int OrderId { get; set; }
        public DateTimeOffset? OrderDate{ get; set; }

        public override string ToString() => $"{OrderDate.Value.Date} ({OrderId})";

        /// <summary>
        /// Validates the order data
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            var isValid = true;

            if (OrderDate == null) isValid = false;

            return isValid;
        }

        public List<Order> Retrieve()
        {
            //
            return new List<Order>();
        }

    }
}
