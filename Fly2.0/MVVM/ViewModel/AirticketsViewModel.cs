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

                              Flight flight = flights.Find(item => item.Id_Flight == SelectedAirticket.Id_Flight);
                              TicketType ticketType = ticketTypes.Find(item => item.Id_TicketType == SelectedAirticket.Id_TicketType);
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
                              var y = (from x in db.Airtickets where x.Id_Airticket == SelectedAirticket.Id_Airticket select x).First();
                              db.Airtickets.Remove(y);
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


                              //List<Flight> flights = db.Flights.ToList();
                              //List<TicketType> ticketTypes = db.TicketTypes.ToList();

                              //Flight flight = flights.Find(item => item.Id_Flight == SelectedAirticket.Id_Flight);
                              //TicketType ticketType = ticketTypes.Find(item => item.Id_TicketType == SelectedAirticket.Id_TicketType);

                              Airticket vm = new Airticket()
                              {

                                  Id_Airticket = airticket.Id_Airticket,
                                  Id_User = airticket.Id_User,
                                  Id_TicketType = airticket.Id_TicketType,
                                  Id_Flight = airticket.Id_Flight,
                                  TicketNumber = airticket.TicketNumber,
                                  Price = airticket.GetPrice(),
                                  SeatOnBoard = airticket.SeatOnBoard,
                              };

                              airticket = db.Airtickets.Find(SelectedAirticket.Id_Airticket);
                              if (airticket != null)
                              {
                                  airticket.Id_Airticket = vm.Id_Airticket;
                                  airticket.Id_User = vm.Id_User;
                                  airticket.Id_TicketType = vm.Id_TicketType;
                                  airticket.Id_Flight = vm.Id_Flight;
                                  airticket.TicketNumber = vm.TicketNumber;
                                  airticket.Price = vm.Price;
                                  airticket.SeatOnBoard = vm.SeatOnBoard;


                                  db.Entry(airticket).State = EntityState.Modified;
                                  db.SaveChanges();
                                  OnPropertyChanged("SelectedAirticket");
                                  OnPropertyChanged("Airticketslist");
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
