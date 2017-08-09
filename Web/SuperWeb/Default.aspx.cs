using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NCCQ.BLL;
using NCCQ.Model;
using System.Text;
using NCCQ.Util;

namespace Web.SuperWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {           
            string checkCode = Session["CheckCode"] as string;
            string checkCodeImg = txt_CheckCodeImg.Text;
            if (checkCode != null)
            {
                if (checkCode.ToLower().Equals(checkCodeImg.ToLower()))
                {
                    if (txt_AdminLogName.Text.Trim() != "" || txt_AdminLogPass.Text.Trim() != "")
                    {
                        T_AdminUserBll adminUserBll = new T_AdminUserBll();
                        T_AdminUser AdminUser = adminUserBll.AdminUserLogin(txt_AdminLogName.Text.Trim(), txt_AdminLogPass.Text.Trim());
                        if (AdminUser.AdminLogName.Equals(txt_AdminLogName.Text.Trim()) || AdminUser.AdminLogPass.Equals(txt_AdminLogPass.Text.Trim()))
                        {
                            if (AdminUser.AdminState != 0)
                            {
                                AddCookie(AdminUser.Id);
                                adminUserBll.NumberLogin(AdminUser.Id);
                                Session["SuperAdminUser"] = AdminUser;
                                Session["AdminState"] = AdminUser.AdminState;
                                new T_SysLogBll().Create("登陆", "成功", ComFunction.GetClientIP(), txt_AdminLogName.Text, ComFunction.GetHostName());
                                Response.Redirect("Main.aspx");
                            }
                            else
                            {
                                showMessage("管理员账户信息处于禁用状态，请联系上级部门！");
                            }
                        }
                        else
                        {
                            showMessage("用户登录失败！请检查用户名和密码是否正确？");
                            new T_SysLogBll().Create("登陆", "失败", ComFunction.GetClientIP(), txt_AdminLogName.Text, ComFunction.GetHostName());
                        }
                    }
                    else
                    {
                        showMessage("用户名和密码不能为空！");
                    }
                }
                else
                {
                    showMessage("验证码错误，请重新输入验证码！");
                }
            }
            else
            {
                showMessage("登录超时请刷新页面重新登录！");
            }
        }
        //
        private void AddCookie(int id)
        {
            try
            {
                HttpCookie cookies = new HttpCookie("AdminCookies");
                cookies.Values.Add("SuperAdminUserCookies", Key.Base64String(id.ToString()));
                cookies.Expires = DateTime.Now.AddDays(6);
                Response.AppendCookie(cookies);
            }
            catch { showMessage("添加Cookies失败,请检查您的浏览器设置是否屏蔽Cookies？"); }
        }      
        //弹出提示框
        private void showMessage(string msg)
        {
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
           // Response.Write("<script language='javascript' type='text/javascript'>alert('" + msg + "');</script>");
        }
    }
}