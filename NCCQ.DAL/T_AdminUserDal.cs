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
    /// 管理员数据操作
    /// </summary>
    public class T_AdminUserDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int HighestLevel()
        {
            string strSql = "select max(AdminType) from T_AdminUser";
            return (int)DbHelper.Factory().ExecuteScalar(strSql);
        }
        /// <summary>
        /// 添加操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create(T_AdminUser model)
        {
            object[] obj = { model.AdminLogName, model.AdminLogPass, model.AdminName, model.AdminTel, model.UnitCode, model.AdminType, model.AdminState, model.AdminLogNum, model.IsCheck, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),model.Roleid };
            string strSql = string.Format("insert into [T_AdminUser]([AdminLogName],[AdminLogPass],[AdminName],[AdminTel],[UnitCode],[AdminType],[AdminState],[AdminLogNum],[IsCheck],[Editor],[CreateDate],[EndDate],roleid) values ('{0}','{1}','{2}','{3}','{4}',{5},{6},{7},{8},'{9}','{10}','{11}','{12}')", obj);
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
        /// 更新操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T_AdminUser model)
        {
            object[] obj = { model.AdminLogName, model.AdminLogPass, model.AdminName, model.AdminTel, model.UnitCode, model.AdminType, model.AdminState, model.AdminLogNum, model.IsCheck, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.EndDate.ToString("yyyy-MM-dd HH:mm:ss"), model.Id,model.Roleid };
            string strSql = string.Format(" update T_AdminUser set AdminLogName='{0}',AdminLogPass='{1}',AdminName='{2}',AdminTel='{3}',UnitCode='{4}',AdminType={5},AdminState={6},AdminLogNum={7},IsCheck={8},Editor='{9}',CreateDate='{10}',EndDate='{11}',roleid='{13}' where Id={12}", obj);
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
        /// 删除操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                string strSql = string.Format("delete from T_AdminUser where Id={0}", id);
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
                throw;
            }
        }
        /// <summary>
        /// 批量删除操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            try
            {
                string strSql = "delete from T_AdminUser where Id in ("+id+")";
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
                throw;
            }
        }
        /// <summary>
        /// 列表查询操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetAllList(string sqlWhere, int startIndex, int pageSize, string order)
        {
            string strSql = "select [Id],[AdminLogName],[AdminLogPass],[AdminName],[AdminTel],[UnitCode],[AdminType],[AdminState],[AdminLogNum],[IsCheck],[Editor],[CreateDate],[EndDate],roleid from [T_AdminUser] ";
            if (sqlWhere != "")
            {
                strSql += string.Format(" where {0}", sqlWhere);
            }
            strSql += order;
            return DbHelper.Factory().ExecuteDataTable(strSql, startIndex * pageSize, pageSize, "T_AdminUser");
        }
        /// <summary>
        /// 更新状态操作
        /// </summary>
        /// <param name="row"></param>
        /// <param name="values"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool UpdateState(string row, string values, string where)
        {
            string strSql = string.Format("update T_AdminUser set {0}={1} where Id ={2}", row, values, where);
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
        /// 返回单个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_AdminUser GetModel(int id)
        {
            T_AdminUser model = null;
            string strSql = string.Format("SELECT [Id],[AdminLogName],[AdminLogPass],[AdminName],[AdminTel],[UnitCode],[AdminType],[AdminState],[AdminLogNum],[IsCheck],[Editor],[CreateDate],[EndDate],roleid FROM [T_AdminUser] where Id = {0}", id);
            using (dynamic read = DbHelper.Factory().ExecuteReader(strSql))
            {
                if (read.Read())
                {
                    model = new T_AdminUser();
                    model.Id = int.Parse(read["Id"].ToString());
                    model.AdminLogName = read["AdminLogName"].ToString();
                    model.AdminLogPass = read["AdminLogPass"].ToString();
                    model.AdminName = read["AdminName"].ToString();
                    model.AdminTel = read["AdminTel"].ToString();
                    model.UnitCode = read["UnitCode"].ToString();
                    model.AdminType = int.Parse(read["AdminType"].ToString());
                    model.AdminState = int.Parse(read["AdminState"].ToString());
                    model.AdminLogNum = int.Parse(read["AdminLogNum"].ToString());
                    model.IsCheck = int.Parse(read["IsCheck"].ToString());
                    model.Editor = read["Editor"].ToString();
                    model.CreateDate = DateTime.Parse(read["CreateDate"].ToString());
                    model.EndDate = DateTime.Parse(read["EndDate"].ToString());
                    model.Roleid = read["roleid"].ToString();
                }
                read.Dispose();
            }
            return model;
        }
        /// <summary>
        /// 数据总和
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int CountNum(string where)
        {
            string strSql = "select count(Id) from T_AdminUser ";
            if (where != "")
            {
                strSql += string.Format(" where {0}", where);
            }
            return (int)DbHelper.Factory().ExecuteScalar(strSql);
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="adminLogName"></param>
        /// <param name="adminLogPass"></param>
        /// <returns></returns>
        public T_AdminUser AdminUserLogin(string adminLogName, string adminLogPass)
        {
            try
            {
                string strSql = string.Format("select top 1 Id,AdminLogName,AdminLogPass,AdminName,AdminTel,UnitCode,AdminType,AdminState,AdminLogNum,IsCheck,Editor,CreateDate,EndDate,roleid from T_AdminUser where AdminLogName='{0}' and AdminLogPass='{1}'", adminLogName, adminLogPass);

                T_AdminUser model = new T_AdminUser();
                using (dynamic read = DbHelper.Factory().ExecuteReader(strSql))
                {
                    if (read.Read())
                    {
                        model.Id = (int)read["Id"];
                        model.AdminLogName = read["AdminLogName"];
                        model.AdminLogPass = read["AdminLogPass"];
                        model.AdminName = read["AdminName"];
                        model.AdminTel = read["AdminTel"];
                        model.UnitCode = read["UnitCode"];
                        try
                        {
                            model.Roleid = read["roleid"];
                        }
                        catch { model.Roleid = ""; }
                        try { model.AdminType = (int)read["AdminType"]; }
                        catch { model.AdminType = 0; }
                        try { model.AdminState = (int)read["AdminState"]; }
                        catch { model.AdminState = 0; }
                        try { model.AdminLogNum = (int)read["AdminLogNum"]; }
                        catch { model.AdminLogNum = 0; }
                        try { model.IsCheck = (int)read["IsCheck"]; }
                        catch { model.IsCheck = 0; }
                        model.Editor = read["Editor"];
                        try { model.CreateDate = (DateTime)read["CreateDate"]; }
                        catch { model.CreateDate = DateTime.Now; }
                        try { model.EndDate = (DateTime)read["EndDate"]; }
                        catch { model.EndDate = DateTime.Now; }
                    }
                    read.Dispose();
                }
                return model;
            }
            catch (Exception) { throw; }
        }
        /// <summary>
        /// 验证用户名
        /// </summary>
        /// <param name="adminLogName"></param>
        /// <returns></returns>
        public bool CheckUserName(string adminLogName)
        {
            try
            {
                bool existence;
                string strSql = string.Format(" select [Id],[AdminLogName],[AdminLogPass],[AdminName],[AdminTel],[UnitCode],[AdminType],[AdminState],[AdminLogNum],[IsCheck],[Editor],[CreateDate],[EndDate] from [T_AdminUser] where [AdminLogName] = '{0}' ", adminLogName);
                using (dynamic read = DbHelper.Factory().ExecuteReader(strSql))
                {
                    if (read.Read())
                    {
                        existence = true;
                    }
                    else
                    {
                        existence = false;
                    }
                    read.Dispose();
                }
                return existence;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 登录次数
        /// </summary>
        /// <param name="id"></param>
        public void NumberLogin(int id)
        {
            try
            {
                DbHelper.Factory().ExecuteNonQuery(string.Format("update T_AdminUser set AdminLogNum=(AdminLogNum+1),EndDate=GETDATE() where Id={0}", id));
            }
            catch (Exception) { throw; }
        }
    }
}
