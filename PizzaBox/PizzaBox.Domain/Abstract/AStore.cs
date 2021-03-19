using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstract
{
    /// <summary>
    /// 
    ///// </summary>
    //[XmlInclude(typeof(ChicagoStore))]
    //[XmlInclude(typeof(NewYorkStore))]
    public abstract class AStore
    {
        public string Name { get; set; }
        // public List<Order> Orders { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
