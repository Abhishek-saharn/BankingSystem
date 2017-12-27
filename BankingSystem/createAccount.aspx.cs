using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            string mobile = Request.Form["mobile"].ToString();
            string accountType = Request.Form["accountType"].ToString();
            string panNumber = Request.Form["panNumber"].ToString();
            string aadhaar = Request.Form["aadhaar"].ToString();
            string cAddress = Request.Form["cAddress"].ToString();
            string pAddress = Request.Form["pAddress"].ToString();
            string nomineeName = Request.Form["nomineeName"].ToString();
            string nomineeRelation = Request.Form["nomineeRelation"].ToString();
            string nomineemobile = Request.Form["nomineemobile"].ToString();
            string nomineeBirthDate = Request.Form["nomineeBirthDate"].ToString();
            string nomineeAddress = Request.Form["nomineeAddress"].ToString();
            string password = Request.Form["password"].ToString();
            string comparePassword = Request.Form["comparePassword"].ToString();
            
            
            
            

        }
    }
}