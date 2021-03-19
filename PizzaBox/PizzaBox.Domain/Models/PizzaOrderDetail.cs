using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class PizzaOrderDetail
    {
        public int PizzaOrderDetailId { get; set; }
        public int PizzaOrderId { get; set; }
        public int PizzaId { get; set; }
        public int PizzaQuantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public double Price { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual PizzaOrder PizzaOrder { get; set; }
    }
}
