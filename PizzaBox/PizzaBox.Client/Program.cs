using System;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Domain.Abstract;
using PizzaBox.Domain.Singletons;
using System.Data;
using System.Data.SqlClient;

namespace PizzaBox.Client
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {


            //PlayWithStore();
            AsACustomer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        //public string  CustomerStoreID;
        public static void GetPizzaStore()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                DataSet tmp = new DataSet();
                 

                conn.ConnectionString = @"Data Source=QBLAP100\SQL1;Initial Catalog=OPOS;Integrated Security=True"; ;

                conn.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("Select StoreID,StoreName from PizzaStore order by 1 ", conn);

                adapter.Fill(tmp);
                string Sid;
                string sname;
                Console.WriteLine("Please select the Store to place order");
                Console.WriteLine("StoreID StoreName");
                for (int x = 0; x < 2; x++)
                    
                {
                    
                    DataRow recCustomers = tmp.Tables[0].Rows[x];
                    Sid = (recCustomers["StoreID"]).ToString();
                    sname = ((String)recCustomers["StoreName"]).ToString();
                    Console.WriteLine(Sid + " " + sname);


                }



            }
        }

        public static void CustomerLogin()
        {
            
            Console.WriteLine("Enter your Login Name: ");
            var lName = Console.ReadLine();
            Console.WriteLine("Enter your Password Name: ");
            var lPassword = Console.ReadLine();
            
            //connection string 
            string ConString = @"Data Source=QBLAP100\SQL1;Initial Catalog=OPOS;Integrated Security=True";

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(ConString);
            conn.Open();

            // create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("uspLogin", conn);

            // set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter to command, which will be passed to the stored procedure

            cmd.Parameters.AddWithValue("@pLoginName", SqlDbType.NVarChar).Value = lName;
            cmd.Parameters.AddWithValue("@pPassword", SqlDbType.NVarChar).Value = lPassword;

            // parameter is OUT parameter.
            IDbDataParameter response = cmd.CreateParameter();
            response.ParameterName = "@responseMessage";
            response.Direction = System.Data.ParameterDirection.Output;
            response.DbType = System.Data.DbType.String;
            response.Size = 50;
            cmd.Parameters.Add(response);

            // execute the command
            cmd.ExecuteNonQuery();

            Console.WriteLine(response.Value);

            if (response.Value.ToString() == "Invalid login")
            {
                Console.WriteLine("Invalid login, Try again or Regiter if you dont have login");
                AsACustomer();

            }
            //else
            //{
            //    GetPizzaStore();
            //    var CustomerStoreID=Console.ReadLine();
            //    Console.Clear();
            //    Console.WriteLine("Select the Option from below");

            //}
            

        }

        public static void CustomerRegister()
        {
            Console.Clear();    
            Console.WriteLine("Enter your Login: ");
            var lName = Console.ReadLine().Trim();
            if (lName.Length == 0)
            {
                Console.WriteLine("You must enter a value ");
                lName = Console.ReadLine().Trim();
            }
            Console.WriteLine("Enter your Password: ");
            var lPassword = Console.ReadLine().Trim();
            if (lPassword.Length == 0)
            {
                Console.WriteLine("You must enter a value ");
                lPassword = Console.ReadLine().Trim();
            }
            Console.WriteLine("Enter your First Name: ");
            var lFirstName = Console.ReadLine().Trim();
            Console.WriteLine("Enter your Last Name: ");
            var lLastName = Console.ReadLine().Trim();
            Console.WriteLine("Enter your Phone : ");
            var lPhone = Console.ReadLine().Trim();
            Console.WriteLine("Enter your E-Mail address: ");
            var lEmail = Console.ReadLine().Trim();

            //connection string 
            string ConString = @"Data Source=QBLAP100\SQL1;Initial Catalog=OPOS;Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(ConString);
            conn.Open();
            // create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("uspAddLogin", conn);

            // set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter to command, which will be passed to the stored procedure

            cmd.Parameters.AddWithValue("@pLogin", SqlDbType.NVarChar).Value = lName;
            cmd.Parameters.AddWithValue("@pPassword", SqlDbType.NVarChar).Value = lPassword;
            cmd.Parameters.AddWithValue("@pFirstName", SqlDbType.NVarChar).Value = lFirstName;
            cmd.Parameters.AddWithValue("@pLastName", SqlDbType.NVarChar).Value = lLastName;
            cmd.Parameters.AddWithValue("@pPhone", SqlDbType.BigInt).Value = lPhone;
            cmd.Parameters.AddWithValue("@pEmail", SqlDbType.NVarChar).Value = lEmail;

            // parameter is OUT parameter.
            IDbDataParameter response = cmd.CreateParameter();
            response.ParameterName = "@responseMessage";
            response.Direction = System.Data.ParameterDirection.Output;
            response.DbType = System.Data.DbType.String;
            response.Size = 50;
            cmd.Parameters.Add(response);

            // execute the command
            cmd.ExecuteNonQuery();

            Console.WriteLine(response.Value);

        }


        public static void PlaceOrder()
        {
            Console.WriteLine("Below Pizza's are available, please enter your option to order:");
            DataSet tmp = new DataSet();
            //connection string 
            string ConString = @"Data Source=QBLAP100\SQL1;Initial Catalog=OPOS;Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(ConString);
            conn.Open();

            var qstr = " Select top 10 PizzaId,PizzaName, PizzaSize, PizzaCrustDescription as Crust, pt.PizzaToppingDescription tp1, pt2.PizzaToppingDescription tp2 , pt3.PizzaToppingDescription tp3, Price " +
" from Pizza p" +
" Left Join PizzaSize ps on p.PizzaSizeID = ps.PizzaSizeID " +
 " Left join PizzaCrust pc on p.PizzaCrustID = pc.PizzaCrustID " +
 " left join  PizzaTopping pt on p.PizzaTopping1 = pt.PizzaToppingID " +
 " left join  PizzaTopping pt2 on p.PizzaTopping2 = pt2.PizzaToppingID " +
 " left join  PizzaTopping pt3 on p.PizzaTopping3 = pt3.PizzaToppingID " +
" order by 1";
            
            SqlDataAdapter adapter = new SqlDataAdapter(qstr, conn);

            adapter.Fill(tmp);
            string PizzaId;
            string PizzaName;
            string PizzaSize;
            string Crust;
            string tp1;
            string tp2;
            string tp3;
            string Price;
            int x = tmp.Tables[0].Rows.Count;
            Console.WriteLine("PizzaId     PizzaName                 PizzaSize    Crust              Pizza Topping                                Price");
            for (int i = 0; i < x; i++)

            {

                DataRow recCustomers = tmp.Tables[0].Rows[i];
                PizzaId = (recCustomers["PizzaId"]).ToString();
                PizzaName = (recCustomers["PizzaName"]).ToString();
                PizzaSize = (recCustomers["PizzaSize"]).ToString();
                Crust = (recCustomers["Crust"]).ToString();
                tp1 = (recCustomers["tp1"]).ToString();
                tp2 = (recCustomers["tp2"]).ToString();
                tp3 = (recCustomers["tp3"]).ToString();
                Price = (recCustomers["Price"]).ToString();

                Console.WriteLine(PizzaId+"          "+PizzaName + " " + PizzaSize + " " + Crust + " " + tp1 + " " + tp2 + " " + tp3 + " " + Price);


            }



            //// create a command object identifying the stored procedure
            //SqlCommand cmd = new SqlCommand("uspAddLogin", conn);

            //// set the command object so it knows to execute a stored procedure
            //cmd.CommandType = CommandType.StoredProcedure;

            //// add parameter to command, which will be passed to the stored procedure

            //cmd.Parameters.AddWithValue("@pLogin", SqlDbType.NVarChar).Value = lName;
            //cmd.Parameters.AddWithValue("@pPassword", SqlDbType.NVarChar).Value = lPassword;
            //cmd.Parameters.AddWithValue("@pFirstName", SqlDbType.NVarChar).Value = lFirstName;
            //cmd.Parameters.AddWithValue("@pLastName", SqlDbType.NVarChar).Value = lLastName;
            //cmd.Parameters.AddWithValue("@pPhone", SqlDbType.BigInt).Value = lPhone;
            //cmd.Parameters.AddWithValue("@pEmail", SqlDbType.NVarChar).Value = lEmail;

            //// parameter is OUT parameter.
            //IDbDataParameter response = cmd.CreateParameter();
            //response.ParameterName = "@responseMessage";
            //response.Direction = System.Data.ParameterDirection.Output;
            //response.DbType = System.Data.DbType.String;
            //response.Size = 50;
            //cmd.Parameters.Add(response);

            //// execute the command
            //cmd.ExecuteNonQuery();

            //Console.WriteLine(response.Value);

        }


        public static void DisplayOrder()
        {
            Console.WriteLine(" Below is your order History");
            DataSet tmp = new DataSet();
            //connection string 
            string ConString = @"Data Source=QBLAP100\SQL1;Initial Catalog=OPOS;Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(ConString);
            conn.Open();

            var qstr = " select po.PizzaOrderId, po.CustomerID,  c.FirstName + ', '  +c.LastName CustomerName,    StoreName,  p.PizzaName ,psz.PizzaSize, psz.Dimenssions,pod.PizzaQuantity,pod.Price ,  OrderDateTime,po.OrderStatus " +
 " from Customer c Left join PizzaOrder po on c.CustomerID = po.CustomerID left join PizzaOrderDetails pod on po.PizzaOrderId = pod.PizzaOrderId Left join PizzaStore ps on po.StoreID = ps.StoreID " +
 " left join vPizza p on pod.PizzaID = p.PizzaID left join PizzaSize psz on p.PizzaSizeID = psz.PizzaSizeID where c.CustomerID = 6";



            SqlDataAdapter adapter = new SqlDataAdapter(qstr, conn);

            adapter.Fill(tmp);
            string CustomerName;
            string StoreName;
            string PizzaName;
            string Dimenssions;
            string PizzaQuantity;
            string Price;
            string OrderDateTime;
            string OrderStatus;
            string PizzaSize;
            int x = tmp.Tables[0].Rows.Count;
            Console.WriteLine("PizzaId PizzaName            StoreName  OrderDateTime  OrderStatus PizzaQuantity Crust    PizzaSize          ");
            for (int i = 0; i < x; i++)

            {

                DataRow recCustomers = tmp.Tables[0].Rows[i];
                CustomerName = (recCustomers["CustomerName"]).ToString();
                StoreName = (recCustomers["StoreName"]).ToString();
                PizzaName = (recCustomers["PizzaName"]).ToString();
                Dimenssions = (recCustomers["Dimenssions"]).ToString();
                PizzaQuantity = (recCustomers["PizzaQuantity"]).ToString();
                Price = (recCustomers["Price"]).ToString();
                OrderDateTime = (recCustomers["OrderDateTime"]).ToString();
                OrderStatus = (recCustomers["OrderStatus"]).ToString();
                PizzaSize = (recCustomers["PizzaSize"]).ToString();

                Console.WriteLine(CustomerName + " " + StoreName + " " + PizzaName + " " + PizzaSize + " " + Dimenssions + " " + PizzaQuantity + " " + Price + " " + OrderDateTime + " " + OrderStatus);


            }




            //// create a command object identifying the stored procedure
            //SqlCommand cmd = new SqlCommand("uspAddLogin", conn);

            //// set the command object so it knows to execute a stored procedure
            //cmd.CommandType = CommandType.StoredProcedure;

            //// add parameter to command, which will be passed to the stored procedure

            //cmd.Parameters.AddWithValue("@pLogin", SqlDbType.NVarChar).Value = lName;
            //cmd.Parameters.AddWithValue("@pPassword", SqlDbType.NVarChar).Value = lPassword;
            //cmd.Parameters.AddWithValue("@pFirstName", SqlDbType.NVarChar).Value = lFirstName;
            //cmd.Parameters.AddWithValue("@pLastName", SqlDbType.NVarChar).Value = lLastName;
            //cmd.Parameters.AddWithValue("@pPhone", SqlDbType.BigInt).Value = lPhone;
            //cmd.Parameters.AddWithValue("@pEmail", SqlDbType.NVarChar).Value = lEmail;

            //// parameter is OUT parameter.
            //IDbDataParameter response = cmd.CreateParameter();
            //response.ParameterName = "@responseMessage";
            //response.Direction = System.Data.ParameterDirection.Output;
            //response.DbType = System.Data.DbType.String;
            //response.Size = 50;
            //cmd.Parameters.Add(response);

            //// execute the command
            //cmd.ExecuteNonQuery();

            //Console.WriteLine(response.Value);

        }


        public static void GetOrderHistory()
        {
            Console.WriteLine(" Below is your order History");
            DataSet tmp = new DataSet();
            //connection string 
            string ConString = @"Data Source=QBLAP100\SQL1;Initial Catalog=OPOS;Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(ConString);
            conn.Open();

            var qstr = " select po.PizzaOrderId, po.CustomerID,  c.FirstName + ', '  +c.LastName CustomerName,    StoreName,  p.PizzaName ,psz.PizzaSize, psz.Dimenssions,pod.PizzaQuantity,pod.Price ,  OrderDateTime,po.OrderStatus " +
 " from Customer c Left join PizzaOrder po on c.CustomerID = po.CustomerID left join PizzaOrderDetails pod on po.PizzaOrderId = pod.PizzaOrderId Left join PizzaStore ps on po.StoreID = ps.StoreID " +
 " left join vPizza p on pod.PizzaID = p.PizzaID left join PizzaSize psz on p.PizzaSizeID = psz.PizzaSizeID where c.CustomerID = 6";



       SqlDataAdapter adapter = new SqlDataAdapter(qstr, conn);

            adapter.Fill(tmp);
            string CustomerName;
            string StoreName;
            string PizzaName;
            string Dimenssions;
            string PizzaQuantity;
            string Price;
            string OrderDateTime;
            string OrderStatus;
            string PizzaSize;
            int x = tmp.Tables[0].Rows.Count;
            Console.WriteLine("PizzaId PizzaName            StoreName  OrderDateTime  OrderStatus PizzaQuantity Crust    PizzaSize          ");
            for (int i = 0; i < x; i++)

            {

                DataRow recCustomers = tmp.Tables[0].Rows[i];
                CustomerName = (recCustomers["CustomerName"]).ToString();
                StoreName = (recCustomers["StoreName"]).ToString();
                PizzaName = (recCustomers["PizzaName"]).ToString();
                Dimenssions = (recCustomers["Dimenssions"]).ToString();
                PizzaQuantity = (recCustomers["PizzaQuantity"]).ToString();
                Price = (recCustomers["Price"]).ToString();
                OrderDateTime = (recCustomers["OrderDateTime"]).ToString();
                OrderStatus = (recCustomers["OrderStatus"]).ToString();
                PizzaSize = (recCustomers["PizzaSize"]).ToString();

                Console.WriteLine(CustomerName  + " "+  StoreName + " " + PizzaName + " " + PizzaSize + " " + Dimenssions + " " + PizzaQuantity + " " + Price + " " + OrderDateTime + " " + OrderStatus);


            }




            //// create a command object identifying the stored procedure
            //SqlCommand cmd = new SqlCommand("uspAddLogin", conn);

            //// set the command object so it knows to execute a stored procedure
            //cmd.CommandType = CommandType.StoredProcedure;

            //// add parameter to command, which will be passed to the stored procedure

            //cmd.Parameters.AddWithValue("@pLogin", SqlDbType.NVarChar).Value = lName;
            //cmd.Parameters.AddWithValue("@pPassword", SqlDbType.NVarChar).Value = lPassword;
            //cmd.Parameters.AddWithValue("@pFirstName", SqlDbType.NVarChar).Value = lFirstName;
            //cmd.Parameters.AddWithValue("@pLastName", SqlDbType.NVarChar).Value = lLastName;
            //cmd.Parameters.AddWithValue("@pPhone", SqlDbType.BigInt).Value = lPhone;
            //cmd.Parameters.AddWithValue("@pEmail", SqlDbType.NVarChar).Value = lEmail;

            //// parameter is OUT parameter.
            //IDbDataParameter response = cmd.CreateParameter();
            //response.ParameterName = "@responseMessage";
            //response.Direction = System.Data.ParameterDirection.Output;
            //response.DbType = System.Data.DbType.String;
            //response.Size = 50;
            //cmd.Parameters.Add(response);

            //// execute the command
            //cmd.ExecuteNonQuery();

            //Console.WriteLine(response.Value);

        }


        public static void GetSize()
        {
            Console.WriteLine("Enter your Login: ");
            var lName = Console.ReadLine();
            if (lName.Length == 0)
            {
                Console.WriteLine("You must enter a value ");
                lName = Console.ReadLine();
            }
            Console.WriteLine("Enter your Password: ");
            var lPassword = Console.ReadLine();
            if (lPassword.Length == 0)
            {
                Console.WriteLine("You must enter a value ");
                lPassword = Console.ReadLine();
            }
            Console.WriteLine("Enter your First Name: ");
            var lFirstName = Console.ReadLine();
            Console.WriteLine("Enter your Last Name: ");
            var lLastName = Console.ReadLine();
            Console.WriteLine("Enter your Phone : ");
            var lPhone = Console.ReadLine();
            Console.WriteLine("Enter your E-Mail address: ");
            var lEmail = Console.ReadLine();

            //connection string 
            string ConString = @"Data Source=QBLAP100\SQL1;Initial Catalog=OPOS;Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(ConString);
            conn.Open();
            // create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("uspAddLogin", conn);

            // set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter to command, which will be passed to the stored procedure

            cmd.Parameters.AddWithValue("@pLogin", SqlDbType.NVarChar).Value = lName;
            cmd.Parameters.AddWithValue("@pPassword", SqlDbType.NVarChar).Value = lPassword;
            cmd.Parameters.AddWithValue("@pFirstName", SqlDbType.NVarChar).Value = lFirstName;
            cmd.Parameters.AddWithValue("@pLastName", SqlDbType.NVarChar).Value = lLastName;
            cmd.Parameters.AddWithValue("@pPhone", SqlDbType.BigInt).Value = lPhone;
            cmd.Parameters.AddWithValue("@pEmail", SqlDbType.NVarChar).Value = lEmail;

            // parameter is OUT parameter.
            IDbDataParameter response = cmd.CreateParameter();
            response.ParameterName = "@responseMessage";
            response.Direction = System.Data.ParameterDirection.Output;
            response.DbType = System.Data.DbType.String;
            response.Size = 50;
            cmd.Parameters.Add(response);

            // execute the command
            cmd.ExecuteNonQuery();

            Console.WriteLine(response.Value);

        }

        public static void GetToppings()
        {
            Console.WriteLine("Enter your Login: ");
            var lName = Console.ReadLine();
            if (lName.Length == 0)
            {
                Console.WriteLine("You must enter a value ");
                lName = Console.ReadLine();
            }
            Console.WriteLine("Enter your Password: ");
            var lPassword = Console.ReadLine();
            if (lPassword.Length == 0)
            {
                Console.WriteLine("You must enter a value ");
                lPassword = Console.ReadLine();
            }
            Console.WriteLine("Enter your First Name: ");
            var lFirstName = Console.ReadLine();
            Console.WriteLine("Enter your Last Name: ");
            var lLastName = Console.ReadLine();
            Console.WriteLine("Enter your Phone : ");
            var lPhone = Console.ReadLine();
            Console.WriteLine("Enter your E-Mail address: ");
            var lEmail = Console.ReadLine();

            //connection string 
            string ConString = @"Data Source=QBLAP100\SQL1;Initial Catalog=OPOS;Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(ConString);
            conn.Open();
            // create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("uspAddLogin", conn);

            // set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter to command, which will be passed to the stored procedure

            cmd.Parameters.AddWithValue("@pLogin", SqlDbType.NVarChar).Value = lName;
            cmd.Parameters.AddWithValue("@pPassword", SqlDbType.NVarChar).Value = lPassword;
            cmd.Parameters.AddWithValue("@pFirstName", SqlDbType.NVarChar).Value = lFirstName;
            cmd.Parameters.AddWithValue("@pLastName", SqlDbType.NVarChar).Value = lLastName;
            cmd.Parameters.AddWithValue("@pPhone", SqlDbType.BigInt).Value = lPhone;
            cmd.Parameters.AddWithValue("@pEmail", SqlDbType.NVarChar).Value = lEmail;

            // parameter is OUT parameter.
            IDbDataParameter response = cmd.CreateParameter();
            response.ParameterName = "@responseMessage";
            response.Direction = System.Data.ParameterDirection.Output;
            response.DbType = System.Data.DbType.String;
            response.Size = 50;
            cmd.Parameters.Add(response);

            // execute the command
            cmd.ExecuteNonQuery();

            Console.WriteLine(response.Value);

        }

        public static void GetCrust()
        {
            Console.WriteLine("Enter your Login: ");
            var lName = Console.ReadLine();
            if (lName.Length == 0)
            {
                Console.WriteLine("You must enter a value ");
                lName = Console.ReadLine();
            }
            Console.WriteLine("Enter your Password: ");
            var lPassword = Console.ReadLine();
            if (lPassword.Length == 0)
            {
                Console.WriteLine("You must enter a value ");
                lPassword = Console.ReadLine();
            }
            Console.WriteLine("Enter your First Name: ");
            var lFirstName = Console.ReadLine();
            Console.WriteLine("Enter your Last Name: ");
            var lLastName = Console.ReadLine();
            Console.WriteLine("Enter your Phone : ");
            var lPhone = Console.ReadLine();
            Console.WriteLine("Enter your E-Mail address: ");
            var lEmail = Console.ReadLine();

            //connection string 
            string ConString = @"Data Source=QBLAP100\SQL1;Initial Catalog=OPOS;Integrated Security=True";
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(ConString);
            conn.Open();
            // create a command object identifying the stored procedure
            SqlCommand cmd = new SqlCommand("uspAddLogin", conn);

            // set the command object so it knows to execute a stored procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameter to command, which will be passed to the stored procedure

            cmd.Parameters.AddWithValue("@pLogin", SqlDbType.NVarChar).Value = lName;
            cmd.Parameters.AddWithValue("@pPassword", SqlDbType.NVarChar).Value = lPassword;
            cmd.Parameters.AddWithValue("@pFirstName", SqlDbType.NVarChar).Value = lFirstName;
            cmd.Parameters.AddWithValue("@pLastName", SqlDbType.NVarChar).Value = lLastName;
            cmd.Parameters.AddWithValue("@pPhone", SqlDbType.BigInt).Value = lPhone;
            cmd.Parameters.AddWithValue("@pEmail", SqlDbType.NVarChar).Value = lEmail;

            // parameter is OUT parameter.
            IDbDataParameter response = cmd.CreateParameter();
            response.ParameterName = "@responseMessage";
            response.Direction = System.Data.ParameterDirection.Output;
            response.DbType = System.Data.DbType.String;
            response.Size = 50;
            cmd.Parameters.Add(response);

            // execute the command
            cmd.ExecuteNonQuery();

            Console.WriteLine(response.Value);

        }



        public static void PlayWithStore()
        {
            foreach (var store in StoreSingleton.Instance.Stores)
            {
                Console.WriteLine(store);
            }
        }

        public static void AsACustomer()
        {
            //var ss = StoreSingleton.Instance;
            Console.WriteLine("");
            Console.WriteLine("                                     *****   Welcome to the Pizza Ordering System    ****");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press 1 to Login");
            Console.WriteLine("Press 2 to Register, if you dont have Login already");
            Console.WriteLine("Press 3 to EXIT");
            var LoginYN = Console.ReadLine().Trim();

            if (int.Parse(LoginYN) == 1)
            {
                CustomerLogin();
                GetPizzaStore();

            }
            else if (int.Parse(LoginYN) == 2)
            {
                CustomerRegister();
                CustomerLogin();
                
            }

            else
            {
                Environment.Exit(0);
            }

           

            // select a store
            var input = Console.ReadLine();

            // print the customer menu
            System.Console.WriteLine("1. Place Order");
            System.Console.WriteLine("2. View Order History");
            System.Console.WriteLine("3. Exit");

            // select a menu option
            var input2 = Console.ReadLine();

            switch (input2)
            {
                case "1":
                    // run the code dor placing order
                    PlaceOrder();
                    DisplayOrder();
                    
                    break;
                case "2":
                    // run the code for view order history
                    GetOrderHistory();
                    break;
            }
        }
    }
}
