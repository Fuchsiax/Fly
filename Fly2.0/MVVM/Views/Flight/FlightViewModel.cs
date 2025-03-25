using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fly2_0.MVVM.ViewModel
{
    class FlightViewModel : ApplicationViewModel
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;

        public FlightViewModel()
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

        public RelayCommand AddFlightCommand
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
                              throw new Exception("Заполните данные нового рейса");
                          }
                          else
                          {
                              db.Configuration.ValidateOnSaveEnabled = false;
                              FlightsList.Add(SelectedFlight);
                              db.Flights.Add(SelectedFlight);
                              db.SaveChanges();
                              MessageBox.Show("Авиарейс добавлен");
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }

        public RelayCommand DeleteFlightCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedFlight == null)
                          {
                              throw new Exception("Выберите авиарейс для удаления");
                          }
                          else
                          {
                              var flight = (from x in db.Flights where x.IdFlight == SelectedFlight.IdFlight select x).First();
                              db.Flights.Remove(flight);
                              FlightsList.Remove(SelectedFlight);
                              db.SaveChanges();
                              MessageBox.Show("Авиарейс удален");

                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }

                  }));
            }
        }
        public RelayCommand EditFlightCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((obj) =>
                  {
                      try
                      {

                          if (SelectedFlight == null)
                          {
                              throw new Exception("Выберите авиарейс для обновления информации");
                          }
                          else
                          {
                              db.Configuration.ValidateOnSaveEnabled = false;
                              Flight flight = SelectedFlight;

                              Flight vm = new Flight()
                              {
                                  IdFlight = flight.IdFlight,
                                  IdAircraft = flight.IdAircraft,
                                  FlightNumber = flight.FlightNumber,
                                  ArrivalAirport = flight.ArrivalAirport,
                                  ArrivalDate = flight.ArrivalDate,
                                  DepartureAirport = flight.DepartureAirport,
                                  DepartureDate = flight.DepartureDate,
                                  Distance = flight.Distance
                              };

                              flight = db.Flights.Find(SelectedFlight.IdFlight);
                              if (flight != null)
                              {
                                  flight.IdFlight = vm.IdFlight;
                                  flight.IdAircraft = vm.IdAircraft;
                                  flight.FlightNumber = vm.FlightNumber;
                                  flight.ArrivalAirport = vm.ArrivalAirport;
                                  flight.ArrivalDate = vm.ArrivalDate;
                                  flight.DepartureAirport = vm.DepartureAirport;
                                  flight.DepartureDate = vm.DepartureDate;
                                  flight.Distance = vm.Distance;
                                  db.Entry(flight).State = EntityState.Modified;
                                  db.SaveChanges();
                                  MessageBox.Show("Информация об авиарейсе изменена");

                              }
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
