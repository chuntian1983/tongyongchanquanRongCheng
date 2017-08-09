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
    public class T_SysFunBll
    {
        T_AdminUser admin = null;
        T_SysFunDal dal = null;
        public T_SysFunBll()
        {
            dal = new T_SysFunDal();
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
                    returnDate = JsonHelper<T_SysFun, int>.JsonDataTable(GetAllList(context), "rows");
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
                    returnDate = JsonHelper<T_SysFun, int>.JsonWriter(GetById(context));
                    break;
                case "parent":
                    returnDate = ParentNode();
                    break;
                case "tree":
                    returnDate = GetTree(context);
                    break;
                case "node":
                    returnDate = AddNode(context);
                    break;
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }

        private string AddNode(int ParentNodeId,HttpContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();
            dynamic dataTable = dal.GetTree(ParentNodeId);
            for (int i = 1; i < dataTable.Rows.Count + 1; i++)
            {
                //判断是否有菜单权限是否选中
                string che = "";
                string sysid =Convert.ToString( dataTable.Rows[i - 1]["NodeId"]);
                DataTable dtse = dal.GetCheck(context.Request.QueryString["roleid"],sysid);
                if (dtse.Rows.Count >= 1)
                {
                    che = "checked";
                }
                stringBuilder.Append("{\"id\":\"" + dataTable.Rows[i - 1]["NodeId"] + "\", \"name\":\"" + dataTable.Rows[i - 1]["DisplayName"] + "\",\"checked\":\"" + che + "\",\"nodes\":[],\"open\":\"true\"}");
                if (i < dataTable.Rows.Count)
                {
                    stringBuilder.Append(",");
                }
            }
            return stringBuilder.ToString();
        }
        private string AddNode(HttpContext context)
        {
            int ParentNodeId = 0;
            try { ParentNodeId = int.Parse(context.Request.QueryString["NodeId"].ToString()); }
            catch { }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            dynamic dataTable = dal.GetTree(ParentNodeId);
            for (int i = 1; i < dataTable.Rows.Count + 1; i++)
            {
                stringBuilder.Append("{\"id\":\"" + dataTable.Rows[i - 1]["NodeId"] + "\", \"name\":\"" + dataTable.Rows[i - 1]["DisplayName"] + "\",\"nodes\":[" + AddNode(dataTable.Rows[i - 1]["NodeId"]) + "],\"open\":\"true\"}");
                if (i < dataTable.Rows.Count)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }
        private string GetTree(HttpContext context)
        {
            int ParentNodeId = 0;
            try { ParentNodeId = int.Parse(context.Request.QueryString["NodeId"].ToString()); }
            catch { }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            dynamic dataTable = dal.GetTree(ParentNodeId);
            for (int i = 1; i < dataTable.Rows.Count + 1; i++)
            {
                //判断是否有菜单权限是否选中
                string che="";
                string sysid =Convert.ToString( dataTable.Rows[i - 1]["NodeId"]);
                DataTable dtse = dal.GetCheck(context.Request.QueryString["roleid"],sysid);
                if (dtse.Rows.Count>=1)
                {
                    che="checked";
                }
                stringBuilder.Append("{\"id\":\"" + dataTable.Rows[i - 1]["NodeId"] + "\", \"name\":\"" + dataTable.Rows[i - 1]["DisplayName"] + "\",\"checked\":\""+che+"\",\"nodes\":[" + AddNode(dataTable.Rows[i - 1]["NodeId"],context) + "],\"open\":\"true\"}");
                if (i < dataTable.Rows.Count)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("]");
            string str = "[{\"id\":\"0\", \"name\":\"系统菜单\",\"nodes\":" + stringBuilder.ToString() + ",\"open\":\"true\"}]";
            return str;
        }
        

        //
        private string ParentNode()
        {
            string parentNode;
            StringBuilder strb = new StringBuilder();
            strb.Append("[");
            string order = " order by NodeId";
            dynamic dataTable = dal.GetAllList(order);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                strb.Append("{\"id\":\"" + dataTable.Rows[i]["NodeId"] + "\", \"text\":\"" + dataTable.Rows[i]["DisplayName"] + "\"}");
                if (i < dataTable.Rows.Count - 1)
                {
                    strb.Append(",");
                }
            }
            strb.Append("]");
            if (dataTable.Rows.Count == 0)
            {
                parentNode = strb.ToString().Insert(1, "{\"id\":\"0\", \"text\":\"无父级节点\"}");
            }
            else
            {
                parentNode = strb.ToString().Insert(1, "{\"id\":\"0\", \"text\":\"无父级节点\"},");
            }
            return parentNode;
        }
        private T_SysFun GetModel(HttpContext context)
        {
            T_SysFun model = new T_SysFun();
            try { model.NodeId = int.Parse(context.Request.Form["NodeId"].ToString()); }
            catch { }
            model.DisplayName = context.Request.Form["DisplayName"].ToString();
            model.NodeURL = context.Request.Form["NodeURL"].ToString();
            try { model.DisplayOrder = int.Parse(context.Request.Form["DisplayOrder"].ToString()); }
            catch { }
            try { model.ParentNodeId = int.Parse(context.Request.Form["ParentNodeId"].ToString()); }
            catch { }
            model.Editor = admin.AdminLogName;
            return model;
        }
        private DataTable GetAllList(HttpContext context)
        {
            string order = string.Format(" order by {0} {1}", context.Request.Form["sort"].ToString(), context.Request.Form["order"].ToString());
            return dal.GetAllList(order);
        }

        private string Delete(HttpContext context)
        {
            if (admin.AdminType == new T_AdminUserDal().HighestLevel())
            {

                int id = 0;
                try { id = int.Parse(context.Request.QueryString["Id"].ToString()); }
                catch { }
                if (dal.Exists(id))
                {
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
                    return "该节点下面包含子节点无法删除，若要删除请先删除子节点数据！";
                }
            }
            else
            {
                return "您没有管理员权限！";
            }
        }

        private string Create(HttpContext context)
        {
            if (admin.AdminType == new T_AdminUserDal().HighestLevel())
            {
                if (dal.Create(GetModel(context)))
                {
                    return "添加系统菜单成功！";
                }
                else
                {
                    return "添加系统菜单失败，错误代码：500";
                }
            }
            else
            {
                return "您没有添加管理员登录账号权限！";
            }
        }

        private string Update(HttpContext context)
        {
            if (admin.AdminType == new T_AdminUserDal().HighestLevel())
            {
                if (dal.Update(GetModel(context)))
                {
                    return "修改系统菜单成功！";
                }
                else
                {
                    return "修改系统菜单失败，错误代码：500";
                }
            }
            else
            {
                return "您没有修改管理员登录账号权限！";
            }
        }

        private T_SysFun GetById(HttpContext context)
        {
            int id = 0;
            try { id = int.Parse(context.Request.QueryString["Id"]); }
            catch { }
            return dal.GetById(id);
        }
    }
}
