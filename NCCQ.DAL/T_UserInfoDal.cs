using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCCQ.Model;
using System.Data;
using NCCQ.DBFactory;
using System.Data.SqlClient;

namespace NCCQ.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class T_UserInfoDal
    {
        //会员注册
        public bool Create(T_UserInfo model)
        {
            try
            {
                object[] obj = { model.UserLogName, model.UserLogPass, model.UserName, model.UserSex, model.CardId, model.UserAddress, model.UserTel, model.UserEmail, model.UserLogNum, model.UserState, model.IsCheck, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.EndDate.ToString("yyyy-MM-dd HH:mm:ss") };
                string strSql = string.Format(" insert into [T_UserInfo]([UserLogName],[UserLogPass],[UserName],[UserSex],[CardId],[UserAddress],[UserTel],[UserEmail],[UserLogNum],[UserState],[IsCheck],[CreateDate],[EndDate])values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},{9},{10},'{11}','{12}')", obj);
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
        //删除会员
        public bool Delete(int id)
        {
            try
            {
                string strSql = string.Format("delete from T_UserInfo where Id={0}", id);
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
        //更新会员信息
        public bool Update(T_UserInfo model)
        {
            try
            {
                object[] obj = { model.UserLogName, model.UserLogPass, model.UserName, model.UserSex, model.CardId, model.UserAddress, model.UserTel, model.UserEmail, model.UserLogNum, model.UserState, model.IsCheck, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.EndDate.ToString("yyyy-MM-dd HH:mm:ss"), model.Id };
                string strSql = string.Format("update [T_UserInfo] set [UserLogName] ='{0}' ,[UserLogPass] ='{1}' ,[UserName] = '{2}',[UserSex] = '{3}',[CardId] = '{4}',[UserAddress] ='{5}',[UserTel] = '{6}',[UserEmail] = '{7}',[UserLogNum] = {8},[UserState] = {9},[IsCheck] = {10},[CreateDate] = '{11}',[EndDate] = '{12}' where Id = {13}", obj);
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
        //获取数据列表信息
        public DataTable GetAllList(string sqlWhere, int startIndex, int pageSize, string order)
        {
            string strSql = "select [Id],[UserLogName],[UserLogPass],[UserName],[UserSex],[CardId],[UserAddress],[UserTel],[UserEmail],[UserLogNum],[UserState],[IsCheck],[CreateDate],[EndDate] from [T_UserInfo] ";
            if (sqlWhere != "")
            {
                strSql += string.Format(" where {0}", sqlWhere);
            }
            strSql += order;
            return DbHelper.Factory().ExecuteDataTable(strSql, startIndex * pageSize, pageSize, "T_UserInfo");
        }
        //获取总和
        public int CountNum(string where)
        {
            string strSql = "select count(Id) from T_UserInfo ";
            if (where != "")
            {
                strSql += string.Format(" where {0}", where);
            }
            return (int)DbHelper.Factory().ExecuteScalar(strSql);
        }
        //单个数据
        public T_UserInfo GetModel(int id)
        {
            try
            {
                string strSql = string.Format("select [Id],[UserLogName],[UserLogPass],[UserName],[UserSex],[CardId],[UserAddress],[UserTel],[UserEmail],[UserLogNum],[UserState],[IsCheck],[CreateDate],[EndDate] from [T_UserInfo] where Id={0}", id);
                T_UserInfo model = null;
                using (dynamic read = DbHelper.Factory().ExecuteReader(strSql.ToString()))
                {
                    model = new T_UserInfo();
                    if (read.Read())
                    {
                        try { model.Id = int.Parse(read["Id"].ToString()); }
                        catch { }
                        model.UserLogName = read["UserLogName"].ToString();
                        model.UserLogPass = read["UserLogPass"].ToString();
                        model.UserName = read["UserName"].ToString();
                        model.UserSex = read["UserSex"].ToString();
                        model.CardId = read["CardId"].ToString();
                        model.UserAddress = read["UserAddress"].ToString();
                        model.UserTel = read["UserTel"].ToString();
                        model.UserEmail = read["UserEmail"].ToString();
                        try { model.UserLogNum = int.Parse(read["UserLogNum"].ToString()); }
                        catch { }
                        try { model.UserState = int.Parse(read["UserState"].ToString()); }
                        catch { }
                        try { model.IsCheck = int.Parse(read["IsCheck"].ToString()); }
                        catch { }
                        try { model.CreateDate = DateTime.Parse(read["CreateDate"].ToString()); }
                        catch { }
                        try { model.EndDate = DateTime.Parse(read["EndDate"].ToString()); }
                        catch { }
                    }
                    read.Dispose();
                }
                return model;
            }
            catch (Exception) { throw; }
        }
        //验证用户名
        public bool CheckUserName(string adminLogName) 
        {
            string strsql = "select * from T_UserInfo where UserLogName='"+adminLogName+"'";
            //SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@UserLogName", adminLogName) };
            DataTable dt = DbHelper.Factory().ExecuteDataTable(strsql);
            if (dt.Rows.Count == 0)
            {
                return true;
            }
            else { return false; }

        }
        //登录次数
        public void NumberLogin(int id) { }
        //会员登录
        public T_UserInfo UserLogin(string userLogName, string userLogPass) { return null; }
        //更新状态
        public bool UpdateState(string row, string value, string where)
        {
            string strSql = string.Format("update T_UserInfo set {0}={1} where Id ={2}", row, value, where);
            if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userpass"></param>
        /// <returns></returns>
        public string Userlog(string username, string userpass)
        {
            string str = "";
            string strsql = "select * from t_userinfo where userlogname='"+username+"'";
            DataTable dt = DbHelper.Factory().ExecuteDataTable(strsql);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["userlogpass"].ToString() == userpass)
                {
                    str = "登录成功"+dt.Rows[0]["id"].ToString();
                }
                else
                {
                    str = "用户密码不正确请重新输入！";
                }
            }
            else
            {
                str = "用户名不存在请重新输入！";
            }
            return str;

        }
    }
}
