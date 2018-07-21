using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
    public class LorryAcSlipDTO
    {
        #region Variables
        private string _LSlipNo;
        private string _LSNo;
        private DateTime _Date, _LorryDate, _LorryToPayDate;
        private string _LorryNo;
        private string _StartFrom;
        private string _DestTo;
        private decimal _Advance,_LorryToPayBalance;
        private decimal _LorryHire;
        private decimal _Balance;
        private decimal _LorryToPay;
        private string _FreightPayable;
        private int _AgentID;
        private string _UserID;
        private string _BranchName;
        #endregion

        #region LSlipNo
        public string LSlipNo
        {
            get { return _LSlipNo; }
            set { _LSlipNo = value; }
        }
        #endregion

        #region LSNo
        public string LSNo
        {
            get { return _LSNo; }
            set { _LSNo = value; }
        }
        #endregion

        #region Date
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        #endregion

        #region LorryDate
        public DateTime LorryDate
        {
            get { return _LorryDate; }
            set { _LorryDate = value; }
        }
        #endregion

        #region LorryToPayDate
        public DateTime LorryToPayDate
        {
            get { return _LorryToPayDate; }
            set { _LorryToPayDate = value; }
        }
        #endregion


        #region LorryNo
        public string LorryNo
        {
            get { return _LorryNo; }
            set { _LorryNo = value; }
        }
        #endregion

        #region StartFrom
        public string StartFrom
        {
            get { return _StartFrom; }
            set { _StartFrom = value; }
        }
        #endregion

        #region DestTo
        public string DestTo
        {
            get { return _DestTo; }
            set { _DestTo = value; }
        }
        #endregion

        #region Advance
        public decimal Advance
        {
            get { return _Advance; }
            set { _Advance = value; }
        }
        #endregion

        #region LorryHire
        public decimal LorryHire
        {
            get { return _LorryHire; }
            set { _LorryHire = value; }
        }
        #endregion

        #region LorryToPay
        public decimal LorryToPay
        {
            get { return _LorryToPay; }
            set { _LorryToPay = value; }
        }
        #endregion

        #region Balance
        public decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        #endregion


        #region LorryToPayBalance
        public decimal LorryToPayBalance
        {
            get { return _LorryToPayBalance; }
            set { _LorryToPayBalance = value; }
        }
        #endregion

        #region FreightPayable
        public string FreightPayable
        {
            get { return _FreightPayable; }
            set { _FreightPayable = value; }
        }
        #endregion

        #region AgentID
        public int AgentID
        {
            get { return _AgentID; }
            set { _AgentID = value; }
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
