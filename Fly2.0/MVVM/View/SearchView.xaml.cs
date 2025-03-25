using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using Fly2._0.MVVM.ViewModel;
using Fly2._0.UserBooking;
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
    /// Логика взаимодействия для SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        ApplicationContext db;
        public SearchView()
        {
            InitializeComponent();
            DataContext = new SearchViewModel();
        }

        private void SearchEntity(string s)
        {
            db = new ApplicationContext();
            try
            {
                var flights = db.Flights;
                List<Flight> p = new List<Flight>();
                foreach (Flight flight in flights)
                {
                    if (flight.DepartureDate.Day >= DateTime.Now.Day && flight.DepartureDate.Month >= DateTime.Now.Month && flight.DepartureDate.Year == DateTime.Now.Year)
                    {
                        if (flight.TravelTime.ToString().StartsWith(s) || flight.Id_Flight.ToString().StartsWith(s) || flight.Id_Aircraft.ToString().StartsWith(s) ||
                    flight.FlightNumber.StartsWith(s) || flight.Distance.ToString().StartsWith(s) || flight.DepartureDate.ToString().StartsWith(s)
                    || flight.DepartureAirport.StartsWith(s) || flight.ArrivalDate.ToString().StartsWith(s) || flight.ArrivalAirport.StartsWith(s))
                        {
                            p.Add(flight);
                        }
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Timetable();
        }

        private void ДатаОтправления_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            db = new ApplicationContext();
            try
            {
                var flights = db.Flights;
                List<Flight> p = new List<Flight>();
                foreach (Flight flight in flights)
                {
                    if (flight.DepartureDate.Day == ДатаОтправления.SelectedDate.Value.Day && flight.DepartureDate.Month == ДатаОтправления.SelectedDate.Value.Month && flight.DepartureDate.Year == ДатаОтправления.SelectedDate.Value.Year)
                    {
                        p.Add(flight);
                    }
                }
                aircraftsGrid.ItemsSource = p;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Timetable()
        {
            db = new ApplicationContext();
            try
            {
                var flights = db.Flights;
                List<Flight> p = new List<Flight>();
                foreach (Flight flight in flights)
                {
                    if (flight.DepartureDate.Day >= DateTime.Now.Day && flight.DepartureDate.Month >= DateTime.Now.Month && flight.DepartureDate.Year == DateTime.Now.Year)
                    {
                        p.Add(flight);
                    }

                }
                aircraftsGrid.ItemsSource = p;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Очистить_дату_Click(object sender, RoutedEventArgs e)
        {
            Timetable();
        }

        private void ДатаОтправления_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            datePicker.SelectedDate = DateTime.Now;
            datePicker.DisplayDateStart = DateTime.Now;
            datePicker.DisplayDateEnd = DateTime.Now.AddMonths(6);
        }
    }
}
