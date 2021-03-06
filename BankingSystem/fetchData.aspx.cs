﻿using System;
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
        public static List<Transaction> getTransations()
        {
            List<Transaction> transactions = new List<Transaction>();
            //Transaction transatction = new Transaction();

            string strConn = @"server=localhost;Integrated Security=true;database=Bank_test";
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader dr = null;

            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                comm = new SqlCommand();
                comm.CommandText = "Report";
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;

                string s_email = Convert.ToString(HttpContext.Current.Session["currentUser"]);

                comm.Parameters.AddWithValue("@email", s_email);
                dr = comm.ExecuteReader();


                while (dr.Read())
                {
                    transactions.Add(new Transaction
                    {
                        id = dr[0].ToString(),
                        from_acc = dr[3].ToString(),
                        to_acc = dr[4].ToString(),
                        tr_date = dr[2].ToString(),
                        transaction_type = dr[1].ToString(),
                        amount = "Rs. " + dr[5].ToString(),
                    });
                    var item = transactions[transactions.Count - 1];

                    if (item.to_acc == "")
                    { item.to_acc = "--"; }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {

                comm.Cancel();
                conn.Close();
            }




            return transactions;


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


            string strConn = @"server=localhost;Integrated Security=true;database=Bank_test";
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader dr = null;

            try
            {
                 conn = new SqlConnection(strConn);
                 conn.Open();
               
                 comm = new SqlCommand();
                 comm.CommandText = "Balance";
                 comm.Connection = conn;
                 comm.CommandType = CommandType.StoredProcedure;
                 string s_email = Convert.ToString(HttpContext.Current.Session["currentUser"]);

                 comm.Parameters.AddWithValue("@email", s_email);
                 dr = comm.ExecuteReader();
                string db_fname = "";
                string db_lname = "";

                string db_type = "";
                string db_Acc_number = "";
                string db_balance = "";
                string db_full_name = db_fname + " " + db_lname;

                
                while (dr.Read())
                {
                    db_fname = dr[1].ToString();
                    db_lname = dr[2].ToString();
                    db_type = dr[4].ToString();
                    db_Acc_number = dr[0].ToString();
                    db_balance = dr[3].ToString();
                  
                }
                bal.account_number = db_Acc_number;
                bal.type = db_type;
                bal.balance = "Rs. " + db_balance;
                bal.full_name = db_fname + " " + db_lname;

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