using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_WPF
{
    public class CPassportnumber : Loger
    {
        private string _passportnumber;
        public string LogPassportnumber
        {
            get { return _passportnumber; }
            set { _passportnumber = value; EditDate = DateTime.Now; EditUser = ""; }
        }
    }
}
