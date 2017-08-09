using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using NCCQ.BLL;

namespace Web.website
{
    public partial class memberlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty( this.txtusername.Text))
            {
                MessageBox.Show(this, "用户名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(this.txtpass.Text))
            {
                MessageBox.Show(this, "请输入密码！");
                return;
            }
            string checkCode = Session["CheckCode"] as string;
            string checkCodeImg = txt_CheckCodeImg.Text;
            if (checkCode != null&&checkCode.ToLower().Equals(checkCodeImg.ToLower()))
            {
                T_UserInfoBll bll = new T_UserInfoBll();
                string str= bll.Userlog(txtusername.Text, txtpass.Text);
                if (str.Contains("登录成功"))
                {
                    Session["hyusername"] = txtusername.Text;
                    Session["userinfoid"] = str.Replace("登录成功", "").Trim();
                    Response.Redirect("../superweb/usermain.aspx");
                }
                else
                {
                    MessageBox.Show(this, str);
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, "验证码错误请重新输入！");
                return;
            }

        }
    }
}