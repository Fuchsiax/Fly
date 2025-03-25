using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using Fly2._0.MVVM.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fly2._0.UserBooking
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
            User find_iduser = users.Find(item => item.Id_User == Airticket.Id_User);
            Flight flight = flights.Find(item => item.Id_Flight == Airticket.Id_Flight);
            TicketType ticket = tickets.Find(item => item.Id_TicketType == Airticket.Id_TicketType);
            Passport passport = passports.Find(item => item.Id_Passport == find_iduser.Id_Passport);
            Aircraft aircraft = aircrafts.Find(item => item.Id_Aircaraft == flight.Id_Aircraft);

            Пассажир.Inlines.Add(find_iduser.Surname + " " + find_iduser.Name);
            Паспорт.Inlines.Add(passport.Number);
            НомерБилета.Inlines.Add(Airticket.TicketNumber);
            Перевозчик.Inlines.Add(aircraft.Company+ " " + aircraft.Name);
            Место.Inlines.Add(Airticket.SeatOnBoard);
            НомерРейса.Inlines.Add("Рейс " + flight.FlightNumber + " " +ticket.Name);
            ВылетАэропорт.Inlines.Add(flight.DepartureAirport);
            ПрибытиеАэропорт.Inlines.Add(flight.ArrivalAirport);
            ВылетДата.Inlines.Add(flight.DepartureDate.ToShortTimeString() + " " + flight.DepartureDate.ToShortDateString());
            ПрибытиеДата.Inlines.Add(flight.ArrivalDate.ToShortTimeString() + " "+ flight.ArrivalDate.ToShortDateString());
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
