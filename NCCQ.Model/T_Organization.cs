using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    /// T_Organization 组织单位表
    /// </summary>
    [Serializable]
    public class T_Organization
    {
        private string _orgcode = string.Empty;
        private string _orgname = string.Empty;
        private string _orgshortname = string.Empty;
        private string _uporgcode = string.Empty;
        private int _seq = 0;
        private int _level = 0;
        private string _shengcode = string.Empty;
        private string _shicode = string.Empty;
        private string _xiancode = string.Empty;
        private string _xiangcode = string.Empty;
        private string _cuncode = string.Empty;
        private string _zuncode = string.Empty;

        /// <summary>
        /// OrgCode 组织单位代码
        /// </summary>		
        public string OrgCode
        {
            get { return _orgcode; }
            set { _orgcode = value; }
        }
        /// <summary>
        /// OrgName 组织单位全称
        /// </summary>		
        public string OrgName
        {
            get { return _orgname; }
            set { _orgname = value; }
        }
        /// <summary>
        /// OrgShortName 组织单位简称
        /// </summary>		
        public string OrgShortName
        {
            get { return _orgshortname; }
            set { _orgshortname = value; }
        }
        /// <summary>
        /// UpOrgCode 上级单位代码
        /// </summary>		
        public string UpOrgCode
        {
            get { return _uporgcode; }
            set { _uporgcode = value; }
        }
        /// <summary>
        /// Seq 编号
        /// </summary>		
        public int Seq
        {
            get { return _seq; }
            set { _seq = value; }
        }
        /// <summary>
        /// Level 级别
        /// </summary>		
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        /// <summary>
        /// ShengCode 省代码
        /// </summary>		
        public string ShengCode
        {
            get { return _shengcode; }
            set { _shengcode = value; }
        }
        /// <summary>
        /// ShiCode 市代码
        /// </summary>		
        public string ShiCode
        {
            get { return _shicode; }
            set { _shicode = value; }
        }
        /// <summary>
        /// XianCode 市县代码
        /// </summary>		
        public string XianCode
        {
            get { return _xiancode; }
            set { _xiancode = value; }
        }
        /// <summary>
        /// XiangCode 乡镇代码
        /// </summary>		
        public string XiangCode
        {
            get { return _xiangcode; }
            set { _xiangcode = value; }
        }
        /// <summary>
        /// CunCode 村代码
        /// </summary>		
        public string CunCode
        {
            get { return _cuncode; }
            set { _cuncode = value; }
        }
        /// <summary>
        /// ZunCode 组代码
        /// </summary>		
        public string ZunCode
        {
            get { return _zuncode; }
            set { _zuncode = value; }
        }
    }
}

