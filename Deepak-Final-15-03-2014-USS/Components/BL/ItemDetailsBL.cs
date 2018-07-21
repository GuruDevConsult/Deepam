using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class ItemDetailsBL
    {
        #region Variables
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        Components.Common.ObjectWrapper ObjWrp;
        int affectedRows = 0;
        private static ItemDetailsBL _Instance;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Constructor & Instance
        public static ItemDetailsBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ItemDetailsBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region ItemMaster Select
        public DataTable ItemMaster_S(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("ItemMaster_S");
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

        #region ItemDetails Save

        public int ItemDetails_I(Components.DTO.ItemDetailsDTO ItemDTO,string Branch,string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("ItemMaster_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Item", DbType.String, ItemDTO.Item);
            //objDataBase.AddInParameter(dbCommand, "@Rate", DbType.Decimal, ItemDTO.Rate);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region ItemDetails Update
        public int ItemDetails_U(Components.DTO.ItemDetailsDTO ItemDTO, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("ItemMaster_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ItemID", DbType.String, ItemDTO.ID);
            objDataBase.AddInParameter(dbCommand, "@Item", DbType.String, ItemDTO.Item);
            //objDataBase.AddInParameter(dbCommand, "@Rate", DbType.Decimal, ItemDTO.Rate);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region ItemDetails Delete
        public int ItemDetails_D(Components.DTO.ItemDetailsDTO ItemDTO, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("ItemMaster_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ItemID", DbType.String, ItemDTO.ID);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

    }
}
