using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fly2._0.MVVM.ViewModel
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
            //Aircraftslist = new ObservableCollection<Aircraft>(db.Aircrafts.Local.ToBindingList());
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
                          if(SelectedAircraft!=null)
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
                              var y = (from x in db.Aircrafts where x.Id_Aircaraft == SelectedAircraft.Id_Aircaraft select x).First();
                              db.Aircrafts.Remove(y);
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
                                  Id_Aircaraft = aircraft.Id_Aircaraft,
                                  Name = aircraft.Name,
                                  Company = aircraft.Company,
                                  SeatOnBoard = aircraft.SeatOnBoard,
                              };

                              aircraft = db.Aircrafts.Find(SelectedAircraft.Id_Aircaraft);
                              if (aircraft != null)
                              {
                                  aircraft.Id_Aircaraft = vm.Id_Aircaraft;
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
