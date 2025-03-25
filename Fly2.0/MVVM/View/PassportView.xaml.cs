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
    /// Логика взаимодействия для PassportView.xaml
    /// </summary>
    public partial class PassportView : UserControl
    {
        ApplicationContext db;
        public PassportView()
        {
            InitializeComponent();
            DataContext = new PassportViewModel();
        }

        private void СрокДействия_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            datePicker.SelectedDate = DateTime.Now;
            datePicker.DisplayDateStart = DateTime.Now;
            datePicker.DisplayDateEnd = DateTime.Now.AddYears(10);
        }

        private void SearchEntity(string s)
        {
            db = new ApplicationContext();
            try
            {
                var passports = db.Passports;
                List<Passport> p = new List<Passport>();
                foreach (Passport passport in passports)
                {
                    if (passport.Validity.ToString().StartsWith(s) || passport.Number.StartsWith(s) || passport.Nationality.StartsWith(s) ||
                    passport.Id_Passport.ToString().StartsWith(s))
                    {
                        p.Add(passport);
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
