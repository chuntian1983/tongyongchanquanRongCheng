using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NCCQ.DBFactory;
using NCCQ.Model;

namespace NCCQ.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class T_ListedProjectTypeDal
    {
        //添加
        public bool Create(T_ListedProjectType model)
        {
            try
            {
                object[] obj = { model.ListedProjectTypeName, model.ListedProjectTypeOrder, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.Editor };
                string strSql = string.Format(" insert into [T_ListedProjectType]([ListedProjectTypeName],[ListedProjectTypeOrder],[CreateDate],[Editor])values('{0}',{1},'{2}','{3}')", obj);
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
        //
        public T_ListedProjectType GetById(int id)
        {
            string strSql = string.Format(" select [Id],[ListedProjectTypeName],[ListedProjectTypeOrder],[CreateDate],[Editor] from T_ListedProjectType where Id={0}", id);
            T_ListedProjectType model = null;
            using (dynamic read = DbHelper.Factory().ExecuteReader(strSql.ToString()))
            {
                model = new T_ListedProjectType();
                if (read.Read())
                {
                    try { model.Id = int.Parse(read["Id"].ToString()); }
                    catch { }
                    model.ListedProjectTypeName = read["ListedProjectTypeName"].ToString();
                    try { model.ListedProjectTypeOrder = int.Parse(read["ListedProjectTypeOrder"].ToString()); }
                    catch { }
                    model.Editor = read["Editor"].ToString();
                    model.CreateDate = DateTime.Parse(read["CreateDate"].ToString());
                }
                read.Dispose();
            }
            return model;
        }
        //更新
        public bool Update(T_ListedProjectType model)
        {
            try
            {
                object[] obj = { model.ListedProjectTypeName, model.ListedProjectTypeOrder, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.Editor, model.Id };
                string strSql = string.Format(" update [T_ListedProjectType] set [ListedProjectTypeName] = '{0}',[ListedProjectTypeOrder] = {1},[CreateDate] = '{2}',[Editor] ='{3}'  where Id={4}", obj);
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
        //获取数据列表
        public DataTable GetAllList(string order)
        {
            try
            {
                string strSql = string.Format("SELECT [Id],[ListedProjectTypeName],[ListedProjectTypeOrder],[CreateDate],[Editor] FROM [T_ListedProjectType] {0}", order);
                return DbHelper.Factory().ExecuteDataTable(strSql);
            }
            catch { throw; }
        }
    }
}
