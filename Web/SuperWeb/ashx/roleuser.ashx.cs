using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCCQ.BLL;
using System.Web.SessionState;

namespace Web.SuperWeb.ashx
{
    /// <summary>
    /// roleuser 的摘要说明
    /// </summary>
    public class roleuser : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            NCCQ.BLL.T_role bll=new T_role();
            context.Response.Write( bll.ProcessRequest(context));
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