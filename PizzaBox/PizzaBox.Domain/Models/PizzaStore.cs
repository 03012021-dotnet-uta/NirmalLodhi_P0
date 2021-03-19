using System;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Domain.Abstract;
using PizzaBox.Domain.Singletons;
using System.Data;
using System.Data.SqlClient;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class PizzaStore
    {
        public PizzaStore()
        {
            PizzaOrders = new HashSet<PizzaOrder>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<PizzaOrder> PizzaOrders { get; set; }

        public void GetPizzaStore()
        {

            //string ConString = @"Data Source=QBLAP100\SQL1;Initial Catalog=OPOS;Integrated Security=True";
            ////create instanace of database connection
            //SqlConnection conn = new SqlConnection(ConString);
            //conn.Open();

            // ARRANGE
            using (SqlConnection conn = new SqlConnection())
            {
                DataSet tmp = new DataSet();

                conn.ConnectionString = @"Data Source=QBLAP100\SQL1;Initial Catalog=OPOS;Integrated Security=True"; ;

                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("Select StoreID,StoreName from PizzaStore order by 1 ", conn);

                adapter.Fill(tmp);
            }
        }


        // print all the stores available, must be from file or db
        //foreach (var item in ss.Stores)
        //{
        //    System.Console.WriteLine(item);
        //}

    }
}
