using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCCQ.Model;
using NCCQ.DAL;
using System.Web;
using NCCQ.Util;
using System.Data;
using System.IO;

namespace NCCQ.BLL
{
    public class T_LinksBll
    {
        T_AdminUser admin = null;
        T_LinksDal dal = null;
        public T_LinksBll()
        {
            dal = new T_LinksDal();
        }
        public string ProcessRequest(HttpContext context)
        {
            try { admin = context.Session["SuperAdminUser"] as T_AdminUser; }
            catch { }
            string action = context.Request.QueryString["action"].ToString();
            string returnDate;
            switch (action)
            {
                case "paging":
                    string str = "\"total\":" + CountNum(context) + ",";
                    returnDate = JsonHelper<T_Links, int>.JsonDataTable(GetAllList(context), "rows").Insert(1, (str));
                    break;
                case "del":
                    returnDate = Delete(context);
                    break;
                case "add":
                    returnDate = Create(context);
                    break;
                case "up":
                    returnDate = Update(context);
                    break;
                case "id":
                    returnDate = JsonHelper<T_Links, int>.JsonWriter(GetById(context));
                    break;
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }
        private T_Links GetModel(HttpContext context)
        {
            T_Links model = new T_Links();
            try { model.Id = int.Parse(context.Request.Form["Id"].ToString()); }
            catch { }
            model.LinkName = context.Request.Form["LinkName"].ToString();
            model.LinkUrl = context.Request.Form["LinkUrl"].ToString();
            model.LinkImgurl = new UpLoad().UpLoadFile("~/linkImg/");
            model.Editor = admin.AdminLogName;
            return model;
        }
        private string Update(HttpContext context)
        {
            if (dal.Update(GetModel(context)))
            {
                return "友情链接信息更新成功！";
            }
            else
            {
                return "友情链接信息更新失败，错误代码：500 ";
            }
        }
        private string Create(HttpContext context)
        {
            if (dal.Create(GetModel(context)))
            {
                return "友情链接信息添加成功！";
            }
            else
            {
                return "友情链接信息添加失败，错误代码：500 ";
            }
        }
        private T_Links GetById(HttpContext context)
        {
            int Id = 0;
            try
            {
                Id = int.Parse(context.Request.QueryString["Id"]);
            }
            catch { }
            return dal.GetById(Id);
        }
        private string Delete(HttpContext context)
        {
            try
            {
                int Id = 0;
                try { Id = int.Parse(context.Request.QueryString["Id"]); }
                catch { }
                T_Links file = GetById(context);
                try
                {
                    string fp = HttpContext.Current.Server.MapPath("~/linkImg/" + file.LinkImgurl);
                    File.Delete(fp);
                }
                catch { }
                if (dal.Delete(Id))
                {
                    return "删除操作成功！";
                }
                else
                {
                    return "删除操作失败，错误代码：500 ";
                }
            }
            catch { return "Error 500"; }
        }
        private int CountNum(HttpContext context)
        {
            string sqlWhere = "";
            return dal.CountNum(sqlWhere);
        }
        private DataTable GetAllList(HttpContext context)
        {
            string sqlWhere = "";
            int startIndex = 0;
            try { startIndex = int.Parse(context.Request.Form["page"]) - 1; }
            catch { }
            int pageSize = 10;
            try { pageSize = int.Parse(context.Request.Form["rows"].ToString()); }
            catch { }
            string order = string.Format(" order by {0} {1}", context.Request.Form["sort"].ToString(), context.Request.Form["order"].ToString());
            return dal.GetAllList(sqlWhere, startIndex, pageSize, order);
        }
    }
}
