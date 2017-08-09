using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SuperWeb
{
    public partial class UserMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["hyusername"] != null)
            {
                lbhy.Text = Session["hyusername"].ToString();
            }
            else
            {
                Response.Redirect("../website/memberlogin.aspx");
            }
        }
    }
}