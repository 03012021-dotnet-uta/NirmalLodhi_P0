using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using PizzaBox.Domain.Abstract;
using PizzaBox.Domain.Singletons;
using System.Data;
using System.Data.SqlClient;
#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class Customer
    {
        public Customer()
        {
            //PizzaOrders = new HashSet<PizzaOrder>();
            PizzaOrders = new HashSet<PizzaOrder>();
        }

        public int CustomerId { get; set; }
        public string LoginName { get; set; }
        //public byte[] PasswordHash { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<PizzaOrder> PizzaOrders { get; set; }

        public void GetCustomer()
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

                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Customer order by 1 ", conn);

                adapter.Fill(tmp);
            }
        }

    }
}
