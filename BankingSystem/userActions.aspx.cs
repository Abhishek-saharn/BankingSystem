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
using System.Web.Script.Services;
using System.Security.Cryptography;
using System.Text;

namespace BankingSystem
{
    public class UserData
    {
        public string userEmail { get; set; }
        public string error { get; set; }
    }
    public class TransferAmountData
    {
        public string toAccount { get; set; }
        public string amount { get; set; }
        public string error { get; set; }
    }
    public class DepositAmountData
    {
        public string error { get; set; }

    }
    public class WithdrawAmountData {
        public string error { get; set; }
    }
    public partial class login : System.Web.UI.Page
    {
        public static string md5Converter(string password)
        {

            // Password Encryption using md5 
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
            //////////
        }
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static UserData checkPassword(string username, string password)
        {
            UserData data = new UserData();

            string strcon = @"server=localhost;Integrated Security=true;database=Bank_test";
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader dr = null;

            string email = "";




            try
            {
                conn = new SqlConnection(strcon);
                conn.Open();
                comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "userinfo";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@email", username);
                comm.Parameters.AddWithValue("@password", password);
                comm.Parameters.Add("@c", SqlDbType.Int);
                comm.Parameters["@c"].Direction = ParameterDirection.ReturnValue;




                comm.ExecuteNonQuery();
                int i;
                i = int.Parse(comm.Parameters["@c"].Value.ToString());

                if (i == 1)
                {
                    email = username;
                    data.userEmail = email;
                    data.error = "NULL";
                    HttpContext.Current.Session["currentUser"] = email;
                    //HttpContext.Current.Response.Redirect("userInfo.html");

                }
                else
                {

                    data.error = "CREDENTIALS ARE WRONG";

                }






            }
            catch (Exception exp)
            {
                // HttpContext.Current.Response.Write("Password Incorrect");
            }

            return data;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static TransferAmountData transferAmount(string from_acc, string to_acc, string amount, string password)
        {
            TransferAmountData tdata = new TransferAmountData();
            string strcon = @"server=localhost;Integrated Security=true;database=Bank_test";
            SqlConnection conn = null;
            SqlCommand comm = null;
            SqlDataReader dr = null;

            try
            {
                conn = new SqlConnection(strcon);
                conn.Open();
                comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "Transfer";
                comm.CommandType = CommandType.StoredProcedure;

               // password = md5Converter(password);


                comm.Parameters.AddWithValue("@from_acc", from_acc);
                comm.Parameters.AddWithValue("@to_acc", to_acc);
                comm.Parameters.AddWithValue("@amount", amount);
                comm.Parameters.AddWithValue("@password", password);


                int i = comm.ExecuteNonQuery();
                if (i > 0)
                {
                    tdata.amount = amount;
                    tdata.toAccount = to_acc;
                    tdata.error = "NULL";

                }
                else
                {
                    tdata.error = "Transaction Not Successful!!";
                }

            }
            catch (Exception ex)
            {

                tdata.error = "Error Occured!! Please Check your credentials.";

            }


            return tdata;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static DepositAmountData depositAmount(string email, string from_acc, string amount)
        {
            DepositAmountData ddata = new DepositAmountData();
            string strcon = @"server=localhost;Integrated Security=true;database=Bank_test";
            SqlConnection conn = null;
            SqlCommand comm = null;
           // SqlDataReader dr = null;

            try
            {
                conn = new SqlConnection(strcon);
                conn.Open();
                comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "Deposit";
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("@email", email);
                comm.Parameters.AddWithValue("@from_acc", from_acc);
                comm.Parameters.AddWithValue("@amount", amount);


                int i = comm.ExecuteNonQuery();
                if (i > 0)
                {
                    ddata.error = "NULL";

                }
                else
                {
                    ddata.error = "Transaction Not Successful!!";
                }

            }
            catch (Exception ex)
            {

                ddata.error = "Error Occured!! Please Check your credentials.";

            }


            return ddata;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static WithdrawAmountData withdrawAmount(string password, string from_acc, string amount)
        {
            WithdrawAmountData ddata = new WithdrawAmountData();
            string strcon = @"server=localhost;Integrated Security=true;database=Bank_test";
            SqlConnection conn = null;
            SqlCommand comm = null;
            // SqlDataReader dr = null;

            try
            {
                conn = new SqlConnection(strcon);
                conn.Open();
                comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "Withdraw";
                comm.CommandType = CommandType.StoredProcedure;

                //password = md5Converter(password);

                comm.Parameters.AddWithValue("@password", password);
                comm.Parameters.AddWithValue("@from_acc", from_acc);
                comm.Parameters.AddWithValue("@amount", amount);


                int i = comm.ExecuteNonQuery();
                if (i > 0)
                {
                    ddata.error = "NULL";

                }
                else
                {
                    ddata.error = "Transaction Not Successful!!";
                }

            }
            catch (Exception ex)
            {

                ddata.error = ex.Message;

            }


            return ddata;
        }
    }
}