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
    public class T_LinksDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public bool Create(T_Links model)
        {
            try
            {
                object[] obj = { model.LinkName, model.LinkUrl, model.LinkImgurl, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss") };
                string strSql = string.Format(" insert into [T_Links]([LinkName],[LinkUrl],[LinkImgurl],[Editor],[CreateDate])values('{0}','{1}','{2}','{3}','{4}')", obj);
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
        /// <param name="id"></param>
        public bool Delete(int Id)
        {
            try
            {
                string strSql = string.Format("delete from T_Links where Id={0}", Id);
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
        public bool Update(T_Links model) 
        {
            try
            {
                object[] obj = { model.LinkName, model.LinkUrl, model.LinkImgurl, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.Id };
                string strSql = string.Format(" update [T_Links] set [LinkName] = '{0}',[LinkUrl] = '{1}',[LinkImgurl] = '{2}',[Editor] = '{3}',[CreateDate] = '{4}' where Id ={5} ", obj);
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
        /// <returns></returns>
        public DataTable GetAllList(string sqlWhere, int startIndex, int pageSize, string order)
        {
            string strSql = "select [Id],[LinkName],[LinkUrl],[LinkImgurl],[Editor],[CreateDate] from [T_Links] ";
            if (sqlWhere != "")
            {
                strSql += string.Format(" where {0}", sqlWhere);
            }
            strSql += order;
            return DbHelper.Factory().ExecuteDataTable(strSql, startIndex * pageSize, pageSize, "T_FileInfo");
        }
        //
        public int CountNum(string where)
        {
            string strSql = "select count(Id) from T_Links ";
            if (where != "")
            {
                strSql += string.Format(" where {0}", where);
            }
            return (int)DbHelper.Factory().ExecuteScalar(strSql);
        }
        //
        public T_Links GetById(int id)
        {
            T_Links model = null;
            string strSql = string.Format("select [Id],[LinkName],[LinkUrl],[LinkImgurl],[Editor],[CreateDate] from [T_Links] where Id= {0}", id);
            using (dynamic read = DbHelper.Factory().ExecuteReader(strSql))
            {
                model = new T_Links();
                if (read.Read())
                {
                    try { model.Id = int.Parse(read["Id"].ToString()); }
                    catch { }
                    model.LinkName = read["LinkName"].ToString();
                    model.LinkUrl = read["LinkUrl"].ToString();
                    model.LinkImgurl = read["LinkImgurl"].ToString();
                    model.Editor = read["Editor"].ToString();
                    try { model.CreateDate = DateTime.Parse(read["CreateDate"].ToString()); }
                    catch { }
                }
                read.Dispose();
            }
            return model;
        }
    }
}
