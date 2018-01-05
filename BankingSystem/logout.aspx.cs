using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;
namespace BankingSystem
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpContext.Current.Session.Abandon();
                Response.Redirect("HomePage.html");

            }
            catch (Exception exp)
            {
                Response.Write("Error:" + exp);
            }
        }
    }
}