using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Components.DTO;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Components.BL
{
    public class BankBL
    {
        #region Variables
        int affectedRows = 0;
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static BankBL _Instance;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region  Instance
        public static BankBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BankBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region BankSave
        public int BankSave(Components.DTO.BankDTO BankDTO, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Bank_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@BankCode", DbType.String, BankDTO.BankCode);
            objDataBase.AddInParameter(dbCommand, "@IFSCode", DbType.String, BankDTO.IFSCode);
            objDataBase.AddInParameter(dbCommand, "@Address", DbType.String, BankDTO.Address);
            objDataBase.AddInParameter(dbCommand, "@City", DbType.String, BankDTO.City);
            objDataBase.AddInParameter(dbCommand, "@PinCode", DbType.Int32, BankDTO.PinCode);
            objDataBase.AddInParameter(dbCommand, "@BankName", DbType.String, BankDTO.BankName);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, BankDTO.BranchName);
            objDataBase.AddInParameter(dbCommand, "@AccType", DbType.String, BankDTO.AccType);
            objDataBase.AddInParameter(dbCommand, "@AccNo", DbType.String, BankDTO.AccNo);
            objDataBase.AddInParameter(dbCommand, "@AccName", DbType.String, BankDTO.AccName);
            objDataBase.AddInParameter(dbCommand, "@DeepakBranchName", DbType.String, BankDTO.DeepakBranchName);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, BankDTO.UserID);
            int affectedrows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedrows;
        }
        #endregion

        #region BankView
        public DataTable BankView(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Bank_S");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@DeepakBranchName", DbType.String, Branch);

            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
        #endregion

        #region BankDelete
        public int BankDelete(int id, int hida, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Bank_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, id);
            objDataBase.AddInParameter(dbCommand, "@AddressID", DbType.Int32, hida);
            objDataBase.AddInParameter(dbCommand, "@DeepakBranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region BankUpdate
        public int BankUpdate(BankDTO BankDTO, int hidb, int hida, string Branch, string UserrID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Bank_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Address", DbType.String, BankDTO.Address);
            objDataBase.AddInParameter(dbCommand, "@City", DbType.String, BankDTO.City);
            objDataBase.AddInParameter(dbCommand, "@PinCode", DbType.Int32, BankDTO.PinCode);
            objDataBase.AddInParameter(dbCommand, "@BankCode", DbType.String, BankDTO.BankCode);
            objDataBase.AddInParameter(dbCommand, "@IFSCode", DbType.String, BankDTO.IFSCode);
            objDataBase.AddInParameter(dbCommand, "@BankName", DbType.String, BankDTO.BankName);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, BankDTO.BranchName);
            objDataBase.AddInParameter(dbCommand, "@AddressID", DbType.Int32, hida);
            objDataBase.AddInParameter(dbCommand, "@BankID", DbType.Int32, hidb);
            objDataBase.AddInParameter(dbCommand, "@AccType", DbType.String, BankDTO.AccType);
            objDataBase.AddInParameter(dbCommand, "@AccNo", DbType.String, BankDTO.AccNo);
            objDataBase.AddInParameter(dbCommand, "@AccName", DbType.String, BankDTO.AccName);
            objDataBase.AddInParameter(dbCommand, "@DeepakBranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion
    }
}
