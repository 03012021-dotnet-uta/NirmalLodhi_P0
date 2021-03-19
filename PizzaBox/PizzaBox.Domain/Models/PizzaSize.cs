using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class PizzaSize
    {
        public PizzaSize()
        {
            PizzaCrusts = new HashSet<PizzaCrust>();
            PizzaToppings = new HashSet<PizzaTopping>();
            Pizzas = new HashSet<Pizza>();
        }

        public int PizzaSizeId { get; set; }
        public string PizzaSize1 { get; set; }
        public string Dimenssions { get; set; }

        public virtual ICollection<PizzaCrust> PizzaCrusts { get; set; }
        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
