using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_WPF
{
    public class CSurname : Loger
    {
        private string _surname;
        public string LogSurname
        {
            get { return _surname; }
            set { _surname = value; EditDate = DateTime.Now; EditUser = ""; }
        }
    }
}
