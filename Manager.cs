
namespace Home_Work_11_WPF
{
    public class Manager : Consultant
    {
        public string Forcombocox { get; set; }
        public string Id { get; set; }        

        public CName Name = new CName();

        public CSurname SurName = new CSurname();

        public CPatronymic Patronymic = new CPatronymic();

        public CPassportseries Passportseries = new CPassportseries();

        public CPassportnumber Passportnumber = new CPassportnumber();
                
    }
}
