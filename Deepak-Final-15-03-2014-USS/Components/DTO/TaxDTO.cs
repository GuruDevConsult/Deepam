using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
    public class TaxDTO
    {
        private string _TaxName;
        private decimal _TaxPercentage;
        private string _TaxInfo1;
        private string _TaxInfo2;
        private string _UserID;
        //private string _BranchName;

        public string TaxName
        {
            get { return _TaxName; }
            set { _TaxName = value; }
        }
        public decimal TaxPercentage
        {
            get { return _TaxPercentage; }
            set { _TaxPercentage = value; }
        }
        public string TaxInfo2
        {
            get { return _TaxInfo2; }
            set { _TaxInfo2 = value; }
        }
        public string TaxInfo1
        {
            get { return _TaxInfo1; }
            set { _TaxInfo1 = value; }
        }
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        //#region BranchName

        //public string BranchName
        //{
        //    get { return _BranchName; }
        //    set { _BranchName = value; }
        //}

        //#endregion
    }
}
