using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NCCQ.Model;
using NCCQ.DBFactory;

namespace NCCQ.DAL
{
    public class T_NewsTypeDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public bool Create(T_NewsType model)
        {
            try
            {
                object[] obj = { model.NewsTypeName, model.UpId, model.TypeLevel, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss") };
                string strSql = string.Format(" insert into [T_NewsType]([NewsTypeName],[UpId],[TypeLevel],[Editor],[CreateDate])values('{0}',{1},{2},'{3}','{4}')", obj);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public bool Update(T_NewsType model)
        {
            try
            {
                object[] obj = { model.NewsTypeName, model.UpId, model.TypeLevel, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.Id };
                string strSql = string.Format(" update [T_NewsType] set [NewsTypeName] ='{0}' ,[UpId] ={1} ,[TypeLevel] = {2},[Editor] ='{3}' ,[CreateDate] ='{4}'  where Id={5} ", obj);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
        /// <summary>
        /// 批量删除操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            try
            {
                string strSql = "delete from T_NewsType where Id in (" + id + ")";
                if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllList(string order)
        {
            string strSql = string.Format("select [Id],[NewsTypeName],[UpId],[TypeLevel],[Editor],[CreateDate] from [T_NewsType] {0}", order);
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }
        //
        public DataTable GetAllList()
        {
            string strSql = " select [Id],[NewsTypeName],[UpId],[TypeLevel],[Editor],[CreateDate] from [T_NewsType] order by TypeLevel";
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }

        public DataTable GetAllList(string UpIdValue, string order)
        {
            string strSql = string.Format("select [Id],[NewsTypeName],[UpId],[TypeLevel],[Editor],[CreateDate] from [T_NewsType] where UpId = {1} {0}", order, UpIdValue);
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UpId"></param>
        /// <returns></returns>
        public DataTable GetLower(int UpId)
        {
            string strSql = string.Format("SELECT [Id],[NewsTypeName],[UpId],[TypeLevel],[Editor],[CreateDate]FROM [T_NewsType] where UpId = {0}", UpId);
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }
        //
        public T_NewsType GetById(int id)
        {
            string strSql = string.Format(" select [Id],[NewsTypeName],[UpId],[TypeLevel],[Editor],[CreateDate] from [T_NewsType] where Id = {0}", id);
            T_NewsType model = null;
            using (dynamic read = DbHelper.Factory().ExecuteReader(strSql.ToString()))
            {
                model = new T_NewsType();
                if (read.Read())
                {
                    try { model.Id = int.Parse(read["Id"].ToString()); }
                    catch { }
                    model.NewsTypeName = read["NewsTypeName"].ToString();
                    try { model.UpId = int.Parse(read["UpId"].ToString()); }
                    catch { }
                    try { model.TypeLevel = int.Parse(read["TypeLevel"].ToString()); }
                    catch { }
                    model.Editor = read["Editor"].ToString();
                    model.CreateDate = DateTime.Parse(read["CreateDate"].ToString());
                }
                read.Dispose();
            }
            return model;
        }
    }
}
