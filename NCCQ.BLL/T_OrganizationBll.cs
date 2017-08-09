using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCCQ.DAL;
using System.Web;
using NCCQ.Model;
using System.Data;
using NCCQ.Util;

namespace NCCQ.BLL
{
    public class T_OrganizationBll
    {
        T_AdminUser admin = null;
        T_OrganizationDal dal = null;
        public T_OrganizationBll()
        {
            dal = new T_OrganizationDal();
        }
        public string ProcessRequest(HttpContext context)
        {
            try { admin = context.Session["SuperAdminUser"] as T_AdminUser; }
            catch { }
            string action = context.Request.QueryString["action"].ToString();
            string returnDate;
            switch (action)
            {
                case "list":
                    returnDate = GetAllList();
                    break;
                case "node":
                    returnDate = AddNodes(context);
                    break;
                case "easycom":
                    returnDate = GetLongList();
                    break;
                case "orglist":
                    returnDate = GetOrglist(context);
                    break;
                case "add":
                    returnDate = Create(context);
                    break;
                case "edit":
                    returnDate = Edit(context);
                    break;
                case "id":
                    returnDate = JsonHelper<T_Organization, int>.JsonWriter(GetById(context));
                    break;
                case "del":
                    returnDate = Del(context);
                    break;
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }
        //修改
        private string Del(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            if (dal.Delete(id))
            {
                return "组织单位信息删除成功！";
            }
            else
            {
                return "组织单位信息删除失败！";
            }
        }
        private T_Organization GetById(HttpContext context)
        {
            NCCQ.Model.T_Organization model = new T_Organization();
            model = dal.GetModel(context.Request.QueryString["id"]);
            return model;
        }
        //修改
        private string Edit(HttpContext context)
        {
            NCCQ.Model.T_Organization model = new T_Organization();
            model = dal.GetModel(context.Request.QueryString["upid"]);

            model.OrgCode = context.Request.Form["OrgCode"];
            model.OrgName = context.Request.Form["OrgName"];
            model.OrgShortName = context.Request.Form["OrgShortName"];
            model.Seq = int.Parse(context.Request.Form["Seq"]);
           

            if (dal.Update(model))
            {
                return "组织单位信息修改成功！";
            }
            else
            {
                return "组织单位信息修改失败，错误代码：500 ";
            }
        }
        //添加
        private string Create(HttpContext context)
        {
            NCCQ.Model.T_Organization modelup = new T_Organization();
            modelup = dal.GetModel(context.Request.QueryString["upid"]);
            NCCQ.Model.T_Organization model = new T_Organization();
            model.Level = modelup.Level - 1;
            model.OrgCode = context.Request.Form["OrgCode"];
            model.OrgName = context.Request.Form["OrgName"];
            model.OrgShortName = context.Request.Form["OrgShortName"];
            model.Seq = int.Parse(context.Request.Form["Seq"]);
            model.UpOrgCode = context.Request.QueryString["upid"];
            
            if (dal.Add(model))
            {
                return "组织单位信息添加成功！";
            }
            else
            {
                return "组织单位信息添加失败，错误代码：500 ";
            }
        }
        private string GetLongList()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            dynamic dataTable = dal.GetAllList(admin.UnitCode);
            for (int i = 1; i < dataTable.Rows.Count + 1; i++)
            {
                stringBuilder.Append("{\"id\":\"" + dataTable.Rows[i - 1]["OrgName"] + "\", \"text\":\"" + dataTable.Rows[i - 1]["OrgName"] + "\"}");
                if (i < dataTable.Rows.Count)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }       
        private string AddNodes(HttpContext context)
        {
            string OrgCode = context.Request.QueryString["OrgCode"].ToString();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            dynamic dataTable = dal.GetLower(OrgCode);
            for (int i = 1; i < dataTable.Rows.Count + 1; i++)
            {
                stringBuilder.Append("{\"id\":\"" + dataTable.Rows[i - 1]["OrgCode"] + "\", \"name\":\"" + dataTable.Rows[i - 1]["OrgShortName"] + "\",\"nodes\":[]}");
                if (i < dataTable.Rows.Count)
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }
        private string GetAllList()
        {
           
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");
            T_Organization model=new T_Organization();
            if (admin.UnitCode != "371082")//判断是否是荣成市
            {
                model = dal.GetModel(admin.UnitCode);
            }
            else
            {
                 model= dal.GetHighestLevel();
                dynamic dataTable = dal.GetLower(model.OrgCode);
                for (int i = 1; i < dataTable.Rows.Count + 1; i++)
                {
                    stringBuilder.Append("{\"id\":\"" + dataTable.Rows[i - 1]["OrgCode"] + "\", \"name\":\"" + dataTable.Rows[i - 1]["OrgShortName"] + "\",\"nodes\":[]}");
                    if (i < dataTable.Rows.Count)
                    {
                        stringBuilder.Append(",");
                    }
                }
            }
            stringBuilder.Append("]");
            return "[{\"id\":\"" + model.OrgCode + "\", \"name\":\"" + model.OrgShortName + "\",\"nodes\":" + stringBuilder.ToString() + ",\"open\":\"true\"}]";
        }
        private string GetOrglist(HttpContext context)
        {
            
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[");

            T_Organization model = dal.GetHighestLevel();
            if (context.Request.QueryString["id"] != null)
            {
                dynamic dataTable = dal.GetLower(context.Request.QueryString["id"]);
                for (int i = 1; i < dataTable.Rows.Count + 1; i++)
                {
                    string stropen = "\"state\"" + ":" + "\"open\"";
                    if (Has_child(dataTable.Rows[i - 1]["OrgCode"]))
                    {
                        stropen = "\"state\"" + ":" + "\"closed\"";
                    }
                    stringBuilder.Append("{\"id\":\"" + dataTable.Rows[i - 1]["OrgCode"] + "\", \"text\":\"" + dataTable.Rows[i - 1]["OrgShortName"] + "\",\"children\":[]," + stropen + "}");
                    if (i < dataTable.Rows.Count)
                    {
                        stringBuilder.Append(",");
                    }
                    
                }
                stringBuilder.Append("]");
                return stringBuilder.ToString();
            }
            else
            {
                dynamic dataTable = dal.GetLower(model.OrgCode);
                for (int i = 1; i < dataTable.Rows.Count + 1; i++)
                {

                    string stropen = "\"state\"" + ":" + "\"open\"";
                    if (Has_child(dataTable.Rows[i - 1]["OrgCode"]))
                    {
                        stropen = "\"state\"" + ":" + "\"closed\"";
                    }
                    stringBuilder.Append("{\"id\":\"" + dataTable.Rows[i - 1]["OrgCode"] + "\", \"text\":\"" + dataTable.Rows[i - 1]["OrgShortName"] + "\",\"children\":[]," + stropen + "}");
                    if (i < dataTable.Rows.Count)
                    {
                        stringBuilder.Append(",");
                    }
                }
                stringBuilder.Append("]");
                string str= "[{\"id\":\"" + model.OrgCode + "\", \"text\":\"" + model.OrgShortName + "\",\"children\":" + stringBuilder.ToString() + ",\"state\":\"open\"}]";
                return "[{\"id\":\"3710\", \"text\":\"威海市\",\"children\":" + str + ",\"state\":\"open\"}]";
            }
        }
        private bool Has_child(string id)
        {
            DataTable dt = dal.GetLower(id);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
