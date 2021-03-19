using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class PizzaOrder
    {
        public int PizzaOrderId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
        public DateTime? OrderDateTime { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? OrderServedDateTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual PizzaStore Store { get; set; }
        public virtual PizzaOrderDetail PizzaOrderDetail { get; set; }
    }
}
