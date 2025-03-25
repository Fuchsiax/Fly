using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fly2_0.MVVM.ViewModel
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
                OnPropertyChanged(nameof(TicketTypeslist));
            }
        }


        private TicketType selectedticketType;

        public TicketType SelectedTicketType
        {
            get { return selectedticketType; }
            set
            {
                selectedticketType = value;
                OnPropertyChanged(nameof(SelectedTicketType));
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
                              var ticket = (from x in db.TicketTypes where x.IdTicketType == SelectedTicketType.IdTicketType select x).First();
                              db.TicketTypes.Remove(ticket);
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
                                  IdTicketType = ticketType.IdTicketType,
                                  Name = ticketType.Name,
                                  Сoefficient = ticketType.Сoefficient,
                                  Description = ticketType.Description,
                                  Bagath = ticketType.Bagath,

                              };

                              ticketType = db.TicketTypes.Find(SelectedTicketType.IdTicketType);
                              if (ticketType != null)
                              {
                                  ticketType.IdTicketType = vm.IdTicketType;
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
