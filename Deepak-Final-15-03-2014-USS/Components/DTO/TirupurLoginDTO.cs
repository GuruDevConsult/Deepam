using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace Components.DTO
{
    public class TirupurLoginDTO
    {
        #region Variables
        private string _UserName, _Password;
        private static string _UserID, _Branch;
        private static int _CompanyID;
        private int _SecuQues;
        private string _SecuAns;
        private string _EmployeeID;
        private string _BranchName;

        #endregion

        #region BranchName
        public static string BranchName
        {
            get { return _Branch; }
            set { _Branch = value; }
        }
        #endregion

        #region BranchN
        public string BranchN
        {
            get { return _BranchName; }
            set { _BranchName = value; }
        }
        #endregion

        #region UserName
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        #endregion

        public static bool IsLive
        {
            get
            {
                return Convert.ToBoolean(HttpContext.Current.Session["IsLive"]);
            }
            set
            {

                System.Web.HttpContext.Current.Session["IsLive"] = value;
            }
        }
        #region Password
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        #endregion

        #region UserID
        public static string UserID
        {
            get 
            { 
                return _UserID; 
            }
            set
            { 
                _UserID = value; 
            }
        }
        #endregion

        #region CompanyID
        public static int CompanyID
        {
            get
            {
                return _CompanyID;
            }
            set
            {
                _CompanyID = value;
            }
        }
        #endregion

        #region SecuQues
        public int SecuQues
        {
            get { return _SecuQues; }
            set { _SecuQues = value; }
        }
        #endregion

        #region SecuAns
        public string SecuAns
        {
            get { return _SecuAns; }
            set { _SecuAns = value; }
        }
        #endregion

        public string EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }

        
    }
}
