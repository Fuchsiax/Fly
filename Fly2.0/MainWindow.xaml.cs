using Fly2._0.Admin;
using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace Fly2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {

            List<User> users = db.Users.ToList();
            User find_iduser = users.Find(item => item.Status == "Online");
            if (find_iduser == null)
            {
                Application.Current.Shutdown();
            }
            else
            {
                find_iduser.Status = "Offline";
                db.Entry(find_iduser).State = EntityState.Modified;
                db.SaveChanges();
                Application.Current.Shutdown();
            }
            
        }

        private void Вход_Checked(object sender, RoutedEventArgs e)
        {
            ПоказатьМеню.Visibility = Visibility.Visible;
        }

        private void Вход_Unchecked(object sender, RoutedEventArgs e)
        {
            ПоказатьМеню.Visibility = Visibility.Hidden;
        }

        private void Регистрация_Checked(object sender, RoutedEventArgs e)
        {
            ПоказатьМеню.Visibility = Visibility.Hidden;
            Вход.IsChecked = false;
        }

        private void Главная_Checked(object sender, RoutedEventArgs e)
        {
            ПоказатьМеню.Visibility = Visibility.Hidden;
            Вход.IsChecked = false;
        }

        private void ButtonCloseLogin_Click(object sender, RoutedEventArgs e)
        {
            Вход.IsChecked = false;
        }

        private void Войти_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {
            try 
            {
                List<Administrator> administrators = db.Administrators.ToList();

                List<User> users = db.Users.ToList();

                if (AdminLogin.IsChecked == true)
                {

                    for (int i = 0; i < administrators.Count; i++)
                    {
                        if (administrators[i].NumberEmployee == UserNumber.Text && administrators[i].Password == Password.Text)
                        {
                            MessageBox.Show("Вы зашли в профиль администартора");
                            AdminstratorWindow adminstratorWindow = new AdminstratorWindow();
                            this.Hide();
                            adminstratorWindow.ShowDialog();
                            this.Show();
                        }
                        else if (administrators[i].NumberEmployee == UserNumber.Text && administrators[i].Password != Password.Text)
                        {
                            throw new Exception("Вы ввели неверный пароль");
                        }
                        else if (UserNumber.Text == null && Password.Text == null)
                        {
                            throw new Exception("Заполните поля данными");
                        }
                    }
                }
                else
                {
                    User find_iduser = users.Find(item => item.ParticipantNumber == UserNumber.Text && item.Password == Password.Text);
                    if (find_iduser == null)
                    {
                        throw new Exception("Пользователь не существует");
                    }
                    else
                    {
                        find_iduser.Status = "Online";
                        db.Entry(find_iduser).State = EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Вы зашли в аккаунт");
                    }
                }
         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }
    }
}
