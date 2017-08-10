using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using NCCQ.DBFactory;
using Maticsoft.Common;
using System.Data.SqlClient;
using Maticsoft.DBUtility;


namespace Web.website
{
    public partial class ShowNews : System.Web.UI.Page
    {
        public string ClassName;
        public string NewsTitle;
        public string Contents;
        public string AddUser;
        public string AddTime;
        public string ReadCounts;
        public string NewsSource;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (safe_360.CheckData(Request.QueryString["id"]))
                {
                    MessageBox.ShowAndRedirect(this, "您输入的字符含有不安全标识，请重新输入！", "default.aspx");
                    return;
                }
                try
                {
                    int.Parse(Request.QueryString["id"]);
                }
                catch {
                    Response.Redirect("default.aspx");
                       }
                SqlParameter[] par = { new SqlParameter("@id",Request.QueryString["id"]) };
                DbHelperSQL.ExecuteSql("update t_news set NumClicks=NumClicks+1 where id=@id", par);
                

                SqlParameter[] par2 = { new SqlParameter("@id", Request.QueryString["id"]) };
                DataTable dt = DbHelperSQL.Query("select * from t_news where id=@id",par2).Tables[0];
                    DataRow row = dt.Rows[0];
                    ClassName =DbHelperSQL.Query("select newstypename from t_newstype where id='" + row["NewsTypeid"].ToString() + "'").Tables[0].Rows[0][0].ToString();
                    NewsTitle = row["NewsTitle"].ToString();
                lbcon.Text= row["NewsContent"].ToString(); ;
               // Contents = row["NewsContent"].ToString();
                    AddUser = row["Editor"].ToString();
                    AddTime = row["CreateDate"].ToString();
                    ReadCounts = row["NumClicks"].ToString();
                    NewsSource = row["NewsSource"].ToString();
                    string afile = row["NewsImg"].ToString();

                    if (afile.Length > 0)
                    {

                        string[] file = afile.Split(new Char[] { '|' });

                        for (int i = 0; i < file.Length - 1; i++)
                        {
                            Appendix.InnerHtml += string.Format("<br/>附加文件：<a href='{0}' target=_blank>{0}</a>", file[i]);
                        }

                    }
                    else
                    {
                        Appendix.Visible = false;
                    }
                
                
            }
        }
    }
}