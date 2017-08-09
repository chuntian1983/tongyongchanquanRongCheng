using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCCQ.Model;
using NCCQ.DAL;
using System.Web;
using NCCQ.Util;
using System.Data;

namespace NCCQ.BLL
{
    public class T_ListedProjectTypeBll
    {
        T_AdminUser admin = null;
        T_ListedProjectTypeDal dal = null;
        public T_ListedProjectTypeBll()
        {
            dal = new T_ListedProjectTypeDal();
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
                    returnDate = JsonHelper<T_ListedProjectType, int>.JsonDataTable(GetAllList(context), "rows");
                    break;
                case "add":
                    returnDate = Create(context);
                    break;
                case "up":
                    returnDate = Update(context);
                    break;
                case "id":
                    returnDate = JsonHelper<T_ListedProjectType, int>.JsonWriter(GetById(context));
                    break;
                case "list":
                    returnDate = GetAllList();
                    break;
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }
        private string GetAllList() 
        {
            StringBuilder strb = new StringBuilder();
            strb.Append("[");
            dynamic dataTable = dal.GetAllList(" order by ListedProjectTypeOrder");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                strb.Append("{\"id\":\"" + dataTable.Rows[i]["Id"] + "\", \"text\":\"" + dataTable.Rows[i]["ListedProjectTypeName"] + "\"}");
                if (i < dataTable.Rows.Count - 1)
                {
                    strb.Append(",");
                }
            }
            strb.Append("]");
            return strb.ToString();
        }
        private T_ListedProjectType GetById(HttpContext context) {
            int id = 0;
            try { id = int.Parse(context.Request.QueryString["Id"]); }
            catch { }
            return dal.GetById(id);
        }
        private string Create(HttpContext context) 
        {
            if (dal.Create(GetModel(context)))
            {
                return "挂牌项目名称类型信息添加成功！";
            }
            else
            {
                return "挂牌项目名称类型信息添加失败，错误代码：500 ";
            }
        }
        private string Update(HttpContext context) 
        {
            if (dal.Update(GetModel(context)))
            {
                return "挂牌项目名称类型信息更新成功！";
            }
            else
            {
                return "挂牌项目名称类型信息更新失败，错误代码：500 ";
            }
        }
        private T_ListedProjectType GetModel(HttpContext context) 
        {
            T_ListedProjectType model = new T_ListedProjectType();
            try { model.Id = int.Parse(context.Request.Form["Id"].ToString().Trim()); }
            catch { }
            model.ListedProjectTypeName = context.Request.Form["ListedProjectTypeName"].ToString().Trim();
            try { model.ListedProjectTypeOrder = int.Parse(context.Request.Form["ListedProjectTypeOrder"].ToString().Trim()); }
            catch { }
            model.Editor = admin.AdminLogName;
            return model;
        }
        private DataTable GetAllList(HttpContext context) 
        {
            string order = string.Format(" order by {0} {1}", context.Request.Form["sort"].ToString(), context.Request.Form["order"].ToString());
             return dal.GetAllList(order);
        }
        public T_ListedProjectType getModel(string id)
        {
            T_ListedProjectType model = new T_ListedProjectType();
            model = dal.GetById(int.Parse(id));
            return model;
        }
    }
}
