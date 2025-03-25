using Fly2._0.Core;
using Fly2._0.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Fly2._0.MVVM.ViewModel
{
    class UsersViewModel : ApplicationViewModel
    {
        ApplicationContext db;
        RelayCommand addCommand;
        RelayCommand editCommand;
        RelayCommand deleteCommand;

        public UsersViewModel()
        {
            db = new ApplicationContext();
            db.TicketTypes.Load();
            //Aircraftslist = new ObservableCollection<Aircraft>(db.Aircrafts.Local.ToBindingList());
            Userslist = new ObservableCollection<User>(db.Users.ToList());
        }
        private ObservableCollection<User> userslist;
        public ObservableCollection<User> Userslist
        {
            get { return userslist; }
            set
            {
                try
                {
                    userslist = value;
                    OnPropertyChanged("Userslist");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }


        private User selectedUser;

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                try
                {
                    selectedUser = value;
                    OnPropertyChanged("SelectedUser");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        public RelayCommand AddUserCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      try
                      {
                          if (SelectedUser == null)
                          {
                              throw new Exception("Заполните поля для добавления нового пользователя");
                          }
                          else
                          {
                              Userslist.Add(SelectedUser);
                              db.Users.Add(SelectedUser);
                              db.SaveChanges();
                              MessageBox.Show("Пользователь добавлен");
                          }

                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }

                  }));
            }
        }

        public RelayCommand EditUserCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      try
                      {
                          if (SelectedUser == null)
                          {
                              throw new Exception("Выберите пользователя для обновления информации");
                          }
                          else
                          {
                              User user = SelectedUser;

                              User vm = new User()
                              {
                                  Id_User = user.Id_User,
                                  Id_Address = user.Id_Address,
                                  Name = user.Name,
                                  Surname = user.Surname,
                                  ParticipantNumber = user.ParticipantNumber,
                                  Password = user.Password,
                                  Sex = user.Sex,
                                  Status = user.Status,
                              };

                              user = db.Users.Find(SelectedUser.Id_User);
                              if (user != null)
                              {
                                  user.Id_User = vm.Id_User;
                                  user.Id_Address = vm.Id_Address;
                                  user.Name = vm.Name;
                                  user.Surname = vm.Surname;
                                  user.ParticipantNumber = vm.ParticipantNumber;
                                  user.Password = vm.Password;
                                  user.Sex = vm.Sex;
                                  user.Status = vm.Status;
                                  db.Entry(user).State = EntityState.Modified;
                                  db.SaveChanges();
                                  MessageBox.Show("Информация о пользователе изменена");

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

        public RelayCommand DeleteUserCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {

                      try
                      {
                          if (SelectedUser == null)
                          {

                              throw new Exception("Выберите пользователя для удаления ");
                          }
                          else
                          {
                              var y = (from x in db.Users where x.Id_User == SelectedUser.Id_User select x).First();
                              db.Users.Remove(y);
                              Userslist.Remove(SelectedUser);
                              db.SaveChanges();
                              MessageBox.Show("Пользователь удален");
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
