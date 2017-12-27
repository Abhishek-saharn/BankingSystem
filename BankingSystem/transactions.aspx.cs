using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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


            Response.Write( toBankName + recieverAccNumber + amount + password);
           
        }
    }
}