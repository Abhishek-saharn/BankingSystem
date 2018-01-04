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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string firstName = Request.Form["firstName"].ToString();
            string lastName = Request.Form["lastName"].ToString();
            string gender = Request.Form["gender"].ToString();
            string birthDate = Request.Form["birthDate"].ToString();
            string fatherName = Request.Form["fatherName"].ToString();
            string motherName = Request.Form["motherName"].ToString();
            string maritalStatus = Request.Form["maritalStatus"].ToString();
            string nationality = Request.Form["nationality"].ToString();
            Int64 mobile = Convert.ToInt64(Request.Form["mobile"].ToString());
            string email = Request.Form["email"].ToString();
            Int64 introducerAccount = Convert.ToInt64(Request.Form["introducer"].ToString());

            string accountType = Request.Form["accountType"].ToString();
            string panNumber = Request.Form["panNumber"].ToString();
            Int64 aadhaar = Convert.ToInt64(Request.Form["aadhaar"].ToString());
            string pAddress = Request.Form["pAddress"].ToString();
            string nomineeName = Request.Form["nomineeName"].ToString();
            string nomineeRelation = Request.Form["nomineeRelation"].ToString();
            Int64 nomineemobile = Convert.ToInt64(Request.Form["nomineemobile"].ToString());
            string nomineeBirthDate = Request.Form["nomineeBirthDate"].ToString();
            string nomineeAddress = Request.Form["nomineeAddress"].ToString();
            string password = Request.Form["password"].ToString();
            string comparePassword = Request.Form["comparePassword"].ToString();

            string strcon = @"server=localhost;Integrated Security=true;database=Bank_test";
            SqlConnection conn = null;
            SqlCommand comm = null;
            //SqlDataReader dr = null;

            try
            {
                conn = new SqlConnection(strcon);
                conn.Open();
                comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "createAccount";
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("@first_name", firstName);
                comm.Parameters.AddWithValue("@last_name", lastName);
                comm.Parameters.AddWithValue("@gender", gender);
                comm.Parameters.AddWithValue("@DOB", birthDate);
                comm.Parameters.AddWithValue("@father_name", fatherName);
                comm.Parameters.AddWithValue("@mother_name", motherName);
                comm.Parameters.AddWithValue("@marital_status", maritalStatus);
                comm.Parameters.AddWithValue("@nationality", nationality);
                comm.Parameters.AddWithValue("@mobile_number", mobile);
                comm.Parameters.AddWithValue("@email", email);
                comm.Parameters.AddWithValue("@type", accountType);
                comm.Parameters.AddWithValue("@PAN", panNumber);
                comm.Parameters.AddWithValue("@aadhaar", aadhaar);
                comm.Parameters.AddWithValue("@address", pAddress);
                comm.Parameters.AddWithValue("@n_name", nomineeName);
                comm.Parameters.AddWithValue("@relation", nomineeRelation);
                comm.Parameters.AddWithValue("@n_mobile", nomineemobile);
                comm.Parameters.AddWithValue("@n_DOB", nomineeBirthDate);
                comm.Parameters.AddWithValue("@n_address", nomineeAddress);
                comm.Parameters.AddWithValue("@password", password);
                comm.Parameters.AddWithValue("@introducer_accnumber", introducerAccount);

                int i = comm.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Updated");

                }

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);

            }

            
            

        }
    }
}