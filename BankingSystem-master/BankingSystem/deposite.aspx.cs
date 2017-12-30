using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankingSystem
{
    public partial class deposite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string accHolderName = Request.Form["accHolderName"].ToString();
            string accNumber = Request.Form["accNumber"].ToString();
            int damount = Convert.ToInt32(Request.Form["damount"].ToString());

            Response.Write(accHolderName + accNumber + damount);

        }
    }
}