using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    /// T_RoleRight 角色权限表
    /// </summary>
    [Serializable]
    public class T_RoleRight
    {
        private int _id;
        private int _adminuserid = 0;
        private int _sysfunid = 0;
        private int _ifadd = 0;
        private int _ifup = 0;
        private int _ifdel = 0;
        private int _ifsel = 0;
        private string _editor = string.Empty;
        private DateTime _createdate = DateTime.Now;

        /// <summary>
        /// Id 编号
        /// </summary>		
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// AdminUserId 管理员外键
        /// </summary>		
        public int AdminUserId
        {
            get { return _adminuserid; }
            set { _adminuserid = value; }
        }
        /// <summary>
        /// SysFunId 菜单栏外键
        /// </summary>		
        public int SysFunId
        {
            get { return _sysfunid; }
            set { _sysfunid = value; }
        }
        /// <summary>
        /// IfAdd 是否添加操作
        /// </summary>		
        public int IfAdd
        {
            get { return _ifadd; }
            set { _ifadd = value; }
        }
        /// <summary>
        /// IfUp 是否更新操作
        /// </summary>		
        public int IfUp
        {
            get { return _ifup; }
            set { _ifup = value; }
        }
        /// <summary>
        /// IfDel 是否删除操作
        /// </summary>		
        public int IfDel
        {
            get { return _ifdel; }
            set { _ifdel = value; }
        }
        /// <summary>
        /// IfSel 是否查询操作
        /// </summary>		
        public int IfSel
        {
            get { return _ifsel; }
            set { _ifsel = value; }
        }
        /// <summary>
        /// Editor 编辑人
        /// </summary>		
        public string Editor
        {
            get { return _editor; }
            set { _editor = value; }
        }
        /// <summary>
        /// CreateDate 创建时间
        /// </summary>		
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
    }
}

