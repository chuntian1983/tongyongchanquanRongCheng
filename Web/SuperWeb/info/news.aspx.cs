using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Web.Controls;

namespace Web.SuperWeb.info
{
    public partial class news : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminState"] == null || Session["AdminState"].ToString() == "")
            {
                Response.Redirect("../GetUserSession.aspx");
            }
        }
        protected LosFormatter losFormatter = new LosFormatter();

        protected override object LoadPageStateFromPersistenceMedium()
        {

            string key = Request.Url + "__VIEWSTATE";
            if (Session[key] != null)
            {
                System.IO.MemoryStream stream = (System.IO.MemoryStream)Session[key];
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                return losFormatter.Deserialize(stream);
            }
            return null;
        }

        protected override void SavePageStateToPersistenceMedium(object viewState)
        {
            string key = Request.Url + "__VIEWSTATE";
            MemoryStream stream = new MemoryStream();
            losFormatter.Serialize(stream, viewState);
            stream.Flush();
            Session[key] = stream;
        }
    }
}