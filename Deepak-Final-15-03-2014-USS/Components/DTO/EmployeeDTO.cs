using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
    public class EmployeeDTO
    {
        
        #region Variables
        private string _Phone;
        private string _Mobile;         
        private string _EmpCode = string.Empty;
        private string _EmpName = string.Empty;
        private string _FatherName = string.Empty;
        private string _MotherName = string.Empty;
        private int _Gender;
        private string _Email = string.Empty;
        private string _Qualification = string.Empty;
        private string _Designation = string.Empty;
        private string _UserID = string.Empty;
        private DateTime _DOJ;
        private DateTime _DOB;
        private string _Address, _City;
        private int _PinCode;
        private string _BranchName;

        #endregion
        
        #region Employee Code
        public string EmpCode
        {
            get
            { return _EmpCode; }
            set
            { _EmpCode = value; }
           
        }
        #endregion

        #region Employee Name
        public string EmpName
        {
            get
            { return _EmpName; }
            set
            { _EmpName = value; }

        }
        #endregion        

        #region Employee's Father Name
        public string FatherName
        {
            get
            { return _FatherName; }
            set
            { _FatherName = value; }

        }
        #endregion

        #region Employee's Mother Name
        public string MotherName
        {
            get
            { return _MotherName; }
            set
            { _MotherName = value; }

        }
        #endregion

        #region Gender
        public int Gender
        {
            get
            { return _Gender; }
            set
            { _Gender = value; }
        }
        #endregion

        #region Employee Date of Birth
        public DateTime DOB
        {
            get
            { return _DOB; }
            set
            { _DOB = value; }
        }
        #endregion


        #region Employee's Phone Number
        public string Phone
        {
            get
            { return _Phone; }
            set
            { _Phone = value; }
        }
        #endregion

        #region Employee's Mobile Number
        public string Mobile
        {
            get
            { return _Mobile; }
            set
            { _Mobile = value; }
        }
        #endregion

        #region Employee's Email
        public string Email
        {
            get
            { return _Email; }
            set
            { _Email = value; }
        }
        #endregion

        #region Employee's Qualification
        public string Qualification
        {
            get
            { return _Qualification; }
            set
            { _Qualification = value; }
        }
        #endregion

        #region Employee's Designation
        public string Designation
        {
            get
            { return _Designation; }
            set
            { _Designation = value; }
        }
        #endregion

        #region Employee's Date of Joining
        public DateTime DOJ
        {
            get
            { return _DOJ; }
            set
            { _DOJ = value; }
        }
        #endregion

        
        #region UserID
        public string UserID
        {            
            get
            { return _UserID; }
            set
            { _UserID = value; }
        }
        #endregion

        #region Address
        public string Address
        {
            get
            { return _Address; }
            set
            { _Address = value; }
        }
        #endregion

        #region City
        public string City
        {
            get
            { return _City; }
            set
            { _City = value; }
        }
        #endregion

        #region PinCode
        public int PinCode
        {
            get
            { return _PinCode; }
            set
            { _PinCode = value; }
        }
        #endregion

        #region BranchName

        public string BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value; }
        }

        #endregion

    }
}
