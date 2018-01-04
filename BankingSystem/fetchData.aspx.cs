using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Services;

namespace BankingSystem
{

    public class user
    {

        public string full_name { get; set; }
        public string pan { get; set; }
        public string email { get; set; }
        public string aadhaar { get; set; }
        public string mobile_number { get; set; }
        public string account_number { get; set; }
        public string type { get; set; }
        public string DOB { get; set; }
        public string address { get; set; }
        public string balance { get; set; }


    }

    public class Transaction
    {
        public string id { get; set; }
        public string transaction_type { get; set; }
        public string to_acc { get; set; }
        public string from_acc { get; set; }
        public string amount { get; set; }
        public string tr_date { get; set; }



    }

    public class balanceGetSet
    {
        public string account_number { get; set; }
        public string type { get; set; }
        public string address { get; set; }
        public string balance { get; set; }
        public string full_name { get; set; }

    }

    public class sessionVar
    {

        public string userEmail { get; set; }

    }

    public partial class fetchData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This method will be used to get Info about the user
        /// </summary>
        /// <returns> An user object</returns>
        ///
        [WebMethod]
        public static user GetUsers(string semail)
        {
            user users = new user();


            string strcon = @"server=localhost;Integrated Security=true;database=Bank_test";
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader dr = null;
            string fname, lname, PAN, email, aadhaar, mobile, accountN, balance, type, DOB, address;



            try
            {
                conn = new SqlConnection(strcon);
                conn.Open();
                comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "userinfoM";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@email", semail);
                dr = comm.ExecuteReader();


                while (dr.Read())
                {

                    PAN = dr[0].ToString();
                    email = dr[1].ToString();
                    aadhaar = dr[2].ToString();
                    mobile = dr[3].ToString();
                    accountN = dr[4].ToString();
                    balance = dr[5].ToString();
                    type = dr[6].ToString();
                    DOB = dr[7].ToString();
                    address = dr[8].ToString();
                    fname = dr[9].ToString();
                    lname = dr[10].ToString();



                    users.pan = PAN;
                    users.email = email;
                    users.aadhaar = aadhaar;
                    users.mobile_number = mobile;
                    users.account_number = accountN;
                    users.balance = balance;
                    users.type = type;
                    users.DOB = DOB;
                    users.address = address;
                    users.full_name = fname + " " + lname;


                }





            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                dr.Close();
                comm.Cancel();
                conn.Close();
            }



            
            return users;

           
        }


        /// <summary>
        /// This function will return all transaction details in list form. 
        /// </summary>
        /// <returns>
        ///     List of Transaction
        /// </returns>
        [WebMethod]
        public static List<Transaction> GetTransations()
        {
            List<Transaction> transactions = new List<Transaction>();
            //Transaction transatction = new Transaction();

            string strConn = @"server=localhost;Integrated Security=true;database=CTS";
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader dr = null;

            try
            {
                /* conn = new SqlConnection(strConn);
                 conn.Open();
               
                 comm = new SqlCommand();
                 comm.CommandText = "Procedure_name";
                 comm.Connection = conn;
                 comm.CommandType = CommandType.StoredProcedure;
                
                 dr = comm.ExecuteReader();*/


                transactions.Add(new Transaction
                {
                    id = "1121",
                    from_acc = "10020010001112",
                    to_acc = "200100222101",
                    tr_date = "22/11/2001 22:02:12",
                    transaction_type = "Credit",
                    amount = "Rs" + "20000",
                });
                transactions.Add(new Transaction
                {
                    id = "1124",
                    from_acc = "10020010001112",
                    to_acc = "200100222101",
                    tr_date = "22/11/2001 22:02:12",
                    transaction_type = "Credit",
                    amount = "Rs" + "9000",
                });

                transactions.Add(new Transaction
                {
                    id = "112166",
                    from_acc = "10020010001112",
                    to_acc = "200100222101",
                    tr_date = "22/11/2001 22:02:12",
                    transaction_type = "Credit",
                    amount = "Rs" + "10000",
                });


                while (dr.Read())
                {


                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                //dr.Close();
                //comm.Cancel();
                //  conn.Close();
            }




            return transactions;

            /*string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(""))
                {
                    cmd.Connection = con;
                    List<user> users = new List<user>();

                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            users.Add(new user
                            {
                               CustomerId = sdr["CustomerId"].ToString(),
                                ContactName = sdr["ContactName"].ToString(),
                                City = sdr["City"].ToString(),
                                Country = sdr["Country"].ToString(),
                                PostalCode = sdr["PostalCode"].ToString(),
                                Phone = sdr["Phone"].ToString(),
                                Fax = sdr["Fax"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return users;
                }
            }*/
        }


        /// <summary>
        /// This method will return data about balance and account information
        /// </summary>
        /// <returns>
        ///     GetBal will return balanceGetSet object. 
        /// </returns>
        [WebMethod]
        public static balanceGetSet GetBal()
        {
            balanceGetSet bal = new balanceGetSet();


            string strConn = @"server=localhost;Integrated Security=true;database=CTS";
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader dr = null;

            try
            {
                /* conn = new SqlConnection(strConn);
                 conn.Open();
               
                 comm = new SqlCommand();
                 comm.CommandText = "Procedure_name";
                 comm.Connection = conn;
                 comm.CommandType = CommandType.StoredProcedure;
                
                 dr = comm.ExecuteReader();*/
                string db_fname = "Shubham";
                string db_lname = "Jadhav";

                string db_type = "Savings Account";
                string db_Acc_number = "1010101010110101";
                string db_address = "Vaikund Apartments, shollinagnallurn, chennai";
                string db_balance = " 2,380";
                string db_full_name = db_fname + " " + db_lname;

                bal.account_number = db_Acc_number;
                bal.type = db_type;
                bal.address = db_address;
                bal.balance = "Rs. " + db_balance;
                bal.full_name = db_full_name;
                while (dr.Read())
                {


                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                //dr.Close();
                //comm.Cancel();
                //  conn.Close();
            }




            return bal;

            /*string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(""))
                {
                    cmd.Connection = con;
                    List<user> users = new List<user>();

                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            users.Add(new user
                            {
                               CustomerId = sdr["CustomerId"].ToString(),
                                ContactName = sdr["ContactName"].ToString(),
                                City = sdr["City"].ToString(),
                                Country = sdr["Country"].ToString(),
                                PostalCode = sdr["PostalCode"].ToString(),
                                Phone = sdr["Phone"].ToString(),
                                Fax = sdr["Fax"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return users;
                }
            }*/
        }

        [WebMethod]
        public static sessionVar GetSession()
        {

            string s_email = Convert.ToString(HttpContext.Current.Session["currentUser"]);
            sessionVar sEmail = new sessionVar();
            sEmail.userEmail = s_email;
            return sEmail;

        }


    }
}