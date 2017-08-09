using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace NCCQ.DBFactory
{
    public class MySqlHelper : DbHelper, IDisposable
    {
        //ConfigurationManager.AppSettings["DataBaseLinks"].ToString();
        private string _DBPath = ConfigurationManager.ConnectionStrings["DataBaseLinks"].ConnectionString;
       
        MySqlConnection connection = null;
        MySqlCommand command = null;
        MySqlDataReader dataReader = null;
        MySqlDataAdapter dataAdapter = null;
        DataSet dataSet = null;
        DataView dataView = null;
        DataTable dataTable = null;
        /// <summary>
        /// 返回一个数据集
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <returns>DataSet</returns>
        public override DataSet DataSet(string _Sql)
        {
            try
            {               
                connection = new MySqlConnection(_DBPath);
                command = new MySqlCommand(_Sql, connection);
                dataAdapter = new MySqlDataAdapter();
                dataSet = new DataSet();
                command.CommandTimeout = 50;
                dataAdapter.SelectCommand = command;
                connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = _Sql;
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Clear();
            }
        }
        /// <summary>
        /// 无参数
        /// 表示连接执行无返回值 Transact-SQL 语句(insert,update,delete等),并返回执行是否成功.
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <returns>int</returns>
        public override int ExecuteNonQuery(string _Sql)
        {
            try
            {
                connection = new MySqlConnection(_DBPath);
                command = new MySqlCommand(_Sql, connection);
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Clear();
            }
        }
        /// <summary>
        /// 带SqlParameter参数的
        /// 表示连接执行无返回值 Transact-SQL 语句(insert,update,delete等),并返回执行是否成功.
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <param name="_Parms">SqlParameter参数</param>
        /// <returns>int</returns>
        public override int ExecuteNonQuery(string _Sql, params  object[] _Parms)
        {
            try
            {
                connection = new MySqlConnection(_DBPath);
                command = new MySqlCommand(_Sql, connection);
                connection.Open();
                command.Parameters.AddRange(_Parms);
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Clear();
            }
        }
        /// <summary>
        /// 无参执行查询返回第一行、列
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <returns>object</returns>
        public override object ExecuteScalar(string _Sql)
        {
            try
            {
                connection = new MySqlConnection(_DBPath);
                command = new MySqlCommand(_Sql, connection);
                connection.Open();
                object ob = null;
                ob = command.ExecuteScalar();
                connection.Close();
                return ob;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Clear();
            }
        }
        /// <summary>
        /// 带参数，执行查询返回第一行、列
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <param name="_Spm">SqlParameter参数</param>
        /// <returns>object</returns>
        public override object ExecuteScalar(string _Sql, object[] _Spm)
        {
            try
            {
                connection = new MySqlConnection(_DBPath);
                command = new MySqlCommand(_Sql, connection);
                connection.Open();
                object ob = null;
                command.Parameters.AddRange(_Spm);
                ob = command.ExecuteScalar();
                connection.Close();
                return ob;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Clear();
            }
        }
        /// <summary>
        /// 从数据库进行流读取的一种方式
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <returns>数据流方式(SqlDataReader)读取</returns>
        public override dynamic ExecuteReader(string _Sql)
        {
            try
            {
                connection = new MySqlConnection(_DBPath);
                command = new MySqlCommand(_Sql, connection);
                connection.Open();
                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return dataReader;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 从数据库进行流读取的一种方式
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <param name="_Spm">SqlParameter参数</param>
        /// <returns>数据流方式(SqlDataReader)读取</returns>
        public override dynamic ExecuteReader(string _Sql, object[] _Spm)
        {
            try
            {
                connection = new MySqlConnection(_DBPath);
                command = new MySqlCommand(_Sql, connection);
                connection.Open();
                command.Parameters.AddRange(_Spm);
                dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return dataReader;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句,并返回数据视图
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <returns>数据视图(DataView)</returns>
        public override DataView ExecuteDataView(string _Sql)
        {
            try
            {
                connection = new MySqlConnection(_DBPath);
                command = new MySqlCommand(_Sql, connection);
                dataAdapter = new MySqlDataAdapter();
                dataSet = new DataSet();
                command.CommandTimeout = 50;
                dataAdapter.SelectCommand = command;
                connection.Open();
                dataAdapter.Fill(dataSet);
                dataView = dataSet.Tables[0].DefaultView;
                return dataView;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Clear();
            }
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句,并返回内存表
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <returns>数据视图(DataTable)</returns>
        public override DataTable ExecuteDataTable(string _Sql)
        {
            try
            {
                connection = new MySqlConnection(_DBPath);
                command = new MySqlCommand(_Sql, connection);
                dataAdapter = new MySqlDataAdapter();
                dataSet = new DataSet();
                command.CommandTimeout = 50;
                dataAdapter.SelectCommand = command;
                connection.Open();
                dataAdapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Clear();
            }
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句,并返回内存表
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <param name="_TableName">表映射的源表的名称</param>
        /// <param name="_StartIndex">缓存开始页索引</param>
        /// <param name="_PageSize">缓存页面大小</param>
        /// <returns>数据视图(DataTable)</returns>
        public override DataTable ExecuteDataTable(string _Sql, int _StartIndex, int _PageSize, string _TableName)
        {
            try
            {
                connection = new MySqlConnection(_DBPath);
                command = new MySqlCommand(_Sql, connection);
                dataAdapter = new MySqlDataAdapter();
                dataSet = new DataSet();
                command.CommandTimeout = 50;
                dataAdapter.SelectCommand = command;
                connection.Open();
                dataAdapter.Fill(dataSet, _StartIndex, _PageSize, _TableName);
                dataTable = dataSet.Tables[0];
                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Clear();
            }
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句,并返回符合条件的ArrayList
        /// </summary>
        /// <param name="_Sql">执行的SQL语句</param>
        /// <param name="_Column">列名</param>
        /// <returns>数据ArrayList</returns>
        public override ArrayList Col(string _Sql, string _Column)
        {
            try
            {
                connection = new MySqlConnection(_DBPath);
                command = new MySqlCommand(_Sql, connection);
                connection.Open();
                dataReader = command.ExecuteReader();
                ArrayList arrayList = new ArrayList();
                while (dataReader.Read())
                {
                    arrayList.Add(dataReader[_Column].ToString());
                }
                Clear();
                return arrayList;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Clear();
            }
        }
        /// <summary>
        ///  操作完毕,清除数据库连接
        /// </summary>
        public void Clear()
        {
            if (connection != null)
            {
                connection.Dispose();
                connection = null;
            }
            if (command != null)
            {
                command.Dispose();
                command = null;
            }
            if (dataReader != null)
            {
                dataReader.Dispose();
                dataReader = null;
            }
            if (dataAdapter != null)
            {
                dataAdapter.Dispose();
                dataAdapter = null;
            }
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Clear();
        }       
    }
}