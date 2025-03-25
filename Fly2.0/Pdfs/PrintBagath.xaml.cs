using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using Fly2_0.MVVM.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Fly2_0.UserBooking
{
    /// <summary>
    /// Логика взаимодействия для PrintBagath.xaml
    /// </summary>
    public partial class PrintBagath : Window
    {
        ApplicationContext db;

        public Airticket Airticket { get; set; }
        public PrintBagath()
        {
            InitializeComponent();
            DataContext = new SearchViewModel();
            db = new ApplicationContext();
        }
        public PrintBagath(Airticket airticket)
        {
            InitializeComponent();
            db = new ApplicationContext();
            Airticket = airticket;
            Set();
        }

        private void Печать_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Билет, "Распечатываем элемент Canvas");
            }
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

            Фамилия.Inlines.Add(find_iduser.Surname + " " + "\nPNR:S5HXV" + "\t BN:35");
            Класс.Inlines.Add("CLASS: " + ticket.Name + " BAGS:1 /7" + "\n SIP\tS7 161" + " " + flight.DepartureDate.ToShortDateString());
            Прибытие.Inlines.Add("MSC " + flight.DepartureAirport + " " + flight.ArrivalDate.ToShortDateString());

        }
    }
}
