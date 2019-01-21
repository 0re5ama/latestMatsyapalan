using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MajorConn
{
    public static class SqlHelper
    {
       static string connstr = "Data Source=.;Initial Catalog=Matasyapalan;Integrated Security=True";
        /// <summary> 
        /// Set the connection, command, and then execute the command with non query. 
        /// </summary> 
        /// 
        public static Int32 ExecuteNonQuery( SqlCommand sm, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(sm.CommandText, conn))
                {
                    // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect  
                    // type is only for OLE DB.   
                    cmd.CommandType = sm.CommandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary> 
        /// Set the connection, command, and then execute the command and only return one value. 
        /// </summary> 
        public static Object ExecuteScalar(String connectionString, String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary> 
        /// Set the connection, command, and then execute the command with query and return the reader. 
        /// </summary> 
        public static SqlDataReader ExecuteReader(SqlCommand sm, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connstr);

            using (SqlCommand cmd = new SqlCommand(sm.CommandText, conn))
            {
                cmd.CommandType = sm.CommandType;
                cmd.Parameters.AddRange(parameters);

                conn.Open();
                // When using CommandBehavior.CloseConnection, the connection will be closed when the  
                // IDataReader is closed. 
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }


        public static SqlDataReader SingleExecuteReader(SqlCommand sm)
        {
            SqlConnection conn = new SqlConnection(connstr);

            using (SqlCommand cmd = new SqlCommand(sm.CommandText, conn))
            {
                cmd.CommandType = sm.CommandType;
               // cmd.Parameters.AddRange(parameters);

                conn.Open();
                // When using CommandBehavior.CloseConnection, the connection will be closed when the  
                // IDataReader is closed. 
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }

    }
}

//////////////////////////

//public static int YourFunction1(int param1, int param2)
//{
//    SqlParameter[] objParameter = new SqlParameter[2];
//    objParameter[0] = new SqlParameter("@param1", param1);
//    objParameter[1] = new SqlParameter("@param2", param2);
//    return Convert.ToInt32(Data.ExecuteScalar("YourProcedureName", objParameter));
//}
//
//public static int YourFunction2()
//{
//    return Data.ExecuteNonQuery("YourProcedureName");
//}
//
//public static void YourFunction3(int param1, int param2, int param3, ref DataTable dt)
//{
//    SqlParameter[] objParameter = new SqlParameter[3];
//    objParameter[0] = new SqlParameter("@param1", param1);
//    objParameter[1] = new SqlParameter("@param2", param2);
//    objParameter[2] = new SqlParameter("@param3", param3);
//    dt.Fill("YourProcedureName", objParameter);
//}


///////////////////////


//using System;
//using System.Data;
//using System.Data.SqlClient;
// 
//namespace Utility
//{
//    public static class SqlHelper
//    {
//        #region "FILL DATA TABLE"
//
//        public static void Fill(DataTable dataTable, String procedureName)
//        {
//            SqlConnection oConnection = new SqlConnection(AccessConfig.GetConnectionString());
//            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);
//            oCommand.CommandType = CommandType.StoredProcedure;
//
//            SqlDataAdapter oAdapter = new SqlDataAdapter();
//
//            oAdapter.SelectCommand = oCommand;
//            oConnection.Open();
//            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
//            {
//                try
//                {
//                    oAdapter.SelectCommand.Transaction = oTransaction;
//                    oAdapter.Fill(dataTable);
//                    oTransaction.Commit();
//                }
//                catch
//                {
//                    oTransaction.Rollback();
//                    throw;
//                }
//                finally
//                {
//                    if (oConnection.State == ConnectionState.Open)
//                        oConnection.Close();
//                    oConnection.Dispose();
//                    oAdapter.Dispose();
//                }
//            }
//        }
//
//        public static void Fill(DataTable dataTable, String procedureName, SqlParameter[] parameters)
//        {
//            SqlConnection oConnection = new SqlConnection(AccessConfig.GetConnectionString());
//            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);
//            oCommand.CommandType = CommandType.StoredProcedure;
//
//            if (parameters != null)
//                oCommand.Parameters.AddRange(parameters);
//
//            SqlDataAdapter oAdapter = new SqlDataAdapter();
//
//            oAdapter.SelectCommand = oCommand;
//            oConnection.Open();
//            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
//            {
//                try
//                {
//                    oAdapter.SelectCommand.Transaction = oTransaction;
//                    oAdapter.Fill(dataTable);
//                    oTransaction.Commit();
//                }
//                catch
//                {
//                    oTransaction.Rollback();
//                    throw;
//                }
//                finally
//                {
//                    if (oConnection.State == ConnectionState.Open)
//                        oConnection.Close();
//                    oConnection.Dispose();
//                    oAdapter.Dispose();
//                }
//            }
//        }
//
//        #endregion
//
//        #region "FILL DATASET"
//
//        public static void Fill(DataSet dataSet, String procedureName)
//        {
//            SqlConnection oConnection = new SqlConnection(AccessConfig.GetConnectionString());
//            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);
//            oCommand.CommandType = CommandType.StoredProcedure;
//
//            SqlDataAdapter oAdapter = new SqlDataAdapter();
//
//            oAdapter.SelectCommand = oCommand;
//            oConnection.Open();
//            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
//            {
//                try
//                {
//                    oAdapter.SelectCommand.Transaction = oTransaction;
//                    oAdapter.Fill(dataSet);
//                    oTransaction.Commit();
//                }
//                catch
//                {
//                    oTransaction.Rollback();
//                    throw;
//                }
//                finally
//                {
//                    if (oConnection.State == ConnectionState.Open)
//                        oConnection.Close();
//                    oConnection.Dispose();
//                    oAdapter.Dispose();
//                }
//            }
//        }
//
//        public static void Fill(DataSet dataSet, String procedureName, SqlParameter[] parameters)
//        {
//            SqlConnection oConnection = new SqlConnection(AccessConfig.GetConnectionString());
//            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);
//            oCommand.CommandType = CommandType.StoredProcedure;
//
//            if (parameters != null)
//                oCommand.Parameters.AddRange(parameters);
//
//            SqlDataAdapter oAdapter = new SqlDataAdapter();
//
//            oAdapter.SelectCommand = oCommand;
//            oConnection.Open();
//            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
//            {
//                try
//                {
//                    oAdapter.SelectCommand.Transaction = oTransaction;
//                    oAdapter.Fill(dataSet);
//                    oTransaction.Commit();
//                }
//                catch
//                {
//                    oTransaction.Rollback();
//                    throw;
//                }
//                finally
//                {
//                    if (oConnection.State == ConnectionState.Open)
//                        oConnection.Close();
//                    oConnection.Dispose();
//                    oAdapter.Dispose();
//                }
//            }
//        }
//
//        #endregion
//
//        #region "EXECUTE SCALAR"
//
//        public static object ExecuteScalar(String procedureName)
//        {
//            SqlConnection oConnection = new SqlConnection(AccessConfig.GetConnectionString());
//            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);
//
//            oCommand.CommandType = CommandType.StoredProcedure;
//            object oReturnValue;
//            oConnection.Open();
//            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
//            {
//                try
//                {
//                    oCommand.Transaction = oTransaction;
//                    oReturnValue = oCommand.ExecuteScalar();
//                    oTransaction.Commit();
//                }
//                catch
//                {
//                    oTransaction.Rollback();
//                    throw;
//                }
//                finally
//                {
//                    if (oConnection.State == ConnectionState.Open)
//                        oConnection.Close();
//                    oConnection.Dispose();
//                    oCommand.Dispose();
//                }
//            }
//            return oReturnValue;
//        }
//
//        public static object ExecuteScalar(String procedureName, SqlParameter[] parameters)
//        {
//            SqlConnection oConnection = new SqlConnection(AccessConfig.GetConnectionString());
//            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);
//
//            oCommand.CommandType = CommandType.StoredProcedure;
//            object oReturnValue;
//            oConnection.Open();
//            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
//            {
//                try
//                {
//                    if (parameters != null)
//                        oCommand.Parameters.AddRange(parameters);
//
//                    oCommand.Transaction = oTransaction;
//                    oReturnValue = oCommand.ExecuteScalar();
//                    oTransaction.Commit();
//                }
//                catch
//                {
//                    oTransaction.Rollback();
//                    throw;
//                }
//                finally
//                {
//                    if (oConnection.State == ConnectionState.Open)
//                        oConnection.Close();
//                    oConnection.Dispose();
//                    oCommand.Dispose();
//                }
//            }
//            return oReturnValue;
//        }
//
//        #endregion
//
//        #region "EXECUTE NON QUERY"
//
//        public static int ExecuteNonQuery(string procedureName)
//        {
//            SqlConnection oConnection = new SqlConnection(AccessConfig.GetConnectionString());
//            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);
//
//            oCommand.CommandType = CommandType.StoredProcedure;
//            int iReturnValue;
//            oConnection.Open();
//            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
//            {
//                try
//                {
//                    oCommand.Transaction = oTransaction;
//                    iReturnValue = oCommand.ExecuteNonQuery();
//                    oTransaction.Commit();
//                }
//                catch
//                {
//                    oTransaction.Rollback();
//                    throw;
//                }
//                finally
//                {
//                    if (oConnection.State == ConnectionState.Open)
//                        oConnection.Close();
//                    oConnection.Dispose();
//                    oCommand.Dispose();
//                }
//            }
//            return iReturnValue;
//        }
//
//        public static int ExecuteNonQuery(string procedureName, SqlParameter[] parameters)
//        {
//            SqlConnection oConnection = new SqlConnection(AccessConfig.GetConnectionString());
//            SqlCommand oCommand = new SqlCommand(procedureName, oConnection);
//
//            oCommand.CommandType = CommandType.StoredProcedure;
//            int iReturnValue;
//            oConnection.Open();
//            using (SqlTransaction oTransaction = oConnection.BeginTransaction())
//            {
//                try
//                {
//                    if (parameters != null)
//                        oCommand.Parameters.AddRange(parameters);
//
//                    oCommand.Transaction = oTransaction;
//                    iReturnValue = oCommand.ExecuteNonQuery();
//                    oTransaction.Commit();
//                }
//                catch
//                {
//                    oTransaction.Rollback();
//                    throw;
//                }
//                finally
//                {
//                    if (oConnection.State == ConnectionState.Open)
//                        oConnection.Close();
//                    oConnection.Dispose();
//                    oCommand.Dispose();
//                }
//            }
//            return iReturnValue;
//        }
//
//        #endregion
//
//    }
//}

