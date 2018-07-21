using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Components.BL
{
    public class StockDetailsBL
    {
        #region Variables
        int affectedRows = 0;
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        Components.DTO.StockDetailsDTO StockDTO;
        private static StockDetailsBL _Instance;
        DataTable dtStock = new DataTable();
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region  Instance
        public static StockDetailsBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StockDetailsBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region Stock Save
        public int StockSave(Components.DTO.StockDetailsDTO StockDTO, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("StockDetails_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@StoreNo", DbType.String, StockDTO.StoreNo);
            objDataBase.AddInParameter(dbCommand, "@ItemName", DbType.String, StockDTO.ItemName);
            objDataBase.AddInParameter(dbCommand, "@Qty", DbType.Int32, StockDTO.Qty);
            objDataBase.AddInParameter(dbCommand, "@Unit", DbType.Int32, StockDTO.Unit);
            objDataBase.AddInParameter(dbCommand, "@LRNo", DbType.String, StockDTO.LRNo);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion


        #region Stock Update
        public int StockUpdate(Components.DTO.StockDetailsDTO StockDTO, int ID, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("StockDetails_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, ID);
            objDataBase.AddInParameter(dbCommand, "@StoreNo", DbType.String, StockDTO.StoreNo);
            objDataBase.AddInParameter(dbCommand, "@ItemName", DbType.String, StockDTO.ItemName);
            objDataBase.AddInParameter(dbCommand, "@Qty", DbType.Int32, StockDTO.Qty);
            objDataBase.AddInParameter(dbCommand, "@Unit", DbType.Int32, StockDTO.Unit);
            objDataBase.AddInParameter(dbCommand, "@LRNo", DbType.String, StockDTO.LRNo);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region Stock Delete
        public int StockDelete(int ID, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("StockDetails_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, ID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region ItemView
        public DataTable ItemView(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("StockDetails_Item_S");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
        #endregion

        #region StorNoView
        public DataTable StorNo_View(string StoreNoView, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("StockDetails_StoreNo_View");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@StoreNo", DbType.String, StoreNoView);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
        #endregion
    }
}
