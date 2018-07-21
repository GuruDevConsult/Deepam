using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Components.BL
{
    public class CompanyBL
    {
        #region Variables
        int retVal = 0;
        private static CompanyBL instance;
        Components.DAL.SQLConnect SqlHelper;
        Components.Common.GlobalFunction GlbFunc;
        Components.Common.ObjectWrapper ObjWrp;
        DataTable dtTR = null;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Instance
        public static CompanyBL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CompanyBL();
                }
                return instance;
            }
        }
        #endregion

        #region Company Save
        public int SaveCompany(Components.DTO.CompanyDTO CompanyDTO)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Company_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            ObjWrp.ObjToParam(CompanyDTO);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;

            //ObjWrp = Components.Common.ObjectWrapper.Instance;
            //SqlHelper = DAL.SQLConnect.Instance;
            //SqlHelper.OpenConnection(true);
            //try
            //{
            //    SqlHelper.SqlProcedure = "Company_I";
            //    SqlParameter[] Param = ObjWrp.ObjToParam(CompanyDTO);
            //    SqlHelper.SqlParam = Param;
            //    Param = null;
            //    retVal = Convert.ToInt32(SqlHelper.ExecScalar());
            //    return retVal;
            //}
            //catch
            //{
            //    return 0;
            //}
            //finally
            //{
            //    SqlHelper.CloseConnection();
            //}
        }
        #endregion

        #region CompanyView
        public DataTable CompanyView(Components.DTO.CompanyDTO CDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Company_S");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@CompanyName", DbType.String, CDTO.CompanyName);
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

        #region CompanyView
        public DataTable Load_Company(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Company_SS");
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

        #region Update Company
        public int UpdateCompany(int CompanyID, int AddID, Components.DTO.CompanyDTO CompanyDTO)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Company_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, CompanyID);
            objDataBase.AddInParameter(dbCommand, "@AddID", DbType.Int32, AddID);
            objDataBase.AddInParameter(dbCommand, "@CompanyName", DbType.String, CompanyDTO.CompanyName);
            objDataBase.AddInParameter(dbCommand, "@Address", DbType.String, CompanyDTO.Address);
            objDataBase.AddInParameter(dbCommand, "@City", DbType.String, CompanyDTO.City);
            objDataBase.AddInParameter(dbCommand, "@Pincode", DbType.Int32, CompanyDTO.Pincode);
            objDataBase.AddInParameter(dbCommand, "@PhonePrime", DbType.String, CompanyDTO.PhonePrime);
            objDataBase.AddInParameter(dbCommand, "@PhoneSecondary", DbType.String, CompanyDTO.PhoneSecondary);
            objDataBase.AddInParameter(dbCommand, "@Mob1", DbType.String, CompanyDTO.Mob1);
            objDataBase.AddInParameter(dbCommand, "@Mob2", DbType.String, CompanyDTO.Mob2);
            objDataBase.AddInParameter(dbCommand, "@EmailPrime", DbType.String, CompanyDTO.EmailPrime);
            objDataBase.AddInParameter(dbCommand, "@EmailSecondary", DbType.String, CompanyDTO.EmailSecondary);
            objDataBase.AddInParameter(dbCommand, "@Website", DbType.String, CompanyDTO.Website);
            objDataBase.AddInParameter(dbCommand, "@Fax", DbType.String, CompanyDTO.Fax);
            objDataBase.AddInParameter(dbCommand, "@TINNo", DbType.String, CompanyDTO.TINNo);
            objDataBase.AddInParameter(dbCommand, "@CSTNo", DbType.String, CompanyDTO.CSTNo);
            objDataBase.AddInParameter(dbCommand, "@AreaCode", DbType.String, CompanyDTO.AreaCode);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, CompanyDTO.BranchName);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, CompanyDTO.UserID);

            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region Delete Company
        public int DeleteCompany(int CompanyID, int AddID, Components.DTO.CompanyDTO CDTO, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Company_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.String, CompanyID);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@AddID", DbType.String, AddID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region Company Already Exists
        public DataTable Exist(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Company_Exists");
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
    }

}

