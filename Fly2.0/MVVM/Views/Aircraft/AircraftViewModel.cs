using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fly2_0.MVVM.ViewModel
{
    class AircraftViewModel : ApplicationViewModel
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;

        public AircraftViewModel()
        {
            db = new ApplicationContext();
            db.TicketTypes.Load();
            Aircraftslist = new ObservableCollection<Aircraft>(db.Aircrafts.ToList());
        }

        private ObservableCollection<Aircraft> aircraftslist;
        public ObservableCollection<Aircraft> Aircraftslist
        {
            get { return this.aircraftslist; }
            set
            {
                if (aircraftslist == value)
                {
                    return;
                }
                else
                {
                    this.aircraftslist = value;
                    OnPropertyChanged(nameof(Aircraftslist));
                }
            }
        }

        private Aircraft selectedAircraft;

        public Aircraft SelectedAircraft
        {
            get { return selectedAircraft; }
            set
            {
                if (selectedAircraft == value)
                {
                    return;
                }
                else
                {
                    selectedAircraft = value;
                    OnPropertyChanged(nameof(SelectedAircraft));
                }

            }
        }

        public RelayCommand AddAircraftCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedAircraft == null)
                          {
                              throw new Exception("Заполните поля для добавления нового авиаборта");
                          }
                          if (SelectedAircraft != null)
                          {

                              db.Aircrafts.Add(SelectedAircraft);
                              db.SaveChanges();
                              Aircraftslist = new ObservableCollection<Aircraft>(db.Aircrafts.ToList());
                              MessageBox.Show("Авиаборт добавлен");
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }

                  }));
            }
        }


        public RelayCommand DeleteAircraftCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedAircraft == null)
                          {
                              throw new Exception("Выберите авиаборт для удаления");
                          }
                          if (SelectedAircraft != null)
                          {
                              var aircraft = (from x in db.Aircrafts where x.IdAircaraft == SelectedAircraft.IdAircaraft select x).First();
                              db.Aircrafts.Remove(aircraft);
                              Aircraftslist = new ObservableCollection<Aircraft>(db.Aircrafts.ToList());
                              db.SaveChanges();
                              MessageBox.Show("Авиаборт удален");
                          }

                      }

                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }


                  }));
            }
        }
        public RelayCommand EditAircraftCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((obj) =>
                  {
                      try
                      {
                          if (SelectedAircraft == null)
                          {
                              throw new Exception("Выберите авиаборт для обновления информации");
                          }
                          if (SelectedAircraft != null)
                          {
                              Aircraft aircraft = SelectedAircraft;

                              Aircraft vm = new Aircraft()
                              {
                                  IdAircaraft = aircraft.IdAircaraft,
                                  Name = aircraft.Name,
                                  Company = aircraft.Company,
                                  SeatOnBoard = aircraft.SeatOnBoard,
                              };

                              aircraft = db.Aircrafts.Find(SelectedAircraft.IdAircaraft);
                              if (aircraft != null)
                              {
                                  aircraft.IdAircaraft = vm.IdAircaraft;
                                  aircraft.Name = vm.Name;
                                  aircraft.Company = vm.Company;
                                  aircraft.SeatOnBoard = vm.SeatOnBoard;
                                  db.Entry(aircraft).State = EntityState.Modified;
                                  db.SaveChanges();
                                  Aircraftslist = new ObservableCollection<Aircraft>(db.Aircrafts.ToList());
                                  MessageBox.Show("Информация об авиаборте изменена");

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
