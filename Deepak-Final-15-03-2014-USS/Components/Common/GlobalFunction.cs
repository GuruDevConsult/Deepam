using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
//using System.Web.Security;

namespace Components.Common
{
    public sealed class GlobalFunction
    {
        #region Variables
        private static GlobalFunction _instance;
        //private string _sproc = string.Empty;
        private static SqlParameter[] _sqlParam = null;
        private string _field1 = string.Empty;
        private string _field2 = string.Empty;
        private string _condition1 = string.Empty;
        private string _condition2 = string.Empty;
        private string _tableName = string.Empty;
        Components.DAL.SQLConnect SqlHelper;
        DataTable dtData;
        public Database objDataBase = DatabaseFactory.CreateDatabase();
        #endregion

        #region Instance
        public static GlobalFunction Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GlobalFunction();
                }
                return _instance;
            }
        }
        public GlobalFunction()
        {
        }



        #endregion

        #region Convert String to Numeric
        public int ConvertStrToInt(string strSource)
        {
            int intResult = 0;
            Regex rxNums = new Regex(@"^\d+$"); // Any positive decimal
            if (rxNums.IsMatch(strSource))
            {
                intResult = Convert.ToInt32(strSource);
            }
            return intResult;
        }

        public long ConvertStrToLong(string strSource)
        {
            long lngResult = 0;
            Regex rxNums = new Regex(@"^\d+$"); // Any positive decimal
            if (rxNums.IsMatch(strSource))
            {
                lngResult = Convert.ToInt64(strSource);
            }
            return lngResult;
        }
        public Decimal ConvertStrToDecimal(string strSource)
        {
            decimal decResult = 0.00m;
            //Regex rxNums = new Regex(@"^(([0-9]*.[0-9]*)?)$"); // Any positive decimal
            Regex rxNums = new Regex(@"^[^.](([0-9]*.[0-9]+)?)$"); // Any positive decimal
            if (rxNums.IsMatch(strSource))
            {
                decResult = Convert.ToDecimal(strSource);
            }
            return decResult;
        }
        #endregion

        #region Convert String to DateTime
        public DateTime ConvertStrToDateTime(string strDate)
        {
            DateTime TempDate = DateTime.ParseExact("01/01/1900 00:00:00", "dd/MM/yyyy HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            if (!String.IsNullOrEmpty(strDate))
            {
                string[] tem = strDate.Split('/');
                int day = int.Parse(tem[0]);
                int month = int.Parse(tem[1]);
                int year = int.Parse(tem[2]);
                TempDate = new DateTime(year, month, day);
            }
            return TempDate;
        }
        #endregion

        #region Indentify and Convert Field Data Type
        public object ConverFieldType(string fieldType, object fieldValue)
        {
            object retFieldVal = fieldValue;
            if (fieldType == "Decimal")
            {
                retFieldVal = ConvertStrToDecimal(Convert.ToString(fieldValue));
                return retFieldVal;
            }
            if (fieldType == "DateTime")
            {
                retFieldVal = ConvertStrToDateTime(Convert.ToString(fieldValue));
                return retFieldVal;
            }
            if (fieldType == "Int")
            {
                retFieldVal = ConvertStrToInt(Convert.ToString(fieldValue));
                return retFieldVal;
            }
            if (fieldType == "Long")
            {
                retFieldVal = ConvertStrToLong(Convert.ToString(fieldValue));
                return retFieldVal;
            }
            return retFieldVal;
        }
        #endregion

        #region Convert Default To Empty Date
        public string DefaultToEmptyDate(string strDate)
        {
            string retDate = string.Empty;
            if (!String.IsNullOrEmpty(strDate) && !strDate.Contains("1900"))
            {
                retDate = strDate;
            }
            return retDate;
        }
        #endregion

        #region Convert ListBox Items to CSV
        public string ConvertListBoxToCSV(ListBox lstItem)
        {
            string strItemCSV = string.Empty;
            int cntItems = lstItem.Items.Count;
            for (int i = 0; i < cntItems; i++)
            {
                strItemCSV = strItemCSV + lstItem.Items[i].Text + ",";
            }
            if (strItemCSV.Length > 0)
            {
                strItemCSV = strItemCSV.Substring(0, strItemCSV.Length - 1);
            }
            return strItemCSV;
        }
        #endregion

        #region Convert CSV to Array
        public string[] CSVToArray(string strCSV)
        {
            string[] strArray;
            strArray = strCSV.Split(new char[] { ',' });
            return strArray;
        }
        #endregion

        #region IsNullorEmpty DataTable
        public bool IsNullorEmptyDT(DataTable dtSource)
        {
            if (dtSource != null && dtSource.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Bind DataTable to Listbox
        public void BindDTtoListBox(ListBox lstBox, DataTable dtSource)
        {
            if (!IsNullorEmptyDT(dtSource))
            {
                foreach (DataRow drItem in dtSource.Rows)
                {
                    ListItem lst = new ListItem();
                    lst.Text = drItem[1].ToString();
                    lstBox.Items.Add(lst);
                }
            }
        }
        #endregion

        #region Convert Address fields to CSV
        public string AddressDRToCSV(DataRow drAddr, string AddrCat)
        {
            //    string strAddressCSV = string.Empty;
            //   // Components.DTO.AddressDTO AddrDTO = new Components.DTO.AddressDTO();
            //    Components.Common.GlobalFunction GlbFunc = Components.Common.GlobalFunction.Instance;

            //    if (drAddr["DoorNumber"].ToString().Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + drAddr["DoorNumber"].ToString() + ", ";
            //        AddrDTO.DoorNumber = drAddr["DoorNumber"].ToString();
            //    }
            //    if (drAddr["Street"].ToString().Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + drAddr["Street"].ToString() + ", ";
            //        AddrDTO.Street = drAddr["Street"].ToString();
            //    }
            //    if (drAddr["Area"].ToString().Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + drAddr["Area"].ToString() + ", ";
            //        AddrDTO.Area = drAddr["Area"].ToString();
            //    }
            //    if (drAddr["City"].ToString().Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + drAddr["City"].ToString() + ", ";
            //        AddrDTO.City = drAddr["City"].ToString();
            //    }
            //    if (drAddr["District"].ToString().Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + drAddr["District"].ToString() + ", ";
            //        AddrDTO.District = drAddr["District"].ToString();
            //    }
            //    if (drAddr["State"].ToString().Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + drAddr["State"].ToString() + ", ";
            //        AddrDTO.State = drAddr["State"].ToString();
            //    }
            //    if (drAddr["Country"].ToString().Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + drAddr["Country"].ToString() + ", ";
            //        AddrDTO.Country = drAddr["Country"].ToString();
            //    }
            //    if (drAddr["PIN"].ToString().Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + drAddr["PIN"].ToString();
            //        AddrDTO.PIN = GlbFunc.ConvertStrToInt(drAddr["PIN"].ToString());
            //    }
            //    if (AddrCat == "Permanent")
            //    {
            //        System.Web.HttpContext.Current.Session["PermAddrDTO"] = AddrDTO;
            //    }
            //    if (AddrCat == "Communication")
            //    {
            //        System.Web.HttpContext.Current.Session["CommAddrDTO"] = AddrDTO;
            //    }
            //    if (strAddressCSV.Trim().EndsWith(","))
            //    {
            //        strAddressCSV = strAddressCSV.Substring(0, strAddressCSV.Length - 2);
            //    }
            //    return strAddressCSV;
            //}

            //public string AddressDTOToCSV(Components.DTO.AddressDTO AddrDTO)
            //{
            //    string strAddressCSV = string.Empty;

            //    if (AddrDTO.DoorNumber.Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + AddrDTO.DoorNumber + ", ";
            //    }
            //    if (AddrDTO.Street.Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + AddrDTO.Street + ", ";
            //    }
            //    if (AddrDTO.Area.Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + AddrDTO.Area + ", ";
            //    }
            //    if (AddrDTO.City.Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + AddrDTO.City + ", ";
            //    }
            //    if (AddrDTO.District.Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + AddrDTO.District + ", ";
            //    }
            //    if (AddrDTO.State.Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + AddrDTO.State + ", ";
            //    }
            //    if (AddrDTO.Country.Length > 0)
            //    {
            //        strAddressCSV = strAddressCSV + AddrDTO.Country + ", ";
            //    }
            //    if (AddrDTO.PIN != 0)
            //    {
            //        strAddressCSV = strAddressCSV + AddrDTO.PIN.ToString();
            //    }

            //    if (strAddressCSV.Trim().EndsWith(","))
            //    {
            //        strAddressCSV = strAddressCSV.Substring(0, strAddressCSV.Length - 2);
            //    }
            //    return strAddressCSV;

            return null;
        }
        #endregion

        #region Is Available Primary Field value
        public bool IsAvail()
        {
            bool avail = false;
            try
            {
                DbCommand dbCommand = objDataBase.GetSqlStringCommand("IsAvail");
                dbCommand.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand, "@Column1", DbType.String, _field1);
                objDataBase.AddInParameter(dbCommand, "@Column2", DbType.String, _field2);
                objDataBase.AddInParameter(dbCommand, "@Value1", DbType.String, _condition1);
                objDataBase.AddInParameter(dbCommand, "@Value2", DbType.String, _condition2);
                objDataBase.AddInParameter(dbCommand, "@TableName", DbType.String, _tableName);
                //FillUpdateParams(ref objDataBase, dbCommand, objAccountsObjects);
                avail = Convert.ToBoolean(objDataBase.ExecuteScalar(dbCommand));
                return avail;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        #endregion

        #region Stored Procedure
        /// <summary>
        /// 
        /// </summary>
        //public string Sproc
        //{
        //    get
        //    {
        //        return _sproc;
        //    }
        //    set
        //    {
        //        _sproc = value;
        //    }
        //}
        #endregion

        #region SQLParam
        /// <summary>
        /// Build specified storedprocedure's paramete(s) as Sqlparameter[] array and assign.
        /// </summary>
        public SqlParameter[] SqlParam
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

        #region Stored Procedure Table Name
        /// <summary>
        /// 
        /// </summary>
        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }
        #endregion

        #region Stored Procedure Field 1
        /// <summary>
        /// 
        /// </summary>
        public string Field1
        {
            get
            {
                return _field1;
            }
            set
            {
                _field1 = value;
            }
        }
        #endregion

        #region Stored Procedure Field 2
        /// <summary>
        /// 
        /// </summary>
        public string Field2
        {
            get
            {
                return _field2;
            }
            set
            {
                _field2 = value;
            }
        }
        #endregion

        #region Stored Procedure Field Condition 1
        /// <summary>
        /// 
        /// </summary>
        public string Condition1
        {
            get
            {
                return _condition1;
            }
            set
            {
                _condition1 = value;
            }
        }
        #endregion

        #region Stored Procedure Field Condition 2
        /// <summary>
        /// 
        /// </summary>
        public string Condition2
        {
            get
            {
                return _condition2;
            }
            set
            {
                _condition2 = value;
            }
        }
        #endregion

        #region Get ResourceDetails
        public DataTable GetResourceDetails(string ResourceName)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand("RESOURCEDETAILS_S");
            dbCommand.CommandType = CommandType.StoredProcedure;
            objDataBase.AddInParameter(dbCommand, "@ResourceName", DbType.String, ResourceName);
            DataTable dt = objDataBase.ExecuteDataSet(dbCommand).Tables[0];
            return dt;
        }
        #endregion

        #region File Upload
        public string UploadFile(FileUpload fluSource, string SrcPath, string Prefix)
        {
            string resultMsg = string.Empty;
            if ((fluSource.PostedFile != null) && (fluSource.PostedFile.ContentLength > 0))
            {
                string fileNameOrg = System.IO.Path.GetFileNameWithoutExtension(fluSource.PostedFile.FileName);
                string fileExtOrg = System.IO.Path.GetExtension(fluSource.PostedFile.FileName);
                string fileName = fileNameOrg + "_" + Prefix + "_" + System.DateTime.Now.TimeOfDay.Milliseconds + fileExtOrg;
                string SaveLocation = SrcPath + "\\" + fileName;
                try
                {
                    fluSource.PostedFile.SaveAs(SaveLocation);
                    resultMsg = SaveLocation;
                }
                catch (Exception ex)
                {
                    resultMsg = "File Upload Failed";
                    //resultMsg = ex.Message;
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to put a generic error message. 
                }
            }
            else
            {
                resultMsg = "Please select a file to upload";
            }
            return resultMsg;
        }
        #endregion

        #region Load AutoGenID
        public string AutoGenID(string IDType)
        {
            try
            {
                string AutoGenID = "";
                DbCommand dbCommand = objDataBase.GetSqlStringCommand("AutoGenenationID");
                dbCommand.CommandType = CommandType.StoredProcedure;
                objDataBase.AddInParameter(dbCommand, "@IDType", DbType.String, IDType);
                objDataBase.AddInParameter(dbCommand, "@BranchName", DbType.String, Components.DTO.LoginDTO.BranchName);
                AutoGenID = Convert.ToString(objDataBase.ExecuteScalar(dbCommand));
                return AutoGenID;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region LoadDataTable()
        public DataTable LoadDataTable(string _StoredProcedure)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand(_StoredProcedure);
            dbCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                return dt;
            }
            return null;
            
        }
        #endregion

        #region LoadDataSet()
        public DataSet LoadDataSet(string _StoredProcedure)
        {
            DbCommand dbCommand = objDataBase.GetSqlStringCommand(_StoredProcedure);
            dbCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = objDataBase.ExecuteDataSet(dbCommand);
            return ds;
        }
        #endregion
    }
}
