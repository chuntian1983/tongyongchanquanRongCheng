using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCCQ.Model;
using NCCQ.DAL;
using System.Data;
using System.Web.SessionState;
using System.Web;
using NCCQ.Util;
using System.IO;

namespace NCCQ.BLL
{
    public class T_SysLogBll
    {
        T_SysLogDal dal = null;
        public T_SysLogBll()
        {
            dal = new T_SysLogDal();
        }

        public string ProcessRequest(HttpContext context)
        {
            string action = context.Request.QueryString["action"].ToString();
            string returnDate;
            switch (action)
            {
                case "paging":
                    string str = "\"total\":" + CountNum(context) + ",";
                    returnDate = JsonHelper<T_SysLog, int>.JsonDataTable(GetAllList(context), "rows").Insert(1, (str));
                    break;
                case "del":
                    returnDate = Delete();
                    break;
                default:
                    returnDate = null;
                    break;
            }
            return returnDate;
        }
        private string Delete()
        {
            try
            {
                DataTable dt = GetAllList();
                foreach (dynamic item in dt.Rows)
                {
                    string mess = "[" + item["Id"] + "][" + item["LogValue"] + "][" + item["Operates"] + "][" + item["HostName"] + "][" + item["Ip"] + "][" + item["Editor"] + "][" + item["CreateDate"] + "]\r\n";
                    SysLogs(mess);
                }
                dal.Delete();
                return "清空日志操作成功！";
            }
            catch
            {
                return "清空日志操作失败！错误代码：500 ";
            }
        }
        private void SysLogs(string mess)
        {
            try
            {
                string fileLogPath = HttpContext.Current.Server.MapPath("~/logs/");
                if (!Directory.Exists(fileLogPath))
                {
                    Directory.CreateDirectory(fileLogPath);
                }
                fileLogPath = Path.Combine(fileLogPath, "sysLogs" + DateTime.Now.ToString("yyyyMMddhh") + ".log");
                File.AppendAllText(fileLogPath, mess, System.Text.Encoding.UTF8);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private DataTable GetAllList(HttpContext context)
        {
            string sqlWhere = "";
            int startIndex = 0;
            int pageSize = 10;
            try { startIndex = int.Parse(context.Request.Form["page"].ToString()) - 1; }
            catch (Exception) { }
            try { pageSize = int.Parse(context.Request.Form["rows"].ToString()); }
            catch (Exception) { }
            if (context.Request.QueryString["StateDate"] != null || context.Request.QueryString["EndDate"] != null)
            {
                sqlWhere = string.Format(" CreateDate between '{0}' and '{1}'", context.Request.QueryString["StateDate"], context.Request.QueryString["EndDate"]);
            }
            string order = string.Format(" order by {0} {1}", context.Request.Form["sort"].ToString(), context.Request.Form["order"].ToString());
            return dal.GetAllList(sqlWhere, startIndex, pageSize, order);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataTable GetAllList()
        {
            return dal.GetAllList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int CountNum(HttpContext context)
        {
            string sqlWhere = "";
            if (context.Request.QueryString["StateDate"] != null || context.Request.QueryString["EndDate"] != null)
            {
                sqlWhere = string.Format(" CreateDate between '{0}' and '{1}'", context.Request.QueryString["StateDate"], context.Request.QueryString["EndDate"]);
            }
            return dal.CountNum(sqlWhere);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LogValue"></param>
        /// <param name="Operates"></param>
        /// <param name="Ip"></param>
        /// <param name="Editor"></param>
        public void Create(string LogValue, string Operates, string Ip, string Editor, string HostName)
        {
            dal.Create(GetModel(LogValue, Operates, Ip, Editor, HostName));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LogValue"></param>
        /// <param name="Operates"></param>
        /// <param name="Ip"></param>
        /// <param name="Editor"></param>
        /// <returns></returns>
        private T_SysLog GetModel(string LogValue, string Operates, string Ip, string Editor, string HostName)
        {
            T_SysLog model = new T_SysLog();
            model.LogValue = LogValue;
            model.Operates = Operates;
            model.Ip = Ip;
            model.Editor = Editor;
            model.HostName = HostName;
            return model;
        }
    }
}
