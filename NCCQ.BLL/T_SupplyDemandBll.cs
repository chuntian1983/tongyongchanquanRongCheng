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
    public class T_SupplyDemandBll
    {
        T_AdminUser admin = null;
        T_SupplyDemandDal dal = null;
        public T_SupplyDemandBll()
        {
            dal = new T_SupplyDemandDal();
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
                    returnDate = JsonHelper<T_SupplyDemand, int>.JsonDataTable(GetAllList(context), "rows").Insert(1, (str));
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
                    returnDate = JsonHelper<T_SupplyDemand, int>.JsonWriter(GetById(context));
                    break;
                case "excel":
                    returnDate =ToExcel(context); 
                    break;
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }
        private string ToExcel(HttpContext context)
        {
            int id = 0;
            try
            {
                id = int.Parse(context.Request.QueryString["Id"]);
            }
            catch { }
            var name = DateTime.Now.ToString("yyyyMMddhhmmss") + new Random(DateTime.Now.Second).Next(10000);
            if (id == 1)
            {
                name = "供应" + name;
            }
            else
            {
                name = "需求" + name;
            }
            var path =HttpContext.Current.Server.MapPath("~/xls_down/" + name + ".xls");
            var dts = new System.Data.DataTable();
            dts = dal.GetDataBySupplyOrDemand(id);
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            for (int z = 0; z < 7; z++)
            {
                dt.Columns.Add("f" + z);
            }
            if (id == 1)//供应信息
            {
                dr = dt.NewRow();
                dr[0] = "项目名称";
                dr[1] = "受让方姓名";
                dr[2] = "受让方面积";
                dr[3] = "受让方意见报价";
                dr[4] = "受让方中心联系方式";
                dt.Rows.Add(dr);
                if (dts.Rows.Count>0)
                {
                    for (int i = 0; i < dts.Rows.Count; i++)
                    {
                        dr = dt.NewRow();
                        dr[0] = dts.Rows[i]["ProName"];
                        dr[1] = dts.Rows[i]["dName"];
                        dr[2] = dts.Rows[i]["dArea"];
                        dr[3] = dts.Rows[i]["dQuotation"];
                        dr[4] = dts.Rows[i]["dCenterContact"];
                        dt.Rows.Add(dr);
                    }
                }
                
            }
            else 
            {
                dr = dt.NewRow();
                dr[0] = "项目名称";
                dr[1] = "转让方名称";
                dr[2] = "转让方拟转出面积";
                dr[3] = "转让方拟转出年限";
                dr[4] = "转让方挂牌价格";
                dt.Rows.Add(dr);
                if (dts.Rows.Count > 0)
                {
                    for (int i = 0; i < dts.Rows.Count; i++)
                    {
                        dr = dt.NewRow();
                        dr[0] = dts.Rows[i]["ProName"];
                        dr[1] = dts.Rows[i]["sName"];
                        dr[2] = dts.Rows[i]["sOutArea"];
                        dr[3] = dts.Rows[i]["sDeadline"];
                        dr[4] = dts.Rows[i]["sListingPrice"];
                        dt.Rows.Add(dr);
                    }
                }
            }
            ExcelHelper.x2003.TableToExcelForXLS(dt, path);
           // downloadfile(path);
            
            return  "../../xls_down/" + name + ".xls";
            
        }
        private int CountNum(HttpContext context)
        {
            string sqlWhere = " 1=1";

            if (admin.Id == 1)
            {

            }
            else
            {
                sqlWhere += string.Format(" and UserInfoId = {0}", admin.Id);
                //会员id
                if (context.Session["userinfoid"] != null)
                {
                    sqlWhere += string.Format(" and userinfoid = '{0}'", context.Session["userinfoid"].ToString());
                }
            }
            
            if (null != context.Request.QueryString["SupplyOrDemand"])
            {
                sqlWhere += string.Format(" and SupplyOrDemand = {0}", context.Request.QueryString["SupplyOrDemand"]);
            }
            if (null != context.Request.QueryString["ProName"])
            {
                sqlWhere += string.Format(" and ProName like '{0}%'", context.Request.QueryString["ProName"]);
            }
            return dal.CountNum(sqlWhere);
        }

        private DataTable GetAllList(HttpContext context)
        {
            string sqlWhere = " 1=1";
           
            if (null != context.Request.QueryString["SupplyOrDemand"])
            {
                sqlWhere += string.Format(" and SupplyOrDemand = {0}", context.Request.QueryString["SupplyOrDemand"]);
            }
            if (null != context.Request.QueryString["ProName"])
            {
                sqlWhere += string.Format(" and ProName like '{0}%'", context.Request.QueryString["ProName"]);
            }
            
            if (admin.Id == 1)
            {

            }
            else
            {
                sqlWhere += string.Format(" and UserInfoId = {0}", admin.Id);
                //会员id
                if (context.Session["userinfoid"] != null)
                {
                    sqlWhere += string.Format(" and userinfoid = '{0}'", context.Session["userinfoid"].ToString());
                }
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

        private string Create(T_SupplyDemand model)
        {
            if (dal.Create(model))
            {
                return "供应需求信息添加成功！";
            }
            else
            {
                return "供应需求信息添加失败，错误代码：500 ";
            }
        }

        private string Update(T_SupplyDemand model)
        {
            if (dal.Update(model))
            {
                return "供应需求信息修改成功！";
            }
            else
            {
                return "供应需求信息修改失败，错误代码：500 ";
            }
        }

        private T_SupplyDemand GetModel(HttpContext context)
        {
            T_SupplyDemand model = new T_SupplyDemand();
            try { model.Id = int.Parse(context.Request.Form["Id"].ToString()); }
            catch { }
            try {
                //会员添加id
                if (context.Session["userinfoid"] != null)
                {
                    model.UserInfoId = int.Parse(context.Session["userinfoid"].ToString());
                }
                else
                {
                    model.UserInfoId = admin.Id;
                }
            }
            catch { }
            try { model.SupplyOrDemand = int.Parse(context.Request.Form["rSupplyOrDemand"].ToString()); }
            catch { }
            model.ProName = context.Request.Form["ProName"].ToString();
            model.KeyWord = context.Request.Form["KeyWord"].ToString();
            model.ProNum = context.Request.Form["ProNum"].ToString();
            model.dName = context.Request.Form["dName"].ToString();
            model.dGlebePurpose = context.Request.Form["dGlebePurpose"].ToString();
            try { model.dListingDate = DateTime.Parse(context.Request.Form["dListingDate"].ToString()); }
            catch { }
            model.dArea = context.Request.Form["dArea"].ToString();
            model.dQuotation = context.Request.Form["dQuotation"].ToString();
            model.dcirculation = context.Request.Form["dcirculation"].ToString();
            model.dDeadline = context.Request.Form["dDeadline"].ToString();
            model.dCenterContact = context.Request.Form["dCenterContact"].ToString();
            model.dProContact = context.Request.Form["dProContact"].ToString();
            model.sName = context.Request.Form["sName"].ToString();
            model.sLandProperties = context.Request.Form["sLandProperties"].ToString();
            model.sOther = context.Request.Form["sOther"].ToString();
            model.sLocated = context.Request.Form["sLocated"].ToString();
            model.sOutArea = context.Request.Form["sOutArea"].ToString();
            model.sDeadline = context.Request.Form["sDeadline"].ToString();
            model.sOutWay = context.Request.Form["sOutWay"].ToString();
            try { model.sListedData = DateTime.Parse(context.Request.Form["sListedData"].ToString()); }
            catch { }
            model.sOutAgain = context.Request.Form["sOutAgain"].ToString();
            model.sTransactions = context.Request.Form["sTransactions"].ToString();
            model.sIsMorSeal = context.Request.Form["sIsMorSeal"].ToString();
            model.sListingPrice = context.Request.Form["sListingPrice"].ToString();
            model.sCenterContact = context.Request.Form["sCenterContact"].ToString();
            model.sProContact = context.Request.Form["sProContact"].ToString();
            model.sSettlement = context.Request.Form["sSettlement"].ToString();
            try
            {
                model.IsCheck = admin.IsCheck;
            }
            catch { model.IsCheck = 1; }
            model.Remark = context.Request.Form["Remark"].ToString();
            return model;
        }

        private T_SupplyDemand GetById(HttpContext context)
        {
            int id = 0;
            try { id = int.Parse(context.Request.QueryString["Id"]); }
            catch { }
            return dal.GetModel(id);
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
                    return "修改供应需求信息状态成功！";
                }
                else
                {
                    return "修改供应需求信息状态失败，错误代码：500";
                }
            }
            else
            {
                return "您没有管理员权限！";
            }
        }
        void downloadfile(string s_path)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(s_path);
            
            HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.AddHeader("Content-Type", "application/octet-stream");
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(file.Name, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.WriteFile(file.FullName);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.End();
        }
    }
}
