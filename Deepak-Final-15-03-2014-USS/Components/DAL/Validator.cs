using System;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Components.DAL
{
    public class Validator
    {

        #region Variables
        private int screenID;
        private DataTable dtValidExp;
        private static Validator instance;
        public Database objDataBase = DatabaseFactory.CreateDatabase();

        #endregion

        #region Constructor & Instance
        public static Validator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Validator();
                }
                return instance;
            }
        }

        private Validator()
        {
        }
        #endregion

        //#region GetValidationExp
        //public DataTable GetValidationExp()
        //{
        //    DbCommand dbCommand = objDataBase.GetSqlStringCommand("GetValidationExp");
        //    dbCommand.CommandType = CommandType.StoredProcedure;
        //    objDataBase.AddInParameter(dbCommand, "@ScreenID", DbType.Int32, screenID);
        //    //DataTable dt = new DataTable();
        //    DataTable dt = objDataBase.ExecuteDataSet(dbCommand).Tables[0];
        //    return dt;
        //}
        //#endregion

        #region Screen ID
        public int ScreenID
        {
            set
            {
                screenID = value;
            }
        }
        #endregion
    }
}
