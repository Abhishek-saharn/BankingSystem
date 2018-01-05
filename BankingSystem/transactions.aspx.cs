using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace BankingSystem
{
    public partial class transactions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fAccountNumber = Request.Form["fAccountNumber"].ToString();
            string toBankName = Request.Form["toBankName"].ToString();
            string recieverAccNumber = Request.Form["recieverAccNumber"].ToString();
            int amount = Convert.ToInt32(Request.Form["amount"].ToString());
            string password = Request.Form["password"].ToString();

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
                // dr = comm.ExecuteReader();
                ////  int i = comm.ExecuteNonQuery();
                comm.Parameters.AddWithValue("@from_acc", fAccountNumber);
                comm.Parameters.AddWithValue("@to_acc", recieverAccNumber);
                comm.Parameters.AddWithValue("@amount", amount);
                comm.Parameters.AddWithValue("@password", password);


                int i = comm.ExecuteNonQuery();
                if (i > 0)
                {
                    Response.Write("UPDATED");

                }

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);

            }




           
        }
    }
}