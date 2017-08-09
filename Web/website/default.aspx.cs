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
using Maticsoft.Common;


namespace Web.website
{
    public partial class _default : System.Web.UI.Page
    {
        public StringBuilder picNews = new StringBuilder();
        public StringBuilder picLinks = new StringBuilder();
        public StringBuilder picTexts = new StringBuilder();
        public StringBuilder InfoList = new StringBuilder();
        public StringBuilder picLinks1 = new StringBuilder();
        public string NewsTitle;
        public string NewsTitle1;
        public string Contents;
        public string Contents1;


        public string Url1;
        public string Url2;
        public string Url3;
        public string Url4;
        public string Url5;
        public string Url6;
        public string Url7;
        public string Url8;
        public string Url9;
        public string Url10;
        public string Url11 = "memberlogin.aspx";

        public StringBuilder tesesb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            Url1 = ConfigurationManager.AppSettings["Url1"];
            Url2 = ConfigurationManager.AppSettings["Url2"];
            Url3 = ConfigurationManager.AppSettings["Url3"];
            Url4 = ConfigurationManager.AppSettings["Url4"];
            Url5 = ConfigurationManager.AppSettings["Url5"];
            Url6 = ConfigurationManager.AppSettings["Url6"];
            Url7 = ConfigurationManager.AppSettings["Url7"];
            Url8 = ConfigurationManager.AppSettings["Url8"];
            Url9 = ConfigurationManager.AppSettings["Url9"];
            Url10 = ConfigurationManager.AppSettings["Url10"];
            Url11 = ConfigurationManager.AppSettings["Url11"];

            //首页图片新闻
            DataTable pics = DbHelper.Factory().ExecuteDataTable("select * from t_news where (newsimg like '%.jpg%')   and newstypeid='2' order by CreateDate desc");
            
