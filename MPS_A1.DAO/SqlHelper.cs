using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections;
using System.Data.OleDb;
using MPS_A1.Utilities;

namespace MPS_A1.DAO
{
    /// <summary>
    /// SqlHelper类高性能数据操作
    /// </summary>
    public class SqlHelper
    {
   
        //public static OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + GlobalInfo.g_DbFullPath);
        //public static OleDbDataAdapter da = new OleDbDataAdapter("select * from student_info", conn);
        ////public static OleDbDataAdapter da;
        //public static DataSet ds = new DataSet();
        //public static DataSet queryDs = new DataSet();
        //public static OleDbCommandBuilder cmd = new OleDbCommandBuilder(da);

        //public static readonly string ConnectionStringLocalTransaction = ConfigurationManager.ConnectionStrings["ETL_CMS_ERPCopy"].ConnectionString;
        //public static readonly string ConnectionStringLocalTransactionCMIS = ConfigurationManager.ConnectionStrings["CMISdefault"].ConnectionString;
     
        // 存贮Cache
        //private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        //static SqlHelper() {/*All static methods*/}

             /*
        /// <summary>
        /// 获取受影响的行数
        /// </summary>
        /// <returns>受此命令影响的行数</returns>
        public static int ExecuteNonQuery(string connectionSql, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionSql))
            {
                ExecuteNonQuery(sqlConnection, cmdType, cmdText, commandParameters);
            }
            return 1;
        }

        /// <summary>
        /// 获取受影响的行数
        /// </summary>
        /// <returns>受此命令影响的行数</returns>
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection sqlConnection =
                new SqlConnection(ConnectionStringLocalTransaction))
            {
                ExecuteNonQuery(sqlConnection, cmdType, cmdText, commandParameters);
            }
            return 1;
        }

        /// <summary>
        /// 返回影响的行数
        /// </summary>
        /// <returns>受此命令影响的行数</returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600 * 24;
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            //cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 返回影响的行数
        /// </summary>
        /// <returns>受此命令影响的行数</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            int val = 0;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandTimeout = 3600 * 24;
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
                val = cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();
                trans.Commit();
            }
            return val;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="connecitonString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteAdapter(string connecitonString, CommandType cmdType, String cmdText)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet db_ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connecitonString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.CommandTimeout = 3600 * 3600;
                sda.SelectCommand = cmd;

                sda.Fill(db_ds);
                conn.Close();
            }
            return db_ds;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="connecitonString"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteAdapter(SqlConnection conn, CommandType cmdType, String cmdText)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet db_ds = new DataSet();

            SqlCommand cmd = new SqlCommand(cmdText, conn);
            //cmd.CommandTimeout = 3600 * 3600;
            sda.SelectCommand = cmd;

            sda.Fill(db_ds);
            //conn.Close();

            return db_ds;
        }

        /// <summary>
        /// 执行命令，返回reader
        /// </summary>
        /// <returns>一个结果集对象SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600 * 3600;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // 连接要关闭
                // CommandBehavior.CloseConnection在异常时不发生作用
                try
                {
                    conn.Open();
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                    //SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    cmd.Parameters.Clear();
                    return rdr;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.StackTrace);
                    //conn.Close();
                    //throw ex;
                    return null;
                }
            }
        }

        /// <summary>
        /// 执行命令，返回reader
        /// </summary>
        /// <returns>一个结果集对象SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600 * 3600;
            //SqlConnection conn = new SqlConnection(connectionString);
            System.Console.WriteLine("初始command");
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                System.Console.WriteLine("开始reader");
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                //SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                System.Console.WriteLine("删除参数");
                cmd.Parameters.Clear();
                System.Console.WriteLine("返回Reader");
                return rdr;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
                //conn.Close();
                //throw ex;
                return null;
            }
        }

        /// <summary>
        /// 返回第一行，第一列
        /// </summary>
        /// <returns>返回的对象，在使用时记得类型转换</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600 * 3600;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 返回第一行，第一列
        /// </summary>
        /// <returns>返回的对象，在使用时记得类型转换</returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 3600 * 24;
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 在缓存中添加参数数组
        /// </summary>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// 提取缓存的参数数组
        /// </summary>
        /// <param name="cacheKey">查找缓存的key</param>
        /// <returns>返回被缓存的参数数组</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];
            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        /// <summary>
        /// 提供一个SqlCommand对象的设置
        /// </summary>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        /// <summary>
        /// 返回Table Schema 构造
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTableSchema(DataColumn[] columnsArray)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(columnsArray);

            return dataTable;
        }

        /// <summary>
        /// 使用 TVP 方式批插入
        /// </summary>
        /// <param name="dataTableParam"></param>
        /// <param name="createTypeProc"></param>
        /// <returns></returns>
        public static long TVPInsert(DataTable dataTableParam, String createTypeProc)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            SqlParameter[] sqlParameter = { new SqlParameter("@TVP", dataTableParam) };
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "CreatePassportWithTVP", sqlParameter);

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// 使用SqlBulkCopy方式插入数据
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static long SqlBulkCopyInsert(DataTable dataTable, String tableName)
        {
            //LogTrace.IN(SqlHelper.SqlBulkCopyInsert);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            SqlConnection sqlConnection = new SqlConnection(ConnectionStringLocalTransaction);
            sqlConnection.Open();
            SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConnection);
            sqlBulkCopy.DestinationTableName = tableName;
            sqlBulkCopy.BatchSize = dataTable.Rows.Count;
            sqlBulkCopy.BulkCopyTimeout = 3600 * 3600;
            if (dataTable != null && dataTable.Rows.Count != 0)
            {
                sqlBulkCopy.WriteToServer(dataTable);
            }
            sqlBulkCopy.Close();
            sqlConnection.Close();
            sqlBulkCopy = null;
            sqlConnection = null;

            stopwatch.Stop();
            //LogTrace.OUT(null);
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// 清除库日志
        /// </summary>
        /// <returns></returns>
        public static object CleanLog()
        {
            return 1;
            //return ExecuteScalar(ConnectionStringLocalTransaction,
            //            CommandType.StoredProcedure, "CleanDBLog", null);
        }*/
    }
}
