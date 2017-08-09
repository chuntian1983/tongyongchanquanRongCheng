using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NCCQ.Model;
using NCCQ.DBFactory;
using System.Collections;
using System.Data.Common;

namespace NCCQ.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class T_SysLogDal
    {
        /// <summary>
        /// 创建日志
        /// </summary>
        /// <param name="model"></param>
        public void Create(T_SysLog model)
        {
            try
            {
                string[] arrayList = { model.LogValue, model.Operates, model.Ip, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"),model.HostName };
                string strSql = string.Format("insert into T_SysLog(LogValue,Operates,Ip,Editor,CreateDate,HostName) values ('{0}','{1}','{2}','{3}','{4}','{5}')", arrayList);
                DbHelper.Factory().ExecuteNonQuery(strSql.ToString());
            }
            catch (Exception) { throw; }
        }
        /// <summary>
        /// 删除所有日志[删除之前将所有的日志文件备份成txt文件]
        /// </summary>
        public void Delete()
        {
            try
            {
                string strSql = "delete from T_SysLog";
                DbHelper.Factory().ExecuteNonQuery(strSql);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 获取数据列表翻页使用
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetAllList(string sqlWhere, int startIndex, int pageSize, string order)
        {
            try
            {
                string strSql = "select Id,LogValue,Operates,Ip,Editor,CreateDate,HostName from T_SysLog";
                if (sqlWhere != "")
                {
                    strSql += string.Format(" where {0}", sqlWhere);
                }
                strSql += order;
                return DbHelper.Factory().ExecuteDataTable(strSql, startIndex * pageSize, pageSize, "T_SysLog");
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int CountNum(string where)
        {
            string strSql = "select isnull(count(Id),0) from T_SysLog";
            if (where != "")
            {
                strSql += string.Format(" where {0}", where);
            }
            return (int)DbHelper.Factory().ExecuteScalar(strSql);
        }
        /// <summary>
        /// 获取所有的数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllList()
        {

            try
            {
                string strSql = "select Id,LogValue,Operates,Ip,Editor,CreateDate,HostName from T_SysLog order by CreateDate desc";
                return DbHelper.Factory().ExecuteDataTable(strSql);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
