using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCCQ.DAL;
using System.Web;
using NCCQ.Model;
using NCCQ.Util;
using System.Data;

namespace NCCQ.BLL
{
   public class T_role
    {
         T_AdminUser admin = null;
       DAL.T_role dal = null;
        public T_role()
        {
            dal = new DAL.T_role();
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
                    returnDate = JsonHelper<Model.T_role, int>.JsonDataTable(GetAllList(context), "rows");
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
                case "Id":
                    returnDate = JsonHelper<Model.T_role, int>.JsonWriter(GetById(context));
                    break;
                case "roleid":
                    returnDate = JsonHelper<T_RoleRight, int>.JsonWriter(GetById(context));
                    break;
                case "rolecombox":
                    returnDate = GetRoleList();
                    break;
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }
        private string GetRoleList()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = dal.GetList("");
            if (dt.Rows.Count>0)
            {
                sb.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("{\"id\":" + dt.Rows[i]["id"] + ",");
                    sb.Append("\"rolename\":\""+dt.Rows[i]["rolename"]+"\"}");
                    if (i<dt.Rows.Count-1)
                    {
                        sb.Append(",");
                    }
                }
                
                sb.Append("]");
            }


            return sb.ToString();
        }
        private DataTable GetAllList(HttpContext context)
        {
            //int adminUserId = 0;
            //try { adminUserId = int.Parse(context.Request.QueryString["adminUserId"]); }
            //catch { }
            //return dal.GetList(adminUserId.ToString());
            return dal.GetList("");
        }

        private string Delete(HttpContext context) 
        {
            if (dal.Delete(int.Parse(context.Request.QueryString["id"])))
            {
                return "删除信息成功！";
            }
            else { return "删除信息失败！"; }
        }

        private Model.T_role GetModel(HttpContext context)
        {
            Model.T_role model = new Model.T_role();
            try { model.id = int.Parse(context.Request.Form["Id"].ToString()); }
            catch { }
            model.rolename = context.Request.Form["rolename"].ToString();
            model.editer = admin.Id.ToString();
            try { model.creatdate = System.DateTime.Now; }
            catch { }
           
            return model;
        }
        public string Create(HttpContext context)
        {
            try
            {
                if (dal.Create(GetModel(context)))
                {
                    return "系统角色添加成功！";
                }
                else
                {
                    return "系统角色添加失败，错误代码：500 ";
                }
            }
            catch { return "Error 500"; }
        }

        private string Update(HttpContext context) {
            string rolename = context.Request.Form["rolename"];
            string id = context.Request.Form["Id"];
            if (dal.Update(rolename,id))
            {
                return "新闻信息修改成功！";
            }
            else
            {
                return "新闻信息修改失败，错误代码：500 ";
            }
        }

        private Model.T_role GetById(HttpContext context) {
           int i= int.Parse(context.Request.QueryString["Id"]);
            return dal.GetModelRole(int.Parse(context.Request.QueryString["Id"]));
        }
    }
}
