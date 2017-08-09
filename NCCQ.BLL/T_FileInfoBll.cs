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
    public class T_FileInfoBll
    {
        T_AdminUser admin = null;
        T_FileInfoDal dal = null;
        public T_FileInfoBll()
        {
            dal = new T_FileInfoDal();
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
                    returnDate = JsonHelper<T_FileInfo, int>.JsonDataTable(GetAllList(context), "rows").Insert(1, (str));
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
                    returnDate = JsonHelper<T_FileInfo, int>.JsonWriter(GetById(context));
                    break;
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }
        private T_FileInfo GetModel(HttpContext context)
        {
            T_FileInfo model = new T_FileInfo();
            try { model.Id = int.Parse(context.Request.Form["Id"].ToString()); }
            catch { }
            model.FileName = context.Request.Form["FileName"].ToString();
            HttpPostedFile hf = HttpContext.Current.Request.Files[0];//获取上传图片对象
            model.FileTypeSuffix = Path.GetExtension(hf.FileName);
            try { model.FileTypeName = int.Parse(context.Request.Form["FileTypeName"].ToString()); }
            catch { }
            model.FilePath = new UpLoad().UpLoadFile("~/files/");
            model.Editor = admin.AdminLogName;
            return model;
        }
        private string Update(HttpContext context)
        {
            if (dal.Update(GetModel(context)))
            {
                return "下载文件信息更新成功！";
            }
            else
            {
                return "下载文件信息更新失败，错误代码：500 ";
            }
        }
        private string Create(HttpContext context)
        {
            if (dal.Create(GetModel(context)))
            {
                return "下载文件信息添加成功！";
            }
            else
            {
                return "下载文件信息添加失败，错误代码：500 ";
            }
        }
        private T_FileInfo GetById(HttpContext context)
        {
            int Id = 0;
            try
            {
                Id = int.Parse(context.Request.QueryString["Id"]);
            }
            catch { }
            return dal.GetModel(Id);
        }
        private string Delete(HttpContext context)
        {
            try
            {
                int Id = 0;
                try { Id = int.Parse(context.Request.QueryString["Id"]); }
                catch { }
                T_FileInfo file = GetById(context);
                try
                {
                    string fp = HttpContext.Current.Server.MapPath("~/files/" + file.FilePath);
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
            if (null != context.Request.QueryString["FileName"])
            {
                sqlWhere += string.Format(" FileName like '{0}%'", context.Request.QueryString["FileName"]);
            }
            return dal.CountNum(sqlWhere);
        }
        private DataTable GetAllList(HttpContext context)
        {
            string sqlWhere = "";
            if (null != context.Request.QueryString["FileName"])
            {
                sqlWhere += string.Format(" a.FileName like '{0}%'", context.Request.QueryString["FileName"]);
            }
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
