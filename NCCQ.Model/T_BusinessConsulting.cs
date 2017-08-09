using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    /// T_BusinessConsulting业务咨询
    /// </summary>
    [Serializable]
    public class T_BusinessConsulting
    {
        private int _id;
        private string _username = string.Empty;
        private string _useraddress = string.Empty;
        private string _usertel = string.Empty;
        private string _useremail = string.Empty;
        private string _constitle = string.Empty;
        private string _conscontent = string.Empty;
        private DateTime _consdate = DateTime.Now;
        private string _replycontent = string.Empty;
        private DateTime _replydate;
        private string _replyuser = string.Empty;
        private string _BusinessType = string.Empty;
        private string _BusinsessState = string.Empty;
        /// <summary>
        /// Id编号
        /// </summary>		
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// UserName姓名
        /// </summary>		
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// UserAddress地址
        /// </summary>		
        public string UserAddress
        {
            get { return _useraddress; }
            set { _useraddress = value; }
        }
        /// <summary>
        /// UserTel电话
        /// </summary>		
        public string UserTel
        {
            get { return _usertel; }
            set { _usertel = value; }
        }
        /// <summary>
        /// UserEmail邮箱
        /// </summary>		
        public string UserEmail
        {
            get { return _useremail; }
            set { _useremail = value; }
        }
        /// <summary>
        /// ConsTitle主题
        /// </summary>		
        public string ConsTitle
        {
            get { return _constitle; }
            set { _constitle = value; }
        }
        /// <summary>
        /// ConsContent内容
        /// </summary>		
        public string ConsContent
        {
            get { return _conscontent; }
            set { _conscontent = value; }
        }
        /// <summary>
        /// ConsDate咨询时间
        /// </summary>		
        public DateTime ConsDate
        {
            get { return _consdate; }
            set { _consdate = value; }
        }
        /// <summary>
        /// ReplyContent回复内容
        /// </summary>		
        public string ReplyContent
        {
            get { return _replycontent; }
            set { _replycontent = value; }
        }
        /// <summary>
        /// ReplyDate回复时间
        /// </summary>		
        public DateTime ReplyDate
        {
            get { return _replydate; }
            set { _replydate = value; }
        }
        /// <summary>
        /// ReplyUser回复人
        /// </summary>		
        public string ReplyUser
        {
            get { return _replyuser; }
            set { _replyuser = value; }
        }
        /// <summary>
        /// 业务类型
        /// </summary>		
        public string BusinessType
        {
            get { return _BusinessType; }
            set { _BusinessType = value; }
        }
        /// <summary>
        /// 回复标识1为回复
        /// </summary>		
        public string BusinsessState
        {
            get { return _BusinsessState; }
            set { _BusinsessState = value; }
        }

    }
}

