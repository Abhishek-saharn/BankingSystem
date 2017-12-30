using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace BankingSystem
{
    public partial class withdraw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int wamount = Convert.ToInt32(Request.Form["wamount"].ToString());
            //string accountNumber = Request.QueryString["accountNumber"].ToString();
            string password = Request.Form["password"].ToString();

            Response.Write(wamount + password);

        }
    }
}