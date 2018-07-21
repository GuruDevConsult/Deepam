using System;
using System.Collections.Generic;
using System.Text;

namespace Components.DTO
{
    public class BranchDTO
    {
        #region Variables
        private string _BranchName;
        private string _UserName;
        private string _Password;
        private string _SecurityQues;
        private string _SecurityAnswer;
        
        #endregion


        #region BranchName
        public string BranchName
        {
            get
            {
                return _BranchName;
            }
            set
            {
                _BranchName = value;
            }

        }
        #endregion

        #region UserName
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }

        }
        #endregion

        #region Password
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }

        }
        #endregion

        #region SecurityQues
        public string SecurityQues
        {
            get
            {
                return _SecurityQues;
            }
            set
            {
                _SecurityQues = value;
            }

        }
        #endregion

        #region SecurityAnswer
        public string SecurityAnswer
        {
            get
            {
                return _SecurityAnswer;
            }
            set
            {
                _SecurityAnswer = value;
            }

        }
        #endregion

    }
}
