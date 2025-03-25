using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using Fly2._0.UserBooking;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : UserControl
    {
        ApplicationContext db;
        public MainWindowView()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Главная_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Регистрация_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Вход_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Войти_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Зарегистрироваться_Click(object sender, RoutedEventArgs e)
        {

        }


        public void Open()
        {

            try
            {
                db.Users.Load();
                var users = db.Users.ToList();
                User find_iduser = users.Find(item => item.Status == "On-line");
                if (find_iduser == null)
                {
                    throw new Exception("Вы не зашли в аккаунт");
                }
                if (find_iduser != null)
                {
                    BookingTicket bookingTicket = new BookingTicket();
                    bookingTicket.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Предложение1_Click(object sender, RoutedEventArgs e)
        {
            Open();
        }

        private void Предложение2_Click(object sender, RoutedEventArgs e)
        {
            Open();
        }

        private void Предложение3_Click(object sender, RoutedEventArgs e)
        {
            Open();
        }
    }
}
