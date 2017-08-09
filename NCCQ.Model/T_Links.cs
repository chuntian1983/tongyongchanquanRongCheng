using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    /// T_Links友情链接表
    /// </summary>
    [Serializable]
    public class T_Links
    {
        private int _id;
        private string _linkname = string.Empty;
        private string _linkurl = string.Empty;
        private string _linkimgurl = string.Empty;
        private string _editor = string.Empty;
        private DateTime _createdate = DateTime.Now;

        /// <summary>
        /// Id编号
        /// </summary>		
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// LinkName友情链接名称
        /// </summary>		
        public string LinkName
        {
            get { return _linkname; }
            set { _linkname = value; }
        }
        /// <summary>
        /// LinkUrl url链接地址
        /// </summary>		
        public string LinkUrl
        {
            get { return _linkurl; }
            set { _linkurl = value; }
        }
        /// <summary>
        /// LinkImgurl 图片地址
        /// </summary>		
        public string LinkImgurl
        {
            get { return _linkimgurl; }
            set { _linkimgurl = value; }
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

