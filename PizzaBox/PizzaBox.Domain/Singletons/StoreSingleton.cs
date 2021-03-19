using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstract;


namespace PizzaBox.Domain.Singletons
{
    /// <summary>
    /// 
    /// </summary>
    public class StoreSingleton
    {
        private static StoreSingleton _storeSingleton;
        public List<AStore> Stores { get; set; } // print job

        public static StoreSingleton Instance
        {
            get
            {
                if (_storeSingleton == null)
                {
                    _storeSingleton = new StoreSingleton(); // printer
                }

                return _storeSingleton;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private StoreSingleton()
        {
            // var fs = new FileStorage();

            // if (Stores == null)
            // {
            //   Stores = fs.ReadFromXml<AStore>().ToList();
            // }
        }

      //  public void Seeding()
      //  {
      //      var stores = new List<AStore>
      //{
      //      string ConString = @"Data Source=QBLAP100\SQL1;Initial Catalog=OPOS;Integrated Security=True";
      //      //create instanace of database connection
      //      SqlConnection conn = new SqlConnection(ConString);
      //      conn.Open();

      //      // create a command object identifying the stored procedure
      //      SqlCommand cmd = new SqlCommand("uspAddLogin", conn);

      //  };

            //var fs = new FileStorage();

            //fs.WriteToXml<AStore>(stores);
            //Stores = fs.ReadFromXml<AStore>().ToList();
        }

        /* SINGLETON METHOD WORKFLOW */

        // public static StoreSingleton GetInstance()
        // {
        //   if (_storeSingleton == null)
        //   {
        //     _storeSingleton = new StoreSingleton(); // printer
        //   }

        //   return _storeSingleton;
        // }
    }

