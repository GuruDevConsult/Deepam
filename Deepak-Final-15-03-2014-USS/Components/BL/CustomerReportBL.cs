using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class CustomerReportBL
    {
        #region Variables
        Components.DAL.SQLConnect SqlHelper;
        private static CustomerReportBL instance;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Constructor & Instance
        public static CustomerReportBL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerReportBL();
                }
                return instance;
            }
        }
        #endregion

        #region CustPayLoad
        public DataTable CustPayLoad(DateTime TDate)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Customer_Report");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@TDate", DbType.DateTime, TDate);
            DataTable dt = objDataBase.ExecuteDataSet(dbCommand).Tables[0];
            return dt;
        }
        #endregion
    }
}
