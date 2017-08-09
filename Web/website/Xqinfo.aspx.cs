using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NCCQ.DBFactory;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.Common;


namespace Web.website
{
    public partial class Xqinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != null)
            {
                if (safe_360.CheckData(Request.QueryString["id"]))
                {
                    MessageBox.ShowAndRedirect(this, "您输入的字符含有不安全标识，请重新输入！", "default.aspx");
                    return;
                }
                try { int.Parse(Request.QueryString["id"]); } catch {
                    Response.Redirect("default.aspx");
                    return;
                }
                Bind();
            }
        }
        protected void Bind()
        {
            DataTable dt = new DataTable();
            dt = DbHelper.Factory().ExecuteDataTable("select * from T_SupplyDemand where id='" + Request.QueryString["id"] + "'");
            if (dt.Rows.Count > 0)
            {
                this.lbxmbh.Text = dt.Rows[0]["ProName"].ToString();
                this.lbxmbh0.Text = dt.Rows[0]["KeyWord"].ToString();
                this.lbxmbh1.Text = dt.Rows[0]["ProNum"].ToString();
                this.lbxmbh2.Text = dt.Rows[0]["sName"].ToString();
                this.lbxmbh3.Text = dt.Rows[0]["sLandProperties"].ToString();
                this.lbxmbh4.Text = dt.Rows[0]["sOther"].ToString();
                this.lbxmbh5.Text = dt.Rows[0]["sLocated"].ToString();
                this.lbxmbh6.Text = dt.Rows[0]["sOutArea"].ToString();
                this.lbxmbh7.Text = dt.Rows[0]["sDeadline"].ToString();
                this.lbxmbh8.Text = dt.Rows[0]["sOutWay"].ToString();
                this.lbxmbh9.Text = dt.Rows[0]["sListedData"].ToString();
                this.lbxmbh10.Text = dt.Rows[0]["sTransactions"].ToString();
                this.lbxmbh11.Text = dt.Rows[0]["Remark"].ToString();

                this.lbxmbh12.Text = dt.Rows[0]["sIsMorSeal"].ToString();
                this.lbxmbh13.Text = dt.Rows[0]["sListingPrice"].ToString();
                this.lbxmbh14.Text = dt.Rows[0]["sCenterContact"].ToString();
                this.lbxmbh15.Text = dt.Rows[0]["sProContact"].ToString();
                this.lbxmbh16.Text = dt.Rows[0]["sSettlement"].ToString();
                string strwhere = " and 1=1";
                if (dt.Rows[0]["keyword"] != null)
                {
                    strwhere += " and keyword like '%" + dt.Rows[0]["keyword"] + "%'";
                }
                BindGpRep("1", strwhere);

            }
        }
        /// <summary>
        /// 绑定挂牌项目信息
        /// </summary>
        /// <param name="typeid">挂牌项目id</param>
        /// <param name="tops">前几条信息</param>
        /// <param name="rep">绑定控件</param>
        protected void BindGpRep(string typeid,string strsql)
        {
            string strwhere = " SupplyOrDemand='" + typeid + "' ";

           
            strwhere += strsql;
           
            
            this.pg.RecordCount = int.Parse(DbHelper.Factory().ExecuteScalar("select count(1) FROM T_SupplyDemand  where " + strwhere + "").ToString());
            this.pg.PageSize = 20;
            if (!string.IsNullOrEmpty(hdpage.Value) && hdpage.Value != "1")
            {
                pg.CurrentPageIndex = int.Parse(hdpage.Value);
            }
            int sindex = (this.pg.CurrentPageIndex - 1) * this.pg.PageSize + 1;
            int eindex = this.pg.CurrentPageIndex * this.pg.PageSize;

            DataTable ds = GetListByPage.GetPage("T_SupplyDemand", "id", " " + strwhere + "", "", sindex, eindex);
            //DataSet ds = bll.GetList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, sb.ToString());


            this.repgongying.DataSource = ds;
            this.repgongying.DataBind();



        }
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            hdpage.Value = "1";
            Bind();
        }
    }
}