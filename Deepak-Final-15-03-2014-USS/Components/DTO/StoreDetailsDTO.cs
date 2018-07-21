using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
    public class StoreDetailsDTO
    {
        #region Variables
        private string _Store;
        private string _StoreAddress;
        private string _BranchName;
        #endregion

        #region Store
        public string Store
        {
            get
            {
                return _Store;
            }
            set
            {
                _Store = value;
            }
        }
        #endregion

        #region StoreAddress
        public string StoreAddress
        {
            get
            {
                return _StoreAddress;
            }
            set
            {
                _StoreAddress = value;
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
