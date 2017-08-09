using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCCQ.DAL;
using NCCQ.Model;
using System.Web;
using NCCQ.Util;
using System.Data;

namespace NCCQ.BLL
{
    public class T_UserInfoBll
    {
        T_AdminUser admin = null;
        T_UserInfoDal dal = null;
        public T_UserInfoBll()
        {
            dal = new T_UserInfoDal();
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
                    returnDate = JsonHelper<T_UserInfo, int>.JsonDataTable(GetAllList(context), "rows").Insert(1, (str));
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
                    returnDate = JsonHelper<T_UserInfo, int>.JsonWriter(GetById(context));
                    break;
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }
        private string RowsState(HttpContext context)
        {
            if (1 == admin.IsCheck)
            {
                string row = context.Request.QueryString["Rows"];
                string values = context.Request.QueryString["Vale"];
                string where = context.Request.QueryString["Id"];
                string value = (values == "0" ? "1" : "0");
                if (dal.UpdateState(row, value, where))
                {
                    return "修改会员状态成功！";
                }
                else
                {
                    return "修改会员状态失败，错误代码：500";
                }
            }
            else
            {
                return "您没有管理员权限！";
            }
        }
        public string Update(T_UserInfo model)
        {
            try
            {
                if (dal.Update(model))
                {
                    return "会员信息修改成功！";
                }
                else
                {
                    return "会员信息修改失败，错误代码：500 ";
                }
            }
            catch { return "Error 500"; }
        }
        private T_UserInfo GetModel(HttpContext context)
        {
            T_UserInfo model = new T_UserInfo();
            try { model.Id = int.Parse(context.Request.Form["Id"].ToString()); }
            catch { }
            model.UserLogName = context.Request.Form["UserLogName"].ToString();
            model.UserLogPass = context.Request.Form["UserLogPass"].ToString();
            model.UserName = context.Request.Form["UserName"].ToString();
            model.UserSex = context.Request.Form["UserSex"].ToString();
            model.CardId = context.Request.Form["CardId"].ToString();
            model.UserAddress = context.Request.Form["UserAddress"].ToString();
            model.UserTel = context.Request.Form["UserTel"].ToString();
            model.UserEmail = context.Request.Form["UserEmail"].ToString();
            try { model.UserLogNum = int.Parse(context.Request.Form["UserLogNum"].ToString()); }
            catch { }
            try { model.UserState = int.Parse(context.Request.Form["UserState"].ToString()); }
            catch { }
            try { model.IsCheck = int.Parse(context.Request.Form["IsCheck"].ToString()); }
            catch { }
            try { model.CreateDate = DateTime.Parse(context.Request.Form["CreateDate"].ToString()); }
            catch { }
            try { model.EndDate = DateTime.Parse(context.Request.Form["EndDate"].ToString()); }
            catch { }
            return model;
        }
        public string Create(T_UserInfo model)
        {
            try
            {
                if (dal.Create(model))
                {
                    return "会员信息添加成功！";
                }
                else
                {
                    return "会员信息添加失败，错误代码：500 ";
                }
            }
            catch { return "Error 500"; }
        }
        private T_UserInfo GetById(HttpContext context)
        {
            int id = 0;
            try { id = int.Parse(context.Request.QueryString["Id"]); }
            catch { }
            return dal.GetModel(id);
        }
        public string Delete(HttpContext context)
        {
            try
            {
                int id = 0;
                try
                {
                    id = int.Parse(context.Request.QueryString["Id"]);
                }
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
            catch { return "Error 500"; }
        }
        private int CountNum(HttpContext context)
        {
            string sqlWhere = "";
            if (context.Request.QueryString["UserName"] != null)
            {
                sqlWhere = string.Format(" UserName like '%{0}%'", context.Request.QueryString["UserName"]);
            }
            return dal.CountNum(sqlWhere);
        }
        private DataTable GetAllList(HttpContext context)
        {
            string sqlWhere = "";
            if (context.Request.QueryString["UserName"] != null)
            {
                sqlWhere = string.Format(" UserName like '%{0}%'", context.Request.QueryString["UserName"]);
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
         //验证用户名
        public bool CheckUserName(string adminLogName)
        {
            return dal.CheckUserName(adminLogName);
        }
         /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userpass"></param>
        /// <returns></returns>
        public string Userlog(string username, string userpass)
        {
            return dal.Userlog(username, userpass);
        }
    }
}
