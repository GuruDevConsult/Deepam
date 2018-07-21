using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace Components.DTO
{
    public class ChangePasswordDTO
    {
        #region Variables
        private string _UserName, _OldPassword;
        private static string _Branch;
        private static string _NewPassword;
        private static string _RetypePassword;
        private string _UserN, _OldPassw,_NewPass,_RetPass;
        #endregion

        #region BranchName
        public static string BranchName
        {
            get
            {
                //return _Branch;
                return Convert.ToString(HttpContext.Current.Session["_Branch"]);
            }
            set
            {
                System.Web.HttpContext.Current.Session["_Branch"] = value;
                //_Branch = value;
            }
        }
        #endregion

        #region OldPassword
        public static string OldPassword
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session["_OldPassword"]);
            }
            set
            {
                System.Web.HttpContext.Current.Session["_OldPassword"] = value;
            }
        }
        #endregion

        #region NewPassword
        public static string NewPassword
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session["_NewPassword"]);
            }
            set
            {
                System.Web.HttpContext.Current.Session["_NewPassword"] = value;
            }
        }
        #endregion

        #region RetypePassword
        public static string RetypePassword
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session["_RetypePassword"]);
            }
            set
            {
                System.Web.HttpContext.Current.Session["_RetypePassword"] = value;
            }
        }
        #endregion

        #region UserN
        public string UserN
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session["_UserN"]);
            }
            set
            {
                System.Web.HttpContext.Current.Session["_UserN"] = value;
            }
        }
        #endregion

        #region OldPassw
        public string OldPassw
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session["_OldPassw"]);
            }
            set
            {
                System.Web.HttpContext.Current.Session["_OldPassw"] = value;
            }
        }
        #endregion

        #region NewPass
        public string NewPass
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session["_NewPass"]);
            }
            set
            {
                System.Web.HttpContext.Current.Session["_NewPass"] = value;
            }
        }
        #endregion

        #region RetPass
        public string RetPass
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session["_RetPass"]);
            }
            set
            {
                System.Web.HttpContext.Current.Session["_RetPass"] = value;
            }
        }
        #endregion

    }
}
