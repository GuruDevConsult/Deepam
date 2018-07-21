using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace Components.DAL
{
    public class SQLConnect1
    {
        #region Variables
        private int paramLen = 0;
        private string connectString = string.Empty;
        private string connectString1 = string.Empty;
        private string sqlProc = string.Empty;
        private SqlParameter[] sqlParam;
        private int rowsAffected = 0;

        private SqlConnection conn = new SqlConnection();
        private SqlConnection conn1 = new SqlConnection();
        private SqlCommand Command = new SqlCommand();
        private SqlDataAdapter DataAdapter = new SqlDataAdapter();
        private SqlDataReader DataReader;
        private SqlTransaction Transaction;
        private static SQLConnect1 instance;
        private string _PageName = string.Empty;
        bool isLive = true;

        #endregion

        #region Constructor & Instance
        public static SQLConnect1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SQLConnect1();
                }
                return instance;
            }
        }
        #endregion

        #region Constructor
        //public Connect(bool isLive)
        private SQLConnect1()
        {
            
            ////if (isLive)
            ////{
            //    connectString = Convert.ToString(ConfigurationManager.ConnectionStrings["USS1"]);
            ////}
            ////else
            ////{
            ////    connectString = Convert.ToString(ConfigurationManager.AppSettings["SqlInternalConnectionString"]);
            ////}
            //conn = new SqlConnection(connectString);
            //if (conn.State == ConnectionState.Closed)
            //{
            //    conn.Open();
            //}
        }
        #endregion

        #region StoredProc Execute
        /// <summary>
        /// Execute the specified storedprocedure 0and returns no of rows affected.
        /// </summary>
        public int Exec()
        {
            try
            {
                Transaction = conn.BeginTransaction(IsolationLevel.Snapshot);
                Command.Parameters.Clear();
                if (sqlParam != null && sqlParam.Length > 0)
                {
                    paramLen = sqlParam.Length;
                    for (int j = 0; j < paramLen; j++)
                    {
                        Command.Parameters.Add(sqlParam[j]);
                    }
                }
                BuildSQLCommand();
                rowsAffected = Command.ExecuteNonQuery();
                Transaction.Commit();
                Command.Parameters.Clear();
                return rowsAffected;
            }
            catch(SqlException e)
            {
                Command.Parameters.Clear();
                Transaction.Rollback();
                return rowsAffected;
            }
            catch (Exception e)
            {
                Command.Parameters.Clear();
                Transaction.Rollback();
                return rowsAffected;
            }
        }
        #endregion

        #region StoredProc Execute1
        /// <summary>
        /// Execute the specified storedprocedure 0and returns no of rows affected.
        /// </summary>
        public int Exec1()
        {
            try
            {
                Transaction = conn1.BeginTransaction(IsolationLevel.Snapshot);
                Command.Parameters.Clear();
                if (sqlParam != null && sqlParam.Length > 0)
                {
                    paramLen = sqlParam.Length;
                    for (int j = 0; j < paramLen; j++)
                    {
                        Command.Parameters.Add(sqlParam[j]);
                    }
                }
                BuildSQLCommand1();
                rowsAffected = Command.ExecuteNonQuery();
                Transaction.Commit();
                Command.Parameters.Clear();
                return rowsAffected;
            }
            catch (SqlException e)
            {
                Command.Parameters.Clear();
                Transaction.Rollback();
                return rowsAffected;
            }
            catch (Exception e)
            {
                Command.Parameters.Clear();
                Transaction.Rollback();
                return rowsAffected;
            }
        }
        #endregion

        #region StoredProc Execute Read
        /// <summary>
        /// Returns dataset resultset without input parameter(s).
        /// </summary>

        public DataSet ExecRead()
        {
            try
            {
                DataSet dsData = new DataSet();
                Transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                if (sqlParam != null && sqlParam.Length > 0)
                {
                    paramLen = sqlParam.Length;
                    for (int j = 0; j < paramLen; j++)
                    {
                        Command.Parameters.Add(sqlParam[j]);
                    }
                }
                BuildSQLCommand();
                DataReader = Command.ExecuteReader();
                dsData = DataReaderToDataSet(DataReader);
                Transaction.Commit();
                Command.Parameters.Clear();
                return dsData;
            }
            catch (SqlException e)
            {
                Transaction.Rollback();
                return null;
            }
            catch (Exception e)
            {
                Transaction.Rollback();
                return null;
            }
        }
        #endregion

        #region StoredProc Return Data Table
        /// <summary>
        /// Returns datatable resultset against specified sql parameter(s).
        /// </summary>
        public DataTable ExecReadDT()
        {
            try
            {
                DataTable dtData = new DataTable();
                Command.Parameters.Clear();
                Transaction = conn.BeginTransaction(IsolationLevel.Snapshot);
                if (sqlParam != null && sqlParam.Length > 0)
                {
                    paramLen = sqlParam.Length;
                    for (int j = 0; j < paramLen; j++)
                    {
                        Command.Parameters.Add(sqlParam[j]);
                    }
                }
                BuildSQLCommand();
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(dtData);
                Transaction.Commit();
                Command.Parameters.Clear();
                return dtData;
            }
            catch (SqlException e)
            {
                Command.Parameters.Clear();
                Transaction.Rollback();
                return null;
            }
            catch(Exception e)
            {
                Command.Parameters.Clear();
                e.Message.ToString();
                 Transaction.Rollback();
                return null;
            }
        }
        #endregion

        #region StoredProc Return Data Set
        /// <summary>
        /// Returns dataset resultset against specified sql parameter(s).
        /// </summary>

        public DataSet ExecReadDS()
        {
            try
            {
                DataSet dsData = new DataSet();
                Command.Parameters.Clear();
                Transaction = conn.BeginTransaction(IsolationLevel.Snapshot);
                if (sqlParam != null && sqlParam.Length > 0)
                {
                    paramLen = sqlParam.Length;
                    for (int j = 0; j < paramLen; j++)
                    {
                        Command.Parameters.Add(sqlParam[j]);
                    }
                }
                BuildSQLCommand();
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(dsData);
                Transaction.Commit();
                Command.Parameters.Clear();
                return dsData;
            }
            catch (SqlException e)
            {
                Transaction.Rollback();
                return null;
            }
            catch (Exception e)
            {
                Transaction.Rollback();
                return null;
            }
        }
        #endregion

        #region StoredProc Return Data Adapter
        /// <summary>
        /// Returns Data Adapter against specified sql parameter(s).
        /// </summary>

        public SqlDataAdapter ExecReadDA()
        {
            try
            {
                Command.Parameters.Clear();
                Transaction = conn.BeginTransaction(IsolationLevel.Snapshot);
                if (sqlParam != null && sqlParam.Length > 0)
                {
                    paramLen = sqlParam.Length;
                    for (int j = 0; j < paramLen; j++)
                    {
                        Command.Parameters.Add(sqlParam[j]);
                    }
                }
                BuildSQLCommand();
                DataAdapter.SelectCommand = Command;
                Transaction.Commit();
                return DataAdapter;
            }
            catch (SqlException e)
            {
                Transaction.Rollback();
                return null;
            }
            catch (Exception e)
            {
                Transaction.Rollback();
                return null;
            }
        }
        #endregion

        #region StoredProc Return Scalar value
        /// <summary>
        /// Returns a 1x1 resultset against specified sql parameter(s).
        /// </summary>
        public object ExecScalar()
        {
            try
            {
                //int indxOutParam = 0;
                Command.Parameters.Clear();
                object objOutput;
                Transaction = conn.BeginTransaction(IsolationLevel.Snapshot);
                //indxOutParam = Command.Parameters.Count - 1;
                if (sqlParam != null && sqlParam.Length > 0)
                {
                    paramLen = sqlParam.Length;
                    for (int j = 0; j < paramLen; j++)
                    {
                        Command.Parameters.Add(sqlParam[j]);
                    }
                }
                BuildSQLCommand();
                objOutput = Command.ExecuteScalar();
                Transaction.Commit();
                Command.Parameters.Clear();
                return objOutput;
            }
            catch (SqlException e)
            {
                Transaction.Rollback();
                Command.Parameters.Clear();
                return null;
            }
            catch (Exception e)
            {
                Transaction.Rollback();
                Command.Parameters.Clear();
                return null;
            }
        }
        #endregion

        #region Build SQLCommand
        private void BuildSQLCommand()
        {
            Command.Connection = conn;
            Command.Transaction = Transaction;
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = sqlProc;
                      
         
        }
        #endregion

        #region Build SQLCommand1
        private void BuildSQLCommand1()
        {
            Command.Connection = conn1;
            Command.Transaction = Transaction;
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = sqlProc;


        }
        #endregion

        #region Convert DateReader to DataSet
        private DataSet DataReaderToDataSet(SqlDataReader reader)
        {
            DataSet dataSet = new DataSet();
            do
            {
                DataTable schemaTable = reader.GetSchemaTable();
                DataTable dataTable = new DataTable();
                int cntRows = 0;
                if (schemaTable != null)
                {
                    cntRows = schemaTable.Rows.Count;
                    for (int i = 0; i < cntRows; i++)
                    {
                        DataRow dataRow = schemaTable.Rows[i];
                        string columnName = (string)dataRow["ColumnName"]; //+ "<C" + i + "/>";
                        DataColumn column = new DataColumn(columnName, (Type)dataRow["DataType"]);
                        dataTable.Columns.Add(column);
                    }

                    dataSet.Tables.Add(dataTable);

                    while (reader.Read())
                    {
                        DataRow dataRow = dataTable.NewRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                            dataRow[i] = reader.GetValue(i);

                        dataTable.Rows.Add(dataRow);
                    }
                }
                else
                {
                    DataColumn column = new DataColumn("RowsAffected");
                    dataTable.Columns.Add(column);
                    dataSet.Tables.Add(dataTable);
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = reader.RecordsAffected;
                    dataTable.Rows.Add(dataRow);
                }
            }
            while (reader.NextResult());
            reader.Close();
            return dataSet;
        }
        #endregion

        #region SQLParam
        /// <summary>
        /// Build specified storedprocedure's paramete(s) as Sqlparameter[] array and assign.
        /// </summary>
        public SqlParameter[] SqlParam
        {
            get
            {
                return sqlParam;
            }
            set
            {
                sqlParam = value;
            }
        }
        #endregion

        #region SqlProcedure
        /// <summary>
        /// Specify the SQL storedprocedure which need to be executed.
        /// </summary>
        public string SqlProcedure
        {
            get
            {
                return sqlProc;
            }
            set
            {
                sqlProc = value;
            }
        }
        #endregion

        #region RowsAffected
        /// <summary>
        /// No of Rows Affected by Last Query
        /// </summary>
        public int RowsAffected
        {
            get
            {
                return rowsAffected;
            }
            set
            {
                rowsAffected = value;
            }
        }
        #endregion

        #region Connection Open, Close
        public void OpenConnection(bool isLive)
        {
            //if (isLive)
            //{
            connectString = Convert.ToString(ConfigurationManager.ConnectionStrings["USS1"]);
            connectString1 = Convert.ToString(ConfigurationManager.ConnectionStrings["USS"].ToString());
            //}
            //else
            //{
            //    connectString = Convert.ToString(ConfigurationManager.AppSettings["SqlInternalConnectionString"]);
            //}
            conn = new SqlConnection(connectString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            conn1 = new SqlConnection(connectString1);
            if (conn1.State == ConnectionState.Closed)
            {
                conn1.Open();
            }
        }
        
       
      
        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public void CloseConnection1()
        {
            if (conn1.State == ConnectionState.Open)
            {
                conn1.Close();
            }
        }
        
       #endregion 

        #region PageName
        /// <summary>
        /// No of Rows Affected by Last Query
        /// </summary>
        public string PageName
        {
            get
            {
                return _PageName;
            }
            set
            {
                _PageName = value;
            }
        }
        #endregion

        #region Reset
        public static void Reset()
        {
            instance = new SQLConnect1();
        }
        #endregion
    }
}
