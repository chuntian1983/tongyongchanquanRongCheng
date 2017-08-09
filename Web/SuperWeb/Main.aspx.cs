using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Controls;

namespace Web.SuperWeb
{
    public partial class Main : System.Web.UI.Page
    {
        public string Platform;
        public string runTime;
        public string CmsRam;
        public string FrameworkBersion;
        public string CacheCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminState"] == null || Session["AdminState"].ToString() == "")
            {
                Response.Redirect("GetUserSession.aspx");
            }
            if (!IsPostBack)
            {
                Platform = Request.Browser.Platform;
                CacheCount = Cache.Count.ToString();
                float y = (float.Parse((Environment.TickCount / 0x3e8).ToString()) / 60 / 60);
                runTime = ((Environment.TickCount / 0x3e8) / 60).ToString() + "分钟 / 约" + string.Format("{0:0.0}", y) + "小时";
                CmsRam = ((Double)GC.GetTotalMemory(false) / 1048576).ToString("N2") + "M";
                FrameworkBersion = string.Concat(new object[] { Environment.Version.Major, ".", Environment.Version.Minor, Environment.Version.Build, ".", Environment.Version.Revision });
            }
        }
    }
}
