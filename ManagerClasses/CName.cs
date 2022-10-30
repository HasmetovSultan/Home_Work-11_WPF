using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_WPF
{
    public class CName : Loger
    {
        private string _name;
        public string LogName
        {
            get { return _name; }
            set { _name = value; EditDate = DateTime.Now; EditUser = ""; }
        }
    }
}
