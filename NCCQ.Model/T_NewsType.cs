using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    ///T_NewsType 新闻类型表
    /// </summary>
    [Serializable]
    public class T_NewsType
    {
        private int _id = 0;
        private string _newstypename = string.Empty;
        private int _upid = 0;
        private int _typelevel = 0;
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
        /// NewsTypeName 新闻类型名称
        /// </summary>		
        public string NewsTypeName
        {
            get { return _newstypename; }
            set { _newstypename = value; }
        }
        /// <summary>
        /// UpId 父节点
        /// </summary>		
        public int UpId
        {
            get { return _upid; }
            set { _upid = value; }
        }
        /// <summary>
        /// TypeLevel 级别
        /// </summary>		
        public int TypeLevel
        {
            get { return _typelevel; }
            set { _typelevel = value; }
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

