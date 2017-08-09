using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NCCQ.DBFactory;
using System.Data;

namespace Web.website
{
    public partial class cjinfolist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                BindGpRep();
            }
        }
        /// <summary>
        /// 绑定挂牌项目信息
        /// </summary>
        /// <param name="typeid">挂牌项目id</param>
        /// <param name="tops">前几条信息</param>
        /// <param name="rep">绑定控件</param>
        protected void BindGpRep()
        {

            string strwhere = " 1=1 ";
            
             strwhere += " and ListingStatus='交易完成'";
            
            this.pg.RecordCount = int.Parse(DbHelper.Factory().ExecuteScalar("select count(1) FROM T_ListedProject  where " + strwhere + "").ToString());
            this.pg.PageSize = 20;
            if (!string.IsNullOrEmpty(hdpage.Value) && hdpage.Value != "1")
            {
                pg.CurrentPageIndex = int.Parse(hdpage.Value);
            }
            int sindex = (this.pg.CurrentPageIndex - 1) * this.pg.PageSize + 1;
            int eindex = this.pg.CurrentPageIndex * this.pg.PageSize;

            DataTable ds = GetListByPage.GetPage("T_ListedProject", "id", " " + strwhere + "", "", sindex, eindex);
            //DataSet ds = bll.GetList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, sb.ToString());
            this.rep1.DataSource = ds;
            this.rep1.DataBind();
        }
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            hdpage.Value = "1";
            
                BindGpRep();
            
        }
    }
}