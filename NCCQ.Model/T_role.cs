using System;
using System.Collections.Generic;

using System.Text;

namespace NCCQ.Model
{
    [Serializable]
    public class T_role
    {
     
        #region Model
        private int _id;
        private string _rolename;
        private string _editer;
        private DateTime _createdate = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rolename
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string editer
        {
            set { _editer = value; }
            get { return _editer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime creatdate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model
    }
}
