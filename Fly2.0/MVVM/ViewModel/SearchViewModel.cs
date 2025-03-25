using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using Fly2._0.UserBooking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fly2._0.MVVM.ViewModel
{
    class SearchViewModel : ApplicationViewModel
    {

        ApplicationContext db;
        RelayCommand openCommand;
        RelayCommand chooseticketTypeCommand;
        RelayCommand chooseflightTypeCommand;
        RelayCommand addCommand;
        RelayCommand printCommand;
        RelayCommand printTicketCommand;

        public SearchViewModel()
        {
            db = new ApplicationContext();
            db.TicketTypes.Load();
            db.Flights.Load();
            db.Airtickets.Load();
            FlightsList = new ObservableCollection<Flight>(db.Flights.ToList());
            TicketTypeslist = new ObservableCollection<TicketType>(db.TicketTypes.ToList());
            Airticketslist = new ObservableCollection<Airticket>(db.Airtickets.ToList());
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

        private ObservableCollection<Airticket> airticketslist;
        public ObservableCollection<Airticket> Airticketslist
        {
            get { return airticketslist; }
            set
            {
                try
                {
                    airticketslist = value;
                    OnPropertyChanged("Airticketslist");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }


        private Airticket selectedAirticket;

        public Airticket SelectedAirticket
        {
            get { return selectedAirticket; }
            set
            {
                try
                {
                    selectedAirticket = value;
                    OnPropertyChanged("SelectedAirticket");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private ObservableCollection<TicketType> ticketTypeslist;
        public ObservableCollection<TicketType> TicketTypeslist
        {
            get { return ticketTypeslist; }
            set
            {
                ticketTypeslist = value;
                OnPropertyChanged("TicketTypeslist");
            }
        }


        private TicketType selectedticketType;

        public TicketType SelectedTicketType
        {
            get { return selectedticketType; }
            set
            {
                selectedticketType = value;
                OnPropertyChanged("SelectedTicketType");
            }
        }


        public RelayCommand OpenChooseFlightCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          db.Users.Load();
                          var users = db.Users.ToList();
                          User find_iduser = users.Find(item => item.Status == "On-line");
                          if (SelectedFlight == null)
                          {
                              return;
                          }
                          if(find_iduser == null)
                          {
                              throw new Exception("Вы не зашли в аккаунт");
                          }
                          if (find_iduser != null)
                          {
                              BookingTicket bookingTicket = new BookingTicket();
                              bookingTicket.ShowDialog();
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }


                  }));
            }
        }

        public RelayCommand ChooseFlightCommand
        {
            get
            {
                return chooseflightTypeCommand ??
                  (chooseflightTypeCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedFlight == null)
                          {
                              return;
                          }
                          else
                          {
                              Flight.ChoosenFlight = SelectedFlight;
                              ChooseTicketWindow bookingTicket = new ChooseTicketWindow();
                              bookingTicket.ShowDialog();
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }


                  }));
            }
        }        
        
        public RelayCommand ChooseTicketCommand
        {
            get
            {
                return chooseticketTypeCommand ??
                  (chooseticketTypeCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedTicketType == null)
                          {
                              return;
                          }
                          else
                          {
                              
                              BookTicketWindow bookingTicket = new BookTicketWindow(Flight.ChoosenFlight, SelectedTicketType);
                              bookingTicket.ShowDialog();
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }


                  }));
            }
        }
        public RelayCommand BookTicketCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedAirticket == null)
                          {
                              return;
                          }
                          else
                          {
                              db.Airtickets.Add(SelectedAirticket);
                              db.SaveChanges();
                              MessageBox.Show("Заявка на бронирование билета отправлена");
                          }
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }      
        
        public RelayCommand OpenPrintCommand
        {
            get
            {
                return printCommand ??
                  (printCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedAirticket == null)
                          {
                              return;
                          }
                          else
                          {
                              PrintAirticket bookingTicket = new PrintAirticket(SelectedAirticket);
                              bookingTicket.ShowDialog();
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

