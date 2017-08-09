using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NCCQ.DAL;
using System.Web;
using NCCQ.Model;
using NCCQ.Util;

namespace NCCQ.BLL
{
    public class T_NewsTypeBll
    {
        T_AdminUser admin = null;
        T_NewsTypeDal dal = null;
        public T_NewsTypeBll()
        {
            dal = new T_NewsTypeDal();
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
                    returnDate = JsonHelper<T_NewsType, int>.JsonDataTable(GetAllList(context), "rows");
                    break;
                case "tree":
                    returnDate = GetTree();
                    break;
                case "node":
                    returnDate = AddNodes(context);
                    break;
                case "list":
                    returnDate = GetAllList();
                    break;
                case "add":
                    returnDate = Create(context);
                    break;
                case "up":
                    returnDate = Update(context);
                    break;
                case "del":
                    returnDate =Delete(context);
                    break;
                case "id":
                    returnDate = JsonHelper<T_NewsType, int>.JsonWriter(GetById(context));
                    break;
                case "upid":
                    string UpId = context.Request.QueryString["UpId"];
                    string order = " order by TypeLevel";
                    returnDate = GetAllList(UpId, order);
                    break;
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }

        private string GetAllList(string UpIdValue, string order)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append("[");
            dynamic dataTable = dal.GetAllList(UpIdValue, order);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                strb.Append("{\"id\":\"" + dataTable.Rows[i]["Id"] + "\", \"text\":\"" + dataTable.Rows[i]["NewsTypeName"] + "\"}");
                if (i < dataTable.Rows.Count - 1)
                {
                    strb.Append(",");
                }
            }
            strb.Append("]");
            return strb.ToString();
        }

        private T_NewsType GetById(HttpContext context)
        {
            int id = 0;
            try { id = int.Parse(context.Request.QueryString["Id"]); }
            catch { }
            return dal.GetById(id);
        }
        private string Update(HttpContext context)
        {
            if (dal.Update(GetModel(context)))
            {
                return "新闻类型信息更新成功！";
            }
            else
            {
                return "新闻类型信息更新失败，错误代码：500 ";
            }
        }
        private string Delete(HttpContext context)
        {
            
                string id = "0";
                try { id = context.Request.QueryString["Id"].ToString().TrimEnd(',').Trim(); }
                catch { }
                if (dal.Delete(id))
                {
                    return "删除操作成功！";
                }
                else
                {
                    return "删除失败请重新操作，错误代码：500 ";
                }
            
        }
        private string Create(HttpContext context)
        {
            if (dal.Create(GetModel(context)))
            {
                return "新闻类型信息添加成功！";
            }
            else
            {
                return "新闻类型信息添加失败，错误代码：500 ";
            }
        }
        private T_NewsType GetModel(HttpContext context)
        {
            T_NewsType model = new T_NewsType();
            try { model.Id = int.Parse(context.Request.Form["Id"].ToString().Trim()); }
            catch { }
            model.NewsTypeName = context.Request.Form["NewsTypeName"].ToString().Trim();
            try { model.UpId = int.Parse(context.Request.Form["UpId"].ToString().Trim()); }
            catch { }
            try { model.TypeLevel = int.Parse(context.Request.Form["TypeLevel"].ToString().Trim()); }
            catch { }
            model.Editor = admin.AdminLogName;
            return model;
        }
        private string GetAllList()
        {
            StringBuilder strb = new StringBuilder();
            strb.Append("[");
            dynamic dataTable = dal.GetAllList();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                strb.Append("{\"id\":\"" + dataTable.Rows[i]["Id"] + "\", \"text\":\"" + dataTable.Rows[i]["NewsTypeName"] + "\"}");
                if (i < dataTable.Rows.Count - 1)
                {
                    strb.Append(",");
                }
            }
            strb.Append("]");
            return strb.ToString();
        }
        private DataTable GetAllList(HttpContext context)
        {
            string order = string.Format(" order by {0} {1}", context.Request.Form["sort"].ToString(), context.Request.Form["order"].ToString());
            return dal.GetAllList(order);
        }
        private string GetTree()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            dynamic dataTable = dal.GetLower(0);
            for (int i = 1; i < dataTable.Rows.Count + 1; i++)
            {
                stringBuilder.Append("{\"id\":\"" + dataTable.Rows[i - 1]["Id"] + "\", \"name\":\"" + dataTable.Rows[i - 1]["NewsTypeName"] + "\",\"nodes\":[]}");
                if (i < dataTable.Rows.Count)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("]");
            return "[{\"id\":\"0\", \"name\":\"新闻类型列表\",\"nodes\":" + stringBuilder.ToString() + ",\"open\":\"true\"}]";
        }
        //
        private string AddNodes(HttpContext context)
        {
            int upId = 0;
            try { upId = int.Parse(context.Request.QueryString["UpId"].ToString()); }
            catch { }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            dynamic dataTable = dal.GetLower(upId);
            for (int i = 1; i < dataTable.Rows.Count + 1; i++)
            {
                stringBuilder.Append("{\"id\":\"" + dataTable.Rows[i - 1]["Id"] + "\", \"name\":\"" + dataTable.Rows[i - 1]["NewsTypeName"] + "\",\"nodes\":[]}");
                if (i < dataTable.Rows.Count)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }
    }
}
