using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankingSystem
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpContext.Current.Session.Abandon();
                Response.Write(Convert.ToString(HttpContext.Current.Session["currentUser"]));
                Response.Redirect("HomePage.html");

            }
            catch (Exception exp)
            {
                Response.Write("Error:" + exp);
            }
        }
    }
}