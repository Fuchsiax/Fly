using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using Fly2_0.MVVM.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fly2_0.UserBooking
{
    /// <summary>
    /// Логика взаимодействия для PrintAirticket.xaml
    /// </summary>
    public partial class PrintAirticket : Window
    {
        ApplicationContext db;

        public Airticket Airticket { get; set; }
        public PrintAirticket()
        {
            InitializeComponent();
            DataContext = new SearchViewModel();
            db = new ApplicationContext();
        }
        public PrintAirticket(Airticket airticket)
        {
            InitializeComponent();
            db = new ApplicationContext();
            Airticket = airticket;
            Set();
        }

        public void Set()
        {
            var users = db.Users.ToList();
            var passports = db.Passports.ToList();
            var flights = db.Flights.ToList();
            var tickets = db.TicketTypes.ToList();
            var aircrafts = db.Aircrafts.ToList();
            User find_iduser = users.Find(item => item.IdUser == Airticket.IdUser);
            Flight flight = flights.Find(item => item.IdFlight == Airticket.IdFlight);
            TicketType ticket = tickets.Find(item => item.IdTicketType == Airticket.IdTicketType);
            Passport passport = passports.Find(item => item.IdPassport == find_iduser.IdPassport);
            Aircraft aircraft = aircrafts.Find(item => item.IdAircaraft == flight.IdAircraft);

            Пассажир.Inlines.Add(find_iduser.Surname + " " + find_iduser.Name);
            Паспорт.Inlines.Add(passport.Number);
            НомерБилета.Inlines.Add(Airticket.TicketNumber);
            Перевозчик.Inlines.Add(aircraft.Company + " " + aircraft.Name);
            Место.Inlines.Add(Airticket.SeatOnBoard);
            НомерРейса.Inlines.Add("Рейс " + flight.FlightNumber + " " + ticket.Name);
            ВылетАэропорт.Inlines.Add(flight.DepartureAirport);
            ПрибытиеАэропорт.Inlines.Add(flight.ArrivalAirport);
            ВылетДата.Inlines.Add(flight.DepartureDate.ToShortTimeString() + " " + flight.DepartureDate.ToShortDateString());
            ПрибытиеДата.Inlines.Add(flight.ArrivalDate.ToShortTimeString() + " " + flight.ArrivalDate.ToShortDateString());
            ВПути.Inlines.Add(flight.TravelTime.ToString());

        }

        private void Печать_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Билет, "Распечатываем билет");
            }
        }

        private void Багаж_Click(object sender, RoutedEventArgs e)
        {
            PrintBagath printBagath = new PrintBagath(Airticket);
            printBagath.ShowDialog();
        }
    }
}
