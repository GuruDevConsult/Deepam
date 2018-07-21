using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Components.BL
{
    public class StoreDetailsBL
    {
        #region Variables
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        Components.Common.ObjectWrapper ObjWrp;
        int affectedRows = 0;
        private static StoreDetailsBL _Instance;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Constructor & Instance
        public static StoreDetailsBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StoreDetailsBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region StoreMaster Select
        public DataTable StoreMaster_S(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("StoreMaster_S");
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

        #region StoreDetails Save

        public int StoreDetails_I(DataTable dtLoad, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("StoreMaster_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            foreach (DataRow dr in dtLoad.Rows)
            {
                objDataBase.AddInParameter(dbCommand, "@StoreNo", DbType.String, dr["StoreNo"].ToString());
                objDataBase.AddInParameter(dbCommand, "@StoreAddress", DbType.String, dr["StoreAddress"].ToString());
                objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                return affectedRows;
            }
            return 0;
        }
        #endregion

        #region StoreDetails Update
        public int StoreDetails_U(Components.DTO.StoreDetailsDTO StoreDTO, int _StoreID, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("StoreMaster_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@StoreID", DbType.String, _StoreID);
            objDataBase.AddInParameter(dbCommand, "@Store", DbType.String, StoreDTO.Store);
            objDataBase.AddInParameter(dbCommand, "@StoreAddress", DbType.String, StoreDTO.StoreAddress);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region StoreDetails Delete
        public int StoreDetails_D(int StoreID, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("StoreMaster_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@StoreID", DbType.String, StoreID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

    }
}
