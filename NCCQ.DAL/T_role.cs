using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCCQ.Model;
using System.Data;
using NCCQ.DBFactory;

namespace NCCQ.DAL
{
    public class T_role
    {
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create(NCCQ.Model.T_role model)
        {
            try
            {
                object[] obj = { model.rolename, model.editer, model.creatdate.ToString("yyyy-MM-dd HH:mm:ss") };
                string strSql = string.Format("insert into T_Role (rolename,editer,creatdate) values ('{0}','{1}','{2}')", obj);
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
        /// 删除权限
        /// </summary>
        /// <param name="adminUserId"></param>
        /// <returns></returns>
        public bool Delete(int adminUserId)
        {
            try
            {
                string strSql = string.Format("delete from T_Role where id={0}", adminUserId);
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
        //更新
        public bool Update(string rolename,string id)
        {
            try
            {
                object[] obj = { rolename, id};
                string strSql = string.Format("update T_Role set rolename='{0}' where Id='{1}'", obj);
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
        //获取单个对象
        public NCCQ.Model.T_role GetModel(int id)
        {
            try
            {
                string strSql = string.Format("select * from T_Role where Id={0}", id);
                NCCQ.Model.T_role model = null;
                using (dynamic read = DbHelper.Factory().ExecuteReader(strSql.ToString()))
                {
                    model =new Model.T_role();
                    if (read.Read())
                    {

                        model.id = int.Parse(read["Id"].ToString());
                        try { model.rolename = int.Parse(read["rolename"].ToString()); }
                        catch { }
                        try { model.editer = int.Parse(read["editer"].ToString()); }
                        catch { }

                        try { model.creatdate = DateTime.Parse(read["creatdate"].ToString()); }
                        catch { }
                    }
                    read.Dispose();
                }
                return model;
            }
            catch (Exception) { throw; }
        }
        public DataTable GetList(string userid)
        {
            string strsql = "select * from t_role";
            if (!string.IsNullOrEmpty(userid))
            {
                strsql += "  where id='"+userid+"'";
            }
            return DbHelper.Factory().ExecuteDataTable(strsql);
        }
        /// <summary>
        /// 返回权限列表信息
        /// </summary>
        /// <param name="adminUserId"></param>
        /// <returns></returns>
        public DataTable GetAllList(int adminUserId)
        {
            string strSql = string.Format(" select a.Id,b.AdminLogName as AdminUserId, c.DisplayName as SysFunId,a.IfAdd,a.IfUp,a.IfDel,a.IfSel,a.Editor,a.CreateDate from T_RoleRight as a left join T_AdminUser as b on a.AdminUserId = b.Id left join T_SysFun as c on a.SysFunId = c.NodeId where a.AdminUserId = {0} ", adminUserId);
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }
        //
        public DataTable GetAllList(int adminUserId, int parentNodeId)
        {
            string strSql = string.Format(" select c.ParentNodeId,c.DisplayName,c.NodeURL,c.NodeId,a.IfAdd,a.IfDel,a.IfSel,a.IfUp from T_RoleRight as a left join T_AdminUser as b on a.AdminUserId = b.Id left join T_SysFun as c on a.SysFunId = c.NodeId where a.AdminUserId = {0} and c.ParentNodeId={1} order by c.DisplayOrder asc ", adminUserId, parentNodeId);
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.T_role GetModelRole(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" id,rolename,editer,creatdate ");
            strSql.Append(" from T_Role ");
            strSql.Append(" where id=" + id + "");
            Model.T_role model = new Model.T_role();
            DataTable ds = DbHelper.Factory().ExecuteDataTable(strSql.ToString());
            if (ds.Rows.Count > 0)
            {
                return DataRowToModel(ds.Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.T_role DataRowToModel(DataRow row)
        {
            Model.T_role model = new Model.T_role();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["rolename"] != null)
                {
                    model.rolename = row["rolename"].ToString();
                }
                if (row["editer"] != null)
                {
                    model.editer = row["editer"].ToString();
                }
                if (row["creatdate"] != null && row["creatdate"].ToString() != "")
                {
                    model.creatdate = DateTime.Parse(row["creatdate"].ToString());
                }
            }
            return model;
        }
    }
}
