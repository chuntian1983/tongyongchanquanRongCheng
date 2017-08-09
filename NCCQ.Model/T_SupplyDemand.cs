using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace NCCQ.Model
{
    /// <summary>
    /// T_SupplyDemand 供应需求信息
    /// </summary>
    [Serializable]
    public class T_SupplyDemand
    {
        private int _id = 0;
        private int _userinfoid = 0;
        private int _supplyordemand = 1;
        private string _proname = string.Empty;
        private string _keyword = string.Empty;
        private string _pronum = string.Empty;
        private string _dname = string.Empty;
        private string _dglebepurpose = string.Empty;
        private DateTime _dlistingdate = DateTime.Now;
        private string _darea = string.Empty;
        private string _dquotation = string.Empty;
        private string _dcirculation = string.Empty;
        private string _ddeadline = string.Empty;
        private string _dcentercontact = string.Empty;
        private string _dprocontact = string.Empty;
        private string _sname = string.Empty;
        private string _slandproperties = string.Empty;
        private string _sother = string.Empty;
        private string _slocated = string.Empty;
        private string _soutarea = string.Empty;
        private string _sdeadline = string.Empty;
        private string _soutway = string.Empty;
        private DateTime _slisteddata = DateTime.Now;
        private string _soutagain = string.Empty;
        private string _stransactions = string.Empty;
        private string _sismorseal = string.Empty;
        private string _slistingprice = string.Empty;
        private string _scentercontact = string.Empty;
        private string _sprocontact = string.Empty;
        private string _ssettlement = string.Empty;
        private int _ischeck = 0;
        private DateTime _createdate = DateTime.Now;
        private string _remark = string.Empty;

        /// <summary>
        /// Id 编号
        /// </summary>		
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// UserInfoId 会员信息表外键
        /// </summary>		
        public int UserInfoId
        {
            get { return _userinfoid; }
            set { _userinfoid = value; }
        }
        /// <summary>
        /// SupplyOrDemand 供求或需求
        /// </summary>		
        public int SupplyOrDemand
        {
            get { return _supplyordemand; }
            set { _supplyordemand = value; }
        }
        /// <summary>
        /// ProName 项目名称
        /// </summary>		
        public string ProName
        {
            get { return _proname; }
            set { _proname = value; }
        }
        /// <summary>
        /// KeyWord 关键字
        /// </summary>		
        public string KeyWord
        {
            get { return _keyword; }
            set { _keyword = value; }
        }
        /// <summary>
        /// ProNum 项目编号
        /// </summary>		
        public string ProNum
        {
            get { return _pronum; }
            set { _pronum = value; }
        }
        /// <summary>
        /// dName 受让方姓名
        /// </summary>		
        public string dName
        {
            get { return _dname; }
            set { _dname = value; }
        }
        /// <summary>
        /// dGlebePurpose 受让方土地用途
        /// </summary>		
        public string dGlebePurpose
        {
            get { return _dglebepurpose; }
            set { _dglebepurpose = value; }
        }
        /// <summary>
        /// dListingDate 受让方挂牌时间
        /// </summary>		
        public DateTime dListingDate
        {
            get { return _dlistingdate; }
            set { _dlistingdate = value; }
        }
        /// <summary>
        /// dArea 受让方面积
        /// </summary>		
        public string dArea
        {
            get { return _darea; }
            set { _darea = value; }
        }
        /// <summary>
        /// dQuotation 受让方意向报价
        /// </summary>		
        public string dQuotation
        {
            get { return _dquotation; }
            set { _dquotation = value; }
        }
        /// <summary>
        /// dcirculation 受让方流转方式
        /// </summary>		
        public string dcirculation
        {
            get { return _dcirculation; }
            set { _dcirculation = value; }
        }
        /// <summary>
        /// dDeadline 受让方流转期限
        /// </summary>		
        public string dDeadline
        {
            get { return _ddeadline; }
            set { _ddeadline = value; }
        }
        /// <summary>
        /// dCenterContact 受让方中心联系方式
        /// </summary>		
        public string dCenterContact
        {
            get { return _dcentercontact; }
            set { _dcentercontact = value; }
        }
        /// <summary>
        /// dProContact 受让方项目联系方式
        /// </summary>		
        public string dProContact
        {
            get { return _dprocontact; }
            set { _dprocontact = value; }
        }
        /// <summary>
        /// sName 转让方名称
        /// </summary>		
        public string sName
        {
            get { return _sname; }
            set { _sname = value; }
        }
        /// <summary>
        /// sLandProperties 转让方土地性质
        /// </summary>		
        public string sLandProperties
        {
            get { return _slandproperties; }
            set { _slandproperties = value; }
        }
        /// <summary>
        /// sOther 转让方其他
        /// </summary>		
        public string sOther
        {
            get { return _sother; }
            set { _sother = value; }
        }
        /// <summary>
        /// sLocated 转让方坐落
        /// </summary>		
        public string sLocated
        {
            get { return _slocated; }
            set { _slocated = value; }
        }
        /// <summary>
        /// sOutArea 转让方拟转出面积
        /// </summary>		
        public string sOutArea
        {
            get { return _soutarea; }
            set { _soutarea = value; }
        }
        /// <summary>
        /// sDeadline 转让方拟转出年限
        /// </summary>		
        public string sDeadline
        {
            get { return _sdeadline; }
            set { _sdeadline = value; }
        }
        /// <summary>
        /// sOutWay 转让方拟转出方式
        /// </summary>		
        public string sOutWay
        {
            get { return _soutway; }
            set { _soutway = value; }
        }
        /// <summary>
        /// sListedData 转让方挂牌时间
        /// </summary>		
        public DateTime sListedData
        {
            get { return _slisteddata; }
            set { _slisteddata = value; }
        }
        /// <summary>
        /// sOutAgain 转让方是否再次转出
        /// </summary>		
        public string sOutAgain
        {
            get { return _soutagain; }
            set { _soutagain = value; }
        }
        /// <summary>
        /// sTransactions 转让方交易方式
        /// </summary>		
        public string sTransactions
        {
            get { return _stransactions; }
            set { _stransactions = value; }
        }
        /// <summary>
        /// sIsMorSeal 转让方标是否存在
        ///抵押、封查等情况
        /// </summary>		
        public string sIsMorSeal
        {
            get { return _sismorseal; }
            set { _sismorseal = value; }
        }
        /// <summary>
        /// sListingPrice 转让方挂牌价格
        /// </summary>		
        public string sListingPrice
        {
            get { return _slistingprice; }
            set { _slistingprice = value; }
        }
        /// <summary>
        /// sCenterContact 转让方联系方式电话
        /// </summary>		
        public string sCenterContact
        {
            get { return _scentercontact; }
            set { _scentercontact = value; }
        }
        /// <summary>
        /// sProContact 转让方项目联系方式
        /// </summary>		
        public string sProContact
        {
            get { return _sprocontact; }
            set { _sprocontact = value; }
        }
        /// <summary>
        /// sSettlement 转让方结算方式
        /// </summary>		
        public string sSettlement
        {
            get { return _ssettlement; }
            set { _ssettlement = value; }
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
        /// <summary>
        /// Remark 备注
        /// </summary>		
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
    }
}

