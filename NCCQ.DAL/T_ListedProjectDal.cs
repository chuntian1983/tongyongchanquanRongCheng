using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NCCQ.Model;
using NCCQ.DBFactory;

namespace NCCQ.DAL
{
    public class T_ListedProjectDal
    {
        //新建
        public bool Create(T_ListedProject model)
        {
            try
            {
                object[] obj = { model.AdminUserId, model.UnitCode, model.ProNum, model.Region, model.ProType, model.OutProName, model.OutName, model.ListingPrice, model.OutPeriod, model.Authorization, model.Located, model.ManageAuth, model.ContractKind, model.OutArea, model.FarmersNum, model.East, model.South, model.West, model.North, model.GlebePurpose, model.WhetherAgainOut, model.OutWay, model.FarmersWishes, model.ListedPeriod, model.TwoApplication, model.TranCondition, model.TranMode, model.IsMorSeal, model.Other, model.EndDate.ToString("yyyy-MM-dd HH:mm:ss"), model.ListingStatus, model.IfUp, model.IsCheck, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss") };
                string strSql = string.Format("insert into [T_ListedProject]([AdminUserId],[UnitCode],[ProNum],[Region],[ProType],[OutProName],[OutName],[ListingPrice],[OutPeriod],[Authorization],[Located],[ManageAuth],[ContractKind],[OutArea],[FarmersNum],[East],[South],[West],[North],[GlebePurpose],[WhetherAgainOut],[OutWay],[FarmersWishes],[ListedPeriod],[TwoApplication],[TranCondition],[TranMode],[IsMorSeal],[Other],[EndDate],[ListingStatus],[IfUp],[IsCheck],[CreateDate])values({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}',{31},{32},'{33}')", obj);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //
        public bool UpdateState(string row, string value, string where)
        {
            string strSql = string.Format("update T_ListedProject set {0}={1} where Id ={2}", row, value, where);
            if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //更新
        public bool Update(T_ListedProject model)
        {
            try
            {
                object[] obj = { model.UnitCode, model.ProNum, model.Region, model.ProType, model.OutProName, model.OutName, model.ListingPrice, model.OutPeriod, model.Authorization, model.Located, model.ManageAuth, model.ContractKind, model.OutArea, model.FarmersNum, model.East, model.South, model.West, model.North, model.GlebePurpose, model.WhetherAgainOut, model.OutWay, model.FarmersWishes, model.ListedPeriod, model.TwoApplication, model.TranCondition, model.TranMode, model.IsMorSeal, model.Other, model.EndDate.ToString("yyyy-MM-dd HH:mm:ss"), model.ListingStatus, model.IfUp, model.IsCheck, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.Id, model.AdminUserId };
                string strSql = string.Format("update T_ListedProject set UnitCode='{0}',ProNum='{1}',Region='{2}',ProType='{3}',OutProName='{4}',OutName='{5}',ListingPrice='{6}',OutPeriod='{7}',[Authorization]='{8}',Located='{9}',ManageAuth='{10}',ContractKind='{11}',OutArea='{12}',FarmersNum='{13}',East='{14}',South='{15}',West='{16}',North='{17}',GlebePurpose='{18}',WhetherAgainOut='{19}',OutWay='{20}',FarmersWishes='{21}',ListedPeriod='{22}',TwoApplication='{23}',TranCondition='{24}',TranMode='{25}',IsMorSeal='{26}',Other='{27}',EndDate='{28}',ListingStatus='{29}',IfUp='{30}',IsCheck='{31}',CreateDate='{32}' where Id={33} and AdminUserId='{34}' ", obj);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //删除
        public bool Delete(int id, int adminUserId)
        {
            try
            {
                string strSql = string.Format("delete from T_ListedProject where Id={0} and AdminUserId={1}", id, adminUserId);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) >= 1)
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
        //删除
        public bool Delete(int id)
        {
            try
            {
                string strSql = string.Format("delete from T_ListedProject where Id={0}", id);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) >= 1)
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
        //二级页面显示获取数据列表
        public DataTable GetAllList(string proType, int startIndex, int pageSize) { return null; }
        //获取单个对象
        public T_ListedProject GetModel(int id)
        {
            try
            {
                T_ListedProject model = null;
                string strSql = string.Format("select top 1 [Id],[AdminUserId],[UnitCode],[ProNum],[Region],[ProType],[OutProName],[OutName],[ListingPrice],[OutPeriod],[Authorization],[Located],[ManageAuth],[ContractKind],[OutArea],[FarmersNum],[East],[South],[West],[North],[GlebePurpose],[WhetherAgainOut],[OutWay],[FarmersWishes],[ListedPeriod],[TwoApplication],[TranCondition],[TranMode],[IsMorSeal],[Other],[EndDate],[ListingStatus],[IfUp],[IsCheck],[CreateDate] from [T_ListedProject] where Id={0}", id);
                using (dynamic read = DbHelper.Factory().ExecuteReader(strSql))
                {
                    model = new T_ListedProject();
                    if (read.Read())
                    {
                        #region
                        model.Id = int.Parse(read["Id"].ToString());
                        model.AdminUserId = int.Parse(read["AdminUserId"].ToString());
                        model.UnitCode = read["UnitCode"].ToString();
                        model.ProNum = read["ProNum"].ToString();
                        model.Region = read["Region"].ToString();
                        model.ProType = read["ProType"].ToString();
                        model.OutProName = read["OutProName"].ToString();
                        model.OutName = read["OutName"].ToString();
                        model.ListingPrice = read["ListingPrice"].ToString();
                        model.OutPeriod = read["OutPeriod"].ToString();
                        model.Authorization = read["Authorization"].ToString();
                        model.Located = read["Located"].ToString();
                        model.ManageAuth = read["ManageAuth"].ToString();
                        model.ContractKind = read["ContractKind"].ToString();
                        model.OutArea = read["OutArea"].ToString();
                        model.FarmersNum = read["FarmersNum"].ToString();
                        model.East = read["East"].ToString();
                        model.South = read["South"].ToString();
                        model.West = read["West"].ToString();
                        model.North = read["North"].ToString();
                        model.GlebePurpose = read["GlebePurpose"].ToString();
                        model.WhetherAgainOut = read["WhetherAgainOut"].ToString();
                        model.OutWay = read["OutWay"].ToString();
                        model.FarmersWishes = read["FarmersWishes"].ToString();
                        model.ListedPeriod = read["ListedPeriod"].ToString();
                        model.TwoApplication = read["TwoApplication"].ToString();
                        model.TranCondition = read["TranCondition"].ToString();
                        model.TranMode = read["TranMode"].ToString();
                        model.IsMorSeal = read["IsMorSeal"].ToString();
                        model.Other = read["Other"].ToString();
                        try { model.EndDate = DateTime.Parse(read["EndDate"].ToString()); }
                        catch { }
                        model.ListingStatus = read["ListingStatus"].ToString();
                        model.IfUp = int.Parse(read["IfUp"].ToString());
                        model.IsCheck = int.Parse(read["IsCheck"].ToString());
                        try { model.CreateDate = DateTime.Parse(read["CreateDate"].ToString()); }
                        catch { }
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
        //一级页面显示
        public DataTable GetTopPageShow(string proType, string top) { return null; }
        //后台管理显示
        public DataTable GetAllList(object sqlWhere, int startIndex, int pageSize, string order)
        {
            string strSql = "SELECT [Id],[AdminUserId],[UnitCode],[ProNum],[Region],[ProType],[OutProName],[OutName],[ListingPrice],[OutPeriod],[Authorization],[Located],[ManageAuth],[ContractKind],[OutArea],[FarmersNum],[East],[South],[West],[North],[GlebePurpose],[WhetherAgainOut],[OutWay],[FarmersWishes],[ListedPeriod],[TwoApplication],[TranCondition],[TranMode],[IsMorSeal],[Other],[EndDate],[ListingStatus],[IfUp],[IsCheck],[CreateDate] FROM [T_ListedProject] ";
            if (sqlWhere.ToString() != "")
            {
                strSql += string.Format(" where {0}", sqlWhere.ToString());
            }
            strSql += order;
            return DbHelper.Factory().ExecuteDataTable(strSql, startIndex * pageSize, pageSize, "T_ListedProject");
        }
        //获取总和
        public int CountNum(string where)
        {
            string strSql = "select count(Id) from T_ListedProject ";
            if (where != "")
            {
                strSql += string.Format(" where {0}", where);
            }
            return (int)DbHelper.Factory().ExecuteScalar(strSql);
        }
    }
}
