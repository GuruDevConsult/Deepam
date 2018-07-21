using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
    public class ReceivedBookDetailsDTO
    {
        #region Variables
        private string _LRNo;
        private DateTime _BookingDate;
        private int _ConsignorID;
        private int _ConsigneeID;
        private string _Desc;
        private decimal _ActualWeight;
        private decimal _ChargedWeight;
        private decimal _FreightCharges;
        private decimal _HandlingCharges;
        private decimal _CartageCharges;
        private decimal _StatisticalCharges;
        private decimal _MiscExp;
        private decimal _Insurance;
        private decimal _AOC;
        private decimal _ServiceTax;
        private decimal _Total;
        private string _InsuranceCoName;
        private string _PolicyNo;
        private DateTime _Date;
        private decimal _InsuranceAmt;
        private string _Risk;
        private int _AgentID;
        private string _From;
        private string _To;
        private decimal _Paid;
        private string _UserID;
        private string _BranchName;

        #endregion

        #region LRNo
        public string LRNo
        {
            get { return _LRNo; }
            set { _LRNo = value; }
        }
        #endregion
        

        #region BookingDate
        public DateTime BookingDate
        {
            get { return _BookingDate; }
            set { _BookingDate = value; }
        }
        #endregion

        #region ConsignorID
        public int ConsignorID
        {
            get { return _ConsignorID; }
            set { _ConsignorID = value; }
        }
        #endregion

        #region ConsigneeID
        public int ConsigneeID
        {
            get { return _ConsigneeID; }
            set { _ConsigneeID = value; }
        }
        #endregion

        #region Desc
        public string Desc
        {
            get { return _Desc; }
            set { _Desc = value; }
        }
        #endregion

        #region ActualWeight
        public decimal ActualWeight
        {
            get { return _ActualWeight; }
            set { _ActualWeight = value; }
        }
        #endregion

        #region ChargedWeight
        public decimal ChargedWeight
        {
            get { return _ChargedWeight; }
            set { _ChargedWeight = value; }
        }
        #endregion

        #region FreightCharges
        public decimal FreightCharges
        {
            get { return _FreightCharges; }
            set { _FreightCharges = value; }
        }
        #endregion

        #region HandlingCharges
        public decimal HandlingCharges
        {
            get { return _HandlingCharges; }
            set { _HandlingCharges = value; }
        }
        #endregion

        #region CartageCharges
        public decimal CartageCharges
        {
            get { return _CartageCharges; }
            set { _CartageCharges = value; }
        }
        #endregion

        #region StatisticalCharges
        public decimal StatisticalCharges
        {
            get { return _StatisticalCharges; }
            set { _StatisticalCharges = value; }
        }
        #endregion

        #region MiscExp
        public decimal MiscExp
        {
            get { return _MiscExp; }
            set { _MiscExp = value; }
        }
        #endregion

        #region Insurance
        public decimal Insurance
        {
            get { return _Insurance; }
            set { _Insurance = value; }
        }
        #endregion

        #region AOC
        public decimal AOC
        {
            get { return _AOC; }
            set { _AOC = value; }
        }
        #endregion

        #region ServiceTax
        public decimal ServiceTax
        {
            get { return _ServiceTax; }
            set { _ServiceTax = value; }
        }
        #endregion

        #region Total
        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        #endregion

        #region InsuranceCoName
        public string InsuranceCoName
        {
            get { return _InsuranceCoName; }
            set { _InsuranceCoName = value; }
        }
        #endregion

        #region PolicyNo
        public string PolicyNo
        {
            get { return _PolicyNo; }
            set { _PolicyNo = value; }
        }
        #endregion

        #region Date
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        #endregion

        #region InsuranceAmt
        public decimal InsuranceAmt
        {
            get { return _InsuranceAmt; }
            set { _InsuranceAmt = value; }
        }
        #endregion

        #region Risk
        public string Risk
        {
            get { return _Risk; }
            set { _Risk = value; }
        }
        #endregion

        #region AgentID
        public int AgentID
        {
            get { return _AgentID; }
            set { _AgentID = value; }
        }
        #endregion

        #region From
        public string From
        {
            get { return _From; }
            set { _From = value; }
        }
        #endregion

        #region To
        public string To
        {
            get { return _To; }
            set { _To = value; }
        }
        #endregion

        #region Paid
        public decimal Paid
        {
            get { return _Paid; }
            set { _Paid = value; }
        }
        #endregion

        #region UserID

        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
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
