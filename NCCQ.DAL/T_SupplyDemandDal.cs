using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCCQ.Model;
using System.Data;
using NCCQ.DBFactory;

namespace NCCQ.DAL
{
    public class T_SupplyDemandDal
    {
        public bool Create(T_SupplyDemand model)
        {
            try
            {
                object[] obj = { model.UserInfoId, model.SupplyOrDemand, model.ProName, model.KeyWord, model.ProNum, model.dName, model.dGlebePurpose, model.dListingDate.ToString("yyyy-MM-dd HH:mm:ss"), model.dArea, model.dQuotation, model.dcirculation, model.dDeadline, model.dCenterContact, model.dProContact, model.sName, model.sLandProperties, model.sOther, model.sLocated, model.sOutArea, model.sDeadline, model.sOutWay, model.sListedData.ToString("yyyy-MM-dd HH:mm:ss"), model.sOutAgain, model.sTransactions, model.sIsMorSeal, model.sListingPrice, model.sCenterContact, model.sProContact, model.sSettlement, model.IsCheck, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.Remark };
                string strSql = string.Format("insert into T_SupplyDemand (UserInfoId,SupplyOrDemand,ProName,KeyWord,ProNum,dName,dGlebePurpose,dListingDate,dArea,dQuotation,dcirculation,dDeadline,dCenterContact,dProContact,sName,sLandProperties,sOther,sLocated,sOutArea,sDeadline,sOutWay,sListedData,sOutAgain,sTransactions,sIsMorSeal,sListingPrice,sCenterContact,sProContact,sSettlement,IsCheck,CreateDate,Remark) values ({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}',{29},'{30}','{31}')", obj);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }

        public bool Update(T_SupplyDemand model)
        {
            try
            {
                object[] obj = { model.UserInfoId, model.SupplyOrDemand, model.ProName, model.KeyWord, model.ProNum, model.dName, model.dGlebePurpose, model.dListingDate.ToString("yyyy-MM-dd HH:mm:ss"), model.dArea, model.dQuotation, model.dcirculation, model.dDeadline, model.dCenterContact, model.dProContact, model.sName, model.sLandProperties, model.sOther, model.sLocated, model.sOutArea, model.sDeadline, model.sOutWay, model.sListedData.ToString("yyyy-MM-dd HH:mm:ss"), model.sOutAgain, model.sTransactions, model.sIsMorSeal, model.sListingPrice, model.sCenterContact, model.sProContact, model.sSettlement, model.IsCheck, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.Remark,model.Id };
                string strSql = string.Format("update T_SupplyDemand set UserInfoId={0},SupplyOrDemand={1},ProName='{2}',KeyWord='{3}',ProNum='{4}',dName='{5}',dGlebePurpose='{6}',dListingDate='{7}',dArea='{8}',dQuotation='{9}',dcirculation='{10}',dDeadline='{11}',dCenterContact='{12}',dProContact='{13}',sName='{14}',sLandProperties='{15}',sOther='{16}',sLocated='{17}',sOutArea='{18}',sDeadline='{19}',sOutWay='{20}',sListedData='{21}',sOutAgain='{22}',sTransactions='{23}',sIsMorSeal='{24}',sListingPrice='{25}',sCenterContact='{26}',sProContact='{27}',sSettlement='{28}',IsCheck={29},CreateDate='{30}',Remark='{31}' where Id ={32}", obj);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }

        public bool Delete(int id, int userId)
        {
            try
            {
                string strSql = string.Format(" delete from T_SupplyDemand where Id ={0} and UserInfoId ={1} ", id, userId);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { throw; }
        }
        public bool Delete(int id)
        {
            try
            {
                string strSql = string.Format(" delete from T_SupplyDemand where Id ={0} ", id);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { throw; }
        }
        public T_SupplyDemand GetModel(int id)
        {
            try
            {
                T_SupplyDemand model = new T_SupplyDemand();
                string strSql = string.Format("select Id,UserInfoId,SupplyOrDemand,ProName,KeyWord,ProNum,dName,dGlebePurpose,dListingDate,dArea,dQuotation,dcirculation,dDeadline,dCenterContact,dProContact,sName,sLandProperties,sOther,sLocated,sOutArea,sDeadline,sOutWay,sListedData,sOutAgain,sTransactions,sIsMorSeal,sListingPrice,sCenterContact,sProContact,sSettlement,IsCheck,CreateDate,Remark from T_SupplyDemand  where Id={0}", id);
                using (dynamic read = DbHelper.Factory().ExecuteReader(strSql))
                {
                    if (read.Read())
                    {
                        #region
                        model.Id = int.Parse(read["Id"].ToString());
                        model.UserInfoId = int.Parse(read["UserInfoId"].ToString());
                        model.SupplyOrDemand = int.Parse(read["SupplyOrDemand"].ToString());
                        model.ProName = read["ProName"].ToString();
                        model.KeyWord = read["KeyWord"].ToString();
                        model.ProNum = read["ProNum"].ToString();
                        model.dName = read["dName"].ToString();
                        model.dGlebePurpose = read["dGlebePurpose"].ToString();
                        model.dListingDate = DateTime.Parse(read["dListingDate"].ToString());
                        model.dArea = read["dArea"].ToString();
                        model.dQuotation = read["dQuotation"].ToString();
                        model.dcirculation = read["dcirculation"].ToString();
                        model.dDeadline = read["dDeadline"].ToString();
                        model.dCenterContact = read["dCenterContact"].ToString();
                        model.dProContact = read["dProContact"].ToString();
                        model.sName = read["sName"].ToString();
                        model.sLandProperties = read["sLandProperties"].ToString();
                        model.sOther = read["sOther"].ToString();
                        model.sLocated = read["sLocated"].ToString();
                        model.sOutArea = read["sOutArea"].ToString();
                        model.sDeadline = read["sDeadline"].ToString();
                        model.sOutWay = read["sOutWay"].ToString();
                        model.sListedData = DateTime.Parse(read["sListedData"].ToString());
                        model.sOutAgain = read["sOutAgain"].ToString();
                        model.sTransactions = read["sTransactions"].ToString();
                        model.sIsMorSeal = read["sIsMorSeal"].ToString();
                        model.sListingPrice = read["sListingPrice"].ToString();
                        model.sCenterContact = read["sCenterContact"].ToString();
                        model.sProContact = read["sProContact"].ToString();
                        model.sSettlement = read["sSettlement"].ToString();
                        model.IsCheck = int.Parse(read["IsCheck"].ToString());
                        model.CreateDate = DateTime.Parse(read["CreateDate"].ToString());
                        model.Remark = read["Remark"].ToString();
                        #endregion
                    }
                    read.Dispose();
                }
                return model;
            }
            catch
            {
                throw;
            }
        }

        public DataTable GetAllList(string sqlWhere, int startIndex, int pageSize, string order)
        {
            string strSql = "select Id,UserInfoId,SupplyOrDemand,ProName,KeyWord,ProNum,dName,dGlebePurpose,dListingDate,dArea,dQuotation,dcirculation,dDeadline,dCenterContact,dProContact,sName,sLandProperties,sOther,sLocated,sOutArea,sDeadline,sOutWay,sListedData,sOutAgain,sTransactions,sIsMorSeal,sListingPrice,sCenterContact,sProContact,sSettlement,IsCheck,CreateDate,Remark from T_SupplyDemand ";
            if (sqlWhere != "")
            {
                strSql += string.Format(" where {0}", sqlWhere);
            }
            strSql += order;
            return DbHelper.Factory().ExecuteDataTable(strSql, startIndex * pageSize, pageSize, "T_SupplyDemand");
        }
        public bool UpdateState(string row, string value, string where)
        {
            string strSql = string.Format("update T_SupplyDemand set {0}={1} where Id ={2}", row, value, where);
            if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //获取总和
        public int CountNum(string where)
        {
            string strSql = "select count(Id) from T_SupplyDemand ";
            if (where != "")
            {
                strSql += string.Format(" where {0}", where);
            }
            return (int)DbHelper.Factory().ExecuteScalar(strSql);
        }
        /// <summary>
        /// 根据类别获取所有信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetDataBySupplyOrDemand(int id)
        {
            DataTable dt = new DataTable();
            string strsql = "select * from T_SupplyDemand where ischeck=1 and SupplyOrDemand="+id+"";
            dt = DbHelper.Factory().ExecuteDataTable(strsql);
            return dt;
        }
    }
}
