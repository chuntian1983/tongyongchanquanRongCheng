using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCCQ.BLL;
using NCCQ.Model;
using NCCQ.DBFactory;
using System.Web.SessionState;

namespace Web.SuperWeb.ashx
{
    /// <summary>
    /// pass 的摘要说明
    /// </summary>
    public class pass : IHttpHandler, IReadOnlySessionState
    {
        

        public void ProcessRequest(HttpContext context)
        {
            string strreturn = "";
            NCCQ.Model.T_AdminUser admin = null;
            try { admin = context.Session["SuperAdminUser"] as T_AdminUser; }
            catch { }
           // NCCQ.BLL.T_role bll = new T_role();
            string oldpass = context.Request.Form["oldpass"];
            if (oldpass == admin.AdminLogPass)
            {
                if (context.Request.Form["newpass"] == context.Request.Form["newpass2"])
                {
                    string strsql = "update T_AdminUser set AdminLogPass='" + context.Request.Form["newpass"] + "' where id='" + admin.Id + "' ";
                    if (DbHelper.Factory().ExecuteNonQuery(strsql) > 0)
                    {
                        strreturn = "修改成功！";
                    }
                    else
                    {
                        strreturn = "修改失败！";
                    }


                }
                else
                {
                    strreturn = "两次密码输入不一样，请重新输入！";
                }
            }
            else
            {
                strreturn = "原密码输入不正确，请重新输入！";
            }
            
           context.Response.Write(strreturn);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}