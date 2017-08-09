using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCCQ.Model;
using System.Data;
using NCCQ.DBFactory;

namespace NCCQ.DAL
{
    /// <summary>
    /// 角色权限表
    /// </summary>
    public class T_RoleRightDal
    {
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create(T_RoleRight model)
        {
            try
            {
                object[] obj = { model.AdminUserId, model.SysFunId, model.IfAdd, model.IfUp, model.IfDel, model.IfSel, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss") };
                string strSql = string.Format("insert into T_RoleRight (AdminUserId,SysFunId,IfAdd,IfUp,IfDel,IfSel,Editor,CreateDate) values ({0},{1},{2},{3},{4},{5},'{6}','{7}')", obj);
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
                string strSql = string.Format("delete from T_RoleRight where AdminUserId={0}", adminUserId);
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
        /// 根据角色判断菜单
        /// </summary>
        /// <param name="adminUserId"></param>
        /// <param name="parentNodeId"></param>
        /// <returns></returns>
        public DataTable GetRoleList(int adminUserId, int parentNodeId)
        {
            string strSql = string.Format(" select c.ParentNodeId,c.DisplayName,c.NodeURL,c.NodeId,a.IfAdd,a.IfDel,a.IfSel,a.IfUp from T_RoleRight as a left join T_Role as b on a.AdminUserId = b.Id left join T_SysFun as c on a.SysFunId = c.NodeId left join T_AdminUser as ad on ad.Roleid=b.id  where ad.Id = {0} and c.ParentNodeId={1} order by c.DisplayOrder asc ", adminUserId, parentNodeId);
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }
        /// <summary>
        /// 超级管理员所有菜单权限
        /// </summary>
        /// <returns></returns>
        public DataTable GetAdminRolelList(int parentNodeId)
        {
            string strSql = string.Format("select * from T_SysFun where ParentNodeId='{0}'",parentNodeId);
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }
    }
}
