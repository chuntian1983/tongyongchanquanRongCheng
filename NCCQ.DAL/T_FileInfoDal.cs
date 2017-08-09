using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NCCQ.Model;
using NCCQ.DBFactory;

namespace NCCQ.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class T_FileInfoDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create(T_FileInfo model)
        {
            try
            {
                object[] obj = { model.FileName, model.FileTypeSuffix, model.FileTypeName, model.FilePath, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss") };
                string strSql = string.Format("insert into [T_FileInfo]([FileName],[FileTypeSuffix],[FileTypeName],[FilePath],[Editor],[CreateDate]) values('{0}','{1}',{2},'{3}','{4}','{5}')", obj);
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
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(int Id)
        {
            try
            {
                string strSql = string.Format("delete from T_FileInfo where Id={0}", Id);
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

        public T_FileInfo GetModel(int id)
        {
            T_FileInfo model = null;
            string strSql = string.Format("select [Id],[FileName],[FileTypeSuffix],[FileTypeName],[FilePath],[Editor],[CreateDate] from [T_FileInfo] where Id= {0}", id);
            using (dynamic read = DbHelper.Factory().ExecuteReader(strSql))
            {
                model = new T_FileInfo();
                if (read.Read())
                {
                    try { model.Id = int.Parse(read["Id"].ToString()); }
                    catch { }
                    model.FileName = read["FileName"].ToString();
                    model.FileTypeSuffix = read["FileTypeSuffix"].ToString();
                    try { model.FileTypeName = int.Parse(read["FileTypeName"].ToString()); }
                    catch { }
                    model.FilePath = read["FilePath"].ToString();
                    model.Editor = read["Editor"].ToString();
                    model.CreateDate = DateTime.Parse(read["CreateDate"].ToString());
                }
                read.Dispose();
            }
            return model;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T_FileInfo model)
        {
            try
            {
                object[] obj = { model.FileName, model.FileTypeSuffix, model.FileTypeName, model.FilePath, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.Id };
                string strSql = string.Format(" update [T_FileInfo] set [FileName] = '{0}',[FileTypeSuffix] = '{1}',[FileTypeName] = {2},[FilePath] = '{3}',[Editor] = '{4}',[CreateDate] ='{5}' where Id= {6} ", obj);
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
        /// <param name="sql"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetAllList(string sqlWhere, int startIndex, int pageSize, string order)
        {
            string strSql = "select a.Id,a.FileName,a.FileTypeSuffix,b.NewsTypeName as FileTypeName,a.FilePath,a.Editor,a.CreateDate from T_FileInfo as a left join T_NewsType as b on a.FileTypeName = b.Id ";
            if (sqlWhere != "")
            {
                strSql += string.Format(" where {0}", sqlWhere);
            }
            strSql += order;
            return DbHelper.Factory().ExecuteDataTable(strSql, startIndex * pageSize, pageSize, "T_FileInfo");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int CountNum(string where)
        {
            string strSql = "select count(Id) from T_FileInfo ";
            if (where != "")
            {
                strSql += string.Format(" where {0}", where);
            }
            return (int)DbHelper.Factory().ExecuteScalar(strSql);
        }
    }
}
