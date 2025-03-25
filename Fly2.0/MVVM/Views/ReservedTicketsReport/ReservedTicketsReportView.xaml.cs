using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using Fly2_0.MVVM.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fly2_0.MVVM.View
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


            var mostFlight = airtickets.GroupBy(i => i.IdFlight).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            var mostAircraft = flights.GroupBy(i => i.IdAircraft).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            var mostTicketType = airtickets.GroupBy(i => i.IdTicketType).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();

            Flight flight = flights.Find(item => item.IdFlight == mostFlight);
            TicketType ticket = tickets.Find(item => item.IdTicketType == mostTicketType);
            Aircraft aircraft = aircrafts.Find(item => item.IdAircaraft == mostAircraft);

            ПопулярныйБорт.Inlines.Add("Самый популярный авиаборт: " + aircraft.Name + " " + aircraft.Company);
            ПопулярныйРейс.Inlines.Add("Самый популярный авиарейс: " + flight.DepartureAirport + " - " + flight.ArrivalAirport);
            ПопулярныйТип.Inlines.Add("Самый популярный тип билета: " + ticket.Name);
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
