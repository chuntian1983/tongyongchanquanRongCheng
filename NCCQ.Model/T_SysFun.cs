using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    /// T_SysFun 系统菜单表
    /// </summary>
    [Serializable]
    public class T_SysFun
    {
        private int _nodeid;
        private string _displayname = string.Empty;
        private string _nodeurl = string.Empty;
        private int _displayorder = 0;
        private int _parentnodeid = 0;
        private string _editor = string.Empty;
        private DateTime _createdate = DateTime.Now;

        /// <summary>
        /// NodeId 菜单节点id
        /// </summary>		
        public int NodeId
        {
            get { return _nodeid; }
            set { _nodeid = value; }
        }
        /// <summary>
        /// DisplayName 菜单名称
        /// </summary>		
        public string DisplayName
        {
            get { return _displayname; }
            set { _displayname = value; }
        }
        /// <summary>
        /// NodeURL 菜单连接地址
        /// </summary>		
        public string NodeURL
        {
            get { return _nodeurl; }
            set { _nodeurl = value; }
        }
        /// <summary>
        /// DisplayOrder 菜单显示顺序
        /// </summary>		
        public int DisplayOrder
        {
            get { return _displayorder; }
            set { _displayorder = value; }
        }
        /// <summary>
        /// ParentNodeId 父节点id
        /// </summary>		
        public int ParentNodeId
        {
            get { return _parentnodeid; }
            set { _parentnodeid = value; }
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

