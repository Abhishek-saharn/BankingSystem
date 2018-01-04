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
namespace BankingSystem
{
    public class UserData
    {
        public string userEmail { get; set; }
        public string error { get; set; }
    }
    public partial class login : System.Web.UI.Page
    {

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
                else { 
                    
                    data.error = "CREDENTIALS ARE WRONG";

                }


               



            }
            catch (Exception exp)
            {
               // HttpContext.Current.Response.Write("Password Incorrect");
            }

            return data;
        }
    }
}