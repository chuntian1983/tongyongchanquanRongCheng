using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    /// T_ListedProject 挂牌项目
    /// </summary>
    [Serializable]
    public class T_ListedProject
    {
        private int _id;
        private int _adminuserid = 0;
        private string _unitcode = string.Empty;
        private string _pronum = string.Empty;
        private string _region = string.Empty;
        private string _protype = string.Empty;
        private string _outproname = string.Empty;
        private string _outname = string.Empty;
        private string _listingprice = string.Empty;
        private string _outperiod = string.Empty;
        private string _authorization = string.Empty;
        private string _located = string.Empty;
        private string _manageauth = string.Empty;
        private string _contractkind = string.Empty;
        private string _outarea = string.Empty;
        private string _farmersnum = string.Empty;
        private string _east = string.Empty;
        private string _south = string.Empty;
        private string _west = string.Empty;
        private string _north = string.Empty;
        private string _glebepurpose = string.Empty;
        private string _whetheragainout = string.Empty;
        private string _outway = string.Empty;
        private string _farmerswishes = string.Empty;
        private string _listedperiod = string.Empty;
        private string _twoapplication = string.Empty;
        private string _trancondition = string.Empty;
        private string _tranmode = string.Empty;
        private string _ismorseal = string.Empty;
        private string _other = string.Empty;
        private DateTime _enddate = DateTime.Now;
        private string _listingstatus = string.Empty;
        private int _ifup = 0;
        private int _ischeck = 0;
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
        /// AdminUserId管理员外键
        /// </summary>	
        public int AdminUserId
        {
            get { return _adminuserid; }
            set { _adminuserid = value; }
        }
        /// <summary>
        /// UnitCode 组织单位代码
        /// </summary>		
        public string UnitCode
        {
            get { return _unitcode; }
            set { _unitcode = value; }
        }
        /// <summary>
        /// ProNum项目编码
        /// </summary>		
        public string ProNum
        {
            get { return _pronum; }
            set { _pronum = value; }
        }
        /// <summary>
        /// Region区域
        /// </summary>		
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }
        /// <summary>
        /// ProType项目类别
        /// </summary>		
        public string ProType
        {
            get { return _protype; }
            set { _protype = value; }
        }
        /// <summary>
        /// OutProName 转出标的名称
        /// </summary>		
        public string OutProName
        {
            get { return _outproname; }
            set { _outproname = value; }
        }
        /// <summary>
        /// OutName 转出方名称
        /// </summary>		
        public string OutName
        {
            get { return _outname; }
            set { _outname = value; }
        }
        /// <summary>
        /// ListingPrice 挂牌价格
        /// </summary>		
        public string ListingPrice
        {
            get { return _listingprice; }
            set { _listingprice = value; }
        }
        /// <summary>
        /// OutPeriod 拟转出期限
        /// </summary>		
        public string OutPeriod
        {
            get { return _outperiod; }
            set { _outperiod = value; }
        }
        /// <summary>
        /// Authorization 授权情况
        /// </summary>		
        public string Authorization
        {
            get { return _authorization; }
            set { _authorization = value; }
        }
        /// <summary>
        /// Located 坐落/市镇村
        /// </summary>		
        public string Located
        {
            get { return _located; }
            set { _located = value; }
        }
        /// <summary>
        /// ManageAuth 权属
        /// </summary>		
        public string ManageAuth
        {
            get { return _manageauth; }
            set { _manageauth = value; }
        }
        /// <summary>
        /// ContractKind 承包方式
        /// </summary>		
        public string ContractKind
        {
            get { return _contractkind; }
            set { _contractkind = value; }
        }
        /// <summary>
        /// OutArea 拟转出面积（亩）
        /// </summary>		
        public string OutArea
        {
            get { return _outarea; }
            set { _outarea = value; }
        }
        /// <summary>
        /// FarmersNum 涉及农户数
        /// </summary>		
        public string FarmersNum
        {
            get { return _farmersnum; }
            set { _farmersnum = value; }
        }
        /// <summary>
        /// East 土地四至东至
        /// </summary>		
        public string East
        {
            get { return _east; }
            set { _east = value; }
        }
        /// <summary>
        /// South 土地四至南至
        /// </summary>		
        public string South
        {
            get { return _south; }
            set { _south = value; }
        }
        /// <summary>
        /// West 土地四至西至
        /// </summary>		
        public string West
        {
            get { return _west; }
            set { _west = value; }
        }
        /// <summary>
        /// North 土地四至北至
        /// </summary>		
        public string North
        {
            get { return _north; }
            set { _north = value; }
        }
        /// <summary>
        /// GlebePurpose 流转承包用途
        /// </summary>		
        public string GlebePurpose
        {
            get { return _glebepurpose; }
            set { _glebepurpose = value; }
        }
        /// <summary>
        /// WhetherAgainOut 是否属于再次转出
        /// </summary>		
        public string WhetherAgainOut
        {
            get { return _whetheragainout; }
            set { _whetheragainout = value; }
        }
        /// <summary>
        /// OutWay 拟转出方式
        /// </summary>		
        public string OutWay
        {
            get { return _outway; }
            set { _outway = value; }
        }
        /// <summary>
        /// FarmersWishes 农户转出意愿情况
        /// </summary>		
        public string FarmersWishes
        {
            get { return _farmerswishes; }
            set { _farmerswishes = value; }
        }
        /// <summary>
        /// ListedPeriod 挂牌公告期
        /// </summary>		
        public string ListedPeriod
        {
            get { return _listedperiod; }
            set { _listedperiod = value; }
        }
        /// <summary>
        /// TwoApplication 如征集到两个及以上有效转入申请
        /// </summary>		
        public string TwoApplication
        {
            get { return _twoapplication; }
            set { _twoapplication = value; }
        }
        /// <summary>
        /// TranCondition 转入方应具备的条件
        /// </summary>		
        public string TranCondition
        {
            get { return _trancondition; }
            set { _trancondition = value; }
        }
        /// <summary>
        /// TranMode 交易方式
        /// </summary>		
        public string TranMode
        {
            get { return _tranmode; }
            set { _tranmode = value; }
        }
        /// <summary>
        /// IsMorSeal 标是否存在
        //抵押、封查等情况
        /// </summary>		
        public string IsMorSeal
        {
            get { return _ismorseal; }
            set { _ismorseal = value; }
        }
        /// <summary>
        /// Other 其它需要披露事项
        /// </summary>		
        public string Other
        {
            get { return _other; }
            set { _other = value; }
        }
        /// <summary>
        /// EndDate 截止日期为
        /// </summary>		
        public DateTime EndDate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }
        /// <summary>
        /// ListingStatus 挂牌状态
        /// </summary>		
        public string ListingStatus
        {
            get { return _listingstatus; }
            set { _listingstatus = value; }
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
        /// CreateDate 创建时间
        /// </summary>		
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
    }
}

