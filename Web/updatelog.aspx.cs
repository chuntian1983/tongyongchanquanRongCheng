using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class updatelog : System.Web.UI.Page
    {
        /// <summary>
        /// 版本号
        /// </summary>
        /// <returns></returns>
        public static string Ver()
        {
            //return "Version:1.0.1.1603R";
            return "v2.0.20160503";
        }
        /// <summary>
        /// 版本升级说明
        /// </summary>
        protected void VersionExplain()
        {
            /*
             * 2016年5月3日发布v2.0.20160503版本
             * 
             * 
             * 
             * 
             * 
             */
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("当前软件版本是" + Ver());
        }
    }
}