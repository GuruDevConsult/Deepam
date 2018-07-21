using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
   public class ItemDetailsDTO
    {
        #region Variables
        private string _ID;
        private string _Item;
        private decimal _Rate;
        private string _BranchName;
        #endregion

        #region ID
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        #endregion

       #region Item
       public string Item
       {
           get
           {
               return _Item;
           }
           set
           {
               _Item = value;
           }
       }
       #endregion

       #region Rate
       public decimal Rate
       {
           get
           {
               return _Rate;
           }
           set
           {
               _Rate = value;
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
