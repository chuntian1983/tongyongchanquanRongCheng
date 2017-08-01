﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NCCQ.BLL;
using System.Web.SessionState;

namespace Web.SuperWeb.ashx
{
    /// <summary>
    /// news 的摘要说明
    /// </summary>
    public class news : IHttpHandler, IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write(new T_NewsBll().ProcessRequest(context));
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