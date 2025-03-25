using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fly2_0.MVVM.ViewModel
{
    class ContactViewModel : ApplicationViewModel
    {

        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;

        public ContactViewModel()
        {
            db = new ApplicationContext();
            db.TicketTypes.Load();
            Contactlist = new ObservableCollection<Contact>(db.Contacts.ToList());
        }

        private ObservableCollection<Contact> contactlist;
        public ObservableCollection<Contact> Contactlist
        {
            get { return contactlist; }
            set
            {
                contactlist = value;
                OnPropertyChanged(nameof(Contactlist));
            }
        }

        private Contact selectedContact;

        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        public RelayCommand AddContactCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedContact == null)
                          {
                              throw new Exception("Заполните поля для добавления новых контактов пользователя");
                          }
                          else
                          {
                              Contactlist.Add(SelectedContact);
                              db.Contacts.Add(SelectedContact);
                              db.SaveChanges();
                              MessageBox.Show("Контакты пользователя добавлены");
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }

                  }));
            }
        }

        public RelayCommand DeleteContactCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedContact == null)
                          {
                              throw new Exception("Выберите контакты пользователя для удаления");
                          }
                          else
                          {
                              var y = (from x in db.Contacts where x.IdContact == SelectedContact.IdContact select x).First();
                              db.Contacts.Remove(y);
                              Contactlist.Remove(SelectedContact);
                              db.SaveChanges();
                              MessageBox.Show("Контакты пользователя удалены");
                          }

                      }

                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        public RelayCommand EditContactCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((obj) =>
                  {
                      try
                      {
                          if (SelectedContact == null)
                          {
                              throw new Exception("Выберите контакты пользователя для обновления информации");
                          }
                          else
                          {
                              Contact contact = SelectedContact;

                              Contact vm = new Contact()
                              {
                                  IdContact = contact.IdContact,
                                  PhoneNumber = contact.PhoneNumber,
                                  Email = contact.Email
                              };

                              contact = db.Contacts.Find(SelectedContact.IdContact);
                              if (contact != null)
                              {
                                  contact.IdContact = vm.IdContact;
                                  contact.PhoneNumber = vm.PhoneNumber;
                                  contact.Email = vm.Email;
                                  db.Entry(contact).State = EntityState.Modified;
                                  db.SaveChanges();
                                  MessageBox.Show("Информация контактов пользователя изменена");

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
