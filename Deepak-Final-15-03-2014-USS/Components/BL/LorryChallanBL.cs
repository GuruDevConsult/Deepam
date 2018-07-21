using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Components.BL
{

    public class LorryChallanBL
    {
        #region Variables
        int affectedRows = 0;
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static LorryChallanBL _Instance;
        int BookItem = 0;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region  Instance
        public static LorryChallanBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LorryChallanBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region LorryChallanSave
        public int LorryChallanSave(Components.DTO.LorryChallanDTO LCDTO, DataTable dtChallan, string Branch, string Branch1,string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryChallan_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ChallanNo", DbType.Int32, LCDTO.ChallanNo);
            objDataBase.AddInParameter(dbCommand, "@StartFrom", DbType.String, LCDTO.StartFrom);
            objDataBase.AddInParameter(dbCommand, "@EndTo", DbType.String, LCDTO.EndTo);
            //objDataBase.AddInParameter(dbCommand, "@ArrivalDate", DbType.DateTime, LCDTO.ArrivalDate);
            objDataBase.AddInParameter(dbCommand, "@TruckNo", DbType.String, LCDTO.TruckNo);
            objDataBase.AddInParameter(dbCommand, "@NameofDriver", DbType.String, LCDTO.NameofDriver);
            objDataBase.AddInParameter(dbCommand, "@TruckownerName", DbType.String, LCDTO.TruckownerName);
            objDataBase.AddInParameter(dbCommand, "@AgentName", DbType.Int32, LCDTO.AgentID);
            objDataBase.AddInParameter(dbCommand, "@ChallanDate", DbType.DateTime, LCDTO.ChallanDate);
            objDataBase.AddInParameter(dbCommand, "@DriverPhoneNo", DbType.String, LCDTO.DriverPhoneNo);
            //objDataBase.AddInParameter(dbCommand, "@FromBranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int LorryChallanID = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));
            if (LorryChallanID > 0)
            {
                foreach (DataRow dr in dtChallan.Rows)
                {
                    dbCommand = objDataBase.GetSqlStringCommand("LorryChallanDesc_I");
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    objDataBase.AddInParameter(dbCommand, "@LorryChallanID", DbType.Int32, LorryChallanID);
                    //DateTime TDate = DateTime.ParseExact(dr["Date"].ToString(), "dd/MM/yyyy", null);
                    ////string date = dr["Date"].ToString();
                    ////dr["Date"] = Convert.ToDateTime(date);
                    ////DateTime date = Convert.ToDateTime(dr["Date"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@LRDate", DbType.DateTime, (TDate));
                    objDataBase.AddInParameter(dbCommand, "@LRNo", DbType.Int32, dr["LRNo"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@NoofPackages", DbType.Int32, dr["NoofPackages"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@Contents", DbType.String, dr["Contents"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@StoreID", DbType.String, dr["StoreID"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@LoadedPackages", DbType.String, dr["LoadedPackages"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@Branch", DbType.String, dr["Branch"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@Weight", DbType.Decimal, dr["Weight"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@ChargedWeight", DbType.Decimal, dr["ChargedWeight"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@ToPay", DbType.Decimal, dr["ToPay"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@Paid", DbType.Decimal, dr["Paid"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@AgentCode", DbType.String, dr["AgentCode"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@Remarks", DbType.String, dr["PrivateMarks"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@CustName", DbType.String, dr["CustName"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@OriCustName", DbType.String, dr["OriCustName"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Mob", DbType.String, dr["Mob1"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@FromBranchName", DbType.String, Branch);
                    objDataBase.AddInParameter(dbCommand, "@ToBranchName", DbType.String, Branch1);
                    objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                    affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                }
               
            }
            if (affectedRows > 0)
            {

                DbCommand dbCommand1 = objDataBase.GetSqlStringCommand("ReceivedLorryChallan_Load");
                dbCommand1.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand1, "@FromBranch", DbType.String, Branch);
                objDataBase.AddInParameter(dbCommand1, "@ToBranch", DbType.String, Branch1);
                objDataBase.AddInParameter(dbCommand1, "@ChallanNo", DbType.Int32, LCDTO.ChallanNo);
                objDataBase.AddInParameter(dbCommand1, "@TruckNo", DbType.String, LCDTO.TruckNo);
                objDataBase.AddInParameter(dbCommand1, "@ChallanDate", DbType.DateTime, LCDTO.ChallanDate);
                objDataBase.AddInParameter(dbCommand1, "@NameofDriver", DbType.String, LCDTO.NameofDriver);
                objDataBase.AddInParameter(dbCommand1, "@StartFrom", DbType.String, LCDTO.StartFrom);
                objDataBase.AddInParameter(dbCommand1, "@DriverPhoneNo", DbType.String, LCDTO.DriverPhoneNo);
                objDataBase.AddInParameter(dbCommand1, "@EndTo", DbType.String, LCDTO.EndTo);
                objDataBase.AddInParameter(dbCommand1, "@TruckownerName", DbType.String, LCDTO.TruckownerName);
                objDataBase.AddInParameter(dbCommand1, "@AgentName", DbType.Int32, LCDTO.AgentID);
                objDataBase.AddInParameter(dbCommand1, "@ArrivalDate", DbType.DateTime, LCDTO.ArrivalDate);
                objDataBase.AddInParameter(dbCommand1, "@UserID", DbType.String, LCDTO.UserID);
                int affectedRows1 = objDataBase.ExecuteNonQuery(dbCommand1);
                return affectedRows1;

            }
            return 0;
        }
        #endregion

      

        #region LorryChallanUpdate
        public int LorryChallanUpdate(Components.DTO.LorryChallanDTO LCDTO, DataTable dtChallan, int LCID, string Branch,string Branch1,string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryChallan_U");
            dbCommand.CommandType = CommandType.StoredProcedure;

            objDataBase.AddInParameter(dbCommand, "@Id", DbType.Int32, LCID);
            objDataBase.AddInParameter(dbCommand, "@StartFrom", DbType.String, LCDTO.StartFrom);
            objDataBase.AddInParameter(dbCommand, "@EndTo", DbType.String, LCDTO.EndTo);
            objDataBase.AddInParameter(dbCommand, "@TruckNo", DbType.String, LCDTO.TruckNo);
            objDataBase.AddInParameter(dbCommand, "@NameofDriver", DbType.String, LCDTO.NameofDriver);
            objDataBase.AddInParameter(dbCommand, "@TruckownerName", DbType.String, LCDTO.TruckownerName);
            objDataBase.AddInParameter(dbCommand, "@AgentName", DbType.Int32, LCDTO.AgentID);
            objDataBase.AddInParameter(dbCommand, "@ChallanDate", DbType.DateTime, LCDTO.ChallanDate);
            objDataBase.AddInParameter(dbCommand, "@ArrivalDate", DbType.DateTime, LCDTO.ArrivalDate);
            objDataBase.AddInParameter(dbCommand, "@DriverPhoneNo", DbType.String, LCDTO.DriverPhoneNo);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            if (affectedRows > 0)
            {
                foreach (DataRow dr in dtChallan.Rows)
                {
                    dbCommand = objDataBase.GetSqlStringCommand("LorryChallanDesc_U");
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    objDataBase.AddInParameter(dbCommand, "@LID", DbType.Int32, LCID);
                    if (dr["LorryChallanID"].ToString() != string.Empty)
                    {
                        objDataBase.AddInParameter(dbCommand, "@LorryChallanID", DbType.Int32, int.Parse(dr["LorryChallanID"].ToString()));
                    }
                    else
                    {
                        objDataBase.AddInParameter(dbCommand, "@LorryChallanID", DbType.String, dr["LorryChallanID"].ToString());
                    }
                   // objDataBase.AddInParameter(dbCommand, "@LRDate", DbType.DateTime, DateTime.ParseExact(dr["Date"].ToString(), "dd/MM/yyyy", null));
                    objDataBase.AddInParameter(dbCommand, "@LRNo", DbType.Int32, dr["LRNo"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@ToBranch", DbType.String, Branch1);
                    //objDataBase.AddInParameter(dbCommand, "@NoofPackages", DbType.Int32, dr["NoofPackages"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@Contents", DbType.String, dr["Contents"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@LoadedPackages", DbType.Int32, dr["LoadedPackages"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@StoreID", DbType.String, dr["StoreID"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@Branch", DbType.String, dr["Branch"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@Weight", DbType.Decimal, dr["Weight"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@ChargedWeight", DbType.Decimal, dr["ChargedWeight"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@ToPay", DbType.Decimal, dr["ToPay"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@Paid", DbType.Decimal, dr["Paid"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@AgentCode", DbType.String, dr["AgentCode"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@Remarks", DbType.String, dr["PrivateMarks"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@CustName", DbType.String, dr["CustName"].ToString());
                    //objDataBase.AddInParameter(dbCommand, "@OriCustName", DbType.String, dr["OriCustName"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Mob", DbType.String, dr["Mob1"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                    objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                    affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                }
            }
            if (affectedRows > 0)
            {
                DbCommand dbCommand1 = objDataBase.GetSqlStringCommand("ReceivedLorryChallan_U");
                dbCommand1.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand1, "@FromBranch", DbType.String, Branch);
                objDataBase.AddInParameter(dbCommand1, "@ToBranch", DbType.String, Branch1);
                objDataBase.AddInParameter(dbCommand1, "@ChallanNo", DbType.Int32, LCDTO.ChallanNo);
                objDataBase.AddInParameter(dbCommand1, "@TruckNo", DbType.String, LCDTO.TruckNo);
                objDataBase.AddInParameter(dbCommand1, "@ChallanDate", DbType.DateTime, LCDTO.ChallanDate);
                objDataBase.AddInParameter(dbCommand1, "@NameofDriver", DbType.String, LCDTO.NameofDriver);
                objDataBase.AddInParameter(dbCommand1, "@StartFrom", DbType.String, LCDTO.StartFrom);
                objDataBase.AddInParameter(dbCommand1, "@DriverPhoneNo", DbType.String, LCDTO.DriverPhoneNo);
                objDataBase.AddInParameter(dbCommand1, "@EndTo", DbType.String, LCDTO.EndTo);
                objDataBase.AddInParameter(dbCommand1, "@TruckownerName", DbType.String, LCDTO.TruckownerName);
                objDataBase.AddInParameter(dbCommand1, "@AgentName", DbType.Int32, LCDTO.AgentID);
                objDataBase.AddInParameter(dbCommand1, "@ArrivalDate", DbType.DateTime, LCDTO.ArrivalDate);
                objDataBase.AddInParameter(dbCommand1, "@UserID", DbType.String, LCDTO.UserID);
                int affectedRows1 = objDataBase.ExecuteNonQuery(dbCommand1);
                return affectedRows1;
            }

            return 0;
        }
        #endregion

        #region Challan_View

        public DataSet Challan_V(Components.DTO.LorryChallanDTO LCDTO, string Branch, string Branch1)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("Challan_View");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ChallanNo", DbType.Int32, LCDTO.ChallanNo);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@ToBranchName", DbType.String, Branch1);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return ds;
        }
        #endregion

        #region OwnerName

        public DataTable OwnerName(string Ownername, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("OwnerName_Details");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@OwnerName", DbType.String, Ownername);
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

        #region View_Grid

        public DataTable View_Grid(string LRNO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryChallan_GridView");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LRNO", DbType.String, LRNO);
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

        #region AgentName

        public DataTable AgentName(Components.DTO.LorryChallanDTO LCDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AgentName_Details");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@AgentName", DbType.String, LCDTO.AgentName);
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

        #region SotreNo

        public DataTable LorryChallan_StoreNo(string StoreNo, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryChallan_StoreNo");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@StoreNo", DbType.String, StoreNo);
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

        #region ChallanNo_View
        public DataTable ChallanNo_View(Components.DTO.LorryChallanDTO LCDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryChallanNo_View");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, LCDTO.FromDate);
            objDataBase.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, LCDTO.ToDate);
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

        #region LorryChallanDelete
        public int LorryChallanDelete(Components.DTO.LorryChallanDTO LCDTO, DataTable DtChallan, int LCID, string Branch,string Branch1)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryChallan_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LCID", DbType.Int32, LCID);
            objDataBase.AddInParameter(dbCommand, "@ChallanNo", DbType.Int32, LCDTO.ChallanNo);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@FromBranchName", DbType.String, Branch1);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region LorryChallan_RowDelete
        public int LorryChallan_RowDelete(int LCID, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryChallan_Row_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, LCID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region LorryChallan_StoreNoview
        public DataTable LorryChallan_StoreNoview(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryChallan_StoreNoview");
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

        #region CustRemarks_View
        public DataTable CustRemarks_View(Components.DTO.LorryChallanDTO LCDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryChallen_CustRemarks_V");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Cust", DbType.String, LCDTO.CustName);
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

        #region OriCust_View
        public DataTable OriCustName_View(Components.DTO.LorryChallanDTO LCDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryChallen_OriCustName_V");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@OriCust", DbType.String, LCDTO.OriCustName);
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

        #region Check_LRNo
        public DataTable LorryChallan_Check_LRNo(int LRNo, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("LorryChallan_Check_LRNo");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LRNo", DbType.Int32, LRNo);
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
