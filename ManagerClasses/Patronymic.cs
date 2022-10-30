using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_WPF
{
    public class CPatronymic : Loger
    {
        private string _patronymic;
        public string LogPatronymic
        {
            get { return _patronymic; }
            set { _patronymic = value; EditDate = DateTime.Now; EditUser = ""; }
        }
    }
}
