using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Components.BL
{
    public class BranchBL
    {
        #region Variables
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static BranchBL _Instance;
        int affectedRows = 0;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        public Database objDataBase1 = DatabaseFactory.CreateDatabase("USS");
        #endregion

        #region Instance
        public static BranchBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BranchBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region BrachName_Check
        public DataTable BrachName_Check(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BrachName_Check");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Branch", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;

        }
        #endregion

        #region BranchSave
        public int BranchSave(Components.DTO.BranchDTO BranchDTO,string NewBranch, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Branch_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@UserName", DbType.String, BranchDTO.UserName);
            objDataBase.AddInParameter(dbCommand, "@Password", DbType.String, BranchDTO.Password);
            objDataBase.AddInParameter(dbCommand, "@SecurityQues", DbType.String, BranchDTO.SecurityQues);
            objDataBase.AddInParameter(dbCommand, "@SecurityAns", DbType.String, BranchDTO.SecurityAnswer);
            objDataBase.AddInParameter(dbCommand, "@NewBranchName", DbType.String, NewBranch);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region DatabaseSave
        public int DatabaseSave(Components.DTO.BranchDTO BranchDTO, string NewBranchName, string Branch, string UserID)
        {
            try
            {
                DbCommand dbCommand = objDataBase1.GetSqlStringCommand("New_Database");//SP in Accounts Database
                dbCommand.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand, "@NewBranchName", DbType.String, NewBranchName);
                objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                objDataBase.AddInParameter(dbCommand, "@UserName", DbType.String, BranchDTO.UserName);
                objDataBase.AddInParameter(dbCommand, "@Password", DbType.String, BranchDTO.Password);
                objDataBase.AddInParameter(dbCommand, "@SecurityQues", DbType.String, BranchDTO.SecurityQues);
                objDataBase.AddInParameter(dbCommand, "@SecurityAns", DbType.String, BranchDTO.SecurityAnswer);
                objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);

                int affectedRows = objDataBase1.ExecuteNonQuery(dbCommand);
                return affectedRows;
            }
            catch
            {
                return affectedRows;
            }
        }
        #endregion

       
    }
}
