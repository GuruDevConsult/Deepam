using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class ContactReportBL
    {
        #region var
        Components.DAL.SQLConnect Sqlhelper = Components.DAL.SQLConnect.Instance;
        Components.Common.GlobalFunction GlbFunc = Components.Common.GlobalFunction.Instance;
        private static ContactReportBL _Instance;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region  Instance
        public static ContactReportBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ContactReportBL();
                }
                return _Instance;
            }
        }
        #endregion

        public DataTable Contact(string ddl)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("ContactReport_S");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Type", DbType.String, ddl);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }
    }
}
