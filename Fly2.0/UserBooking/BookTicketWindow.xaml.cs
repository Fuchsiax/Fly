using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using Fly2._0.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace Fly2._0.UserBooking
{
    /// <summary>
    /// Логика взаимодействия для BookTicketWindow.xaml
    /// </summary>
    public partial class BookTicketWindow : Window
    {
        ApplicationContext db;

        Flight ChoosenFlight { get; set; }
        TicketType ChoosenTicketType { get; set; }

        public BookTicketWindow()
        {
            InitializeComponent();
        }       
        public BookTicketWindow(Flight flight , TicketType ticketType)
        {
            InitializeComponent();
            this.DataContext = new SearchViewModel();
            ChoosenFlight = flight;
            ChoosenTicketType = ticketType;
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void BookingTicket_Loaded(object sender, RoutedEventArgs e)
        {
            db = new ApplicationContext();
            try
            {
                var airtickets = db.Airtickets;
                var users = db.Users.ToList();
                List<Airticket> p = new List<Airticket>();
               
                User find_iduser = users.Find(item => item.Status == "On-line");
                double price = ChoosenFlight.Distance * ChoosenTicketType.Сoefficient + 50;
                Airticket airticket = new Airticket(find_iduser.Id_User,ChoosenTicketType.Id_TicketType,ChoosenFlight.Id_Flight, GenerateTicketNumber(),GenerateSeatNumber(),price);

                p.Add(airticket);
                Grid.ItemsSource = p;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string GenerateSeatNumber()
        {
            int num_letters2 = 2;

            char[] letters2 = "1234567890".ToCharArray();

            string login = "A";
            Random random = new Random();


            for (int j = 1; j <= num_letters2; j++)
            {
                int letter_num = random.Next(0, letters2.Length - 1);

                login += letters2[letter_num];

            }
            return login;
        }
        public string GenerateTicketNumber()
        {
            int num_letters2 = 6;

            char[] letters2 = "ABCDEF1234567890".ToCharArray();

            string login = "";
            Random random = new Random();


            for (int j = 1; j <= num_letters2; j++)
            {
                int letter_num = random.Next(0, letters2.Length - 1);

                login += letters2[letter_num];

            }
            return login;
        }
    }
}
