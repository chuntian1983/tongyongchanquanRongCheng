using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCCQ.Model;
using System.Web;
using System.Data;
using NCCQ.DAL;

namespace NCCQ.BLL
{
    public class MainH
    {
        T_AdminUser adminUser = null;
        //
        public string ProcessRequest(HttpContext context)
        {
            try { adminUser = context.Session["SuperAdminUser"] as T_AdminUser; }
            catch { }
            string action = context.Request.QueryString["action"].ToString();
            string returnDate;
            switch (action)
            {
                case "fun":
                    returnDate = GetSysFun();
                    break;
                case "aname":
                    returnDate = GetAdminUserName();
                    break;
                case "emp":
                    returnDate = GetEliminateUserSession(context);
                    break;
                default:
                    returnDate = "请求错误!";
                    break;
            }
            return returnDate;
        }
        private string GetSysFun()
        {
            int parentNodeId = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
           // dynamic dataTable = new T_RoleRightDal().GetAllList(adminUser.Id, parentNodeId);
            dynamic dataTable;
            if (adminUser.Id == 1)
            {
                dataTable = new T_RoleRightDal().GetAdminRolelList(parentNodeId);
            }
            else
            {
                 dataTable = new T_RoleRightDal().GetRoleList(adminUser.Id, parentNodeId);
            }
            for (int i = 1; i < dataTable.Rows.Count + 1; i++)
            {
                stringBuilder.Append("{\"menuid\":\"" + dataTable.Rows[i - 1]["NodeId"] + "\",\"menuname\":\"" + dataTable.Rows[i - 1]["DisplayName"] + "\",\"menus\":" + AddMenusNodes(dataTable.Rows[i - 1]["NodeId"]) + "}");
                if (i < dataTable.Rows.Count)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }

        private string AddMenusNodes(int parentNodeId)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
           // dynamic dataTable = new T_RoleRightDal().GetAllList(adminUser.Id, parentNodeId);
            dynamic dataTable;
            if (adminUser.Id == 1)
            {
                dataTable = new T_RoleRightDal().GetAdminRolelList(parentNodeId);
            }
            else
            {
                dataTable = new T_RoleRightDal().GetRoleList(adminUser.Id, parentNodeId);
            }
            for (int i = 1; i < dataTable.Rows.Count + 1; i++)
            {
                stringBuilder.Append("{\"menuid\":\"" + dataTable.Rows[i - 1]["NodeId"] + "\",\"menuname\":\"" + dataTable.Rows[i - 1]["DisplayName"] + "\",\"url\":\"" + dataTable.Rows[i - 1]["NodeURL"] + "?add=1&del=1&sel=1&up=1" + "\"}");
                if (i < dataTable.Rows.Count)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }
        private string GetEliminateUserSession(HttpContext context)
        {
            context.Session.Clear();
            return "退出成功";
        }
        //
        private string GetAdminUserName()
        {
            string adminName = adminUser.AdminLogName;
            if (adminUser.AdminName != "")
            {
                adminName = adminUser.AdminName;
            }
            return adminName;
        }
    }
}
