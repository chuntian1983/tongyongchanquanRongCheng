using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    /// T_FileInfo上传文件信息表
    /// </summary>
    [Serializable]
    public class T_FileInfo
    {
        private int _id;
        private string _filename = string.Empty;
        private string _filetypesuffix = string.Empty;
        private int _filetypename = 0;
        private string _filepath = string.Empty;
        private string _editor = string.Empty;
        private DateTime _createdate = DateTime.Now;

        /// <summary>
        /// Id文件编号
        /// </summary>		
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// FileName文件名称
        /// </summary>		
        public string FileName
        {
            get { return _filename; }
            set { _filename = value; }
        }
        /// <summary>
        /// FileTypeSuffix文件类型后缀
        /// </summary>		
        public string FileTypeSuffix
        {
            get { return _filetypesuffix; }
            set { _filetypesuffix = value; }
        }
        /// <summary>
        /// FileTypeName文件类型名称
        /// </summary>		
        public int FileTypeName
        {
            get { return _filetypename; }
            set { _filetypename = value; }
        }
        /// <summary>
        /// FilePath文件路径
        /// </summary>		
        public string FilePath
        {
            get { return _filepath; }
            set { _filepath = value; }
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
    }
}

