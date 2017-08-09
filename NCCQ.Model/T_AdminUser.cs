using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    /// T_AdminUser 系统管理员表
    /// </summary>
    [Serializable]
    public class T_AdminUser
    {
        private int _id = 0;
        private string _adminlogname = string.Empty;
        private string _adminlogpass = string.Empty;
        private string _adminname = string.Empty;
        private string _admintel = string.Empty;
        private string _unitcode = string.Empty;
        private int _admintype = 0;
        private int _adminstate = 0;
        private DateTime _createdate = DateTime.Now;
        private int _adminlognum = 0;
        private int _ischeck = 0;
        private string _editor = string.Empty;
        private DateTime _enddate = DateTime.Now;
        private string _roleid;
        /// <summary>
        /// id编号
        /// </summary>	       
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// AdminLogName登陆名
        /// </summary>		
        public string AdminLogName
        {
            get { return _adminlogname; }
            set { _adminlogname = value; }
        }
        /// <summary>
        /// AdminLogPass密码
        /// </summary>		
        public string AdminLogPass
        {
            get { return _adminlogpass; }
            set { _adminlogpass = value; }
        }
        /// <summary>
        /// AdminName管理员姓名
        /// </summary>		
        public string AdminName
        {
            get { return _adminname; }
            set { _adminname = value; }
        }
        /// <summary>
        /// AdminTel管理员电话
        /// </summary>		
        public string AdminTel
        {
            get { return _admintel; }
            set { _admintel = value; }
        }
        /// <summary>
        /// UnitCode组织单位代码
        /// </summary>	
        public string UnitCode
        {
            get { return _unitcode; }
            set { _unitcode = value; }
        }
        /// <summary>
        /// AdminType管理员类型
        /// </summary>		
        public int AdminType
        {
            get { return _admintype; }
            set { _admintype = value; }
        }
        /// <summary>
        /// AdminState管理员状态
        /// </summary>		
        public int AdminState
        {
            get { return _adminstate; }
            set { _adminstate = value; }
        }
        /// <summary>
        /// AdminLogNum管理员登陆次数
        /// </summary>		
        public int AdminLogNum
        {
            get { return _adminlognum; }
            set { _adminlognum = value; }
        }
        /// <summary>
        /// IsCheck是否有权限越级审核
        /// </summary>		
        public int IsCheck
        {
            get { return _ischeck; }
            set { _ischeck = value; }
        }
        /// <summary>
        /// Editor编辑人
        /// </summary>		
        public string Editor
        {
            get { return _editor; }
            set { _editor = value; }
        }
        /// <summary>
        /// CreateDate创建时间
        /// </summary>		
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime EndDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 角色id
        /// </summary>		
        public string Roleid
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
    }
}

