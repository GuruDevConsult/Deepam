using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
    public class UnitDetailsDTO
    {
        #region Variables
        private string _Unit;
        private string _BranchName;
        #endregion

        #region Unit
        public string Unit
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

        #region BranchName

        public string BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value; }
        }

        #endregion

    }
}
