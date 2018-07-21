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
        int BookingID = 0;
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

       
        //public static object UnwrapNullableInt(Nullable<Int32?> val)
        //{

        //    if (!val.HasValue)
        //        return null;
        //    return val.Value;
        //}
        //public static object UnwrapNullableDecimal(Nullable<decimal?> val)
        //{

        //    if (!val.HasValue)
        //        return null;
        //    return val.Value;
        //}
        //public static object UnwrapNullableString(Nullable<String> val)
        //{

        //    if (!val.HasValue)
        //        return null;
        //    return val.Value;
        //}
        //public static object UnwrapNullable(Nullable<DateTime?> val)
        //{

        //    if (!val.HasValue)
        //        return null;
        //    return val.Value;
        //}
      
      
      

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

        //#region BookDetailsSave
        //public int BookDetSave(Components.DTO.BookDetailsDTO BDDTO,string Branch, string UserID)
        //{
        //    DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_I");
        //    dbCommand.CommandType = CommandType.StoredProcedure;
        //    objDataBase.AddInParameter(dbCommand, "@BookingDate", DbType.DateTime, BDDTO.BookingDate);
        //    objDataBase.AddInParameter(dbCommand, "@ConsignorID", DbType.Int32, BDDTO.ConsigneeID);
        //    objDataBase.AddInParameter(dbCommand, "@ConsigneeID", DbType.Int32, BDDTO.ConsignorID);
        //    //objDataBase.AddInParameter(dbCommand, "@StoreID", DbType.Int32, BDDTO.StoreID);
        //    objDataBase.AddInParameter(dbCommand, "@LRNO", DbType.String, BDDTO.LRNo);
        //    objDataBase.AddInParameter(dbCommand, "@InsuranceDetails", DbType.String, BDDTO.InsuranceCoName);
        //    //objDataBase.AddInParameter(dbCommand, "@PolicyNo", DbType.String, BDDTO.PolicyNo);
        //    //objDataBase.AddInParameter(dbCommand, "@Date", DbType.DateTime, BDDTO.Date);
        //    //objDataBase.AddInParameter(dbCommand, "@Risk", DbType.String, BDDTO.Risk);
        //    objDataBase.AddInParameter(dbCommand, "@AgentID", DbType.Int32, BDDTO.AgentID);
        //    objDataBase.AddInParameter(dbCommand, "@From", DbType.String, BDDTO.From);
        //    objDataBase.AddInParameter(dbCommand, "@To", DbType.String, BDDTO.To);
        //    objDataBase.AddInParameter(dbCommand, "@NoOfPackages ", DbType.Int32, BDDTO.NoOfPack);
        //    objDataBase.AddInParameter(dbCommand, "@ItemName ", DbType.String, BDDTO.ItemName);
        //    objDataBase.AddInParameter(dbCommand, "@Rate ", DbType.Decimal, BDDTO.Rate);
        //    objDataBase.AddInParameter(dbCommand, "@ActualWeight", DbType.Decimal, BDDTO.ActualWeight);
        //    objDataBase.AddInParameter(dbCommand, "@ChargedWeight", DbType.Decimal, BDDTO.ChargedWeight);
        //    objDataBase.AddInParameter(dbCommand, "@TotalWeight", DbType.Decimal, BDDTO.FreightCharges);
        //    objDataBase.AddInParameter(dbCommand, "@HandlingCharge", DbType.Decimal, BDDTO.HandlingCharges);
        //    objDataBase.AddInParameter(dbCommand, "@WastageCharge", DbType.Decimal, BDDTO.CartageCharges);
        //    objDataBase.AddInParameter(dbCommand, "@StatisticalCharge", DbType.Decimal, BDDTO.StatisticalCharges);
        //    objDataBase.AddInParameter(dbCommand, "@MiscExp", DbType.Decimal, BDDTO.MiscExp);
        //    objDataBase.AddInParameter(dbCommand, "@Insurance", DbType.Decimal, BDDTO.Insurance);
        //    objDataBase.AddInParameter(dbCommand, "@AOC", DbType.Decimal, BDDTO.AOC);
        //    objDataBase.AddInParameter(dbCommand, "@ServiceTaxPer", DbType.Decimal, BDDTO.ServiceTaxPer);
        //    objDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.Decimal, BDDTO.ServiceTax);
        //    objDataBase.AddInParameter(dbCommand, "@Total", DbType.Decimal, BDDTO.Total);
        //    objDataBase.AddInParameter(dbCommand, "@PayType", DbType.String, BDDTO.PayType);
        //    //objDataBase.AddInParameter(dbCommand, "@PaymentMode", DbType.String, BDDTO.PaymentMode);
        //    objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
        //    //objDataBase.AddInParameter(dbCommand, "@Balanceamount", DbType.Decimal, Balanceamount);
        //    objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
        //   if(BDDTO.PayType=="Paid")
        //   {
        //       BookingID = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));
        //   }
        //   else
        //   {
        //       affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
        //   }
        //   if (BDDTO.PayType == "Paid")
        //   {
        //       if (BookingID > 0)
        //       {
        //           DbCommand dbCommand1 = objDataBase.GetSqlStringCommand("BookDetails_Cheque_I");
        //           dbCommand1.CommandType = CommandType.StoredProcedure;
        //           objDataBase.AddInParameter(dbCommand1, "@BookingID", DbType.Int32, BookingID);
        //           objDataBase.AddInParameter(dbCommand, "@PaymentMode", DbType.String, BDDTO.PaymentMode);
        //           objDataBase.AddInParameter(dbCommand1, "@Amount", DbType.Decimal,BDDTO.Amount);
        //           objDataBase.AddInParameter(dbCommand1, "@ChequeNo", DbType.Int32,BDDTO.ChequeNo);
        //           objDataBase.AddInParameter(dbCommand1, "@ChequeDate", DbType.DateTime,BDDTO.ChequeDate);
        //           objDataBase.AddInParameter(dbCommand1, "@BankDetails", DbType.String,BDDTO.BankName);
        //           objDataBase.AddInParameter(dbCommand1, "@Branch", DbType.String, Branch);
        //           objDataBase.AddInParameter(dbCommand1, "@UserID", DbType.String, UserID);
        //           affectedRows = objDataBase.ExecuteNonQuery(dbCommand1);
        //       }
               
        //    }
        //   return affectedRows;
        //    //return 0;
        //}
        //#endregion

        #region BookDetails_Agent_Load
        public DataTable BookDetails_Agent_Load(DateTime Fromdate,DateTime Todate, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_Agent_Load");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@Fromdate", DbType.DateTime, Fromdate);
            objDataBase.AddInParameter(dbCommand, "@Todate", DbType.DateTime, Todate);
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

        #region BookDetails_LrNo_Load
        public DataTable BookDetails_LrNo_Load(string AgentName,string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_View_Load");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@AgentName", DbType.String, AgentName);
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

        #region BookDetails_NameDetails_Load
        public DataTable BookDetails_NameDetails_Load(string CustomerName, string Contents, string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_NameDetails_Load");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@CustomerName", DbType.String,CustomerName);
            objDataBase.AddInParameter(dbCommand, "@Contents", DbType.String,Contents);
            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String,Branch);
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
        public int BookDetSave(Components.DTO.BookDetailsDTO BDDTo, string FromBranch,string UserID)
        {
           
                DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_I");
                dbCommand.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand, "@LRNo", DbType.Int32, BDDTo.LRNo);
                objDataBase.AddInParameter(dbCommand, "@BookingDate", DbType.DateTime, BDDTo.BookingDate);
                objDataBase.AddInParameter(dbCommand, "@ConsignorName", DbType.String, String.IsNullOrEmpty(BDDTo.ConsignorName) ? DBNull.Value.ToString() : BDDTo.ConsignorName);
                objDataBase.AddInParameter(dbCommand, "@ConsigneeName", DbType.String, String.IsNullOrEmpty(BDDTo.ConsigneeName) ? DBNull.Value.ToString() : BDDTo.ConsigneeName);
                objDataBase.AddInParameter(dbCommand, "@From", DbType.String, BDDTo.From);
                objDataBase.AddInParameter(dbCommand, "@To", DbType.String, BDDTo.To);
                objDataBase.AddInParameter(dbCommand, "@NoOfPackages", DbType.Int32, BDDTo.NoOfPack);
                objDataBase.AddInParameter(dbCommand, "@CustomerName", DbType.String,String.IsNullOrEmpty(BDDTo.CustomerName)?DBNull.Value.ToString():BDDTo.CustomerName);
                objDataBase.AddInParameter(dbCommand, "@ActualWeight", DbType.Decimal, BDDTo.ActualWeight);
                objDataBase.AddInParameter(dbCommand, "@ChargedWeight", DbType.Decimal, BDDTo.ChargedWeight);
                objDataBase.AddInParameter(dbCommand, "@Contents", DbType.String, String.IsNullOrEmpty(BDDTo.ItemName)?DBNull.Value.ToString():BDDTo.ItemName);
                objDataBase.AddInParameter(dbCommand, "@Freight", DbType.Decimal, BDDTo.FreightCharges);
                objDataBase.AddInParameter(dbCommand, "@PrivateMarks", DbType.String, String.IsNullOrEmpty(BDDTo.PrivateMark)?DBNull.Value.ToString():BDDTo.PrivateMark);
                objDataBase.AddInParameter(dbCommand, "@Packings", DbType.String, String.IsNullOrEmpty(BDDTo.Packings)?DBNull.Value.ToString():BDDTo.Packings);
                objDataBase.AddInParameter(dbCommand, "@AgentName", DbType.String,String.IsNullOrEmpty(BDDTo.AgentName)?DBNull.Value.ToString():BDDTo.AgentName);
                objDataBase.AddInParameter(dbCommand, "@PayType", DbType.String, BDDTo.PayType);
                objDataBase.AddInParameter(dbCommand, "@LabourCharge", DbType.Decimal,BDDTo.LabourCharges);
                objDataBase.AddInParameter(dbCommand, "@DeliveryCharge", DbType.Decimal,BDDTo.DeliveryCharges);
                objDataBase.AddInParameter(dbCommand, "@StatisticalCharge", DbType.Decimal, BDDTo.StatisticalCharges);
                objDataBase.AddInParameter(dbCommand, "@CartageCharge", DbType.Decimal, BDDTo.CartageCharges);
                objDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.Decimal,BDDTo.ServiceTax);
                objDataBase.AddInParameter(dbCommand, "@PhoneNumber", DbType.String, BDDTo.PhoneNumber);
                //objDataBase.AddInParameter(dbCommand, "@PaidAmount", DbType.Decimal, dr["PaidAmount"].ToString());
                //objDataBase.AddInParameter(dbCommand, "@Total", DbType.Decimal, dr["Total"].ToString());
                objDataBase.AddInParameter(dbCommand, "@FromBranch", DbType.String, FromBranch);
                objDataBase.AddInParameter(dbCommand, "@ToBranch", DbType.String,BDDTo.To);
                objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
                affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                //if (dr["PaymentMode"].ToString() == "Cheque" || dr["PaymentMode"].ToString() == "Cash")
                //{
                //    BookingID = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));
                //}
                //else
                //{
                //    affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                //}
                //if (dr["PaymentMode"].ToString() == "Cheque" || dr["PaymentMode"].ToString() == "Cash")
                //{
                //    if (BookingID > 0)
                //    {
                //        DbCommand dbCommand1 = objDataBase.GetSqlStringCommand("BookDetails_Cheque_I");
                //        dbCommand1.CommandType = CommandType.StoredProcedure;
                //        objDataBase.AddInParameter(dbCommand1, "@BookingID", DbType.Int32, BookingID);
                //        objDataBase.AddInParameter(dbCommand1, "@PaymentMode", DbType.String, dr["PaymentMode"].ToString());
                //        if (dr["Amount"].ToString() != string.Empty)
                //        {
                //            objDataBase.AddInParameter(dbCommand1, "@Amount", DbType.Decimal, decimal.Parse(dr["Amount"].ToString()));
                //        }
                //        else
                //        {
                //            objDataBase.AddInParameter(dbCommand1, "@Amount", DbType.Decimal,DBNull.Value);
                //        }
                //        if (dr["ChequeNo"].ToString() != string.Empty)
                //        {
                //            objDataBase.AddInParameter(dbCommand1, "@ChequeNo", DbType.Int32, int.Parse(dr["ChequeNo"].ToString()));
                //        }
                //        else
                //        {
                //            objDataBase.AddInParameter(dbCommand1, "@ChequeNo", DbType.Int32,DBNull.Value);
                //        }
                //        if (dr["ChequeDate"].ToString() != string.Empty)
                //        {
                //            objDataBase.AddInParameter(dbCommand1, "@ChequeDate", DbType.DateTime, dr["ChequeDate"].ToString());
                //        }
                //        else 
                //        {
                //            objDataBase.AddInParameter(dbCommand1, "@ChequeDate", DbType.DateTime,DBNull.Value);
                //        }
                       
                //        objDataBase.AddInParameter(dbCommand1, "@BankDetails", DbType.String, string.IsNullOrEmpty(dr["BankName"].ToString()) ? Convert.DBNull : dr["BankName"].ToString());
                //        objDataBase.AddInParameter(dbCommand1, "@Branch", DbType.String, Branch);
                //        objDataBase.AddInParameter(dbCommand1, "@UserID", DbType.String, UserID);
                //        affectedRows = objDataBase.ExecuteNonQuery(dbCommand1);
                //    }
                //}

           
            return affectedRows;
        }
        #endregion
  
        #region DeleteBookDet
        public int DeleteBookDet(Components.DTO.BookDetailsDTO BDDTO,int ID,string FromBranch, string UserID)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_D");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32, ID);
            objDataBase.AddInParameter(dbCommand, "@LRno", DbType.Int32, BDDTO.LRNo);
            objDataBase.AddInParameter(dbCommand, "@FromBranchName", DbType.String, FromBranch);
            //objDataBase.AddInParameter(dbCommand, "@ToBranchName", DbType.String, ToBranch);
            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
            int affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
            return affectedRows;
        }
        #endregion

        #region LoadData
        public DataTable LoadData(Components.DTO.BookDetailsDTO BDDTO, string Branch,string ToBranch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_View");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@LRN", DbType.Int32, BDDTO.LRNo);
            objDataBase.AddInParameter(dbCommand, "@FromBranchName", DbType.String, Branch);
            objDataBase.AddInParameter(dbCommand, "@ToBranchName", DbType.String, ToBranch);
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }

            return null;
        }
        #endregion

        //#region BookDetailsUpdate
        //public int BookDetUpdate(Components.DTO.BookDetailsDTO BDDTO, DataTable dtBItem, int LRNoID, string Branch, string UserID)
        //{
        //    DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_U");
        //    dbCommand.CommandType = CommandType.StoredProcedure;
        //    objDataBase.AddInParameter(dbCommand, "@ID", DbType.String, LRNoID);

        //    objDataBase.AddInParameter(dbCommand, "@BookingDate", DbType.DateTime, BDDTO.BookingDate);
        //    objDataBase.AddInParameter(dbCommand, "@ConsignorID", DbType.Int32, BDDTO.ConsignorID);
        //    objDataBase.AddInParameter(dbCommand, "@ConsigneeID", DbType.Int32, BDDTO.ConsigneeID);
        //    objDataBase.AddInParameter(dbCommand, "@StoreID", DbType.Int32, BDDTO.StoreID);
        //    objDataBase.AddInParameter(dbCommand, "@InsuranceCoName", DbType.String, BDDTO.InsuranceCoName);
        //    objDataBase.AddInParameter(dbCommand, "@PolicyNo", DbType.String, BDDTO.PolicyNo);
        //    objDataBase.AddInParameter(dbCommand, "@Date", DbType.DateTime, BDDTO.Date);
        //    objDataBase.AddInParameter(dbCommand, "@Risk", DbType.String, BDDTO.Risk);
        //    objDataBase.AddInParameter(dbCommand, "@AgentID", DbType.Int32, BDDTO.AgentID);
        //    objDataBase.AddInParameter(dbCommand, "@PFrom", DbType.String, BDDTO.From);
        //    objDataBase.AddInParameter(dbCommand, "@PTo", DbType.String, BDDTO.To);
        //    objDataBase.AddInParameter(dbCommand, "@FreightCharges", DbType.Decimal, BDDTO.FreightCharges);
        //    objDataBase.AddInParameter(dbCommand, "@HandlingCharges", DbType.Decimal, BDDTO.HandlingCharges);
        //    objDataBase.AddInParameter(dbCommand, "@CartageCharges", DbType.Decimal, BDDTO.CartageCharges);
        //    objDataBase.AddInParameter(dbCommand, "@StatisticalCharges", DbType.Decimal, BDDTO.StatisticalCharges);
        //    objDataBase.AddInParameter(dbCommand, "@MiscExp", DbType.Decimal, BDDTO.MiscExp);
        //    objDataBase.AddInParameter(dbCommand, "@Insurance", DbType.Decimal, BDDTO.Insurance);
        //    objDataBase.AddInParameter(dbCommand, "@AOC", DbType.Decimal, BDDTO.AOC);
        //    objDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.Decimal, BDDTO.ServiceTax);
        //    objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
        //    objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
        //    int AddressBookInfoID = Convert.ToInt32(objDataBase.ExecuteScalar(dbCommand));
        //    if (AddressBookInfoID > 0)
        //    {
        //        foreach (DataRow dr in dtBItem.Rows)
        //        {
        //            dbCommand = objDataBase.GetSqlStringCommand("BookDetailsItem_U");
        //            dbCommand.CommandType = CommandType.StoredProcedure;
        //            objDataBase.AddInParameter(dbCommand, "@BookDetID", DbType.Int32, LRNoID);

        //            objDataBase.AddInParameter(dbCommand, "@NoOfPack", DbType.String, dr["Packages"].ToString());
        //            objDataBase.AddInParameter(dbCommand, "@ItemName", DbType.String, dr["ItemName"].ToString());
        //            objDataBase.AddInParameter(dbCommand, "@Rate", DbType.Decimal, dr["Rate"].ToString());
        //            objDataBase.AddInParameter(dbCommand, "@ActWeight", DbType.Decimal, dr["Weight"].ToString());
        //            objDataBase.AddInParameter(dbCommand, "@ChargedWeight", DbType.Decimal, dr["ChargedWeight"].ToString());
        //            objDataBase.AddInParameter(dbCommand, "@Total", DbType.Decimal, dr["Total"].ToString());
        //            objDataBase.AddInParameter(dbCommand, "@BookDetailsItemID", DbType.Int32, dr["BookingDetailsID"].ToString());
        //            objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Branch);
        //            objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
        //            affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
        //        }
        //        return affectedRows;
        //    }
        //    return 0;
        //}
        //#endregion

         #region BookDetailsUpdate
        public int BookDetUpdate(Components.DTO.BookDetailsDTO BDDTo, int ID, string FromBranch, string ToBranch, string UserID)
        {
            {
                DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_U");
                dbCommand.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand, "@ID", DbType.Int32,ID);
                objDataBase.AddInParameter(dbCommand, "@LRNO", DbType.Int32, BDDTo.LRNo);
                objDataBase.AddInParameter(dbCommand, "@BookingDate", DbType.DateTime, BDDTo.BookingDate);
                objDataBase.AddInParameter(dbCommand, "@From", DbType.String, BDDTo.From);
                objDataBase.AddInParameter(dbCommand, "@To", DbType.String, BDDTo.To);
                objDataBase.AddInParameter(dbCommand, "@ConsignorID", DbType.String, String.IsNullOrEmpty(BDDTo.ConsignorName)? DBNull.Value.ToString():BDDTo.ConsignorName);
                objDataBase.AddInParameter(dbCommand, "@ConsigneeID", DbType.String, String.IsNullOrEmpty(BDDTo.ConsigneeName)? DBNull.Value.ToString():BDDTo.ConsigneeName);
                //objDataBase.AddInParameter(dbCommand, "@StoreID", DbType.Int32, BDDTO.StoreID);
                objDataBase.AddInParameter(dbCommand, "@NoOfPackages ", DbType.Int32, BDDTo.NoOfPack);
                objDataBase.AddInParameter(dbCommand, "@CustomerName", DbType.String, String.IsNullOrEmpty(BDDTo.CustomerName) ? DBNull.Value.ToString() : BDDTo.CustomerName);
                objDataBase.AddInParameter(dbCommand, "@ActualWeight", DbType.Decimal, BDDTo.ActualWeight);
                objDataBase.AddInParameter(dbCommand, "@ChargedWeight", DbType.Decimal, BDDTo.ChargedWeight);
                objDataBase.AddInParameter(dbCommand, "@ItemName", DbType.String,String.IsNullOrEmpty(BDDTo.ItemName) ? DBNull.Value.ToString() : BDDTo.ItemName);                  
                objDataBase.AddInParameter(dbCommand, "@TotalWeight", DbType.Decimal, BDDTo.FreightCharges);
                objDataBase.AddInParameter(dbCommand, "@PrivateMark", DbType.String, String.IsNullOrEmpty(BDDTo.PrivateMark)? DBNull.Value.ToString():BDDTo.PrivateMark);
                objDataBase.AddInParameter(dbCommand, "@Packings", DbType.String, String.IsNullOrEmpty(BDDTo.Packings)? DBNull.Value.ToString():BDDTo.Packings);
                objDataBase.AddInParameter(dbCommand, "@PayType", DbType.String, BDDTo.PayType);
                objDataBase.AddInParameter(dbCommand, "@AgentID", DbType.Int32, BDDTo.AgentID);
                objDataBase.AddInParameter(dbCommand, "@LabourCharge", DbType.Decimal, BDDTo.LabourCharges);
                objDataBase.AddInParameter(dbCommand, "@DeliveryCharge", DbType.Decimal, BDDTo.DeliveryCharges);
                objDataBase.AddInParameter(dbCommand, "@StatisticalCharge", DbType.Decimal, BDDTo.StatisticalCharges);
                objDataBase.AddInParameter(dbCommand, "@CartageCharge", DbType.Decimal, BDDTo.CartageCharges);
                objDataBase.AddInParameter(dbCommand, "@ServiceTax", DbType.Decimal, BDDTo.ServiceTax);
                objDataBase.AddInParameter(dbCommand, "@PhoneNumber", DbType.String, BDDTo.PhoneNumber);
                //objDataBase.AddInParameter(dbCommand, "@PaidAmount", DbType.Decimal, dr["PaidAmount"].ToString());
                //objDataBase.AddInParameter(dbCommand, "@Total", DbType.Decimal, dr["Total"].ToString());
                objDataBase.AddInParameter(dbCommand, "@FromBranchName", DbType.String, FromBranch);
                objDataBase.AddInParameter(dbCommand, "@ToBranchName", DbType.String, BDDTo.To);
                objDataBase.AddInParameter(dbCommand, "@UserID", DbType.String, UserID);
              
                    affectedRows = objDataBase.ExecuteNonQuery(dbCommand);
                return affectedRows;
            }
                //    if (BDDTO.PaymentMode == "Cheque" || BDDTO.PaymentMode == "Cash")
                //{
                //    if (affectedRows > 0)
                //    {
                //        DbCommand dbCommand1 = objDataBase.GetSqlStringCommand("BookDetails_Cheque_U");
                //        dbCommand1.CommandType = CommandType.StoredProcedure;
                //        objDataBase.AddInParameter(dbCommand1, "@BookingID", DbType.Int32, BookID);
                //        objDataBase.AddInParameter(dbCommand1, "@PaymentMode", DbType.String, BDDTO.PaymentMode);
                //        if (BDDTO.Amount !=0)
                //        {
                //            objDataBase.AddInParameter(dbCommand1, "@Amount", DbType.Decimal, BDDTO.Amount);
                //        }
                //        else
                //        {
                //            objDataBase.AddInParameter(dbCommand1, "@Amount", DbType.Decimal, DBNull.Value);
                //        }
                       
                //      objDataBase.AddInParameter(dbCommand1, "@ChequeNo", DbType.Int32, BDDTO.ChequeNo);
                      
                //        if (BDDTO.ChequeDate != null)
                //        {
                //            objDataBase.AddInParameter(dbCommand1, "@ChequeDate", DbType.DateTime,BDDTO.ChequeDate);
                //        }
                //        else
                //        {
                //            objDataBase.AddInParameter(dbCommand1, "@ChequeDate", DbType.DateTime, DBNull.Value);
                //        }

                //        objDataBase.AddInParameter(dbCommand1, "@BankDetails", DbType.String, string.IsNullOrEmpty(BDDTO.BankName) ? Convert.DBNull : BDDTO.BankName);
                //        objDataBase.AddInParameter(dbCommand1, "@Branch", DbType.String, Branch);
                //        objDataBase.AddInParameter(dbCommand1, "@UserID", DbType.String, UserID);
                //        affectedRows = objDataBase.ExecuteNonQuery(dbCommand1);
                //        return affectedRows;
                //    }

               
                
                //return 0;
            

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

        #region Tax_Load
        public DataTable Tax_Load(string Branch)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("BookDetails_TaxName_S");
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
