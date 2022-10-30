using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_11_WPF
{
    public class Loger
    {
        public static MainWindow Mwin { get; set; }
        public DateTime EditDate { get; set; } 

        private string _editUser;
        public string EditUser
        {
            get { return _editUser; }
            set { _editUser = Mwin.TBuser.Text; }
        }
    }
}
