using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
   public class NewUserDTO
    {
        #region Private Variables
        private string _UserName;
        private string  _StaffID;
        private string _Password;
        private string _StaffName;
        private string _SecQuestions;
        private string _Answers;

        #endregion

        #region Public variables
       public string UserName
        {
            get { return _UserName; }

            set { _UserName = value; }
        }
       public string StaffID
       {
           get { return _StaffID; }

           set { _StaffID = value; }
       }
       public string StaffName
       {
           get { return _StaffName; }

           set { _StaffName = value; }
       }
       public string Password
       {
           get { return _Password; }

           set { _Password = value; }
       }
       public string SecQuestions
       {
           get { return _SecQuestions; }

           set { _SecQuestions = value; }
       }
       public string Answers
       {
           get { return _Answers; }

           set { _Answers = value; }
       }
        #endregion
   }

}
