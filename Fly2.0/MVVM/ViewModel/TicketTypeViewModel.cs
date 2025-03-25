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
    class TicketTypeViewModel : ApplicationViewModel
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;

        public TicketTypeViewModel()
        {
            db = new ApplicationContext();
            db.TicketTypes.Load();
            TicketTypeslist = new ObservableCollection<TicketType>(db.TicketTypes.ToList());
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

        public RelayCommand AddTicketTypeCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedTicketType == null)
                          {
                              throw new Exception("Заполните поля для добавления нового авиабилета");
                          }
                          else
                          {

                              db.TicketTypes.Add(SelectedTicketType);
                              db.SaveChanges();
                              MessageBox.Show("Тип билета добавлен");
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }


                  }));
            }
        }

        public RelayCommand DeleteTicketTypeCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      bool oldValidateOnSaveEnabled = db.Configuration.ValidateOnSaveEnabled;
                      try
                      {
                          if (SelectedTicketType == null)
                          {
                              throw new Exception("Выберите тип билета для удаления");
                          }
                          else
                          {
                              var y = (from x in db.TicketTypes where x.Id_TicketType == SelectedTicketType.Id_TicketType select x).First();
                              db.TicketTypes.Remove(y);
                              TicketTypeslist.Remove(SelectedTicketType);
                              db.SaveChanges();
                              MessageBox.Show("Тип билета удален");
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                      finally
                      {
                          db.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
                      }
                  }));
            }
        }
        public RelayCommand EditTicketTypeCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((obj) =>
                  {
                      try
                      {

                          if (SelectedTicketType == null)
                          {
                              throw new Exception("Выберите тип билета для обновления информации");
                          }
                          else
                          {
                              TicketType ticketType = SelectedTicketType;

                              TicketType vm = new TicketType()
                              {
                                  Id_TicketType = ticketType.Id_TicketType,
                                  Name = ticketType.Name,
                                  Сoefficient = ticketType.Сoefficient,
                                  Description = ticketType.Description,
                                  Bagath = ticketType.Bagath,

                              };

                              ticketType = db.TicketTypes.Find(SelectedTicketType.Id_TicketType);
                              if (ticketType != null)
                              {
                                  ticketType.Id_TicketType = vm.Id_TicketType;
                                  ticketType.Name = vm.Name;
                                  ticketType.Сoefficient = vm.Сoefficient;
                                  ticketType.Description = vm.Description;
                                  ticketType.Bagath = vm.Bagath;
                                  db.Entry(ticketType).State = EntityState.Modified;
                                  db.SaveChanges();
                                  MessageBox.Show("Информация о типе билета изменена");

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
