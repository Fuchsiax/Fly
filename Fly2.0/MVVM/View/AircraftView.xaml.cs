using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using Fly2._0.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AircraftView.xaml
    /// </summary>
    public partial class AircraftView : UserControl
    {
        ApplicationContext db;
        public AircraftView()
        {
            InitializeComponent();
            //DataContext = new AircraftViewModel();
        }

        private void SearchEntity(string s)
        {
            db = new ApplicationContext();
            try
            {
                var aircrafts = db.Aircrafts;
                List<Aircraft> a = db.Aircrafts.ToList();
                List<Aircraft> p = new List<Aircraft>();
                foreach (Aircraft aircraft in aircrafts)
                {
                    if (aircraft.Name.StartsWith(s) || aircraft.Company.StartsWith(s) || aircraft.SeatOnBoard.ToString().StartsWith(s) || aircraft.Id_Aircaraft.ToString().StartsWith(s) )
                    {
                        p.Add(aircraft);
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
