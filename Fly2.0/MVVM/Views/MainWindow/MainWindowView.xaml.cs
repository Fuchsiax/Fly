using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using Fly2_0.UserBooking;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fly2_0.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : UserControl
    {
        private ApplicationContext db;
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
        public void Open()
        {

            try
            {
                db.Users.Load();
                var users = db.Users.ToList();
                User find_iduser = users.Find(item => item.Status == "Online");
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
