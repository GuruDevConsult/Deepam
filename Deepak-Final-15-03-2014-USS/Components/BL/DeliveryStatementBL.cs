using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class DeliveryStatementBL
    {
        #region Vaiables
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static DeliveryStatementBL _Instance;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Instance
        public static DeliveryStatementBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DeliveryStatementBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region DeliveryDate_Check

        public DataTable DeliveryDate_Check(DateTime DelDate, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("DeliveryStatement_DateCheck");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@DelDate", DbType.DateTime, DelDate);
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
