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
    /// Логика взаимодействия для DeleteView.xaml
    /// </summary>
    public partial class DeleteView : UserControl
    {
        ApplicationContext db;
        public DeleteView()
        {
            InitializeComponent();
            DataContext = new SearchViewModel();
            db = new ApplicationContext();
            Report();
        }

        public void Report()
        {
            var users = db.Users.ToList();
            var passports = db.Passports.ToList();
            var flights = db.Flights.ToList();
            var tickets = db.TicketTypes.ToList();
            var aircrafts = db.Aircrafts.ToList();
            var airtickets = db.Airtickets.ToList();

       
           var mostFlight = airtickets.GroupBy(i => i.Id_Flight).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
           var mostAircraft = flights.GroupBy(i => i.Id_Aircraft).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
           var mostTicketType = airtickets.GroupBy(i => i.Id_TicketType).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();

            Flight flight = flights.Find(item => item.Id_Flight == mostFlight);
            TicketType ticket = tickets.Find(item => item.Id_TicketType == mostTicketType);
            Aircraft aircraft = aircrafts.Find(item => item.Id_Aircaraft == mostAircraft);

            ПопулярныйБорт.Inlines.Add("Самый популярный авиаборт: " + aircraft.Name + " " + aircraft.Company);
            ПопулярныйРейс.Inlines.Add("Самый популярный авиарейс: " + flight.DepartureAirport + " - " + flight.ArrivalAirport);
            ПопулярныйТип.Inlines.Add("Самый популярный тип билета: " + ticket.Name);
        }


        private void Печать_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Отчет, "Распечатываем элемент Canvas");
            }
        }
    }
}
