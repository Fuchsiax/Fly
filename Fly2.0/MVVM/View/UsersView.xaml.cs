using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using Fly2._0.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fly2._0.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {

        ApplicationContext db;
        public UsersView()
        {
            InitializeComponent();
            DataContext = new UsersViewModel();
        }

        private void ДатаРождения_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            datePicker.SelectedDate = DateTime.Now;
            datePicker.DisplayDateStart = DateTime.Now.AddYears(-100);
            datePicker.DisplayDateEnd = DateTime.Now;
 
        }

        private void SearchEntity(string s)
        {
            db = new ApplicationContext();
            try
            {
                var users = db.Users;
                List<User> p = new List<User>();
                foreach (User user in users)
                {
                    if (user.Surname.StartsWith(s) || user.Status.StartsWith(s) || user.Sex.StartsWith(s) ||
                    user.Id_User.ToString().StartsWith(s) || user.Password.StartsWith(s) || user.ParticipantNumber.StartsWith(s)
                    || user.Name.StartsWith(s) || user.Id_Passport.ToString().StartsWith(s) || user.Id_Contact.ToString().StartsWith(s)
                    || user.Id_Address.ToString().StartsWith(s) || user.DateOfBirth.ToString().StartsWith(s))
                    {
                        p.Add(user);
                    }
                }
                aircraftsGrid.ItemsSource = p;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = Search.Text;
            SearchEntity(s);
        }
    }
}
