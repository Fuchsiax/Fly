using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using Fly2_0.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Fly2_0.MVVM.View
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
                    user.IdUser.ToString().StartsWith(s) || user.Password.StartsWith(s) || user.ParticipantNumber.StartsWith(s)
                    || user.Name.StartsWith(s) || user.IdPassport.ToString().StartsWith(s) || user.IdContact.ToString().StartsWith(s)
                    || user.IdAddress.ToString().StartsWith(s) || user.DateOfBirth.ToString().StartsWith(s))
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
