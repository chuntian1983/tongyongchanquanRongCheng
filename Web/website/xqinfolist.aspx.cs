﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NCCQ.DBFactory;
using System.Data;
using Maticsoft.Common;

namespace Web.website
{
    public partial class xqinfolist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["typeid"] != null)
            {
                if (safe_360.CheckData(Request.QueryString["typeid"]))
                {
                    MessageBox.ShowAndRedirect(this, "您输入的字符含有不安全标识，请重新输入！", "default.aspx");
                    return;
                }
                BindGpRep(Request.QueryString["typeid"]);
            }
        }
        /// <summary>
        /// 绑定挂牌项目信息
        /// </summary>
        /// <param name="typeid">挂牌项目id</param>
        /// <param name="tops">前几条信息</param>
        /// <param name="rep">绑定控件</param>
        protected void BindGpRep(string typeid)
        {
            string strwhere = " 1=1 ";
            if (typeid == "114")
            {
                if (Session["xqstrwhere"] != null)
                {
                    strwhere = Session["xqstrwhere"].ToString();
                }
            }
            else
            {
                strwhere += " and SupplyOrDemand='" + typeid + "'";
            }
            this.pg.RecordCount = int.Parse(DbHelper.Factory().ExecuteScalar("select count(1) FROM T_SupplyDemand  where "+strwhere+"").ToString());
            this.pg.PageSize = 20;
            if (!string.IsNullOrEmpty(hdpage.Value) && hdpage.Value != "1")
            {
                pg.CurrentPageIndex = int.Parse(hdpage.Value);
            }
            int sindex = (this.pg.CurrentPageIndex - 1) * this.pg.PageSize + 1;
            int eindex = this.pg.CurrentPageIndex * this.pg.PageSize;

            DataTable ds = GetListByPage.GetPage("T_SupplyDemand", "id", " "+strwhere+"", "", sindex, eindex);
            //DataSet ds = bll.GetList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, sb.ToString());
            

            this.repxuqiu.DataSource = ds;
            this.repxuqiu.DataBind();
            


        }
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            hdpage.Value = "1";
            if (Request.QueryString["typeid"] != null)
            {
                BindGpRep(Request.QueryString["typeid"]);
            }
        }
    }
}