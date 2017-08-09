using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    ///T_ListedProjectType 挂牌项目名称类型
    /// </summary>
    [Serializable]
    public class T_ListedProjectType
    {
        private int _id;
        private string _listedprojecttypename = string.Empty;
        private int _listedprojecttypeorder = 0;
        private DateTime _createdate = DateTime.Now;
        private string _editor = string.Empty;

        /// <summary>
        /// Id 编号
        /// </summary>		
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// ListedProjectTypeName 挂牌项目名称
        /// </summary>		
        public string ListedProjectTypeName
        {
            get { return _listedprojecttypename; }
            set { _listedprojecttypename = value; }
        }
        /// <summary>
        /// ListedProjectTypeOrder 排序
        /// </summary>		
        public int ListedProjectTypeOrder
        {
            get { return _listedprojecttypeorder; }
            set { _listedprojecttypeorder = value; }
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
        /// Editor 编辑人
        /// </summary>		
        public string Editor
        {
            get { return _editor; }
            set { _editor = value; }
        }
    }
}

