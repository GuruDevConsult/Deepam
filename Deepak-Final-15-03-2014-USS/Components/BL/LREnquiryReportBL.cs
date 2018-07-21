using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class LREnquiryReportBL
    {
        #region Vaiables
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static LREnquiryReportBL _Instance;
        public Database objDataBase = DatabaseFactory.CreateDatabase();

        #endregion

        #region Instance
        public static LREnquiryReportBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LREnquiryReportBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region ArrivalDate_Check

        public DataTable ArrivalDate_Check(int LRNO)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LREnquiry_ArrivalDate");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LRNO", DbType.Int32, LRNO);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
        #endregion

        #region LRNOCheck
        public DataTable LRNO_Check(int LRNO)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LREnquiry_LRNO");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LRNO", DbType.Int32, LRNO);
            //objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
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
