using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NCCQ.BLL
{
    public class ComFunction
    {
        /// <summary>
        /// 获取用户IP信息
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            string str = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            switch (str)
            {
                case null:
                case "":
                    str = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    break;
            }
            if ((str != null) && !(str == string.Empty))
            {
                return str;
            }
            return HttpContext.Current.Request.UserHostAddress;
        }
        //
        public static string GetHostName()
        {
            return HttpContext.Current.Request.ServerVariables["REMOTE_HOST"];
        }
    }
}