using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fly2_0.MVVM.ViewModel
{
    class AddressViewModel : ApplicationViewModel
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;

        private ObservableCollection<Address> addresslist;
        public ObservableCollection<Address> Addresslist
        {
            get { return addresslist; }
            set
            {
                addresslist = value;
                OnPropertyChanged(nameof(Addresslist));
            }
        }


        private Address selectedAddress;

        public Address SelectedAddress
        {
            get { return selectedAddress; }
            set
            {
                selectedAddress = value;
                OnPropertyChanged(nameof(SelectedAddress));
            }
        }


        public AddressViewModel()
        {
            db = new ApplicationContext();
            db.TicketTypes.Load();
            //Aircraftslist = new ObservableCollection<Aircraft>(db.Aircrafts.Local.ToBindingList());
            Addresslist = new ObservableCollection<Address>(db.Addresses.ToList());
        }

        public RelayCommand AddAddressCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (SelectedAddress == null)
                          {
                              throw new Exception("Заполните поля для добавления нового адреса");
                          }
                          else
                          {

                              db.Addresses.Add(SelectedAddress);
                              db.SaveChanges();
                              Addresslist.Add(SelectedAddress);
                              MessageBox.Show("Адрес добавлен");
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }

                  }));
            }
        }


        public RelayCommand DeleteAddressCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {

                      try
                      {
                          if (SelectedAddress == null)
                          {
                              throw new Exception("Выберите адрес для удаления");
                          }
                          else
                          {
                              var address = (from x in db.Addresses where x.IdAddress == SelectedAddress.IdAddress select x).First();
                              db.Addresses.Remove(address);
                              db.SaveChanges();
                              Addresslist.Remove(SelectedAddress);
                              MessageBox.Show("Адрес удален");
                          }

                      }

                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }

                  }));
            }
        }
        public RelayCommand EditAddressCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((obj) =>
                  {
                      try
                      {
                          if (SelectedAddress == null)
                          {
                              throw new Exception("Выберите адрес для обновления информации");
                          }
                          else
                          {
                              Address address = SelectedAddress;

                              Address vm = new Address()
                              {
                                  IdAddress = address.IdAddress,
                                  Country = address.Country,
                                  City = address.City,
                                  PostAddress = address.PostAddress,
                                  Adress = address.Adress,
                              };

                              address = db.Addresses.Find(SelectedAddress.IdAddress);
                              if (address != null)
                              {
                                  address.IdAddress = vm.IdAddress;
                                  address.Country = vm.Country;
                                  address.City = vm.City;
                                  address.PostAddress = vm.PostAddress;
                                  address.Adress = vm.Adress;
                                  db.Entry(address).State = EntityState.Modified;
                                  db.SaveChanges();
                                  MessageBox.Show("Информация адреса изменена");

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
