using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fly2_0.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AircraftView.xaml
    /// </summary>
    public partial class AircraftView : UserControl
    {
        private ApplicationContext db;
        public AircraftView()
        {
            InitializeComponent();
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
                    if (aircraft.Name.StartsWith(s) || aircraft.Company.StartsWith(s) || aircraft.SeatOnBoard.ToString().StartsWith(s) || aircraft.IdAircaraft.ToString().StartsWith(s))
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
