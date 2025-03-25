using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fly2_0.MVVM.ViewModel
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
                OnPropertyChanged(nameof(FlightsList));
            }
        }


        private Flight selectedFlight;

        public Flight SelectedFlight
        {
            get { return selectedFlight; }
            set
            {
                selectedFlight = value;
                OnPropertyChanged(nameof(SelectedFlight));
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
