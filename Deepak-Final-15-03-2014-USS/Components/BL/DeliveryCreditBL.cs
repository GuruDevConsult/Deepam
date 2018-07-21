using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class DeliveryCreditBL
    {
        #region Variables
        int affectedRows = 0;
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static DeliveryCreditBL _Instance;
        DataTable dtDelyCr;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region  Instance
        public static DeliveryCreditBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DeliveryCreditBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region MRNO View
        public DataTable MRNO_View(string Cust)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliveryCredit_DebitsCredits_Cr");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Cust", DbType.String, Cust);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
        #endregion

        #region Save
        public int DelCreditSave(DateTime Dt, string CustName, string MRType, decimal Amt, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliveryCredit_DebitsCredits_Cr_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Date", DbType.Int32, Dt);
            objDataBase.AddInParameter(dbCommand, "@Cust", DbType.Int32, CustName);
            objDataBase.AddInParameter(dbCommand, "@MRType", DbType.Int32, MRType);
            objDataBase.AddInParameter(dbCommand, "@Amt", DbType.String, Amt);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion


    }
}
