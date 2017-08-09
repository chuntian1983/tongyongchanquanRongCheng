using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using NCCQ.DBFactory;

namespace NCCQ.DBFactory
{
   public static class GetListByPage
    {
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="zjid">主键id</param>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static DataTable GetPage(string tablename,string zjid,string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T."+zjid+" desc");
            }
            strSql.Append(")AS Row, T.*  from "+tablename+" T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelper.Factory().ExecuteDataTable(strSql.ToString());
        }
    }
}
