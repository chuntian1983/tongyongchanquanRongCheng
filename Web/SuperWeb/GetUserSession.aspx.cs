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
    public partial class GetUserSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckUser();
        }

        public void CheckUser()
        {
            if (null != Session["SuperAdminUser"])
            {
                if (!Session["AdminState"].ToString().Equals("1"))
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "mess", "<script>alert('账号登陆信息被禁用！');window.open('Default.aspx','_top');</script>");
                }
            }
            else
            {
                try
                {
                    //GetSession();
                    //Page.ClientScript.RegisterStartupScript(GetType(), "mess", "<script>javascript:window.history.back();</script>");
                    Page.ClientScript.RegisterStartupScript(GetType(), "mess", "<script>alert('会话超时或未登录!请重新登录');window.open('Default.aspx','_top');</script>");
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "mess", "<script>alert('会话超时或未登录!请重新登录');window.open('Default.aspx','_top');</script>");
                }
            }
        }

        private void GetSession()
        {
            try
            {
                int id = int.Parse(Key.FromBase64String(Request.Cookies["AdminCookies"]["SuperAdminUserCookies"].ToString()));
                T_AdminUser AdminUser = new AdminUserBll().GetModel(id);
                Session["SuperAdminUser"] = AdminUser;
                Session["AdminState"] = AdminUser.AdminState;
            }
            catch
            {
                throw;
            }
        }       
    }
}