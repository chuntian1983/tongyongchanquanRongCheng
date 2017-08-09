using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    /// T_SysLog 系统日志表
    /// </summary>
    [Serializable]
    public class T_SysLog
    {
        private int _id;
        private string _logvalue = string.Empty;
        private string _operates = string.Empty;
        private string _ip = string.Empty;
        private string _editor = string.Empty;
        private string _hostname = string.Empty;        
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
        /// LogValue 操作日志内容
        /// </summary>		
        public string LogValue
        {
            get { return _logvalue; }
            set { _logvalue = value; }
        }
        /// <summary>
        /// Operates 操作类型
        /// </summary>		
        public string Operates
        {
            get { return _operates; }
            set { _operates = value; }
        }
        /// <summary>
        /// Ip 操作ip
        /// </summary>	
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        /// <summary>
        /// 主机名称
        /// </summary>
        public string HostName
        {
            get { return _hostname; }
            set { _hostname = value; }
        }
        /// <summary>
        /// Editor 操作人
        /// </summary>		
        public string Editor
        {
            get { return _editor; }
            set { _editor = value; }
        }
        /// <summary>
        /// CreateDate 添加时间
        /// </summary>		
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
    }
}

