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
                   
                

                DbHelper.Factory().ExecuteNonQuery("update t_news set NumClicks=NumClicks+1 where id='" + Request.QueryString["id"] + "'");
                DataTable dt = DbHelper.Factory().ExecuteDataTable("select * from t_news where id='" + Request.QueryString["id"] + "'");
                DataRow row = dt.Rows[0];
                ClassName = DbHelper.Factory().ExecuteDataTable("select newstypename from t_newstype where id='" + row["NewsTypeid"].ToString() + "'").Rows[0][0].ToString();
                NewsTitle = row["NewsTitle"].ToString();
                Contents = row["NewsContent"].ToString();
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
                else
                {
                    MessageBox.ShowAndRedirect(this, "您输入的字符含有不安全标识，请重新输入！", "default.aspx");
                    return;
                }
            }
        }
    }
}