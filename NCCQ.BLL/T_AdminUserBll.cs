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
    public class T_AdminUserBll
    {
        T_AdminUser admin = null;
        T_AdminUserDal dal = null;
        public T_AdminUserBll()
        {
            dal = new T_AdminUserDal();
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
                    returnDate = JsonHelper<T_AdminUser, int>.JsonDataTable(GetAllList(context), "rows").Insert(1, (str));
                    break;
                case "del":
                    returnDate = Delete(context);
                    break;
                case "add":
                    returnDate = Create(GetModel(context));
                    break;
                case "up":
                    returnDate = Update(GetModel(context)); ;
                    break;
                case "rs":
                    returnDate = RowsState(context);
                    break;
                case "id":
                    returnDate = JsonHelper<T_AdminUser, int>.JsonWriter(GetById(context));
                    break;
                case "ck":
                    returnDate = CheckAdminUserName(context);
                    break;
                case "pass":
                    returnDate = JsonHelper<T_AdminUser, int>.JsonWriter(GetSessionById(context));
                    break;
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }

        private string CheckAdminUserName(HttpContext context)
        {
            string adminLogName = context.Request.QueryString["AdminLogName"];
            if (dal.CheckUserName(adminLogName))
            {
                return "Y";
            }
            else
            {
                return "N";
            }
        }

        private T_AdminUser GetById(HttpContext context)
        {
            int id = 0;
            try { id = int.Parse(context.Request.QueryString["Id"]); }
            catch { }
            return dal.GetModel(id);
        }
        private T_AdminUser GetSessionById(HttpContext context)
        {
            int id = 0;
            try { id = admin.Id; }
            catch { }
            return dal.GetModel(id);
        }
        private string Update(T_AdminUser model)
        {
            if (admin.AdminType == dal.HighestLevel())
            {
                if (dal.Update(model))
                {
                    return "修改管理员登录账号成功！";
                }
                else
                {
                    return "修改管理员登录账号失败，错误代码：500";
                }
            }
            else
            {
                return "您没有修改管理员登录账号权限！";
            }
        }
        //
        private T_AdminUser GetModel(HttpContext context)
        {
            T_AdminUser model = new T_AdminUser();
            try { model.Id = int.Parse(context.Request.Form["Id"].ToString()); }
            catch { }
            model.AdminLogName = context.Request.Form["AdminLogName"].ToString();
            model.AdminLogPass = context.Request.Form["AdminLogPass"].ToString();
            model.AdminName = context.Request.Form["AdminName"].ToString();
            model.AdminTel = context.Request.Form["AdminTel"].ToString();
            model.UnitCode = context.Request.Form["UnitCode"].ToString();
            try { model.AdminType = new T_OrganizationDal().GetLevel(model.UnitCode); }
            catch { }
            try { model.AdminState = int.Parse(context.Request.Form["AdminState"].ToString()); }
            catch { }
            try { model.AdminLogNum = int.Parse(context.Request.Form["AdminLogNum"].ToString()); }
            catch { }
            try { model.IsCheck = int.Parse(context.Request.Form["IsCheck"].ToString()); }
            catch { }
            model.Editor = admin.AdminLogName;
            model.Roleid = context.Request.Form["roleid"].ToString();
            return model;
        }
        private string Create(T_AdminUser model)
        {
            if (admin.AdminType == dal.HighestLevel())
            {
                if (dal.Create(model))
                {
                    return "添加管理员登录账号成功！";
                }
                else
                {
                    return "添加管理员登录账号失败，错误代码：500";
                }
            }
            else
            {
                return "您没有添加管理员登录账号权限！";
            }
        }

        private string RowsState(HttpContext context)
        {
            if (admin.AdminType == dal.HighestLevel())
            {

                string row = context.Request.QueryString["Rows"];
                string values = context.Request.QueryString["Vale"];
                string where = context.Request.QueryString["Id"];
                string value = (values == "0" ? "1" : "0");
                if (dal.UpdateState(row, value, where))
                {
                    return "修改权限状态设置成功！";
                }
                else
                {
                    return "修改权限状态设置失败，错误代码：500";
                }
            }
            else
            {
                return "您没有管理员权限！";
            }
        }

        private string Delete(HttpContext context)
        {
            if (admin.AdminType == dal.HighestLevel())
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
            else
            {
                return "您没有管理员权限！";
            }
        }
        private int CountNum(HttpContext context)
        {
            string sqlWhere = "";
            if (admin.AdminType == dal.HighestLevel())
            {
                if (context.Request.QueryString["AdminLogName"] != null)
                {
                    sqlWhere += string.Format(" AdminLogName like '%{0}%'", context.Request.QueryString["AdminLogName"]);
                }
            }
            else
            {
                sqlWhere += string.Format(" Id = {0}", admin.Id);
            }
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
            if (admin.AdminType == dal.HighestLevel())
            {
                if (context.Request.QueryString["AdminLogName"] != null)
                {
                    sqlWhere += string.Format(" AdminLogName like '%{0}%'", context.Request.QueryString["AdminLogName"]);
                }
            }
            else
            {
                sqlWhere += string.Format(" Id = {0}", admin.Id);
            }
            return dal.GetAllList(sqlWhere, startIndex, pageSize, order);
        }
        public T_AdminUser AdminUserLogin(string adminLogName, string adminLogPass)
        {
            return dal.AdminUserLogin(adminLogName, adminLogPass);
        }
        public void NumberLogin(int id)
        {
            dal.NumberLogin(id);
        }
    }
}
