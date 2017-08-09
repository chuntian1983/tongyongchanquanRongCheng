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
using System.Text;
using NCCQ.DBFactory;

namespace Web.website
{
    public partial class LeftInfo0 : System.Web.UI.UserControl
    {
        public string ClassName;
        public StringBuilder ModelList = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string classid = string.Empty;
            //if (Request.QueryString["lbid"] == null)
            //{
               
            //}
            //else
            //{
            //    classid = Request.QueryString["lbid"];
            //}
            //if (Request.QueryString["class"]!=null)
            //{
            //    classid = Request.QueryString["class"];
            //}
            //ClassName = DbHelper.Factory().ExecuteDataTable("select newstypename from t_newstype where id='" + classid + "'").Rows[0][0].ToString();
            //string cp = DbHelper.Factory().ExecuteDataTable("select upid from t_newstype where id='" + classid + "'").Rows[0][0].ToString();
            //string rowStyle = "style='height:22px;border-bottom: 1px dotted #CCCCCC;'";
            //string rowTemplate = "<tr><td {2}><img src=Images1/20.jpg>&nbsp;&nbsp;&nbsp;&nbsp;<a href='ShowNewsList.aspx?nm=&class={1}'>{0}</a></td></tr>";
            //DataTable newsType = DbHelper.Factory().ExecuteDataTable("select * from t_newstype where upid='" + classid + "'");
            //foreach (DataRow row in newsType.Rows)
            //{
            //    ModelList.Append(string.Format(rowTemplate, row["cname"].ToString(), row["id"].ToString(), rowStyle));
            //}
            BindRep(10,this.repzuixin);
        }
        /// <summary>
        /// 绑定新闻信息
        /// </summary>
        /// <param name="lbid">新闻类别id</param>
        /// <param name="tops">前几行</param>
        /// <param name="rep">绑定控件</param>
        protected void BindRep(int tops, Repeater rep)
        {
            DataTable dtgzdt = new DataTable();
            dtgzdt = DbHelper.Factory().ExecuteDataTable("select top(" + tops + ")* from t_news where ifshow=1   order by CreateDate");
            rep.DataSource = dtgzdt;
            rep.DataBind();
        }
    }
}