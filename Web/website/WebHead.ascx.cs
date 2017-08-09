using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using NY.DBUtility;
using System.Data;

namespace Web.website
{
    public partial class WebHead : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string strsql = "select * from t_news where newstitle like @keyword";
            
            SqlParameter[] par = { new SqlParameter("@keyword","%"+this.txtkeyword.Text.Trim()+"%") };
            DataTable dt = new DataTable();
        dt = DbHelperSQL.Query(strsql, par).Tables[0];
           
            Session["searchdt"] = dt;
            Response.Redirect("searchlist.aspx");
            
        }
    }
}