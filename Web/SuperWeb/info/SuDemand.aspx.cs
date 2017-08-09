using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SuperWeb.info
{
    public partial class SuDemand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 //if (Session["AdminState"] == null || Session["AdminState"].ToString() == "")
 //           {
 //               Response.Redirect("../GetUserSession.aspx");
 //           }
            if (Session["userinfoid"]!=null)
            {
                
            }
        }
    }
}