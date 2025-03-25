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
    /// Логика взаимодействия для FlightView.xaml
    /// </summary>
    public partial class FlightView : UserControl
    {
        ApplicationContext db;
        public FlightView()
        {
            InitializeComponent();
            DataContext = new FlightViewModel();
        }

        private void ДатаВылета_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            datePicker.SelectedDate = DateTime.Now;
            datePicker.DisplayDateStart = DateTime.Now.AddMonths(-6);
            datePicker.DisplayDateEnd = DateTime.Now.AddMonths(6);
        }

        private void ДатаПрилета_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            datePicker.SelectedDate = DateTime.Now;
            datePicker.DisplayDateStart = DateTime.Now.AddMonths(-6);
            datePicker.DisplayDateEnd = DateTime.Now.AddMonths(6);
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
                    if (flight.TravelTime.ToString().StartsWith(s) || flight.IdFlight.ToString().StartsWith(s) || flight.IdAircraft.ToString().StartsWith(s) ||
                    flight.FlightNumber.StartsWith(s) || flight.Distance.ToString().StartsWith(s) || flight.DepartureDate.ToString().StartsWith(s)
                    || flight.DepartureAirport.StartsWith(s) || flight.ArrivalDate.ToString().StartsWith(s) || flight.ArrivalAirport.StartsWith(s))
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

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = Search.Text;
            SearchEntity(s);
        }
    }
}
