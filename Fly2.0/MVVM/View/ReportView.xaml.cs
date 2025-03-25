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
    /// Логика взаимодействия для ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        ApplicationContext db;
        public ReportView()
        {
            InitializeComponent();
            DataContext = new SearchViewModel();
            db = new ApplicationContext();
        }

        private void РейсыОт_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            datePicker.DisplayDateStart = DateTime.Now.AddMonths(-6);
            datePicker.DisplayDateEnd = DateTime.Now.AddMonths(6);
        }

        private void РейсыДо_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            datePicker.DisplayDateStart = DateTime.Now.AddMonths(-6);
            datePicker.DisplayDateEnd = DateTime.Now.AddMonths(6);
        }

        private void РейсыОт_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFlights();
        }

        private void РейсыДо_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFlights();
        }

        public void SetFlights()
        {
            db = new ApplicationContext();
            try
            {
                int count = 0;
                var flights = db.Flights;
                List<Flight> p = new List<Flight>();
                foreach (Flight flight in flights)
                {
                    if (РейсыОт.SelectedDate.Value != null && РейсыДо.SelectedDate.Value == null)
                    {
                        throw new Exception("Установите период от");
                    }
                    else if (РейсыОт.SelectedDate.Value == null && РейсыДо.SelectedDate.Value != null)
                    {
                        throw new Exception("Установите период до");
                    }
                    else if (flight.DepartureDate.Day >= РейсыОт.SelectedDate.Value.Day && flight.DepartureDate.Month >= РейсыОт.SelectedDate.Value.Month && flight.DepartureDate.Year >= РейсыОт.SelectedDate.Value.Year &&
                        flight.DepartureDate.Day <= РейсыДо.SelectedDate.Value.Day && flight.DepartureDate.Month <= РейсыДо.SelectedDate.Value.Month && flight.DepartureDate.Year <= РейсыДо.SelectedDate.Value.Year)
                    {
                        p.Add(flight);
                        count++;
                    }
                    else if (РейсыОт.SelectedDate.Value == null && РейсыДо.SelectedDate.Value == null)
                    {
                        p.Add(flight);
                    }

                }
                Период.Inlines.Add("от: " + РейсыОт.SelectedDate.Value.ToShortDateString() + "\tдо: " + РейсыДо.SelectedDate.Value.ToShortDateString());
                КоличествоВыполненых.Inlines.Add("Количество выполненных рейсов: " + count);
                aircraftsGrid.ItemsSource = p;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Печать_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Отчет, "Распечатываем элемент Canvas");
            }
        }

        //public void Set()
        //{
        //    var users = db.Users.ToList();
        //    var passports = db.Passports.ToList();
        //    var flights = db.Flights.ToList();
        //    var tickets = db.TicketTypes.ToList();
        //    var aircrafts = db.Aircrafts.ToList();


        //    //User find_iduser = users.Find(item => item.Id_User == Airticket.Id_User);
        //    //Flight flight = flights.Find(item => item.Id_Flight == Airticket.Id_Flight);
        //    //TicketType ticket = tickets.Find(item => item.Id_TicketType == Airticket.Id_TicketType);
        //    //Passport passport = passports.Find(item => item.Id_Passport == find_iduser.Id_Passport);
        //    //Aircraft aircraft = aircrafts.Find(item => item.Id_Aircaraft == flight.Id_Aircraft);

        //    //Фамилия.Inlines.Add(find_iduser.Surname + " " + "\nPNR:S5HXV" + "\t BN:35");
        //    //Класс.Inlines.Add("CLASS: " + ticket.Name + " BAGS:1 /7" + "\n SIP\tS7 161" + " " + flight.DepartureDate.ToShortDateString());
        //    //Прибытие.Inlines.Add("MSC " + flight.DepartureAirport + " " + flight.ArrivalDate.ToShortDateString());

        //}
    }
}
