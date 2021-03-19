using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class AComponent
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
