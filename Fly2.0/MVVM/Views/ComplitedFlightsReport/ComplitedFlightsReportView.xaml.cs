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
                printDialog.PrintVisual(Отчет, "Распечатываем");
            }
        }
    }
}
