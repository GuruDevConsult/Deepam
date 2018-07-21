using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// Summary description for Search
/// </summary>
namespace Components.Common
{
    public class Search
    {
        #region Variables
        private static int screenID;
        private static string _SQLProcedure;
        private static SqlParameter[] _sqlParam = null;
        private static string searchText;
        private static DataTable dtBrowseSource = null;
        private static DataTable dtBrowseBuffer = null;
        private static DataTable dtSearchResult = null;
        private static DataRow dtSelectedRow = null;
        private static DataView dvSearch = null;
        private static Search _Instance;
        private static DataSet dSBrowseSource = null;
        private static DataSet dSBrowseBuffer = null;
        #endregion

        #region Instantiation
        public static Search Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Search();
                }
                return _Instance;
            }
        }
        #endregion

        #region Property
        public static DataTable BrowseSource
        {
            get { return dtBrowseSource; }
            set { dtBrowseSource = value; }
        }
        public static DataTable BrowseSourceBuf
        {
            get { return dtBrowseBuffer; }
            set { dtBrowseBuffer = value; }
        }

        public static DataTable SearchResult
        {
            get { return dtSearchResult; }
            set { dtSearchResult = value; }
        }
        public static DataSet dSBrowse
        {
            get { return dSBrowseSource; }
            set { dSBrowseSource = value; }
        }
        public static DataSet dSBrowseBuf
        {
            get { return dSBrowseBuffer; }
            set { dSBrowseBuffer = value; }
        }
        public static DataRow SelectedRow
        {
            get { return dtSelectedRow; }
            set { dtSelectedRow = value; }
        }

        public static string SearchText
        {
            get { return searchText; }
            set { searchText = value; }
        }
        #endregion

        #region FilterContent
        public static void FilterContent()
        {
            string strFilter = string.Empty;
            if (dtBrowseBuffer != null && dtBrowseBuffer.Rows.Count > 0)
            {
                dvSearch = dtBrowseBuffer.DefaultView;
                dvSearch.RowStateFilter = DataViewRowState.CurrentRows;
                foreach (DataColumn dcSearch in dtBrowseBuffer.Columns)
                {
                    strFilter = strFilter + "convert(" + dcSearch.ColumnName + ", 'System.String') like '%" + searchText + @"%' or ";
                }
                strFilter = strFilter.Substring(0, strFilter.Length - 4);
                dvSearch.RowFilter = strFilter;
                dtSearchResult = dvSearch.ToTable();
            }
        }
        #endregion

        #region Filter Data Table with 1 condition 
        public DataTable FilterDT1(DataTable dtSource, string fieldName, string fieldValue)
        {
            DataView dvSource = dtSource.DefaultView;
            string strFilter = string.Empty;
            //strFilter = fieldName + "=" + fieldValue;
            strFilter = fieldName + " = '" + fieldValue + " ' ";
            dvSource.RowFilter = strFilter;
            dtSource = dvSource.ToTable();
            return dtSource;
        }
        #endregion

        //#region Filter Data Table with 2 conditions
        //public DataTable FilterDT2(DataTable dtSource, string fieldName1, string fieldValue1, string fieldName2, string fieldValue2, string condition)
        //{
        //    DataView dvSource = dtSource.DefaultView;
        //    string strFilter = string.Empty;
        //    strFilter = fieldName1 + "like '%" + fieldValue1 + "%'" + condition + fieldName2 + "like '%" + fieldValue2 + "%'";
        //    dvSource.RowFilter = strFilter;
        //    dtSource = dvSource.ToTable();
        //    return dtSource;
        //}
        //#endregion
        #region Filter Data Table with 2 conditions
        public DataTable FilterDT2(DataTable dtSource, string fieldName1, string fieldValue1, string fieldName2, string fieldValue2, string condition)
        {
            DataView dvSource = dtSource.DefaultView;
            string strFilter = string.Empty;
           // strFilter = fieldName1 + "=" +fieldValue1 + condition + fieldName2 + "=" +fieldValue2;
            strFilter = fieldName1 + "='" + fieldValue1 + "'" + condition + fieldName2 + "='" + fieldValue2 + "'";
            dvSource.RowFilter = strFilter;
            dtSource = dvSource.ToTable();
            return dtSource;
        }
       

        #endregion

        #region Screen ID
        public static int ScreenID
        {
            set
            {
                screenID = value;
            }
            get
            {
                return screenID;
            }
        }
        #endregion

        #region Sql Procedure
        public static string SQLProcedure
        {
            set
            {
                _SQLProcedure = value;
            }
        }
        #endregion

        #region SQLParam
        /// <summary>
        /// Build specified storedprocedure's paramete(s) as Sqlparameter[] array and assign.
        /// </summary>
        public static SqlParameter[] SqlParam
        {
            get
            {
                return _sqlParam;
            }
            set
            {
                _sqlParam = value;
            }
        }
        #endregion

        #region Bind Browse Data
        public static void BindBrowseData()
        {
            Components.DAL.SQLConnect SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            SqlHelper.SqlProcedure = _SQLProcedure;
            SqlHelper.SqlParam = _sqlParam;
            dtBrowseSource = SqlHelper.ExecReadDT();
            SqlHelper.CloseConnection();
           // _SQLProcedure = string.Empty;
            _sqlParam = null;
        }
        #endregion


        #region Bind Browse Data
        public static void BindBrowse()
        {
            Components.DAL.SQLConnect SqlHelper = DAL.SQLConnect.Instance;
            SqlHelper.OpenConnection(true);
            SqlHelper.SqlProcedure = _SQLProcedure;
            SqlHelper.SqlParam = _sqlParam;
         dSBrowseSource = SqlHelper.ExecReadDS();
            SqlHelper.CloseConnection();
            // _SQLProcedure = string.Empty;
            _sqlParam = null;
        }
         #endregion
    }

}

