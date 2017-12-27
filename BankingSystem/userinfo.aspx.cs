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
        public string username { get; set; }
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
    public partial class userinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static user GetUsers()
        {
            user users = new user();
            

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
                users.username = "Shubhammmmm";
                users.pan = "1212121";
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




            return users;

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
    }
}