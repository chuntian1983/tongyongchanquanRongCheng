using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.website
{
    public partial class tsjy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    model.BusinessType = "1";
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