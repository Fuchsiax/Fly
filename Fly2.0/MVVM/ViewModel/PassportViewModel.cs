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
    class PassportViewModel : ApplicationViewModel
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;

        public PassportViewModel()
        {
            db = new ApplicationContext();
            db.TicketTypes.Load();
            //Aircraftslist = new ObservableCollection<Aircraft>(db.Aircrafts.Local.ToBindingList());
            Passportlist = new ObservableCollection<Passport>(db.Passports.ToList());
        }

        private ObservableCollection<Passport> passportlist;
        public ObservableCollection<Passport> Passportlist
        {
            get { return passportlist; }
            set
            {
                passportlist = value;
                OnPropertyChanged("Passportlist");
            }
        }


        private Passport selectedPassport;

        public Passport SelectedPassport
        {
            get { return selectedPassport; }
            set
            {
                selectedPassport = value;
                OnPropertyChanged("SelectedPassport");
            }
        }

        public RelayCommand AddPassportCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedPassport == null)
                          {
                              throw new Exception("Заполните поля для добавления нового паспорта");
                          }
                          else
                          {
                              Passportlist.Add(SelectedPassport);
                              db.Passports.Add(SelectedPassport);
                              db.SaveChanges();
                              MessageBox.Show("Паспорт добавлен");
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }

                  }));
            }
        }


        public RelayCommand DeletePassportCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedPassport == null)
                          {
                              throw new Exception("Выберите паспорт для удаления");
                          }
                          else
                          {
                              var y = (from x in db.Passports where x.Id_Passport == SelectedPassport.Id_Passport select x).First();
                              db.Passports.Remove(y);
                              Passportlist.Remove(SelectedPassport);
                              db.SaveChanges();
                              MessageBox.Show("Паспорт удален");
                          }

                      }

                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        public RelayCommand EditPassportCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((obj) =>
                  {
                      try
                      {
                          if (SelectedPassport == null)
                          {
                              throw new Exception("Выберите паспорт для обновления информации");
                          }
                          else
                          {
                              Passport passport = SelectedPassport;

                              Passport vm = new Passport()
                              {
                                  Id_Passport = passport.Id_Passport,
                                  Nationality = passport.Nationality,
                                  Validity = passport.Validity,
                                  Number = passport.Number,
                              };

                              passport = db.Passports.Find(SelectedPassport.Id_Passport);
                              if (passport != null)
                              {
                                  passport.Id_Passport = vm.Id_Passport;
                                  passport.Nationality = vm.Nationality;
                                  passport.Validity = vm.Validity;
                                  passport.Number = vm.Number;
                                  db.Entry(passport).State = EntityState.Modified;
                                  db.SaveChanges();
                                  MessageBox.Show("Информация паспорта изменена");

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
