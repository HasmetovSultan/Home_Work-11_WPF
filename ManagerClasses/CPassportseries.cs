using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_WPF
{
    public class CPassportseries : Loger
    {
        private string _passportseries;
        public string LogPassportseries
        {
            get { return _passportseries; }
            set { _passportseries = value; EditDate = DateTime.Now; EditUser = ""; }
        }
    }
}
