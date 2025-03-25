using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fly2._0.MVVM.ViewModel
{
    class ChooseFlightViewModel : ApplicationViewModel
    {
        ApplicationContext db;
        RelayCommand addCommand;

        public ChooseFlightViewModel()
        {
            db = new ApplicationContext();
            db.TicketTypes.Load();
            FlightsList = new ObservableCollection<Flight>(db.Flights.ToList());
        }

        private ObservableCollection<Flight> flightslist;
        public ObservableCollection<Flight> FlightsList
        {
            get { return flightslist; }
            set
            {
                flightslist = value;
                OnPropertyChanged("FlightsList");
            }
        }


        private Flight selectedFlight;

        public Flight SelectedFlight
        {
            get { return selectedFlight; }
            set
            {
                selectedFlight = value;
                OnPropertyChanged("SelectedFlight");
            }
        }


        public RelayCommand ChooseFlightCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedFlight == null)
                          {
                              return;
                          }
                          else
                          {
                              
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }


                  }));
            }
        }
    }
}
