using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data.SqlClient;

namespace Components.BL
{
    public sealed class ValidationHelper
    {
        #region Variables
        private int screenID;
        private static ValidationHelper _instance;
        private DataTable dtValidExp;
        #endregion

        public static ValidationHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ValidationHelper();

                return _instance;
            }
        }

        public class ValidationField
        {
            //public string ScreenID = string.Empty;
            public string Name = string.Empty;
            public string RegEx = string.Empty;
            //public int MaxLength = 0;
            public string RegExErrorMessage = string.Empty;
            public string RequiredErrorMessage = string.Empty;
        }

        private System.Collections.Specialized.HybridDictionary _cachedValidationFields = new System.Collections.Specialized.HybridDictionary();

        private ValidationHelper()
        {
        }

        public ValidationField Field(string FieldName)
        {
            return ((ValidationField) _cachedValidationFields[FieldName]);
        }

        //public DataTable GetValidation()
        //{

        //    //DataRow drValidExp;
        //    Components.DAL.Validator _Validator = Components.DAL.Validator.Instance;
        //    _Validator.ScreenID = screenID;
        //    dtValidExp = _Validator.GetValidationExp();
        //    return dtValidExp;
        //    //foreach (DataRow tempLoop_dr in dtValidExp.Rows)
        //    //{
        //    //    drValidExp = tempLoop_dr;
        //    //    ValidationField Field = new ValidationField();
        //    //    //Field.ScreenID = drValidExp["ResourceID"].ToString();
        //    //    Field.Name = drValidExp["FieldName"].ToString();
        //    //    Field.RegEx = drValidExp["RegEx"].ToString();
        //    //    Field.RegExErrorMessage = drValidExp["RegExMessage"].ToString();
        //    //    Field.RequiredErrorMessage = drValidExp["ReqMessage"].ToString();
        //    //    if (!_cachedValidationFields.Contains(Field.Name))
        //    //    {
        //    //        _cachedValidationFields.Add(Field.Name, Field);
        //    //    }
        //    //}
            
        //}

        #region VailidateEmail

        //public bool validateEmail(string strEmail)
        //{
        //    string at = "@";
        //    string dot = ".";
        //    int lat = strEmail.IndexOf(at);
        //    int lstr = strEmail.Length;
        //    int ldot = strEmail.IndexOf(dot);


        //    if (strEmail.IndexOf('.', strEmail.Length - 1) != -1)
        //    {
        //        return false;
        //    }

        //    if (strEmail.IndexOf(at) == -1 || strEmail.IndexOf(at) == 0 || strEmail.IndexOf(at) == lstr - 1)
        //    {
        //        return false;
        //    }

        //    if (strEmail.IndexOf(dot) == -1 || strEmail.IndexOf(dot) == 0 || strEmail.IndexOf(dot) == lstr - 1)
        //    {
        //        return false;
        //    }

        //    if (strEmail.IndexOf(at, (lat + 1)) != -1)
        //    {
        //        return false;
        //    }

        //    if (strEmail.Substring(lat - 1, 1) == dot || strEmail.Substring(lat + 1, 1) == dot)
        //    {
        //        return false;
        //    }

        //    if (strEmail.IndexOf(dot, (lat + 2)) == -1)
        //    {
        //        return false;
        //    }

        //    if (strEmail.IndexOf(" ") != -1)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        #endregion

        #region Reset
        public static void Reset()
        {
            _instance = new ValidationHelper();
        }
        #endregion

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
