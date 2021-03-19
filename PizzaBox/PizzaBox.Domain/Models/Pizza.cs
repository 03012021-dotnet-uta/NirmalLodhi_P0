using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaOrderDetails = new HashSet<PizzaOrderDetail>();
        }

        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public int PizzaSizeId { get; set; }
        public int PizzaCrustId { get; set; }
        public int PizzaTopping1 { get; set; }
        public int PizzaTopping2 { get; set; }
        public int? PizzaTopping3 { get; set; }
        public int? PizzaTopping4 { get; set; }
        public int? PizzaTopping5 { get; set; }
        public double Price { get; set; }

        public virtual PizzaCrust PizzaCrust { get; set; }
        public virtual PizzaSize PizzaSize { get; set; }
        public virtual PizzaTopping PizzaTopping1Navigation { get; set; }
        public virtual PizzaTopping PizzaTopping2Navigation { get; set; }
        public virtual PizzaTopping PizzaTopping3Navigation { get; set; }
        public virtual PizzaTopping PizzaTopping4Navigation { get; set; }
        public virtual PizzaTopping PizzaTopping5Navigation { get; set; }
        public virtual ICollection<PizzaOrderDetail> PizzaOrderDetails { get; set; }
    }
}
