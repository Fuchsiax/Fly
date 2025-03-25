using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fly2_0.MVVM.ViewModel
{
    class AirticketsViewModel : ApplicationViewModel
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;

        private ObservableCollection<Airticket> airticketslist;
        public ObservableCollection<Airticket> Airticketslist
        {
            get { return airticketslist; }
            set
            {
                try
                {
                    airticketslist = value;
                    OnPropertyChanged(nameof(Airticketslist));
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
                    OnPropertyChanged(nameof(SelectedAirticket));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        public AirticketsViewModel()
        {
            db = new ApplicationContext();
            db.TicketTypes.Load();
            Airticketslist = new ObservableCollection<Airticket>(db.Airtickets.ToList());
        }

        public RelayCommand AddAirticketCommand
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
                              throw new Exception("Заполните поля для добавления нового авиабилета");
                          }
                          else
                          {
                              List<Flight> flights = db.Flights.ToList();
                              List<TicketType> ticketTypes = db.TicketTypes.ToList();

                              Flight flight = flights.Find(item => item.IdFlight == SelectedAirticket.IdFlight);
                              TicketType ticketType = ticketTypes.Find(item => item.IdTicketType == SelectedAirticket.IdTicketType);
                              SelectedAirticket.Price = flight.Distance * ticketType.Сoefficient + 50;

                              db.Airtickets.Add(SelectedAirticket);
                              db.SaveChanges();
                              MessageBox.Show("Авиабилет добавлен");
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }

                  }));
            }
        }

        public RelayCommand DeleteAirticketCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedAirticket == null)
                          {

                              throw new Exception("Выберите авиабилет для удаления ");
                          }
                          else
                          {
                              var airticket = (from x in db.Airtickets where x.IdAirticket == SelectedAirticket.IdAirticket select x).First();
                              db.Airtickets.Remove(airticket);
                              Airticketslist.Remove(SelectedAirticket);

                              db.SaveChanges();
                              MessageBox.Show("Авиабилет удален");
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        public RelayCommand EditAirticketCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((obj) =>
                  {
                      try
                      {
                          if (SelectedAirticket == null)
                          {
                              throw new Exception("Выберите авиабилет для обновления информации");
                          }
                          else
                          {
                              Airticket airticket = SelectedAirticket;

                              Airticket vm = new Airticket()
                              {

                                  IdAirticket = airticket.IdAirticket,
                                  IdUser = airticket.IdUser,
                                  IdTicketType = airticket.IdTicketType,
                                  IdFlight = airticket.IdFlight,
                                  TicketNumber = airticket.TicketNumber,
                                  Price = airticket.GetPrice(),
                                  SeatOnBoard = airticket.SeatOnBoard,
                              };

                              airticket = db.Airtickets.Find(SelectedAirticket.IdAirticket);
                              if (airticket != null)
                              {
                                  airticket.IdAirticket = vm.IdAirticket;
                                  airticket.IdUser = vm.IdUser;
                                  airticket.IdTicketType = vm.IdTicketType;
                                  airticket.IdFlight = vm.IdFlight;
                                  airticket.TicketNumber = vm.TicketNumber;
                                  airticket.Price = vm.Price;
                                  airticket.SeatOnBoard = vm.SeatOnBoard;


                                  db.Entry(airticket).State = EntityState.Modified;
                                  db.SaveChanges();
                                  OnPropertyChanged(nameof(SelectedAirticket));
                                  OnPropertyChanged(nameof(Airticketslist));
                                  MessageBox.Show("Информация об авиабилете изменена");

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
