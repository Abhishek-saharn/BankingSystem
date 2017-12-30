using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankingSystem
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // var request = HttpContext.Current.Request;
            string email = Request.Form["email"].ToString();
            string enteredPassword = Request.Form["password"].ToString();
            Response.Write(email);
            Response.Write(enteredPassword);

            // Server.Transfer("userInfo.html");
        }
    }
}