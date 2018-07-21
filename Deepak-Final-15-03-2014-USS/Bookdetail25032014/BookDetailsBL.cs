using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Components.BL
{
    public class BookDetailsBL
    {
        #region Variables
        int affectedRows = 0;
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static BookDetailsBL _Instance;
        DataTable dtBook;
        int BookItem = 0;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region  Instance
        public static BookDetailsBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BookDetailsBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region BookDetails_Consignor View
        public DataTable BookDetails_Consignor_View(string Consignor, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_Consignor_V");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Consignor", DbType.String, Consignor);
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

        #region BookDetails_Consignee View
        public DataTable BookDetails_Consignee_View(string Consignee, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_Consignee_V");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Consignee", DbType.String, Consignee);
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

        #region BookDetails_Agent View
        public DataTable BookDetails_Agent_View(string Agent, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_Agent_V");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Agent", DbType.String, Agent);
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

        #region BookDetails_StoreNo View
        public DataTable BookDetails_StoreNo_View(string StoreID, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_StoreNo_V");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@StoreNo", DbType.String, StoreID);
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

        #region BookDetailsSave
        public int BookDetSave(Components.DTO.BookDetailsDTO BDDTO, DataTable dtBItem, string Branch, string UserID,decimal Balanceamount)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_I");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LRNO", DbType.String, BDDTO.LRNo);
            objDataBase.AddInParameter(dbCommand, "@ConsignorID", DbType.Int32, BDDTO.ConsigneeID);
            objDataBase.AddInParameter(dbCommand, "@ConsigneeID", DbType.Int32, BDDTO.ConsignorID);
            objDataBase.AddInParameter(dbCommand, "@StoreID", DbType.Int32, BDDTO.StoreID);
            objDataBase.AddInParameter(dbCommand, "@BookingDate", DbType.DateTime, BDDTO.BookingDate);
            objDataBase.AddInParameter(dbCommand, "@InsuranceCoName", DbType.String, BDDTO.InsuranceCoName);
            objDataBase.AddInParameter(dbCommand, "@PolicyNo", DbType.String, BDDTO.PolicyNo);
            objDataBase.AddInParameter(dbCommand, "@Date", DbType.DateTime, BDDTO.Date);
            objDataBase.AddInParameter(dbCommand, "@Risk", DbType.String, BDDTO.Risk);
            objDataBase.AddInParameter(dbCommand, "@AgentID", DbType.Int32, BDDTO.AgentID);
            objDataBase.AddInParameter(dbCommand, "@PFrom", DbType.String, BDDTO.From);
            objDataBase.AddInParameter(dbCommand, "@PTo", DbType.String, BDDTO.To);
            objDataBase.AddInParameter(dbCommand, "@FreightCharges", DbType.Decimal, BDDTO.FreightCharges);
            objDataBase.AddInParameter(dbCommand, "@HandlingCharges", DbType.Decimal, BDDTO.HandlingCharges);
            objDataBase.AddInParameter(dbCommand, "@CartageCharges", DbType.Decimal, BDDTO.CartageCharges);
            objDataBase.AddInParameter(dbCommand, "@StatisticalCharges", DbType.Decimal, BDDTO.StatisticalCharges);
            objDataBase.AddInParameter(dbCommand, "@MiscExp", DbType.Decimal, BDDTO.MiscExp);
            objDataBase.AddInParameter(dbCommand, "@Insurance", DbType.Decimal, BDDTO.Insurance);
            objDataBase.AddInParameter(dbCommand, "@AOC", DbType.Decimal, BDDTO.AOC);
            objDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.Decimal, BDDTO.ServiceTax);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@Balanceamount", DbType.Decimal, Balanceamount);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int BookDetailsID = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));
            if (BookDetailsID > 0)
            {
                foreach (DataRow dr in dtBItem.Rows)
                {
                    dbCommand = objDataBase.GetSqlStringCommand("BookDetailsItem_I");
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    objDataBase.AddInParameter(dbCommand, "@BookDetailsID", DbType.Int32, BookDetailsID);
                    objDataBase.AddInParameter(dbCommand, "@NoOfPack", DbType.String, dr["Packages"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@ItemName", DbType.String, dr["ItemName"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Packings", DbType.String, dr["Packings"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Rate", DbType.Decimal, dr["Rate"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@ActWeight", DbType.Decimal, dr["Weight"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@ChargedWeight", DbType.Decimal, dr["ChargedWeight"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Total", DbType.Decimal, dr["Total"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                    objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                    affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                }
                return affectedRows;
            }
            return 0;
        }
        #endregion

        #region DeleteBookDet
        public int DeleteBookDet(Components.DTO.BookDetailsDTO BDDTO, DataTable dtBookD, int BookDetID, string UserID, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, BookDetID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region LoadData
        public DataSet LoadData(Components.DTO.BookDetailsDTO BDDTO, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_V");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LRN", DbType.String, BDDTO.LRNo);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            DataSet dt = objDataBase.ExecuteDataSet(dbCommand);
            return dt;
        }
        #endregion

        #region BookDetailsUpdate
        public int BookDetUpdate(Components.DTO.BookDetailsDTO BDDTO, DataTable dtBItem, int LRNoID, string Branch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_U");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.String, LRNoID);

            objDataBase.AddInParameter(dbCommand, "@BookingDate", DbType.DateTime, BDDTO.BookingDate);
            objDataBase.AddInParameter(dbCommand, "@ConsignorID", DbType.Int32, BDDTO.ConsignorID);
            objDataBase.AddInParameter(dbCommand, "@ConsigneeID", DbType.Int32, BDDTO.ConsigneeID);
            objDataBase.AddInParameter(dbCommand, "@StoreID", DbType.Int32, BDDTO.StoreID);
            objDataBase.AddInParameter(dbCommand, "@InsuranceCoName", DbType.String, BDDTO.InsuranceCoName);
            objDataBase.AddInParameter(dbCommand, "@PolicyNo", DbType.String, BDDTO.PolicyNo);
            objDataBase.AddInParameter(dbCommand, "@Date", DbType.DateTime, BDDTO.Date);
            objDataBase.AddInParameter(dbCommand, "@Risk", DbType.String, BDDTO.Risk);
            objDataBase.AddInParameter(dbCommand, "@AgentID", DbType.Int32, BDDTO.AgentID);
            objDataBase.AddInParameter(dbCommand, "@PFrom", DbType.String, BDDTO.From);
            objDataBase.AddInParameter(dbCommand, "@PTo", DbType.String, BDDTO.To);
            objDataBase.AddInParameter(dbCommand, "@FreightCharges", DbType.Decimal, BDDTO.FreightCharges);
            objDataBase.AddInParameter(dbCommand, "@HandlingCharges", DbType.Decimal, BDDTO.HandlingCharges);
            objDataBase.AddInParameter(dbCommand, "@CartageCharges", DbType.Decimal, BDDTO.CartageCharges);
            objDataBase.AddInParameter(dbCommand, "@StatisticalCharges", DbType.Decimal, BDDTO.StatisticalCharges);
            objDataBase.AddInParameter(dbCommand, "@MiscExp", DbType.Decimal, BDDTO.MiscExp);
            objDataBase.AddInParameter(dbCommand, "@Insurance", DbType.Decimal, BDDTO.Insurance);
            objDataBase.AddInParameter(dbCommand, "@AOC", DbType.Decimal, BDDTO.AOC);
            objDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.Decimal, BDDTO.ServiceTax);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int AddressBookInfoID = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));
            if (AddressBookInfoID > 0)
            {
                foreach (DataRow dr in dtBItem.Rows)
                {
                    dbCommand = objDataBase.GetSqlStringCommand("BookDetailsItem_U");
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    objDataBase.AddInParameter(dbCommand, "@BookDetID", DbType.Int32, LRNoID);

                    objDataBase.AddInParameter(dbCommand, "@NoOfPack", DbType.String, dr["Packages"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@ItemName", DbType.String, dr["ItemName"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Rate", DbType.Decimal, dr["Rate"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@ActWeight", DbType.Decimal, dr["Weight"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@ChargedWeight", DbType.Decimal, dr["ChargedWeight"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@Total", DbType.Decimal, dr["Total"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@BookDetailsItemID", DbType.Int32, dr["BookingDetailsID"].ToString());
                    objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
                    objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                    affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                }
                return affectedRows;
            }
            return 0;
        }
        #endregion

        #region BookingDetails_StoreNoview
        public DataTable BookingDetails_StoreNoview(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookingDetails_StoreNoview");
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

        #region Rate_Load
        public DataTable Rate_Load(string ItemName, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_Rate_S");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ItemName", DbType.String, ItemName);
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

        #region GridRateLoad
        public DataTable GridRateLoad(string consigne,string Packings , string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_Rateselect");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Consignee", DbType.String, consigne);
            objDataBase.AddInParameter(dbCommand, "@Packings", DbType.String, Packings);
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


        #region ItemName Load
        public DataTable ItemName_Load(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_ItemName_S");
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

        #region BookingDetails_RowDelete
        public int BookingDetails_RowDelete(int BDID, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_Row_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, BDID);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region Autogeneration
        public string AutoGenID(string IDType, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("AutoGenenationID");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@IDType", DbType.String, IDType);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
            object result = objDataBase.ExecuteScalar(dbCommand);
            return result.ToString();
        }
        #endregion
    }
}
