using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCCQ.BLL;
using System.Web.SessionState;

namespace Web.SuperWeb
{
    /// <summary>
    /// sysLog 的摘要说明
    /// </summary>
    public class sysLog : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write(new T_SysLogBll().ProcessRequest(context));
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