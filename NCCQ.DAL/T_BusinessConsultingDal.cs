using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NCCQ.Model;
using NCCQ.DBFactory;

namespace NCCQ.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class T_BusinessConsultingDal
    {
        //
        public bool Create(T_BusinessConsulting model)
        {
            try
            {
                object[] obj = { model.UserName, model.UserAddress, model.UserTel, model.UserEmail, model.ConsTitle, model.ConsContent, model.ConsDate.ToString("yyyy-MM-dd HH:mm:ss"), model.ReplyContent, model.ReplyDate.ToString("yyyy-MM-dd HH:mm:ss"), model.ReplyUser,model.BusinessType };
                string strSql = string.Format("insert into [T_BusinessConsulting]([UserName],[UserAddress],[UserTel],[UserEmail],[ConsTitle],[ConsContent],[ConsDate],[ReplyContent],[ReplyDate],[ReplyUser],BusinessType)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", obj);
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
        //
        public bool Delete(int id)
        {
            try
            {
                string strSql = string.Format("delete from T_BusinessConsulting where Id={0}", id);
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
        //
        public bool Update(T_BusinessConsulting model)
        {
            try
            {
                object[] obj = { model.ReplyContent, model.ReplyDate.ToString("yyyy-MM-dd HH:mm:ss"), model.ReplyUser, model.Id,model.BusinsessState };
                string strSql = string.Format("update [T_BusinessConsulting] set [ReplyContent] ='{0}',[ReplyDate] ='{1}',[ReplyUser] ='{2}',BusinsessState='{4}' where [Id]={3} ", obj);
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

        public int CountNum(string where)
        {
            string strSql = "select count(Id) from T_BusinessConsulting ";
            if (where != "")
            {
                strSql += string.Format(" where {0}", where);
            }
            return (int)DbHelper.Factory().ExecuteScalar(strSql);
        }
        //
        public DataTable GetAllList(string sqlWhere, int startIndex, int pageSize, string order)
        {
            string strSql = "select [Id],[UserName],[UserAddress],[UserTel],[UserEmail],[ConsTitle],[ConsContent],[ConsDate],[ReplyContent],[ReplyDate],[ReplyUser],BusinessType from [T_BusinessConsulting] ";
            if (sqlWhere != "")
            {
                strSql += string.Format(" where {0}", sqlWhere);
            }
            strSql += order;
            return DbHelper.Factory().ExecuteDataTable(strSql, startIndex * pageSize, pageSize, "T_BusinessConsulting");
        }
        //
        public bool Reply() { return true; }

        public T_BusinessConsulting GetModel(int id)
        {
            T_BusinessConsulting model = null;
            string strSql = string.Format("select  top 1 Id,UserName,UserAddress,UserTel,UserEmail,ConsTitle,ConsContent,ConsDate,ReplyContent,ReplyDate,ReplyUser from T_BusinessConsulting  where Id={0}", id);
            using (dynamic read = DbHelper.Factory().ExecuteReader(strSql))
            {
                model = new T_BusinessConsulting();
                if (read.Read())
                {
                    model.Id = int.Parse(read["Id"].ToString());
                    model.UserName = read["UserName"].ToString();
                    model.UserAddress = read["UserAddress"].ToString();
                    model.UserTel = read["UserTel"].ToString();
                    model.UserEmail = read["UserEmail"].ToString();
                    model.ConsTitle = read["ConsTitle"].ToString();
                    model.ConsContent = read["ConsContent"].ToString();
                    try { model.ConsDate = DateTime.Parse(read["ConsDate"].ToString()); }
                    catch { }
                    model.ReplyContent = read["ReplyContent"].ToString();
                    try { model.ReplyDate = DateTime.Parse(read["ReplyDate"].ToString()); }
                    catch { }
                    model.ReplyUser = read["ReplyUser"].ToString();
                }
                read.Dispose();
            }
            return model;
        }
    }
}
