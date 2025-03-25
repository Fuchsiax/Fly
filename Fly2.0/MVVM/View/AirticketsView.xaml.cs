using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using Fly2._0.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace Fly2._0.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AirticketsView.xaml
    /// </summary>
    public partial class AirticketsView : UserControl
    {
        ApplicationContext db;
        public AirticketsView()
        {
            InitializeComponent();
            DataContext = new AirticketsViewModel();
        }

        private void SearchEntity(string s)
        {
            db = new ApplicationContext();
            try
            {
                var airtickets = db.Airtickets;
                List<Airticket> p = new List<Airticket>();
                foreach (Airticket airticket in airtickets)
                {
                    if (airticket.TicketNumber.StartsWith(s) || airticket.SeatOnBoard.StartsWith(s) || airticket.Price.ToString().StartsWith(s) ||
                    airticket.Id_User.ToString().StartsWith(s) || airticket.Id_TicketType.ToString().StartsWith(s) || airticket.Id_Flight.ToString().StartsWith(s)
                    || airticket.Id_Airticket.ToString().StartsWith(s))
                    {
                        p.Add(airticket);
                    }
                }
                Grid.ItemsSource = p;
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
