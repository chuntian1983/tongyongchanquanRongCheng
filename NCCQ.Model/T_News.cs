using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    ///T_News 新闻表
    /// </summary>
    [Serializable]
    public class T_News
    {
        private int _id;
        private int _adminuserid = 0;
        private int _newstypeid = 0;
        private string _keyword = string.Empty;
        private string _content = string.Empty;
        private string _unitcode = string.Empty;
        private string _newstitle = string.Empty;
        private string _newssubheading = string.Empty;
        private string _newssource = string.Empty;
        private string _newscontent = string.Empty;
        private string _newsimg = string.Empty;
        private int _numclicks = 0;
        private int _ifshow = 0;
        private int _ifhost = 0;
        private int _ifdel = 0;
        private int _ifup = 0;
        private int _ischeck = 0;
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
        /// NewsTypeId 新闻类别
        /// </summary>		
        public int NewsTypeId
        {
            get { return _newstypeid; }
            set { _newstypeid = value; }
        }
        /// <summary>
        /// Keyword 新闻关键字
        /// </summary>		
        public string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; }
        }
        /// <summary>
        /// Content 新闻内容
        /// </summary>		
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        /// <summary>
        /// UnitCode 组织单位
        /// </summary>		
        public string UnitCode
        {
            get { return _unitcode; }
            set { _unitcode = value; }
        }
        /// <summary>
        /// NewsTitle 新闻主标题
        /// </summary>		
        public string NewsTitle
        {
            get { return _newstitle; }
            set { _newstitle = value; }
        }
        /// <summary>
        /// NewsSubheading 新闻副标题
        /// </summary>		
        public string NewsSubheading
        {
            get { return _newssubheading; }
            set { _newssubheading = value; }
        }
        /// <summary>
        /// NewsSource 新闻来源
        /// </summary>		
        public string NewsSource
        {
            get { return _newssource; }
            set { _newssource = value; }
        }
        /// <summary>
        /// NewsContent 新闻内容
        /// </summary>		
        public string NewsContent
        {
            get { return _newscontent; }
            set { _newscontent = value; }
        }
        /// <summary>
        /// NewsImg 新闻图片
        /// </summary>		
        public string NewsImg
        {
            get { return _newsimg; }
            set { _newsimg = value; }
        }
        /// <summary>
        /// NumClicks 点击数(默认0)
        /// </summary>		
        public int NumClicks
        {
            get { return _numclicks; }
            set { _numclicks = value; }
        }
        /// <summary>
        /// IfShow 新闻是否显示
        /// </summary>		
        public int IfShow
        {
            get { return _ifshow; }
            set { _ifshow = value; }
        }
        /// <summary>
        /// IfHost 是否热点新闻
        /// </summary>		
        public int IfHost
        {
            get { return _ifhost; }
            set { _ifhost = value; }
        }
        /// <summary>
        /// IfDel 是否删除
        /// </summary>		
        public int IfDel
        {
            get { return _ifdel; }
            set { _ifdel = value; }
        }
        /// <summary>
        /// IfUp 是否置顶
        /// </summary>		
        public int IfUp
        {
            get { return _ifup; }
            set { _ifup = value; }
        }
        /// <summary>
        /// IsCheck 审核是否通过
        /// </summary>		
        public int IsCheck
        {
            get { return _ischeck; }
            set { _ischeck = value; }
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

