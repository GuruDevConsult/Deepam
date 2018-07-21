using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class AddressBookBL
    {
        #region Variables
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static AddressBookBL _Instance;
        int affectedRows = 0;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Instance
        public static AddressBookBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AddressBookBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region AddressBookSave
        public int AddressBookSave(Components.DTO.AddressBookDTO AddrDTO, DataTable dtFreight, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AddressBook_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Address", DbType.String, string.IsNullOrEmpty(AddrDTO.Address) ? DBNull.Value.ToString() : AddrDTO.Address);
            objDataBase.AddInParameter(dbCommand, "@AgentCode", DbType.String, string.IsNullOrEmpty(AddrDTO.AgentCode) ? DBNull.Value.ToString() : AddrDTO.AgentCode);
            objDataBase.AddInParameter(dbCommand, "@Category", DbType.String, AddrDTO.Category);
            objDataBase.AddInParameter(dbCommand, "@PinCode", DbType.Int32, AddrDTO.PinCode);
            objDataBase.AddInParameter(dbCommand, "@City", DbType.String, AddrDTO.City);
            objDataBase.AddInParameter(dbCommand, "@Name", DbType.String, AddrDTO.Name);
            objDataBase.AddInParameter(dbCommand, "@SurName", DbType.String, string.IsNullOrEmpty(AddrDTO.SurName) ? DBNull.Value.ToString() : AddrDTO.SurName);
            objDataBase.AddInParameter(dbCommand, "@OriCustName", DbType.String, AddrDTO.OriCustName);
            objDataBase.AddInParameter(dbCommand, "@GroupName", DbType.String, AddrDTO.GroupName);
            objDataBase.AddInParameter(dbCommand, "@GroupID", DbType.Int32, AddrDTO.GroupID);
            objDataBase.AddInParameter(dbCommand, "@PhonePrime", DbType.String, string.IsNullOrEmpty(AddrDTO.PriPhone) ? DBNull.Value.ToString() : AddrDTO.PriPhone);
            objDataBase.AddInParameter(dbCommand, "@PhoneSecondary", DbType.String, string.IsNullOrEmpty(AddrDTO.SecPhone) ? DBNull.Value.ToString() : AddrDTO.SecPhone);
            objDataBase.AddInParameter(dbCommand, "@Mob1", DbType.String, string.IsNullOrEmpty(AddrDTO.Mob1) ? DBNull.Value.ToString() : AddrDTO.Mob1);
            objDataBase.AddInParameter(dbCommand, "@Mob2", DbType.String, string.IsNullOrEmpty(AddrDTO.Mob2) ? DBNull.Value.ToString() : AddrDTO.Mob2);
            objDataBase.AddInParameter(dbCommand, "@EmailPrime", DbType.String, string.IsNullOrEmpty(AddrDTO.PriEmail) ? DBNull.Value.ToString() : AddrDTO.PriEmail);
            objDataBase.AddInParameter(dbCommand, "@EmailSecondary", DbType.String, string.IsNullOrEmpty(AddrDTO.SecEmail) ? DBNull.Value.ToString() : AddrDTO.SecEmail);
            objDataBase.AddInParameter(dbCommand, "@Website", DbType.String, string.IsNullOrEmpty(AddrDTO.Website) ? DBNull.Value.ToString() : AddrDTO.Website);
            objDataBase.AddInParameter(dbCommand, "@Fax", DbType.String, string.IsNullOrEmpty(AddrDTO.Fax) ? DBNull.Value.ToString() : AddrDTO.Fax);
            objDataBase.AddInParameter(dbCommand, "@TINNo", DbType.String, string.IsNullOrEmpty(AddrDTO.TinNo) ? DBNull.Value.ToString() : AddrDTO.TinNo);
            objDataBase.AddInParameter(dbCommand, "@CSTNo", DbType.String, string.IsNullOrEmpty(AddrDTO.CstNo) ? DBNull.Value.ToString() : AddrDTO.CstNo);
            objDataBase.AddInParameter(dbCommand, "@Areacode", DbType.String, string.IsNullOrEmpty(AddrDTO.AreaCode) ? DBNull.Value.ToString() : AddrDTO.AreaCode);
            objDataBase.AddInParameter(dbCommand, "@Labour", DbType.Decimal, AddrDTO.Labour);
            objDataBase.AddInParameter(dbCommand, "@Delivery", DbType.Decimal, AddrDTO.Delivery);
            objDataBase.AddInParameter(dbCommand, "@Stationary", DbType.Decimal, AddrDTO.Stationary);
            objDataBase.AddInParameter(dbCommand, "@Demurrage", DbType.Decimal, AddrDTO.Demurrage);
            objDataBase.AddInParameter(dbCommand, "@LocalCartage", DbType.Decimal, AddrDTO.LocalCartage);
            objDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.Decimal, AddrDTO.ServiceTax);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int AddressBookInfoID = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));

            if (AddressBookInfoID > 0)
            {
                if (dtFreight != null && dtFreight.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtFreight.Rows)
                    {
                        dbCommand = objDataBase.GetSqlStringCommand("AddressFreight_I");
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        objDataBase.AddInParameter(dbCommand, "@AddressID", DbType.Int32, AddressBookInfoID);
                        objDataBase.AddInParameter(dbCommand, "@Packings", DbType.String, dr["Packings"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@Weight", DbType.Decimal, dr["Weight"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@Fixed", DbType.Decimal, dr["Fixed"].ToString());
                        objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                        objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                        affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                    }
                    return affectedRows;
                }
                
            }
            return AddressBookInfoID;
        }
        #endregion

        #region AddressBookView
        public DataSet AddressBookView(string nam, string CateName, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AddressBook_S");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Name", DbType.String, nam);
            objDataBase.AddInParameter(dbCommand, "@CateName", DbType.String, CateName);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return ds;
        }
        #endregion

        #region AddressBook_Check_Change_Name
        public DataTable AddressBook_Check_Change_Name(int CheckName, string CateName, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AddressBook_Check_Change_Name");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@CheckName", DbType.Int32, CheckName);
            objDataBase.AddInParameter(dbCommand, "@CateName", DbType.String, CateName);
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

        #region AccountsName_Check
        public DataTable AccountsName_Check(string AccName, string CateName, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AddressBook_AccName_Check");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@AccName", DbType.String, AccName);
            objDataBase.AddInParameter(dbCommand, "@CateName", DbType.String, CateName);
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

        #region Category_View
        public DataTable Category_View(string Types, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AddressBook_V");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Type", DbType.String, Types);
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

        #region AgentCode_Check
        public DataTable AgentCode_Check(string AgentCode, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AddressBook_AgentCode_Check");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@AgentCode", DbType.String, AgentCode);
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

        #region GroupName_Load
        public DataTable GroupName_Load(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AddressBook_GroupLoad");
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

        #region FreightRate_Load
        public DataTable FreightRate_Load(string name,string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("FreightRate_S");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@CustomerName", DbType.String, name);
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

        #region AddressBookUpdate
        public int AddressBookUpdate(Components.DTO.AddressBookDTO AddrDTO, DataTable dtFreight1, int hidc, int hida, int hidAccID, int hidChargesID, string BranchName, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AddressBook_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@AgentCode", DbType.String, AddrDTO.AgentCode);
            objDataBase.AddInParameter(dbCommand, "@Address", DbType.String, AddrDTO.Address);
            objDataBase.AddInParameter(dbCommand, "@Category", DbType.String, AddrDTO.Category);
            objDataBase.AddInParameter(dbCommand, "@PinCode", DbType.Int32, AddrDTO.PinCode);
            objDataBase.AddInParameter(dbCommand, "@City", DbType.String, AddrDTO.City);
            objDataBase.AddInParameter(dbCommand, "@Name", DbType.String, AddrDTO.Name);
            objDataBase.AddInParameter(dbCommand, "@SurName", DbType.String, AddrDTO.SurName);
            objDataBase.AddInParameter(dbCommand, "@OriCustName", DbType.String, AddrDTO.OriCustName);
            objDataBase.AddInParameter(dbCommand, "@GroupName", DbType.String, AddrDTO.GroupName);
            objDataBase.AddInParameter(dbCommand, "@GroupID", DbType.Int32, AddrDTO.GroupID);
            objDataBase.AddInParameter(dbCommand, "@PhonePrime", DbType.String, AddrDTO.PriPhone);
            objDataBase.AddInParameter(dbCommand, "@PhoneSecondary", DbType.String, AddrDTO.SecPhone);
            objDataBase.AddInParameter(dbCommand, "@Mob1", DbType.String, AddrDTO.Mob1);
            objDataBase.AddInParameter(dbCommand, "@Mob2", DbType.String, AddrDTO.Mob2);
            objDataBase.AddInParameter(dbCommand, "@EmailPrime", DbType.String, AddrDTO.PriEmail);
            objDataBase.AddInParameter(dbCommand, "@EmailSecondary", DbType.String, AddrDTO.SecEmail);
            objDataBase.AddInParameter(dbCommand, "@Website", DbType.String, AddrDTO.Website);
            objDataBase.AddInParameter(dbCommand, "@Fax", DbType.String, AddrDTO.Fax);
            objDataBase.AddInParameter(dbCommand, "@TINNo", DbType.String, AddrDTO.TinNo);
            objDataBase.AddInParameter(dbCommand, "@CSTNo", DbType.String, AddrDTO.CstNo);
            objDataBase.AddInParameter(dbCommand, "@Areacode", DbType.String, AddrDTO.AreaCode);
            objDataBase.AddInParameter(dbCommand, "@Labour", DbType.Decimal, AddrDTO.Labour);
            objDataBase.AddInParameter(dbCommand, "@Delivery", DbType.Decimal, AddrDTO.Delivery);
            objDataBase.AddInParameter(dbCommand, "@Stationary", DbType.Decimal, AddrDTO.Stationary);
            objDataBase.AddInParameter(dbCommand, "@Demurrage", DbType.Decimal, AddrDTO.Demurrage);
            objDataBase.AddInParameter(dbCommand, "@LocalCartage", DbType.Decimal, AddrDTO.LocalCartage);
            objDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.Decimal, AddrDTO.ServiceTax);
            objDataBase.AddInParameter(dbCommand, "@AddressID", DbType.Int32, hida);
            objDataBase.AddInParameter(dbCommand, "@ContactID", DbType.Int32, hidc);
            objDataBase.AddInParameter(dbCommand, "@AccID", DbType.Int32, hidAccID);
            objDataBase.AddInParameter(dbCommand, "@ChargesID", DbType.Int32, hidChargesID);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, BranchName);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            if (affectedRows > 0)
            {
                foreach (DataRow dr in dtFreight1.Rows)
                {
                    dbCommand = objDataBase.GetSqlStringCommand("AddressFreight_U");
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    objDataBase.AddInParameter(dbCommand, "@AddressFreightID", DbType.Int32, hidc);
                    if (dr["FreightID"].ToString() != string.Empty)
                    {
                        objDataBase.AddInParameter(dbCommand, "@FreightID", DbType.Int32, int.Parse(dr["FreightID"].ToString()));
                    }
                    else
                    {
                        objDataBase.AddInParameter(dbCommand, "@FreightID", DbType.String, dr["FreightID"].ToString());
                    }
                    objDataBase.AddInParameter(dbCommand, "@Packings", DbType.String, dr["Packings"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Weight", DbType.Decimal, dr["Weight"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Fixed", DbType.Decimal, dr["Fixed"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, BranchName);
                    objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                    affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                }
                return affectedRows;
            }
            return 0;
        }
        #endregion

        #region AddressBookDelete
        public int AddressBookDelete(int id, int hida, int hidAccID, string BranchName, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AddressBook_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, id);
            objDataBase.AddInParameter(dbCommand, "@AddressID", DbType.Int32, hida);
            objDataBase.AddInParameter(dbCommand, "@AccID", DbType.Int32, hidAccID);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, BranchName);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region AddressBook_RowDelete
        public int AddressBook_RowDelete(int AFreightID, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AddressFreight_Row_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, AFreightID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion
    }
}
