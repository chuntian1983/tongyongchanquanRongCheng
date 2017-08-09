using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NCCQ.DAL;
using NCCQ.Model;
using NCCQ.Util;
using System.Data;

namespace NCCQ.BLL
{
    public class T_BusinessConsultingBll
    {
        T_AdminUser admin = null;
        T_BusinessConsultingDal dal = null;

        public T_BusinessConsultingBll()
        {
            dal = new T_BusinessConsultingDal();
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
                    returnDate = JsonHelper<T_BusinessConsulting, int>.JsonDataTable(GetAllList(context), "rows").Insert(1, (str));
                    break;
                case "tousu":
                    string strs = "\"total\":" + CountNumts(context) + ",";
                    returnDate = JsonHelper<T_BusinessConsulting, int>.JsonDataTable(GetAllListts(context), "rows").Insert(1, (strs));
                    break;
                case "del":
                    returnDate = Delete(context);
                    break;
                case "add":
                    returnDate = Create(GetModel(context));
                    break;
                case "up":
                    returnDate = Update(GetModel(context));
                    break;
                case "Id":
                    returnDate = JsonHelper<T_BusinessConsulting, int>.JsonWriter(GetById(context));
                    break;
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }
        private int CountNum(HttpContext context)
        {
            string sqlWhere = " BusinessType='0' ";
            if (null != context.Request.QueryString["ConsTitle"])
            {
                sqlWhere = string.Format(" and ConsTitle like '%{0}%'", context.Request.QueryString["ConsTitle"].ToString());
            }
            return dal.CountNum(sqlWhere);
        }
        private int CountNumts(HttpContext context)
        {
            string sqlWhere = " BusinessType='1' ";
            if (null != context.Request.QueryString["ConsTitle"])
            {
                sqlWhere = string.Format(" and ConsTitle like '%{0}%'", context.Request.QueryString["ConsTitle"].ToString());
            }
            return dal.CountNum(sqlWhere);
        }
        private DataTable GetAllList(HttpContext context)
        {
            string sqlWhere = " BusinessType='0' ";
            if (null != context.Request.QueryString["ConsTitle"])
            {
                sqlWhere = string.Format(" and ConsTitle like '%{0}%'", context.Request.QueryString["ConsTitle"].ToString());
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
        private DataTable GetAllListts(HttpContext context)
        {
            string sqlWhere = " BusinessType='1' ";
            if (null != context.Request.QueryString["ConsTitle"])
            {
                sqlWhere = string.Format(" and ConsTitle like '%{0}%'", context.Request.QueryString["ConsTitle"].ToString());
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
        private string Delete(HttpContext context)
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
        private T_BusinessConsulting GetModel(HttpContext context)
        {
            T_BusinessConsulting model = new T_BusinessConsulting();
            try { model.Id = int.Parse(context.Request.Form["Id"].ToString()); }
            catch { }
            model.UserName = context.Request.Form["UserName"].ToString();
            model.UserAddress = context.Request.Form["UserAddress"].ToString();
            model.UserTel = context.Request.Form["UserTel"].ToString();
            model.UserEmail = context.Request.Form["UserEmail"].ToString();
            model.ConsTitle = context.Request.Form["ConsTitle"].ToString();
            model.ConsContent = context.Request.Form["ConsContent"].ToString();
            try { model.ConsDate = DateTime.Parse(context.Request.Form["ConsDate"].ToString()); }
            catch { }
            model.ReplyContent = context.Request.Form["ReplyContent"].ToString();
            try { model.ReplyDate = DateTime.Parse(context.Request.Form["ReplyDate"].ToString()); }
            catch { }
            model.ReplyUser = context.Request.Form["ReplyUser"].ToString();
            model.BusinsessState = "1";
            return model;
        }
        private string Create(T_BusinessConsulting model)
        {
            try
            {
                if (dal.Create(model))
                {
                    return "业务咨询信息添加成功！";
                }
                else
                {
                    return "业务咨询信息添加失败，错误代码：500 ";
                }
            }
            catch { return "Error 500"; }
        }
        private string Update(T_BusinessConsulting model)
        {
            try
            {
                if (dal.Update(model))
                {
                    return "业务咨询信息修改成功！";
                }
                else
                {
                    return "业务咨询信息修改失败，错误代码：500 ";
                }
            }
            catch { return "Error 500"; }
        }
        private T_BusinessConsulting GetById(HttpContext context)
        {
            int id = 0;
            try { id = int.Parse(context.Request.QueryString["Id"]); }
            catch { }
            return dal.GetModel(id);
        }
        public void Add(T_BusinessConsulting model)
        {
            dal.Create(model);
        }
    }
}
