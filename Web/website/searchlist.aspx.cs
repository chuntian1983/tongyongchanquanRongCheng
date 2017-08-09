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
using NY.DBUtility;
using System.Data.SqlClient;

namespace Web.website
{
    public partial class searchlist : System.Web.UI.Page
    {
        public string ClassName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        private void Bind()
        {
            ClassName = "搜索信息列表"; //DbHelper.Factory().ExecuteDataTable("select NewsTypeName from t_newstype where id='" + Request.QueryString["lbid"] + "'").Rows[0][0].ToString();
            //SqlParameter[] par={new SqlParameter("@keyword",)};
            //DataTable ds =DbHelperSQL.ExecuteSql("",); DbHelper.Factory().ExecuteDataTable("select * from t_news where NewsTypeId='" + Request.QueryString["lbid"] + "' order by CreateDate desc");
            DataTable ds = new DataTable();
            if (Session["searchdt"]!=null)
            {
                ds = Session["searchdt"] as DataTable;
            }
            if (ds.Rows.Count == 0)
            {
                // Fun_9E80C11A6A9440949C86FA4D12B01BD0.Fun_533AB4215E894315A90295B58D5A7336(GridView1, ds);
            }
            else
            {
                GridView1.DataSource = ds.DefaultView;
                GridView1.DataKeyNames = new string[] { "id" };
                GridView1.Columns[2].Visible = true;
                GridView1.DataBind();
                GridView1.Columns[2].Visible = false;
                Label lb = (Label)GridView1.BottomPagerRow.Cells[0].FindControl("ShowPageInfo");
                lb.Text = "记录数：" + ds.Rows.Count.ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                lb.Text += "总页数：" + (GridView1.PageIndex + 1) + "/" + GridView1.PageCount + "页";
                if (GridView1.AllowPaging)
                {
                    DropDownList ddl = (DropDownList)GridView1.BottomPagerRow.Cells[0].FindControl("JumpPage");
                    ddl.Items.Clear();
                    for (int i = 0; i < GridView1.PageCount; i++)
                    {
                        ddl.Items.Add(new ListItem("第" + (i + 1).ToString() + "页", i.ToString()));
                    }
                    ddl.SelectedIndex = GridView1.PageIndex;
                }
            }
        }
        protected void Fun_ADA162A2B67849BE9E78F16CF5E2F4BC(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridView1.PageIndex = Convert.ToInt32(ddl.SelectedValue);
            Bind();
        }

        protected void Fun_7D7C6C8605D84A43BC6DEAB1B71BA736(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0;
            Bind();
        }

        protected void Fun_6D4066F03C9048D2B493145F67949985(object sender, EventArgs e)
        {
            if (GridView1.PageIndex > 0)
            {
                GridView1.PageIndex -= 1;
                Bind();
            }
        }

        protected void Fun_25E80831410741DFA561BAFDA942D4C2(object sender, EventArgs e)
        {
            if (GridView1.PageIndex < GridView1.PageCount)
            {
                GridView1.PageIndex += 1;
                Bind();
            }
        }

        protected void Fun_135A605A3357484A83413430EE60047E(object sender, EventArgs e)
        {
            GridView1.PageIndex = GridView1.PageCount;
            Bind();
        }

        protected void Fun_A2500144CE07445DB52955237F3BC2D1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Style["cursor"] = "hand";
                string ID = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
                e.Row.Attributes["onclick"] = "window.open('ShowNews.aspx?class=" + e.Row.Cells[2].Text + "&id=" + ID + "');";
                string typeTitle = string.Empty;
                if (Request.QueryString["newstype"] == "X")
                {
                    typeTitle = DbHelper.Factory().ExecuteDataTable("select NewsTypeName from t_newstype where id='" + e.Row.Cells[2].Text + "'").Rows[0][0].ToString();
                    typeTitle = "<a href=\\'ShowNewsList.aspx?class=" + e.Row.Cells[2].Text + "\\'><span style='color:Green'>" + typeTitle + "</span></a>";
                    typeTitle = "&nbsp;[" + typeTitle + "]&nbsp;";
                }
                e.Row.Cells[0].Text = "<img src='Images/dot2.jpg' width=8 height=10>&nbsp;" + typeTitle + e.Row.Cells[0].Text;
                e.Row.Cells[0].CssClass = "t0";
                e.Row.Cells[1].CssClass = "t0";
                //鼠标特效
                e.Row.Attributes["onmouseover"] = "this.style.background='#F6F6F6';";
                e.Row.Attributes["onmouseout"] = "this.style.background='#FFFFFF';";
            }
        }
    }
}