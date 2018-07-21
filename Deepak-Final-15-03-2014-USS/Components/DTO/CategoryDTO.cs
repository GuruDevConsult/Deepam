using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
   public class CategoryDTO
    {
       private string _Category;
       private string _CategoryName;
       private string _BranchName;

       public string Category
       {
           get { return _Category; }
           set { _Category = value; }
       }
       public string CategoryName
       {
           get { return _CategoryName; }
           set { _CategoryName = value; }
       }

       #region BranchName

       public string BranchName
       {
           get { return _BranchName; }
           set { _BranchName = value; }
       }

       #endregion
    }
}
