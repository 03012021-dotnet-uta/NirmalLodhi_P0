using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class PizzaTopping
    {
        public PizzaTopping()
        {
            PizzaPizzaTopping1Navigations = new HashSet<Pizza>();
            PizzaPizzaTopping2Navigations = new HashSet<Pizza>();
            PizzaPizzaTopping3Navigations = new HashSet<Pizza>();
            PizzaPizzaTopping4Navigations = new HashSet<Pizza>();
            PizzaPizzaTopping5Navigations = new HashSet<Pizza>();
        }

        public int PizzaToppingId { get; set; }
        public string PizzaToppingDescription { get; set; }
        public int PizzaSizeId { get; set; }
        public double? ToppingPrice { get; set; }

        public virtual PizzaSize PizzaSize { get; set; }
        public virtual ICollection<Pizza> PizzaPizzaTopping1Navigations { get; set; }
        public virtual ICollection<Pizza> PizzaPizzaTopping2Navigations { get; set; }
        public virtual ICollection<Pizza> PizzaPizzaTopping3Navigations { get; set; }
        public virtual ICollection<Pizza> PizzaPizzaTopping4Navigations { get; set; }
        public virtual ICollection<Pizza> PizzaPizzaTopping5Navigations { get; set; }
    }
}
