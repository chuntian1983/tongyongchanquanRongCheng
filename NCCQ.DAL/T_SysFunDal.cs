using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCCQ.DBFactory;
using System.Data;
using NCCQ.Model;

namespace NCCQ.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class T_SysFunDal
    {
        //是否存在
        public bool Exists(int NodeId)
        {
            try
            {
                string strSql = string.Format("select ParentNodeId from T_SysFun where ParentNodeId={0}", NodeId);
                using (dynamic read = DbHelper.Factory().ExecuteReader(strSql))
                {
                    if (read.Read())
                    {
                        read.Dispose();
                        return false;
                    }
                    else
                    {
                        read.Dispose();
                        return true;
                    }
                }
            }
            catch { return false; }
        }
        //创建
        public bool Create(T_SysFun model)
        {
            object[] obj = { model.DisplayName, model.NodeURL, model.DisplayOrder, model.ParentNodeId, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss") };
            string strSql = string.Format(" insert into T_SysFun (DisplayName,NodeURL,DisplayOrder,ParentNodeId,Editor,CreateDate) values ('{0}','{1}',{2},{3},'{4}','{5}') ", obj);
            if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0) { return true; } else { return false; }
        }
        //更新
        public bool Update(T_SysFun model)
        {
            object[] obj = { model.DisplayName, model.NodeURL, model.DisplayOrder, model.ParentNodeId, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.NodeId };
            string strSql = string.Format(" update T_SysFun set DisplayName = '{0}',NodeURL = '{1}',DisplayOrder = {2},ParentNodeId = {3},Editor = '{4}',CreateDate ='{5}' where NodeId={6} ", obj);
            if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0) { return true; } else { return false; }
        }
        //删除
        public bool Delete(int id)
        {
            string strSql = string.Format(" delete from T_SysFun where NodeId ={0} ", id);
            if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0) { return true; } else { return false; }
        }
        //查询单个对象
        public T_SysFun GetById(int id)
        {
            string strSql = string.Format(" SELECT NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId,Editor,CreateDate FROM T_SysFun where NodeId = {0} ", id);
            T_SysFun model = null;
            using (dynamic read = DbHelper.Factory().ExecuteReader(strSql))
            {
                if (read.Read())
                {
                    model = new T_SysFun();
                    try { model.NodeId = int.Parse(read["NodeId"].ToString()); }
                    catch { }
                    model.DisplayName = read["DisplayName"].ToString();
                    model.NodeURL = read["NodeURL"].ToString();
                    try { model.DisplayOrder = int.Parse(read["DisplayOrder"].ToString()); }
                    catch { }
                    try { model.ParentNodeId = int.Parse(read["ParentNodeId"].ToString()); }
                    catch { }
                    model.Editor = read["Editor"].ToString();
                    model.CreateDate = DateTime.Parse(read["CreateDate"].ToString());
                }
                read.Dispose();
            }
            return model;
        }
        //返回所有
        public DataTable GetAllList(string order)
        {
            string strSql = string.Format(" SELECT NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId,Editor,CreateDate FROM T_SysFun {0} ", order);
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }
        //
        public DataTable GetTree(int ParentNodeId)
        {
            string strSql = string.Format(" SELECT NodeId,DisplayName,NodeURL,DisplayOrder,ParentNodeId,Editor,CreateDate FROM T_SysFun where ParentNodeId = {0} order by ParentNodeId asc ", ParentNodeId);
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }
        /// <summary>
        /// 角色是否存在菜单权限
        /// </summary>
        /// <param name="roleid">角色id</param>
        /// <param name="sysfunid">菜单id</param>
        /// <returns></returns>
        public DataTable GetCheck(string roleid, string sysfunid)
        {
            string strsql = "select * from T_RoleRight where AdminUserId='" + roleid + "' and SysFunId='"+sysfunid+"'";
            return DbHelper.Factory().ExecuteDataTable(strsql);
        }
    }
}
