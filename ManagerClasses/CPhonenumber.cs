using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_WPF.ManagerClasses
{
    public class CPhonenumber : Loger
    {
        private string _phonenumber;
        public string LogPhonenumber
        {
            get { return _phonenumber; }
            set { _phonenumber = value; EditDate = DateTime.Now; EditUser = ""; }
        }
    }
}
