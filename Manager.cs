
using PropertyChanged;

namespace Home_Work_11_WPF
{
    [AddINotifyPropertyChangedInterface]
    public class Manager : Consultant
    {
        public string Forcombobox { get; set; }
        public string Id { get; set; }        

        public CName Name = new CName();

        public CSurname SurName = new CSurname();

        public CPatronymic Patronymic = new CPatronymic();

        public CPassportseries Passportseries = new CPassportseries();

        public CPassportnumber Passportnumber = new CPassportnumber();
                
    }
}
