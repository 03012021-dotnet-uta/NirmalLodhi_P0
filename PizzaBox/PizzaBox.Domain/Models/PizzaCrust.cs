using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class PizzaCrust
    {
        public PizzaCrust()
        {
            Pizzas = new HashSet<Pizza>();
        }

        public int PizzaCrustId { get; set; }
        public string PizzaCrustDescription { get; set; }
        public int PizzaSizeId { get; set; }
        public double? CrustPrice { get; set; }

        public virtual PizzaSize PizzaSize { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
