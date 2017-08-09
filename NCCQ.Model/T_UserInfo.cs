using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    /// T_UserInfo 会员信息
    /// </summary>
    [Serializable]
    public class T_UserInfo
    {
        private int _id;
        private string _userlogname = string.Empty;
        private string _userlogpass = string.Empty;
        private string _username = string.Empty;
        private string _usersex = string.Empty;
        private string _cardid = string.Empty;
        private string _useraddress = string.Empty;
        private string _usertel = string.Empty;
        private string _useremail = string.Empty;
        private int _userlognum = 0;
        private int _userstate = 0;
        private int _ischeck = 0;
        private DateTime _createdate = DateTime.Now;
        private DateTime _enddate = DateTime.Now;

        /// <summary>
        /// Id编号
        /// </summary>		
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// UserLogName 登陆账号名称
        /// </summary>		
        public string UserLogName
        {
            get { return _userlogname; }
            set { _userlogname = value; }
        }
        /// <summary>
        /// UserLogPass 登陆密码
        /// </summary>		
        public string UserLogPass
        {
            get { return _userlogpass; }
            set { _userlogpass = value; }
        }
        /// <summary>
        /// UserName 会员姓名
        /// </summary>		
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// UserSex 会员性别
        /// </summary>		
        public string UserSex
        {
            get { return _usersex; }
            set { _usersex = value; }
        }
        /// <summary>
        /// CardId 身份证号码
        /// </summary>		
        public string CardId
        {
            get { return _cardid; }
            set { _cardid = value; }
        }
        /// <summary>
        /// UserAddress 会员地址
        /// </summary>		 
        public string UserAddress
        {
            get { return _useraddress; }
            set { _useraddress = value; }
        }
        /// <summary>
        /// UserTel 会员电话
        /// </summary>		
        public string UserTel
        {
            get { return _usertel; }
            set { _usertel = value; }
        }
        /// <summary>
        /// UserEmail 会员电子邮箱
        /// </summary>		
        public string UserEmail
        {
            get { return _useremail; }
            set { _useremail = value; }
        }
        /// <summary>
        /// UserLogNum 会员登陆次数
        /// </summary>		
        public int UserLogNum
        {
            get { return _userlognum; }
            set { _userlognum = value; }
        }
        /// <summary>
        /// UserState 用户状态
        /// </summary>		
        public int UserState
        {
            get { return _userstate; }
            set { _userstate = value; }
        }
        /// <summary>
        /// IsCheck 是否有权限越级审核
        /// </summary>		
        public int IsCheck
        {
            get { return _ischeck; }
            set { _ischeck = value; }
        }
        /// <summary>
        /// CreateDate 创建时间
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
    }
}

