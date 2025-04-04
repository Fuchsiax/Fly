﻿using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using Fly2_0.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Fly2_0.UserBooking
{
    /// <summary>
    /// Логика взаимодействия для BookingTicket.xaml
    /// </summary>
    public partial class BookingTicket : Window
    {

        ApplicationContext db;
        public BookingTicket()
        {
            InitializeComponent();
            DataContext = new SearchViewModel();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                        if (flight.TravelTime.ToString().StartsWith(s) || flight.IdFlight.ToString().StartsWith(s) || flight.IdAircraft.ToString().StartsWith(s) ||
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
