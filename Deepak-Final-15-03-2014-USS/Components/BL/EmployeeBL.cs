using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class EmployeeBL
    {
        #region Variables
        private int screenID;
        //private DataTable dtValidExp;
        int EmployeeId = 0;
        int returnVal = 0;
        int affectedRows = 0;
        DataTable dtEmployee;

        Components.Common.GlobalFunction GlbFunc;
        private static EmployeeBL instance;
        Components.DAL.SQLConnect SqlHelper;
        Components.Common.ObjectWrapper ObjWrp;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Constructor & Instance
        public static EmployeeBL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeBL();
                }
                return instance;
            }
        }
        private EmployeeBL()
        {
        }
        #endregion

        #region SaveEmployee
        public int EmployeeSave(Components.DTO.EmployeeDTO EmpDTO)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Employee_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@EmpCode", DbType.String, EmpDTO.EmpCode);
            objDataBase.AddInParameter(dbCommand, "@EmpName", DbType.String, EmpDTO.EmpName);
            objDataBase.AddInParameter(dbCommand, "@Designation", DbType.String, EmpDTO.Designation);
            objDataBase.AddInParameter(dbCommand, "@Address", DbType.String, EmpDTO.Address);
            objDataBase.AddInParameter(dbCommand, "@City", DbType.String, EmpDTO.City);
            objDataBase.AddInParameter(dbCommand, "@PinCode", DbType.Int32, EmpDTO.PinCode);
            objDataBase.AddInParameter(dbCommand, "@FatherName", DbType.String, EmpDTO.FatherName);
            objDataBase.AddInParameter(dbCommand, "@MotherName", DbType.String, EmpDTO.MotherName);
            objDataBase.AddInParameter(dbCommand, "@Gender", DbType.String, EmpDTO.Gender);
            objDataBase.AddInParameter(dbCommand, "@DOB", DbType.DateTime, EmpDTO.DOB);
            objDataBase.AddInParameter(dbCommand, "@Phone", DbType.String, EmpDTO.Phone);
            objDataBase.AddInParameter(dbCommand, "@Mobile", DbType.String, EmpDTO.Mobile);
            objDataBase.AddInParameter(dbCommand, "@Email", DbType.String, EmpDTO.Email);
            objDataBase.AddInParameter(dbCommand, "@Qualification", DbType.String, EmpDTO.Qualification);
            objDataBase.AddInParameter(dbCommand, "@DOJ", DbType.DateTime, EmpDTO.DOJ);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, EmpDTO.UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, EmpDTO.BranchName);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        public DataTable EmployeeLoad(string _EmpCode, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Employee_S");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@EmpCode", DbType.String, _EmpCode);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
        }

        #region UpdateEmployee
        public int EmployeeUpdate(Components.DTO.EmployeeDTO EmpDTO, int ID, int AddID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Employee_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, ID);
            objDataBase.AddInParameter(dbCommand, "@AddID", DbType.Int32, AddID);
            objDataBase.AddInParameter(dbCommand, "@EmpCode", DbType.String, EmpDTO.EmpCode);
            objDataBase.AddInParameter(dbCommand, "@EmpName", DbType.String, EmpDTO.EmpName);
            objDataBase.AddInParameter(dbCommand, "@Designation", DbType.String, EmpDTO.Designation);
            objDataBase.AddInParameter(dbCommand, "@Address", DbType.String, EmpDTO.Address);
            objDataBase.AddInParameter(dbCommand, "@City", DbType.String, EmpDTO.City);
            objDataBase.AddInParameter(dbCommand, "@PinCode", DbType.Int32, EmpDTO.PinCode);
            objDataBase.AddInParameter(dbCommand, "@FatherName", DbType.String, EmpDTO.FatherName);
            objDataBase.AddInParameter(dbCommand, "@MotherName", DbType.String, EmpDTO.MotherName);
            objDataBase.AddInParameter(dbCommand, "@Gender", DbType.String, EmpDTO.Gender);
            objDataBase.AddInParameter(dbCommand, "@DOB", DbType.DateTime, EmpDTO.DOB);
            objDataBase.AddInParameter(dbCommand, "@Phone", DbType.String, EmpDTO.Phone);
            objDataBase.AddInParameter(dbCommand, "@Mobile", DbType.String, EmpDTO.Mobile);
            objDataBase.AddInParameter(dbCommand, "@Email", DbType.String, EmpDTO.Email);
            objDataBase.AddInParameter(dbCommand, "@Qualification", DbType.String, EmpDTO.Qualification);
            objDataBase.AddInParameter(dbCommand, "@DOJ", DbType.DateTime, EmpDTO.DOJ);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, EmpDTO.UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, EmpDTO.BranchName);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region DeleteEmployee
        public int EmployeeDelete(int ID, int AddID, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Employee_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, ID);
            objDataBase.AddInParameter(dbCommand, "@AddID", DbType.Int32, AddID);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

    }
}
