using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Home_Work_11_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public static ObservableCollection<Manager> _workers { get; set; } = new ObservableCollection<Manager>();        
        public string path = "Workers.json";
        public MainWindow()
        {
            InitializeComponent();
            ExistsFileCreate();
            Loger.Mwin = this;
            ReadFileJson();
            CBox.ItemsSource = _workers;
        }

        /// <summary>
        /// Создать файл если его нет
        /// </summary>
        private void ExistsFileCreate()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }
        /// <summary>
        /// Запись в файл в формате json
        /// </summary>
        /// <param name="manager"></param>
        private void SaveWorker(ObservableCollection<Manager> _workers)
        {
            File.Create(path).Close();
            for (int i = 0; i < _workers.Count; i++)            {
                
                using (FileStream fs = new FileStream(path, FileMode.Append))         // Сохраняем в jeson формате в файл
                {                                                                     //
                    string jsonUser = JsonConvert.SerializeObject(_workers[i]);       //
                    using (StreamWriter stream = new StreamWriter(fs))                //                                                               
                        stream.WriteLine(jsonUser);                                   //                                                              
                }
            }
        }
        /// <summary>
        /// Чтение файла Json
        /// </summary>
        private void ReadFileJson()
        {
            string[] s = File.ReadAllLines(path); // Чтение файла!
            for (int i = 0; i < s.Length; i++)
            {
                string a = s[i];
                Manager manager = JsonConvert.DeserializeObject<Manager>(a);
                _workers.Add(manager);
            }            
        }
        /// <summary>
        /// Очистка Текст боксов
        /// </summary>
        private void ClearTextBox()
        {
            TBName.Text = "";
            TBSurname.Text = "";
            TBPatronymic.Text = "";
            TBPhonenumber.Text = "";
            TBPassportseries.Text = "";
            TBPassportnumber.Text = "";
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TBuser.Text == "USER: MANAGER")
            {
                Manager manager = new Manager();
                manager.Name.LogName = TBName.Text;
                manager.SurName.LogSurname = TBSurname.Text;
                manager.Patronymic.LogPatronymic = TBPatronymic.Text;
                manager.Phonenumber.LogPhonenumber = TBPhonenumber.Text;
                manager.Passportseries.LogPassportseries = TBPassportseries.Text;
                manager.Passportnumber.LogPassportnumber = TBPassportnumber.Text;

                manager.Forcombobox = $"{TBSurname.Text} {TBName.Text} {TBPatronymic.Text}";



                if (TBName.Text == ""
                    || TBSurname.Text == ""
                    || TBPhonenumber.Text == ""
                    || TBPassportseries.Text == ""
                    || TBPassportnumber.Text == "")
                {
                    MessageBox.Show("Заполните все поля!");
                    return;
                }
                //********************IF CONSULTANT*************************************
                string id = TBalert.Text;
                if (id != "")
                {
                    for (int i = 0; i < _workers.Count; i++)
                    {
                        if (id == _workers[i].Id.ToString())
                        {
                            string caption = "Данные работника будут перезаписаны!";
                            string messageBoxText = "Сохранить изменения?";
                            MessageBoxButton button = MessageBoxButton.YesNo;
                            MessageBoxImage icon = MessageBoxImage.Warning;
                            MessageBoxResult result;

                            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

                            if (result == MessageBoxResult.Yes)
                            {
                                manager.Id = id;

                                if (_workers[i].Name.LogName != TBName.Text)
                                { _workers[i].Name.LogName = TBName.Text; }
                                if (_workers[i].SurName.LogSurname != TBSurname.Text)
                                { _workers[i].SurName.LogSurname = TBSurname.Text; }
                                if (_workers[i].Patronymic.LogPatronymic != TBPatronymic.Text)
                                { _workers[i].Patronymic.LogPatronymic = TBPatronymic.Text; }
                                if (_workers[i].Phonenumber.LogPhonenumber != TBPhonenumber.Text)
                                { _workers[i].Phonenumber.LogPhonenumber = TBPhonenumber.Text; }
                                if (_workers[i].Passportseries.LogPassportseries != TBPassportseries.Text)
                                { _workers[i].Passportseries.LogPassportseries = TBPassportseries.Text; }
                                if (_workers[i].Passportnumber.LogPassportnumber != TBPassportnumber.Text)
                                { _workers[i].Passportnumber.LogPassportnumber = TBPassportnumber.Text; }

                                _workers[i].Forcombobox = $"{TBSurname.Text} {TBName.Text} {TBPatronymic.Text}";
                                ClearTextBox();
                                SaveWorker(_workers);
                                MessageBox.Show("Работник изменён!");
                            }                            
                                return;                            
                        }
                    }
                }
                manager.Id = Guid.NewGuid().ToString();
                _workers.Add(manager);
                ClearTextBox();
                SaveWorker(_workers);
                MessageBox.Show("Работник добавлен!");
            }
            else if (TBuser.Text == "USER: CONSULTANT")
            {
                if (TBPhonenumber.Text != "")
                {
                    for (int i = 0; i < _workers.Count; i++)
                    {
                        if (TBalert.Text == _workers[i].Id.ToString())
                        {
                            string caption = "Данные работника будут перезаписаны!";
                            string messageBoxText = "Сохранить изменения?";
                            MessageBoxButton button = MessageBoxButton.YesNo;
                            MessageBoxImage icon = MessageBoxImage.Warning;
                            MessageBoxResult result;

                            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

                            if (result == MessageBoxResult.Yes)
                            {
                                if (_workers[i].Phonenumber.LogPhonenumber != TBPhonenumber.Text)
                                { _workers[i].Phonenumber.LogPhonenumber = TBPhonenumber.Text; }

                                ClearTextBox();
                                SaveWorker(_workers);
                                MessageBox.Show("Работник изменён!");
                                return;
                            }
                            else if (result == MessageBoxResult.No)
                            {
                                return;
                            }
                        }
                    }
                }
                else 
                {
                    MessageBox.Show("Поле не должно быть пустым");
                    return;
                }
                
            }
        }

        private void Btnuser_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();

            if (TBuser.Text == "USER: MANAGER")
            {
                TBuser.Text = "USER: CONSULTANT";

                TBalert.Text = "Выберите Воркера!";

                TBName.IsEnabled = false;
                TBSurname.IsEnabled = false;
                TBPatronymic.IsEnabled = false;
                TBPhonenumber.IsEnabled = false;
                TBPassportseries.Text = "**-**";
                TBPassportnumber.Text = "***-***";
                TBPassportseries.IsEnabled = false;
                TBPassportnumber.IsEnabled = false;

            }
            else if (TBuser.Text == "USER: CONSULTANT")
            {
                TBuser.Text = "USER: MANAGER";

                TBalert.Text = "";

                TBName.IsEnabled = true;
                TBSurname.IsEnabled = true;
                TBPatronymic.IsEnabled = true;
                TBPhonenumber.IsEnabled = true;
                TBPassportseries.Text = "";
                TBPassportnumber.Text = "";
                TBPassportseries.IsEnabled = true;
                TBPassportnumber.IsEnabled = true;

            }
        }
        //********************************ВЫБОР В КОМБОБОКС***************************
        private void CBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBalert.Text = "";

            if (TBuser.Text == "USER: CONSULTANT")
            {

                TBName.IsEnabled = false;
                TBSurname.IsEnabled = false;
                TBPatronymic.IsEnabled = false;
                TBPhonenumber.IsEnabled = true;
                TBPassportseries.Text = "**-**";
                TBPassportnumber.Text = "***-***";
                TBPassportseries.IsEnabled = false;
                TBPassportnumber.IsEnabled = false;

            }
            else if (TBuser.Text == "USER: MANAGER")
            {

                TBName.IsEnabled = true;
                TBSurname.IsEnabled = true;
                TBPatronymic.IsEnabled = true;
                TBPhonenumber.IsEnabled = true;
                TBPassportseries.Text = "";
                TBPassportnumber.Text = "";
                TBPassportseries.IsEnabled = true;
                TBPassportnumber.IsEnabled = true;
            }
            var search = (CBox.SelectedValue as Manager).Id;
            Manager temp = _workers.FirstOrDefault(w => w.Id == search);

            if (TBuser.Text == "USER: CONSULTANT")
            {
                TBName.IsEnabled = false;
                TBSurname.IsEnabled = false;
                TBPatronymic.IsEnabled = false;
                TBPhonenumber.IsEnabled = true;
                TBPassportseries.Text = "**-**";
                TBPassportnumber.Text = "***-***";
                TBPassportseries.IsEnabled = false;
                TBPassportnumber.IsEnabled = false;

                TBalert.Text = temp.Id;
                TBalert.IsEnabled = false;
                TBName.Text = temp.Name.LogName;
                TBSurname.Text = temp.SurName.LogSurname;
                TBPatronymic.Text = temp.Patronymic.LogPatronymic;
                TBPhonenumber.Text = temp.Phonenumber.LogPhonenumber;
            }
            else if (TBuser.Text == "USER: MANAGER")
            {
                TBalert.Text = temp.Id;
                TBalert.IsEnabled = false;
                TBName.Text = temp.Name.LogName;
                TBSurname.Text = temp.SurName.LogSurname;
                TBPatronymic.Text = temp.Patronymic.LogPatronymic;
                TBPhonenumber.Text = temp.Phonenumber.LogPhonenumber;
                TBPassportseries.Text = temp.Passportseries.LogPassportseries;
                TBPassportnumber.Text = temp.Passportnumber.LogPassportnumber;
            }
        }
    }
}
