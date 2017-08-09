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
    public class T_RoleRightBll
    {
        T_AdminUser admin = null;
        T_RoleRightDal dal = null;
        public T_RoleRightBll()
        {
            dal = new T_RoleRightDal();
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
                    returnDate = JsonHelper<T_RoleRight, int>.JsonDataTable(GetAllList(context), "rows");
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
                    returnDate = JsonHelper<T_RoleRight, int>.JsonWriter(GetById(context));
                    break;
                
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }
        
        private DataTable GetAllList(HttpContext context)
        {
            int adminUserId = 0;
            try { adminUserId = int.Parse(context.Request.QueryString["adminUserId"]); }
            catch { }
            return dal.GetAllList(adminUserId);
        }

        private string Delete(HttpContext context) { return "研发中...."; }

        private string Create(HttpContext context)
        {
            T_RoleRight model = new T_RoleRight();
            int error = 0;
            int succ = 0;
            model.AdminUserId = int.Parse(context.Request.QueryString["AdminUserId"]);
           
            model.IfAdd = int.Parse(context.Request.QueryString["IfAdd"]);
            model.IfUp = int.Parse(context.Request.QueryString["IfUp"]);
            model.IfDel = int.Parse(context.Request.QueryString["IfDel"]);
            model.IfSel = int.Parse(context.Request.QueryString["IfSel"]);
            model.Editor = admin.AdminLogName;
            string[] sysFun = context.Request.QueryString["Role"].ToString().Split(',');
            dal.Delete(model.AdminUserId);
            for (int i = 0; i < sysFun.Length; i++)
            {
                if (sysFun[i] != "0")
                {
                    model.SysFunId = int.Parse(sysFun[i]);
                    if (dal.Create(model)) { succ++; } else { error++; }
                }
            }
            return "共获取到授权权限[" + (sysFun.Length - 1) + "]条，成功了[" + succ + "]条，失败了[" + error + "]条。";
        }

        private string Update(HttpContext context) { return "研发中...."; }

        private T_RoleRight GetById(HttpContext context) { return null; }
    }
}
