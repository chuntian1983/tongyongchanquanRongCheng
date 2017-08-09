using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NCCQ.DBFactory;
using NCCQ.Model;

namespace NCCQ.DAL
{
    public class T_OrganizationDal
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(NCCQ.Model.T_Organization model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.OrgCode != null)
            {
                strSql1.Append("OrgCode,");
                strSql2.Append("'" + model.OrgCode + "',");
            }
            if (model.OrgName != null)
            {
                strSql1.Append("OrgName,");
                strSql2.Append("'" + model.OrgName + "',");
            }
            if (model.OrgShortName != null)
            {
                strSql1.Append("OrgShortName,");
                strSql2.Append("'" + model.OrgShortName + "',");
            }
            if (model.UpOrgCode != null)
            {
                strSql1.Append("UpOrgCode,");
                strSql2.Append("'" + model.UpOrgCode + "',");
            }
            if (model.Seq != null)
            {
                strSql1.Append("Seq,");
                strSql2.Append("" + model.Seq + ",");
            }
            if (model.Level != null)
            {
                strSql1.Append("Level,");
                strSql2.Append("" + model.Level + ",");
            }
            if (model.ShengCode != null)
            {
                strSql1.Append("ShengCode,");
                strSql2.Append("'" + model.ShengCode + "',");
            }
            if (model.ShiCode != null)
            {
                strSql1.Append("ShiCode,");
                strSql2.Append("'" + model.ShiCode + "',");
            }
            if (model.XianCode != null)
            {
                strSql1.Append("XianCode,");
                strSql2.Append("'" + model.XianCode + "',");
            }
            if (model.XiangCode != null)
            {
                strSql1.Append("XiangCode,");
                strSql2.Append("'" + model.XiangCode + "',");
            }
            if (model.CunCode != null)
            {
                strSql1.Append("CunCode,");
                strSql2.Append("'" + model.CunCode + "',");
            }
            if (model.ZunCode != null)
            {
                strSql1.Append("ZunCode,");
                strSql2.Append("'" + model.ZunCode + "',");
            }
            strSql.Append("insert into T_Organization(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            int rows =DbHelper.Factory().ExecuteNonQuery(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(T_Organization model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Organization set ");
            if (model.OrgName != null)
            {
                strSql.Append("OrgName='" + model.OrgName + "',");
            }
            if (model.OrgShortName != null)
            {
                strSql.Append("OrgShortName='" + model.OrgShortName + "',");
            }
            if (model.UpOrgCode != null)
            {
                strSql.Append("UpOrgCode='" + model.UpOrgCode + "',");
            }
            if (model.Seq != null)
            {
                strSql.Append("Seq=" + model.Seq + ",");
            }
            if (model.Level != null)
            {
                strSql.Append("Level=" + model.Level + ",");
            }
            if (model.ShengCode != null)
            {
                strSql.Append("ShengCode='" + model.ShengCode + "',");
            }
            else
            {
                strSql.Append("ShengCode= null ,");
            }
            if (model.ShiCode != null)
            {
                strSql.Append("ShiCode='" + model.ShiCode + "',");
            }
            else
            {
                strSql.Append("ShiCode= null ,");
            }
            if (model.XianCode != null)
            {
                strSql.Append("XianCode='" + model.XianCode + "',");
            }
            else
            {
                strSql.Append("XianCode= null ,");
            }
            if (model.XiangCode != null)
            {
                strSql.Append("XiangCode='" + model.XiangCode + "',");
            }
            else
            {
                strSql.Append("XiangCode= null ,");
            }
            if (model.CunCode != null)
            {
                strSql.Append("CunCode='" + model.CunCode + "',");
            }
            else
            {
                strSql.Append("CunCode= null ,");
            }
            if (model.ZunCode != null)
            {
                strSql.Append("ZunCode='" + model.ZunCode + "',");
            }
            else
            {
                strSql.Append("ZunCode= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where OrgCode='" + model.OrgCode + "' ");
            int rowsAffected =DbHelper.Factory().ExecuteNonQuery(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string OrgCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Organization ");
            strSql.Append(" where OrgCode='" + OrgCode + "' ");
            int rowsAffected =DbHelper.Factory().ExecuteNonQuery(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }		/// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string OrgCodelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Organization ");
            strSql.Append(" where OrgCode in (" + OrgCodelist + ")  ");
            int rows =DbHelper.Factory().ExecuteNonQuery(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T_Organization GetModel(string OrgCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" OrgCode,OrgName,OrgShortName,UpOrgCode,Seq,Level,ShengCode,ShiCode,XianCode,XiangCode,CunCode,ZunCode ");
            strSql.Append(" from T_Organization ");
            strSql.Append(" where OrgCode='" + OrgCode + "' ");
            T_Organization model = new T_Organization();
            DataTable ds =DbHelper.Factory().ExecuteDataTable(strSql.ToString());
            if (ds.Rows.Count > 0)
            {
                return DataRowToModel(ds.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public T_Organization DataRowToModel(DataRow row)
        {
            T_Organization model = new T_Organization();
            if (row != null)
            {
                if (row["OrgCode"] != null)
                {
                    model.OrgCode = row["OrgCode"].ToString();
                }
                if (row["OrgName"] != null)
                {
                    model.OrgName = row["OrgName"].ToString();
                }
                if (row["OrgShortName"] != null)
                {
                    model.OrgShortName = row["OrgShortName"].ToString();
                }
                if (row["UpOrgCode"] != null)
                {
                    model.UpOrgCode = row["UpOrgCode"].ToString();
                }
                if (row["Seq"] != null && row["Seq"].ToString() != "")
                {
                    model.Seq = int.Parse(row["Seq"].ToString());
                }
                if (row["Level"] != null && row["Level"].ToString() != "")
                {
                    model.Level = int.Parse(row["Level"].ToString());
                }
                if (row["ShengCode"] != null)
                {
                    model.ShengCode = row["ShengCode"].ToString();
                }
                if (row["ShiCode"] != null)
                {
                    model.ShiCode = row["ShiCode"].ToString();
                }
                if (row["XianCode"] != null)
                {
                    model.XianCode = row["XianCode"].ToString();
                }
                if (row["XiangCode"] != null)
                {
                    model.XiangCode = row["XiangCode"].ToString();
                }
                if (row["CunCode"] != null)
                {
                    model.CunCode = row["CunCode"].ToString();
                }
                if (row["ZunCode"] != null)
                {
                    model.ZunCode = row["ZunCode"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetLevel(string orgCode)
        {
            int level = 0;
            string strSql = string.Format("select top 1 [OrgCode],[OrgName],[OrgShortName],[UpOrgCode],[Seq],[Level],[ShengCode],[ShiCode],[XianCode],[XiangCode],[CunCode],[ZunCode] from T_Organization where OrgCode = '{0}'", orgCode);
            T_Organization model = null;
            using (dynamic read = DbHelper.Factory().ExecuteReader(strSql))
            {
                model = new T_Organization();
                if (read.Read())
                {
                    level = int.Parse(read["Level"].ToString());
                }
                read.Dispose();
            }
            return level;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T_Organization GetHighestLevel()
        {
            string strSql = "select top 1 [OrgCode],[OrgName],[OrgShortName],[UpOrgCode],[Seq],[Level],[ShengCode],[ShiCode],[XianCode],[XiangCode],[CunCode],[ZunCode] from T_Organization order by [Level] desc";
            T_Organization model = null;
            using (dynamic read = DbHelper.Factory().ExecuteReader(strSql))
            {
                model = new T_Organization();
                if (read.Read())
                {
                    model.OrgCode = read["OrgCode"].ToString();
                    model.OrgName = read["OrgName"].ToString();
                    model.OrgShortName = read["OrgShortName"].ToString();
                    model.UpOrgCode = read["UpOrgCode"].ToString();
                    model.Seq = int.Parse(read["Seq"].ToString());
                    model.Level = int.Parse(read["Level"].ToString());
                    model.ShengCode = read["ShengCode"].ToString();
                    model.ShiCode = read["ShiCode"].ToString();
                    model.XianCode = read["XianCode"].ToString();
                    model.XiangCode = read["XiangCode"].ToString();
                    model.CunCode = read["CunCode"].ToString();
                    model.ZunCode = read["ZunCode"].ToString();
                }
                read.Dispose();
            }
            return model;
        }
        public T_Organization GetModelByUnit()
        {
            string strSql = "select top 1 [OrgCode],[OrgName],[OrgShortName],[UpOrgCode],[Seq],[Level],[ShengCode],[ShiCode],[XianCode],[XiangCode],[CunCode],[ZunCode] from T_Organization order by [Level] desc";
            T_Organization model = null;
            using (dynamic read = DbHelper.Factory().ExecuteReader(strSql))
            {
                model = new T_Organization();
                if (read.Read())
                {
                    model.OrgCode = read["OrgCode"].ToString();
                    model.OrgName = read["OrgName"].ToString();
                    model.OrgShortName = read["OrgShortName"].ToString();
                    model.UpOrgCode = read["UpOrgCode"].ToString();
                    model.Seq = int.Parse(read["Seq"].ToString());
                    model.Level = int.Parse(read["Level"].ToString());
                    model.ShengCode = read["ShengCode"].ToString();
                    model.ShiCode = read["ShiCode"].ToString();
                    model.XianCode = read["XianCode"].ToString();
                    model.XiangCode = read["XiangCode"].ToString();
                    model.CunCode = read["CunCode"].ToString();
                    model.ZunCode = read["ZunCode"].ToString();
                }
                read.Dispose();
            }
            return model;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UpOrgCode"></param>
        /// <returns></returns>
        public DataTable GetLower(string UpOrgCode)
        {
            string strSql = string.Format("select[OrgCode],[OrgName],[OrgShortName],[UpOrgCode],[Seq],[Level],[ShengCode],[ShiCode],[XianCode],[XiangCode],[CunCode],[ZunCode] from T_Organization where UpOrgCode='{0}'", UpOrgCode);
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }
        //
        public DataTable GetAllList()
        {
            string strSql = "select[OrgCode],[OrgName],[OrgShortName],[UpOrgCode],[Seq],[Level],[ShengCode],[ShiCode],[XianCode],[XiangCode],[CunCode],[ZunCode] from T_Organization order by Level desc";
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }
        public DataTable GetAllList(string orgcode)
        {
            string strSql = "select[OrgCode],[OrgName],[OrgShortName],[UpOrgCode],[Seq],[Level],[ShengCode],[ShiCode],[XianCode],[XiangCode],[CunCode],[ZunCode] from T_Organization where orgcode like '" + orgcode + "%' order by Level desc";
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }
    }
}
