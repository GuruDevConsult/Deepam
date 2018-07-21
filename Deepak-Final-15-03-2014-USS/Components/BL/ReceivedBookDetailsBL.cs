using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Components.BL
{
    public class ReceivedBookDetailsBL
    {
        #region Variables
        int affectedRows = 0;
        Components.Common.GlobalFunction GlbFunc;
        Components.DAL.SQLConnect SqlHelper;
        private static ReceivedBookDetailsBL _Instance;
        DataTable dtBook;
        int BookItem = 0;
        #endregion

        #region  Instance
        public static ReceivedBookDetailsBL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ReceivedBookDetailsBL();
                }
                return _Instance;
            }
        }
        #endregion

        #region ReceivedBookDetails_Consignor View
        public DataTable ReceivedBookDetails_Consignor_View(string Consignor)
        {
            SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            int i = 0;
            try
            {
                SqlHelper.SqlProcedure = "ReceivedBookDetails_Consignor_V";
                SqlParameter[] Param = new SqlParameter[1];
                Param[i++] = new SqlParameter("@Consignor", Consignor);
                SqlHelper.SqlParam = Param;
                Param = null;
                dtBook = SqlHelper.ExecReadDT();
                return dtBook;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SqlHelper.CloseConnection();
            }

        }
        #endregion

        #region ReceivedBookDetails_Consignee View
        public DataTable ReceivedBookDetails_Consignee_View(string Consignee)
        {
            SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            int i = 0;
            try
            {
                SqlHelper.SqlProcedure = "ReceivedBookDetails_Consignee_V";
                SqlParameter[] Param = new SqlParameter[1];
                Param[i++] = new SqlParameter("@Consignee", Consignee);
                SqlHelper.SqlParam = Param;
                Param = null;
                dtBook = SqlHelper.ExecReadDT();
                return dtBook;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SqlHelper.CloseConnection();
            }

        }
        #endregion

        #region ReceivedBookDetails_Agent View
        public DataTable ReceivedBookDetails_Agent_View(string Agent)
        {
            SqlHelper.OpenConnection(true);
            int i = 0;
            try
            {
                SqlHelper.SqlProcedure = "ReceivedBookDetails_Agent_V";
                SqlParameter[] Param = new SqlParameter[1];
                Param[i++] = new SqlParameter("@Agent", Agent);
                SqlHelper.SqlParam = Param;
                Param = null;
                dtBook = SqlHelper.ExecReadDT();
                return dtBook;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SqlHelper.CloseConnection();
            }
        }
        #endregion

        #region ReceivedBookDetailsSave
        public int ReceivedBookDetSave(Components.DTO.ReceivedBookDetailsDTO BDDTO, DataTable dtBItem)
        {
            int BookDetailsID = 0;
            GlbFunc = Components.Common.GlobalFunction.Instance;
            SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            try
            {
                SqlHelper.SqlProcedure = "ReceivedBookDetails_I";
                SqlParameter[] Param = new SqlParameter[21];
                int i = 0;
                Param[i++] = new SqlParameter("@LRNO", BDDTO.LRNo);
                Param[i++] = new SqlParameter("@BookingDate", BDDTO.BookingDate);
                Param[i++] = new SqlParameter("@ConsignorID", BDDTO.ConsignorID);
                Param[i++] = new SqlParameter("@ConsigneeID", BDDTO.ConsigneeID);
                Param[i++] = new SqlParameter("@InsuranceCoName", BDDTO.InsuranceCoName);
                Param[i++] = new SqlParameter("@PolicyNo", BDDTO.PolicyNo);
                Param[i++] = new SqlParameter("@Date", BDDTO.Date);
                Param[i++] = new SqlParameter("@Risk", BDDTO.Risk);
                Param[i++] = new SqlParameter("@AgentID", BDDTO.AgentID);
                Param[i++] = new SqlParameter("@PFrom", BDDTO.From);
                Param[i++] = new SqlParameter("@PTo", BDDTO.To);
                Param[i++] = new SqlParameter("@FreightCharges", BDDTO.FreightCharges);
                Param[i++] = new SqlParameter("@HandlingCharges", BDDTO.HandlingCharges);
                Param[i++] = new SqlParameter("@CartageCharges", BDDTO.CartageCharges);
                Param[i++] = new SqlParameter("@StatisticalCharges", BDDTO.StatisticalCharges);
                Param[i++] = new SqlParameter("@MiscExp", BDDTO.MiscExp);
                Param[i++] = new SqlParameter("@Insurance", BDDTO.Insurance);
                Param[i++] = new SqlParameter("@AOC", BDDTO.AOC);
                Param[i++] = new SqlParameter("@ServiceTax", BDDTO.ServiceTax);
                Param[i++] = new SqlParameter("@Paid", BDDTO.Paid);
                Param[i++] = new SqlParameter("@UserID", BDDTO.UserID);
                SqlHelper.SqlParam = Param;
                Param = null;
                BookDetailsID = Convert.ToInt32(SqlHelper.ExecScalar());
                if (BookDetailsID > 0)
                {
                    foreach (DataRow dr in dtBItem.Rows)
                    {
                        SqlHelper.SqlProcedure = "ReceivedBookDetailsItem_I";
                        SqlParameter[] Param1 = new SqlParameter[6];
                        int j = 0;
                        Param1[j++] = new SqlParameter("@BookDetailsID", BookDetailsID);
                        Param1[j++] = new SqlParameter("@NoOfPack", dr["Packages"].ToString());
                        Param1[j++] = new SqlParameter("@Desc", dr["Descr"].ToString());
                        Param1[j++] = new SqlParameter("@ActWeight", dr["Weight"].ToString());
                        Param1[j++] = new SqlParameter("@ChargedWeight", dr["ChargedWeight"].ToString());
                        Param1[j++] = new SqlParameter("@UserID", BDDTO.UserID);
                        SqlHelper.SqlParam = Param1;
                        Param1 = null;
                        affectedRows = Convert.ToInt32(SqlHelper.ExecScalar());
                    }
                    return affectedRows;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
                SqlHelper.CloseConnection();
            }
        }
        #endregion

        #region ReceivedDeleteBookDet
        public int ReceivedDeleteBookDet(Components.DTO.ReceivedBookDetailsDTO BDDTO, DataTable dtBookD, int BookDetID)
        {
            SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            try
            {
                int i = 0;
                SqlHelper.SqlProcedure = "ReceivedBookDetails_D";
                SqlParameter[] Param = new SqlParameter[2];
                Param[i++] = new SqlParameter("@ID", BookDetID);
                Param[i++] = new SqlParameter("UserID", BDDTO.UserID);
                SqlHelper.SqlParam = Param;
                Param = null;
                BookItem = SqlHelper.Exec();
                return BookItem;
            }
            catch
            {
                return 0;
            }
            finally
            {
                SqlHelper.CloseConnection();
            }
        }
        #endregion

        #region ReceivedLoadData
        public DataSet ReceivedLoadData(Components.DTO.ReceivedBookDetailsDTO BDDTO)
        {
            SqlHelper = Components.DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            SqlHelper.SqlProcedure = "ReceivedBookDetails_V";
            try
            {
                SqlParameter[] Param = new SqlParameter[1];
                int i = 0;
                Param[i++] = new SqlParameter("@LRN", BDDTO.LRNo);
                SqlHelper.SqlParam = Param;
                Param = null;
                DataSet dsBook = SqlHelper.ExecReadDS();
                return dsBook;
            }
            catch
            {
                return null;
            }
            finally
            {
                SqlHelper.CloseConnection();
            }
        }
        #endregion

        #region ReceivedBookDetailsUpdate
        public int ReceivedBookDetUpdate(Components.DTO.ReceivedBookDetailsDTO BDDTO, DataTable dtBItem, int LRNoID)
        {
            GlbFunc = Components.Common.GlobalFunction.Instance;
            SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            try
            {
                SqlHelper.SqlProcedure = "ReceivedBookDetails_U";
                SqlParameter[] Param = new SqlParameter[21];
                int i = 0;
                Param[i++] = new SqlParameter("@ID", LRNoID);
                Param[i++] = new SqlParameter("@BookingDate", BDDTO.BookingDate);
                Param[i++] = new SqlParameter("@ConsignorID", BDDTO.ConsignorID);
                Param[i++] = new SqlParameter("@ConsigneeID", BDDTO.ConsigneeID);
                Param[i++] = new SqlParameter("@InsuranceCoName", BDDTO.InsuranceCoName);
                Param[i++] = new SqlParameter("@PolicyNo", BDDTO.PolicyNo);
                Param[i++] = new SqlParameter("@Date", BDDTO.Date);
                Param[i++] = new SqlParameter("@Risk", BDDTO.Risk);
                Param[i++] = new SqlParameter("@AgentID", BDDTO.AgentID);
                Param[i++] = new SqlParameter("@PFrom", BDDTO.From);
                Param[i++] = new SqlParameter("@PTo", BDDTO.To);
                Param[i++] = new SqlParameter("@FreightCharges", BDDTO.FreightCharges);
                Param[i++] = new SqlParameter("@HandlingCharges", BDDTO.HandlingCharges);
                Param[i++] = new SqlParameter("@CartageCharges", BDDTO.CartageCharges);
                Param[i++] = new SqlParameter("@StatisticalCharges", BDDTO.StatisticalCharges);
                Param[i++] = new SqlParameter("@MiscExp", BDDTO.MiscExp);
                Param[i++] = new SqlParameter("@Insurance", BDDTO.Insurance);
                Param[i++] = new SqlParameter("@AOC", BDDTO.AOC);
                Param[i++] = new SqlParameter("@ServiceTax", BDDTO.ServiceTax);
                Param[i++] = new SqlParameter("@Paid", BDDTO.Paid);
                Param[i++] = new SqlParameter("@UserID", BDDTO.UserID);
                SqlHelper.SqlParam = Param;
                Param = null;
                affectedRows = GlbFunc.ConvertStrToInt(SqlHelper.Exec().ToString());

                //affectedRows = Convert.ToInt32(SqlHelper.ExecScalar());
                if (affectedRows > 0)
                {
                    foreach (DataRow dr in dtBItem.Rows)
                    {
                        SqlHelper.SqlProcedure = "ReceivedBookDetailsItem_U";
                        SqlParameter[] Param1 = new SqlParameter[7];
                        int j = 0;
                        Param1[j++] = new SqlParameter("@BookDetID", LRNoID);
                        Param1[j++] = new SqlParameter("@NoOfPack", dr["Packages"].ToString());
                        Param1[j++] = new SqlParameter("@Desc", dr["Descr"].ToString());
                        Param1[j++] = new SqlParameter("@ActWeight", dr["Weight"].ToString());
                        Param1[j++] = new SqlParameter("@ChargedWeight", dr["ChargedWeight"].ToString());
                        Param1[j++] = new SqlParameter("@BookDetailsItemID", dr["BookingDetailsID"].ToString());
                        Param1[j++] = new SqlParameter("@UserID", BDDTO.UserID);
                        SqlHelper.SqlParam = Param1;
                        Param1 = null;
                        BookItem = Convert.ToInt32(SqlHelper.Exec().ToString());

                        //BookItem = Convert.ToInt32(SqlHelper.ExecScalar());
                    }
                    return BookItem;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
                SqlHelper.CloseConnection();
            }
        }
        #endregion

    }
}
