using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NCCQ.DBFactory;
using System.Data;
using System.Data.SqlClient;

namespace Web.website
{
    public partial class ywzx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        protected void Bind()
        {
            DataTable dt = new DataTable();
            dt = DbHelper.Factory().ExecuteDataTable("select * from T_BusinessConsulting where BusinessType='0'");
            string strwhere = " BusinessType='0' and BusinsessState='1' ";

            this.pg.RecordCount = int.Parse(DbHelper.Factory().ExecuteScalar("select count(1) FROM T_BusinessConsulting  where " + strwhere + "").ToString());
            this.pg.PageSize = 5;
            if (!string.IsNullOrEmpty(hdpage.Value) && hdpage.Value != "1")
            {
                pg.CurrentPageIndex = int.Parse(hdpage.Value);
            }
            int sindex = (this.pg.CurrentPageIndex - 1) * this.pg.PageSize + 1;
            int eindex = this.pg.CurrentPageIndex * this.pg.PageSize;

            DataTable ds = GetListByPage.GetPage("T_BusinessConsulting", "id", " " + strwhere + "", "", sindex, eindex);

            this.repgongying.DataSource = ds;
            this.repgongying.DataBind();
        }
        /// <summary>
        /// 绑定挂牌项目信息
        /// </summary>
        /// <param name="typeid">挂牌项目id</param>
        /// <param name="tops">前几条信息</param>
        /// <param name="rep">绑定控件</param>
        protected void BindGpRep(string typeid, string strsql)
        {
            //string strwhere = " SupplyOrDemand='" + typeid + "' ";


            //strwhere += strsql;


            //this.pg.RecordCount = int.Parse(DbHelper.Factory().ExecuteScalar("select count(1) FROM T_SupplyDemand  where " + strwhere + "").ToString());
            //this.pg.PageSize = 20;
            //if (!string.IsNullOrEmpty(hdpage.Value) && hdpage.Value != "1")
            //{
            //    pg.CurrentPageIndex = int.Parse(hdpage.Value);
            //}
            //int sindex = (this.pg.CurrentPageIndex - 1) * this.pg.PageSize + 1;
            //int eindex = this.pg.CurrentPageIndex * this.pg.PageSize;

            //DataTable ds = GetListByPage.GetPage("T_SupplyDemand", "id", " " + strwhere + "", "", sindex, eindex);
            ////DataSet ds = bll.GetList(this.AspNetPager1.PageSize, this.AspNetPager1.CurrentPageIndex, sb.ToString());


            //this.repxuqiu.DataSource = ds;
            //this.repxuqiu.DataBind();



        }
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            hdpage.Value = "1";
            Bind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string checkCode = Session["CheckCode"] as string;
            string checkCodeImg = txt_CheckCodeImg.Text;
            if (checkCode != null)
            {
                if (checkCode.ToLower().Equals(checkCodeImg.ToLower()))
                {
                    NCCQ.Model.T_BusinessConsulting model = new NCCQ.Model.T_BusinessConsulting();
                    model.BusinessType = "0";
                    model.ConsContent = this.txtcontent.Text;
                    model.ConsDate = System.DateTime.Now;
                    model.ConsTitle = this.txttitle.Text;
                    model.UserName = this.txtname.Text;
                    model.UserTel = this.txtlxfs.Text;
                    model.ReplyDate = System.DateTime.Now;
                    NCCQ.BLL.T_BusinessConsultingBll bll = new NCCQ.BLL.T_BusinessConsultingBll();
                    bll.Add(model);
                    showMessage("提交成功！");
                    this.txtlxfs.Text = "";
                    this.txtname.Text = "";
                    this.txttitle.Text = "";
                    this.txtcontent.Text = "";
                    
                }
                else
                {
                    showMessage("验证码错误，请重新输入验证码！");
                }

            }
            else
            {
                showMessage("验证码错误，请重新输入验证码！");
            }
        }
        //弹出提示框
        private void showMessage(string msg)
        {
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
            // Response.Write("<script language='javascript' type='text/javascript'>alert('" + msg + "');</script>");
        }
    }
}