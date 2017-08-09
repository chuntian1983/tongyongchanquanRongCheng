using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NCCQ.Util;
using NCCQ.Model;
using System.Data;
using NCCQ.DAL;

namespace NCCQ.BLL
{
    public class T_NewsBll
    {
        T_AdminUser admin = null;
        T_NewsDal dal = null;
        T_AdminUserDal adminDal = null;
        public T_NewsBll()
        {
            dal = new T_NewsDal();
            adminDal = new T_AdminUserDal();
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
                    returnDate = JsonHelper<T_News, int>.JsonDataTable(GetAllList(context), "rows").Insert(1, (str));
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
                case "top":
                    returnDate = JsonHelper<T_News, int>.JsonDataTable(GetTopPageShow(context));
                    break;
                case "Home":
                    returnDate = JsonHelper<T_News, int>.JsonDataTable(GetHomeList(context));
                    break;
                case "HomeCount":
                    returnDate = HomeCount(context);
                    break;
                case "Id":
                    returnDate = JsonHelper<T_News, int>.JsonWriter(GetById(context));
                    break;
                case "rs":
                    returnDate = RowsState(context);
                    break;
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }
        //
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
                    return "修改新闻状态成功！";
                }
                else
                {
                    return "修改新闻状态失败，错误代码：500";
                }
            }
            else
            {
                return "您没有管理员权限！";
            }
        }
        //第二页列表新闻数量总和
        private string HomeCount(HttpContext context)
        {
            string sqlWhere = string.Format(" NewType = {0}", admin.Id);
            return dal.CountNum(sqlWhere).ToString();
        }
        //获取单个对象
        public T_News GetById(HttpContext context)
        {
            int id = 0;
            try { id = int.Parse(context.Request.QueryString["Id"]); }
            catch { }
            return dal.GetModel(id);
        }
        //第二页列表展示新闻
        public DataTable GetHomeList(HttpContext context)
        {
            string newType = context.Request.QueryString["NewType"];
            int startIndex = 0;
            try { startIndex = int.Parse(context.Request.QueryString["StartIndex"]); }
            catch { }
            int pageSize = 0;
            try { pageSize = int.Parse(context.Request.QueryString["PageSize"]); }
            catch { }
            return dal.GetAllList(newType, startIndex, pageSize);
        }
        //首页显示TOP新闻
        private DataTable GetTopPageShow(HttpContext context)
        {
            string newType = context.Request.QueryString["NewType"];
            string top = context.Request.QueryString["Top"];
            return dal.GetTopPageShow(newType, top);
        }
        //添加新闻信息
        private string Create(HttpContext context)
        {
            if (dal.Create(GetModel(context)))
            {
                return "新闻信息添加成功！";
            }
            else
            {
                return "新闻信息添加失败，错误代码：500 ";
            }
        }
        //更新新闻信息
        public string Update(HttpContext context)
        {
            if (dal.Update(GetModel(context)))
            {
                return "新闻信息修改成功！";
            }
            else
            {
                return "新闻信息修改失败，错误代码：500 ";
            }
        }
        //获取前台数据封装成对象
        private T_News GetModel(HttpContext context)
        {
            T_News model = new T_News();
            try { model.Id = int.Parse(context.Request.Form["Id"].ToString()); }
            catch { }
            model.AdminUserId = admin.Id;
            try { model.NewsTypeId = int.Parse(context.Request.Form["NewsTypeId"].ToString()); }
            catch { }
            model.Keyword = context.Request.Form["Keyword"].ToString();
            model.Content = context.Request.Form["Content"].ToString();
            model.UnitCode = context.Request.Form["UnitCode"].ToString();
            model.NewsTitle = context.Request.Form["NewsTitle"].ToString();
            model.NewsSubheading = context.Request.Form["NewsSubheading"].ToString();
            model.NewsSource = context.Request.Form["NewsSource"].ToString();
            model.NewsContent = context.Request.Form["NewsContent"].ToString();
            model.NewsImg = new UpLoadImg().uploadpeopleimg("175", "175");
            try { model.NumClicks = int.Parse(context.Request.Form["NumClicks"].ToString()); }
            catch { }
            model.IfShow = admin.IsCheck;
            try { model.IfHost = int.Parse(context.Request.Form["IfHost"].ToString()); }
            catch { }
            try { model.IfDel = int.Parse(context.Request.Form["IfDel"].ToString()); }
            catch { }
            try { model.IfUp = int.Parse(context.Request.Form["IfUp"].ToString()); }
            catch { }
            model.IsCheck = admin.IsCheck;
            model.Editor = admin.AdminLogName;
            return model;
        }
        //删除新闻
        private string Delete(HttpContext context)
        {
            int id = 0;
            try
            {
                id = int.Parse(context.Request.QueryString["id"]);
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
        //后台管理员新闻列表
        private DataTable GetAllList(HttpContext context)
        {
            string sqlWhere = "";
            if (admin.AdminType != adminDal.HighestLevel())
            {
                sqlWhere = string.Format(" T_News.AdminUserId = {0}", admin.Id);
            }
            else { sqlWhere = " 1=1 "; }
            if (!string.IsNullOrEmpty(context.Request.QueryString["NewsTitle"]))
            {
                sqlWhere += string.Format(" and NewsTitle like '{0}%'", context.Request.QueryString["NewsTitle"]);
            }
            if (!string.IsNullOrEmpty(context.Request.QueryString["NewsType"]))
            {
                 sqlWhere += string.Format(" and newstypeid='{0}'", context.Request.QueryString["NewsType"]);
            }
            if (admin.UnitCode!="371082"&&!string.IsNullOrEmpty(admin.UnitCode))
            {
                sqlWhere += " and T_News.UnitCode='" + admin.UnitCode + "'";
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
        //数据总和
        private int CountNum(HttpContext context)
        {
            string sqlWhere = "";
            if (admin.AdminType != adminDal.HighestLevel())
            {
                sqlWhere = string.Format(" T_News.AdminUserId = {0}", admin.Id);
            }
            else { sqlWhere = " 1=1 "; }
            if (!string.IsNullOrEmpty(context.Request.QueryString["NewsTitle"]))
            {
                sqlWhere += string.Format(" and NewsTitle like '{0}%'", context.Request.QueryString["NewsTitle"]);
            }
            if (!string.IsNullOrEmpty(context.Request.QueryString["NewsType"]))
            {
                sqlWhere += string.Format(" and newstypeid='{0}'", context.Request.QueryString["NewsType"]);
            }
            if (admin.UnitCode != "371082" && !string.IsNullOrEmpty(admin.UnitCode))
            {
                sqlWhere += " and T_News.UnitCode='" + admin.UnitCode + "'";
            }
            return dal.CountNum(sqlWhere);
        }
    }
}