            for (int i = 0; i < pics.Rows.Count; i++)
            {
                NewsTitle1 = pics.Rows[i]["NewsTitle"].ToString();
                NewsTitle = pics.Rows[i]["NewsTitle"].ToString();
                if (NewsTitle.Length > 14)
                {
                    NewsTitle = NewsTitle.Substring(0, 14) + "...";
                }
                Contents = pics.Rows[i]["NewsContent"].ToString();
                if (Contents.Length > 30)
                {
                    Contents = Contents.Substring(0, 30) + "...";
                }
                Contents = "&nbsp;&nbsp;&nbsp;&nbsp;" + Contents;
                string afile = pics.Rows[i]["NewsImg"].ToString();
                string pic = afile;
                //if (afile.Length > 0)
                //{
                //    string[] file = afile.Split(new Char[] { '|' });

                //    for (int j = 0; j < file.Length - 1; j++)
                //    {
                //        if (file[j].EndsWith(".jpg"))
                //        {
                //            pic = file[j];
                //        }
                //    }
                //}
                if (pic.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase))
                {
                    string showTitle = pics.Rows[i]["NewsTitle"].ToString().Replace("'", "‘").Replace("\"", "”");
                    if (showTitle.Length > 12)
                    {
                        showTitle = showTitle.Substring(0, 12);
                    }
                    picNews.Append("|" +"../newsimg/max/"+ pic);
                    picLinks.Append("|ShowNews.aspx?id=" + pics.Rows[i]["id"].ToString()+"&lbid="+pics.Rows[i]["newstypeid"]+"");
                    picTexts.Append("|" + showTitle);
                }

            }
            if (picNews.Length > 0)
            {
                picNews.Remove(0, 1);
                picLinks.Remove(0, 1);
                picTexts.Remove(0, 1);
            }
            //工作动态
            BindRep("2", 8, this.repfwsn);
            //通知公告
            BindRep("14", 8, this.reptz);
            ////成交公告
            //BindRep("5", 8, this.repchengjiao);
            BindGpRep(8, this.repchengjiao);
            //交易指南
            BindRep("4", 8, this.repjyzn);
            //政策法规
            BindRep("3", 8, this.repzcfg);
            //经验交流
            BindRep("8", 8, this.repjyjl);

            
            GetTese();
            BindGpRep("1", 12, rep1);
            BindGpRep("2", 12, Repeater1);
            BindGpRep("3", 12, Repeater2);
            BindGpRep("4", 12, Repeater3);
            BindGpRep("5", 12, Repeater4);
            BindGpRep("6", 12, Repeater5);
            BindGpRep("7", 12, Repeater6);
            BindGpRep("9", 12, Repeater7);
            BindGpRep("10", 12, Repeater8);
            BindGpRep("11",12, Repeater9);
            BindGpRep("12",12, Repeater10);
            //绑定供求信息
            BindRepGq("1", 7, repgongying);
            BindRepGq("2", 7, repxuqiu);
            if (!IsPostBack)
            {
                this.ddlcity.DataSource = GetOrgList("3710");
                this.ddlcity.DataTextField = "OrgShortName";
                this.ddlcity.DataValueField = "OrgCode";
                this.ddlcity.DataBind();
                this.ddlcity.Items.Insert(0,new ListItem("请选择"));
                GetProjectTypeList();
            }
            
        }
        /// <summary>
        /// 绑定供求信息
        /// </summary>
        /// <param name="lbid">新闻类别id</param>
        /// <param name="tops">前几行</param>
        /// <param name="rep">绑定控件</param>
        protected void BindRepGq(string lbid, int tops, Repeater rep)
        {
            DataTable dtgzdt = new DataTable();
            dtgzdt = DbHelper.Factory().ExecuteDataTable("select top(" + tops + ")* from T_SupplyDemand  where  SupplyOrDemand='" + lbid + "' and IsCheck='1' order by  CreateDate desc");
            rep.DataSource = dtgzdt;
            rep.DataBind();
        }
        /// <summary>
        /// 绑定新闻信息
        /// </summary>
        /// <param name="lbid">新闻类别id</param>
        /// <param name="tops">前几行</param>
        /// <param name="rep">绑定控件</param>
        protected void BindRep(string lbid, int tops, Repeater rep)
        {
            DataTable dtgzdt = new DataTable();
            dtgzdt = DbHelper.Factory().ExecuteDataTable("select top("+tops+")* from t_news where  newstypeid='"+lbid+"' order by ifup desc, CreateDate desc");
            rep.DataSource = dtgzdt;
            rep.DataBind();
        }
        /// <summary>
        /// 绑定挂牌项目信息
        /// </summary>
        /// <param name="typeid">挂牌项目id</param>
        /// <param name="tops">前几条信息</param>
        /// <param name="rep">绑定控件</param>
        protected void BindGpRep(string typeid,int tops,Repeater rep)
        {
            DataTable dt = new DataTable();
            dt = DbHelper.Factory().ExecuteDataTable("select top(" + tops + ")* from T_ListedProject where ProType='" + typeid + "' order by ifup desc,ListedPeriod desc, CreateDate desc");
            rep.DataSource = dt;
            rep.DataBind();
        }
        /// <summary>
        /// 绑定交易完成挂牌项目信息
        /// </summary>
        /// <param name="typeid">挂牌项目id</param>
        /// <param name="tops">前几条信息</param>
        /// <param name="rep">绑定控件</param>
        protected void BindGpRep(int tops, Repeater rep)
        {
            DataTable dt = new DataTable();
            dt = DbHelper.Factory().ExecuteDataTable("select top(" + tops + ")* from T_ListedProject where ListingStatus='交易完成' order by ifup desc,ListedPeriod desc, CreateDate desc");
            rep.DataSource = dt;
            rep.DataBind();
        }
        protected void GetTese()
        {
            //特色产品图片获取
            DataTable pics = DbHelper.Factory().ExecuteDataTable("select * from t_news where (newsimg like '%.jpg%')   and newstypeid='6' order by CreateDate");
            for (int i = 0; i < pics.Rows.Count; i++)
            {

                NewsTitle = pics.Rows[i]["NewsTitle"].ToString();
                if (NewsTitle.Length > 8)
                {
                    NewsTitle = NewsTitle.Substring(0, 8) + "...";
                }
                //Contents = pics.Rows[i]["contents"].ToString();
                //if (Contents.Length > 30)
                //{
                //    Contents = Contents.Substring(0, 30) + "...";
                //}
                //Contents = "&nbsp;&nbsp;&nbsp;&nbsp;" + Contents;
                string afile = pics.Rows[i]["Newsimg"].ToString();
                string pic = string.Empty;
                if (afile.Length > 0)
                {
                    string[] file = afile.Split(new Char[] { '|' });
                    //只取第一张图片
                    if (file[0].EndsWith(".jpg"))
                    {
                        pic = file[0];
                    }
                    tesesb.Append(@"<td><a href='ShowNews.aspx?id=" + pics.Rows[i]["id"].ToString() + "&lbid="+pics.Rows[i]["newstypeid"]+"'");
                    tesesb.Append(@" target='_blank' style='text-decoration: none;'>
<img src='../newsimg/min/" + pic + "' width='150' height='107' /><br /><br />" + NewsTitle + "</a></td>");
                }
            }
        }
        /// <summary>
        /// 地区列表
        /// </summary>
        /// <param name="parorgcode"></param>
        /// <returns></returns>
        private DataTable GetOrgList(string parorgcode)
        {
            DataTable dt = new DataTable();
            string strsql = "select * from T_Organization where UpOrgCode='"+parorgcode+"'";
            dt = DbHelper.Factory().ExecuteDataTable(strsql);
            return dt;
        }
        /// <summary>
        /// 项目类型
        /// </summary>
        /// <param name="parorgcode"></param>
        /// <returns></returns>
        private void GetProjectTypeList()
        {
            DataTable dt = new DataTable();
            string strsql = "select * from T_ListedProjectType ";
            dt = DbHelper.Factory().ExecuteDataTable(strsql);
            this.ddlleibie.DataSource = dt;
            this.ddlleibie.DataTextField = "ListedProjectTypeName";
            this.ddlleibie.DataValueField = "id";
            this.ddlleibie.DataBind();
            this.ddlleibie.Items.Insert(0, new ListItem("请选择"));
        }
        protected void ddlleixing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlcity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlcity.SelectedValue != "请选择")
            {
                this.ddlzhen.DataSource = GetOrgList(this.ddlcity.SelectedValue);
                this.ddlzhen.DataTextField = "OrgShortName";
                this.ddlzhen.DataValueField = "OrgCode";
                this.ddlzhen.DataBind();
            }
            else
            {
                this.ddlzhen.Items.Clear();
                this.ddlzhen.Items.Insert(0, new ListItem("请选择"));
            }
        }

        protected void imgbtntj_Click(object sender, ImageClickEventArgs e)
        {
            if (this.ddlleixing.Text != "请选择")
            {
                StringBuilder strsql = new StringBuilder();
                strsql.Append(" 1=1");

                if (this.ddlleixing.Text == "挂牌项目")
                {
                    Session["gpstrwhere"] = null;
                    if (this.ddlzhen.SelectedValue != "请选择")
                    {
                        strsql.Append(" and UnitCode='" + this.ddlzhen.SelectedValue + "'");
                    }
                    if (this.ddlleibie.SelectedValue != "请选择")
                    {
                        strsql.Append(" and ProType='" + this.ddlleibie.SelectedValue + "'");
                    }
                    if (!string.IsNullOrEmpty(this.txtmj1.Value))
                    {
                        strsql.Append(" and OutArea like '%" + MessageBox.StripHT(this.txtmj1.Value) + "%' ");
                    }
                    if (!string.IsNullOrEmpty(this.txtjiage.Text))
                    {
                        strsql.Append(" and ListingPrice like '%" + MessageBox.StripHT(this.txtjiage.Text) + "%'");
                    }

                    Session["gpstrwhere"] = strsql.ToString();

                    Response.Redirect("gpinfolist.aspx?typeid=114");
                }
                else
                {
                    if (this.ddlgongqiu.SelectedValue == "供应信息")
                    {
                        Session["gqstrwhere"] = null;
                        strsql.Append(" and SupplyOrDemand='1'");

                        if (!string.IsNullOrEmpty(this.txtmj1.Value))
                        {
                            strsql.Append(" and dArea like '%" + MessageBox.StripHT(this.txtmj1.Value) + "%' ");
                        }
                        if (!string.IsNullOrEmpty(this.txtjiage.Text))
                        {
                            strsql.Append(" and dQuotation like '%" + MessageBox.StripHT(this.txtjiage.Text) + "%'");
                        }

                        Session["gqstrwhere"] = strsql.ToString();

                        Response.Redirect("gqinfolist.aspx?typeid=114");

                    }
                    else
                    {
                        Session["xqstrwhere"] = null;
                        strsql.Append(" and SupplyOrDemand='2'");
                        if (!string.IsNullOrEmpty(this.txtmj1.Value))
                        {
                            strsql.Append(" and sOutArea like '%" + MessageBox.StripHT(this.txtmj1.Value) + "%' ");
                        }
                        if (!string.IsNullOrEmpty(this.txtjiage.Text))
                        {
                            strsql.Append(" and sDeadline like '%" + MessageBox.StripHT(this.txtjiage.Text) + "%'");
                        }

                        Session["xqstrwhere"] = strsql.ToString();

                        Response.Redirect("xqinfolist.aspx?typeid=114");
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "请选择项目查询类型！");
            }
        }
    }
}