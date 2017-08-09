using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using NCCQ.DBFactory;
using System.Data;
using System.Collections;
using System.Configuration;

namespace NCCQ.DBFactory
{
    /// <summary>
    /// 数据库操作父类
    /// </summary>
    public abstract class DbHelper
    {
        private static string DbType = ConfigurationManager.ConnectionStrings["DbType"].ConnectionString.Trim();
        /// <summary>
        /// 数据库转换
        /// </summary>
        /// <returns>返回抽象的子类</returns>
        public static DbHelper Factory()
        {
            DbHelper dbHelper = null;
            switch (DbType)
            {
                case "MSSQL": //Microsoft SqlServer Datatbase
                    dbHelper = new MsSqlHelper();
                    break;
                case "MYSQL"://MySql Database
                    dbHelper = new MySqlHelper();
                    break;
                case "Oracle"://Oracle Database
                    dbHelper = null;
                    break;
                case "Access"://Microsoft Access Database
                    dbHelper = null;
                    break;
                default:
                    dbHelper = null;
                    break;
            }
            return dbHelper;
        }
        //---------------单条SQL语句的函数-------------------------------
        /// <summary>
        /// 返回一个数据集
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <returns>DataSet</returns>
        public abstract DataSet DataSet(string _Sql);
        /// <summary>
        /// 无参数
        /// 表示连接执行无返回值 Transact-SQL 语句(insert,update,delete等),并返回执行是否成功.
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <returns>int</returns>
        public abstract int ExecuteNonQuery(string _Sql);
        /// <summary>
        /// 带SqlParameter参数的
        /// 表示连接执行无返回值 Transact-SQL 语句(insert,update,delete等),并返回执行是否成功.
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <param name="_Parms">SqlParameter参数</param>
        /// <returns>int</returns>
        public abstract int ExecuteNonQuery(string _Sql, params object[] _Parms);
        /// <summary>
        /// 无参执行查询返回第一行、列
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <returns>object</returns>
        public abstract object ExecuteScalar(string _Sql);
        /// <summary>
        /// 带参数，执行查询返回第一行、列
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <param name="_Spm">SqlParameter参数</param>
        /// <returns>object</returns>
        public abstract object ExecuteScalar(string _Sql, params object[] _Spm);
        /// <summary>
        /// 对连接执行 Transact-SQL 语句,并返回数据视图
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <returns>数据视图(DataView)</returns>
        public abstract DataView ExecuteDataView(string _Sql);
        /// <summary>
        /// 对连接执行 Transact-SQL 语句,并返回内存表
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <returns>数据视图(DataTable)</returns>
        public abstract DataTable ExecuteDataTable(string _Sql);
        /// <summary>
        /// 对连接执行 Transact-SQL 语句,并返回内存表
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <param name="_TableName">表映射的源表的名称</param>
        /// <param name="_StartIndex">缓存开始页索引</param>
        /// <param name="_PageSize">缓存页面大小</param>
        /// <returns>数据视图(DataTable)</returns>
        public abstract DataTable ExecuteDataTable(string _Sql, int _StartIndex, int _PageSize, string _TableName);
        /// <summary>
        /// 对连接执行 Transact-SQL 语句,并返回符合条件的ArrayList
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <param name="_Column">列名</param>
        /// <returns>数据ArrayList</returns>
        public abstract ArrayList Col(string _Sql, string _Column);
        /// <summary>
        /// 从数据库进行流读取的一种方式
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <returns>数据流方式(SqlDataReader)读取</returns>
        public abstract dynamic ExecuteReader(string _Sql);
        /// <summary>
        /// 从数据库进行流读取的一种方式
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <param name="_Spm">SqlParameter参数</param>
        /// <returns>数据流方式(SqlDataReader)读取</returns>
        public abstract dynamic ExecuteReader(string _Sql, object[] _Spm);        
        //----------------执行存储过程的函数------------------------------
        // public abstract int ExecuteNonQueryPro(string _ProName, params object[] _values);
        // public abstract dynamic ExecuteReaderPro(string _ProName, params object[] _values);
        // public abstract dynamic ExecuteReaderPro(string _ProName);
        // public abstract int ExecuteScalarPro(string _ProName, params object[] _values);
        // public abstract DataTable DataSetPro(string _ProName, params object[] _values);
    }
}
