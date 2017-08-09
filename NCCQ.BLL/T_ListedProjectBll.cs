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
    public class T_ListedProjectBll
    {
        T_AdminUser admin = null;
        T_ListedProjectDal dal = null;
        T_AdminUserDal adminDal = null;
        public T_ListedProjectBll()
        {
            dal = new T_ListedProjectDal();
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
                    returnDate = JsonHelper<T_ListedProject, int>.JsonDataTable(GetAllList(context), "rows").Insert(1, (str));
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
                    returnDate = JsonHelper<T_ListedProject, int>.JsonWriter(GetById(context));
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
                    return "修改挂牌项目状态成功！";
                }
                else
                {
                    return "修改挂牌项目状态失败，错误代码：500";
                }
            }
            else
            {
                return "您没有管理员权限！";
            }
        }
        private T_ListedProject GetById(HttpContext context)
        {
            int id = 0;
            try { id = int.Parse(context.Request.QueryString["Id"]); }
            catch { }
            return dal.GetModel(id);
        }
        private int CountNum(HttpContext context)
        {
            string sqlWhere = " 1=1";
            if (admin.AdminType != adminDal.HighestLevel())
            {
                sqlWhere += string.Format(" and UnitCode like '{0}%'", admin.UnitCode);
            }
            
            if (null != context.Request.QueryString["OutProName"])
            {
                sqlWhere += string.Format(" and OutProName like '{0}%'", context.Request.QueryString["OutProName"]);
            }
            return dal.CountNum(sqlWhere);
        }
        private DataTable GetAllList(HttpContext context)
        {
            string sqlWhere = " 1=1";           
            if (admin.AdminType != adminDal.HighestLevel())
            {
                sqlWhere += string.Format(" and UnitCode like '{0}%'", admin.UnitCode);
            }
            else
            {
                
            }
            if (null != context.Request.QueryString["OutProName"])
            {
                sqlWhere += string.Format(" and OutProName like '{0}%'", context.Request.QueryString["OutProName"]);
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
            try { id = int.Parse(context.Request.QueryString["id"]); }
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
                return "添加操作成功！";
            }
            else
            {
                return "添加失败请重新操作，错误代码：500 ";
            }
        }
        private string Update(HttpContext context)
        {
            if (dal.Update(GetModel(context)))
            {
                return "更新操作成功！";
            }
            else
            {
                return "更新失败请重新操作，错误代码：500 ";
            }
        }

        private T_ListedProject GetModel(HttpContext context)
        {
            T_ListedProject model = new T_ListedProject();
            try { model.Id = int.Parse(context.Request.Form["Id"].ToString()); }
            catch { }
            model.AdminUserId = admin.Id;
            model.UnitCode = context.Request.Form["UnitCode"].ToString();
            if ("" != context.Request.Form["ProNum"].ToString())
            {
                model.ProNum = context.Request.Form["ProNum"].ToString();
            }
            else
            {
                model.ProNum = model.UnitCode + DateTime.Now.ToString("yyyyMMddhhmmss");
            }
            model.Region = context.Request.Form["Region"].ToString();
            model.ProType = context.Request.Form["ProType"].ToString();
            model.OutProName = context.Request.Form["OutProName"].ToString();
            model.OutName = context.Request.Form["OutName"].ToString();
            model.ListingPrice = context.Request.Form["ListingPrice"].ToString();
            model.OutPeriod = context.Request.Form["OutPeriod"].ToString();
            model.Authorization = context.Request.Form["Authorization"].ToString();
            model.Located = context.Request.Form["Located"].ToString();
            model.ManageAuth = context.Request.Form["ManageAuth"].ToString();
            model.ContractKind = context.Request.Form["ContractKind"].ToString();
            model.OutArea = context.Request.Form["OutArea"].ToString();
            model.FarmersNum = context.Request.Form["FarmersNum"].ToString();
            model.East = context.Request.Form["East"].ToString();
            model.South = context.Request.Form["South"].ToString();
            model.West = context.Request.Form["West"].ToString();
            model.North = context.Request.Form["North"].ToString();
            model.GlebePurpose = context.Request.Form["GlebePurpose"].ToString();
            model.WhetherAgainOut = context.Request.Form["WhetherAgainOut"].ToString();
            model.OutWay = context.Request.Form["OutWay"].ToString();
            model.FarmersWishes = context.Request.Form["FarmersWishes"].ToString();
            model.ListedPeriod = context.Request.Form["ListedPeriod"].ToString();
            model.TwoApplication = context.Request.Form["TwoApplication"].ToString();
            model.TranCondition = context.Request.Form["TranCondition"].ToString();
            model.TranMode = context.Request.Form["TranMode"].ToString();
            model.IsMorSeal = context.Request.Form["IsMorSeal"].ToString();
            model.Other = context.Request.Form["Other"].ToString();
            try { model.EndDate = DateTime.Parse(context.Request.Form["EndDate"].ToString()); }
            catch { model.EndDate = DateTime.Now; }
            model.ListingStatus = context.Request.Form["ListingStatus"].ToString();
            try { model.IfUp = int.Parse(context.Request.Form["IfUp"].ToString()); }
            catch { }
            try { model.IsCheck = admin.IsCheck; }
            catch { }
            return model;
        }
    }
}
