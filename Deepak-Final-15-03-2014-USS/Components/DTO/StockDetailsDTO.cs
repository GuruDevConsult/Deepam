using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
    public class StockDetailsDTO
    {
        #region Variables       
        private int _hidID;
        private string  _StoreNo;
        private string _ItemName;
        private int _Qty;
        private int _Unit;
        private string _LRNo;
        private string _UserID;
        private string _BranchName;
        
        #endregion

        #region hidID
        public int hidID
        {
            get
            {
                return _hidID;
            }
            set
            {
                _hidID = value;
            }
        }
        #endregion

        #region StoreNo
        public string  StoreNo
        {
            get
            {
                return _StoreNo;
            }
            set
            {
                _StoreNo = value;
            }
        }
        #endregion

        #region ItemName
        public string ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                _ItemName = value;
            }
        }
        #endregion

        #region Qty
        public int Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                _Qty = value;
            }
        }
        #endregion

        #region Unit
        public int Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                _Unit = value;
            }
        }
        #endregion

        #region LRNo
        public string LRNo
        {
            get
            {
                return _LRNo;
            }
            set
            {
                _LRNo = value;
            }
        }
        #endregion

        #region UserID
        public string UserID
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

        #region BranchName

        public string BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value; }
        }

        #endregion


    }
}
