using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class APizza
    {
        //public Crust Crust { get; set; }
        //public Size Size { get; set; }
        //public List<Topping> Toppings { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public APizza()
        {
            FactoryMethod();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FactoryMethod()
        {
            AddCrust();
            AddSize();
            AddToppings();
        }

        protected abstract void AddCrust();
        protected abstract void AddSize();
        protected abstract void AddToppings();
    }
}
