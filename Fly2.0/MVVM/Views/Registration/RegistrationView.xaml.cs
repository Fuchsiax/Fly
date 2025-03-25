using Fly2_0.Core;
using Fly2_0.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fly2_0.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : UserControl
    {
        ApplicationContext db;
        public RegistrationView()
        {
            InitializeComponent();
            db = new ApplicationContext();
        }

        private void Регистрация_Click(object sender, RoutedEventArgs e)
        {
            Registration();
        }

        public void Registration()
        {
            try
            {
                List<User> users = db.Users.ToList();
                List<Address> addresses = db.Addresses.ToList();
                List<Passport> passports = db.Passports.ToList();
                List<Contact> contacts = db.Contacts.ToList();

                if (ПравилаУчастия.IsChecked == false)
                {
                    throw new Exception("Примите правила участия в FlyHawk");
                }

                if (NameU.Text.Length > 30)
                {
                    throw new Exception("Имя не должно привышать 30 символов");
                }
                else if (NameU.Text.Length == 0)
                {
                    throw new Exception("Заполните поле Имя");
                }
                if (SurnameU.Text.Length > 30)
                {
                    throw new Exception("Фамилия не должна привышать 30 символов");
                }
                if (SurnameU.Text.Length == 0)
                {
                    throw new Exception("Заполните поле Фамилия");
                }
                if (DateOfBirthU.SelectedDate == null)
                {
                    throw new Exception("Укажите дату рождения");
                }
                if (CountryU.Text.Length > 20)
                {
                    throw new Exception("Название страны не должно привышать 20 символов");
                }
                if (CountryU.Text.Length == 0)
                {
                    throw new Exception("Заполните поле Страна");
                }
                if (CityU.Text.Length > 20)
                {
                    throw new Exception("Название города не должно привышать 20 символов");
                }
                if (CityU.Text.Length == 0)
                {
                    throw new Exception("Заполните поле Город");
                }
                if (PostcodeU.Text.Length == 0)
                {
                    throw new Exception("Заполните поле Индекс");
                }
                if (PostcodeU.Text.Length > 7)
                {
                    throw new Exception("Индекс не может соостоять больше чем из 7 символов");
                }
                if (AddressU.Text.Length > 50)
                {
                    throw new Exception("Адрес не может соостоять больше чем из 50 символов");
                }
                if (AddressU.Text.Length == 0)
                {
                    throw new Exception("Заполните поле Адрес");
                }
                if (PhoneNumberU.Text.Length == 0)
                {
                    throw new Exception("Заполните поле Номер телефона");
                }
                if (PhoneNumberU.Text.Length > 13)
                {
                    throw new Exception("Номер телефона не может состоять больше чем из 13 символов");
                }
                if (EmailU.Text.Length > 50)
                {
                    throw new Exception("Электронная почта не может состоять больше чем из 50 символов");
                }
                if (EmailU.Text.Length == 0)
                {
                    throw new Exception("Заполните поле Электронная почта");
                }
                if (Citizenship.Text.Length == 0)
                {
                    throw new Exception("Заполните поле Национальность");
                }
                if (Citizenship.Text.Length > 30)
                {
                    throw new Exception("Национальность не может состоять больше чем из 30 символов");
                }
                if (ValidityU.SelectedDate == null)
                {
                    throw new Exception("Укажите дату срока действия паспорта");
                }
                if (Passport.Text.Length > 9)
                {
                    throw new Exception("Паспорт не может состоять больше чем из 9 символов");
                }
                if (Passport.Text.Length == 0)
                {
                    throw new Exception("Заполните поле Номер паспорта");
                }

                Address address = new Address(CountryU.Text, CityU.Text, PostcodeU.Text, AddressU.Text);
                Passport passport = new Passport(Citizenship.Text, Passport.Text, ValidityU.SelectedDate);
                Contact contact = new Contact(PhoneNumberU.Text, EmailU.Text);

                Address find_addres = addresses.Find(item => item.Adress == address.Adress && item.City == address.City && item.Country == address.Country && item.PostAddress == address.PostAddress);
                if (find_addres == null)
                {
                    db.Addresses.Add(address);
                }

                Passport find_passport = passports.Find(item => item.Nationality == passport.Nationality && item.Number == passport.Number && item.Validity == passport.Validity);
                if (find_passport == null)
                {
                    db.Passports.Add(passport);
                }
                else
                {
                    throw new Exception("Такой паспорт уже зарегистрирован в системе");
                }
                Contact find_contact = contacts.Find(item => item.Email == contact.Email && item.PhoneNumber == contact.PhoneNumber);
                if (find_contact == null)
                {
                    db.Contacts.Add(contact);
                }
                else
                {
                    throw new Exception("Такие данные уже зарегистрированы в системе");
                }

                db.SaveChanges();

                addresses = db.Addresses.ToList();
                passports = db.Passports.ToList();
                contacts = db.Contacts.ToList();

                int idA;
                int idP;
                int idC;

                Address find_idaddres = addresses.Find(item => item.Adress == address.Adress && item.City == address.City && item.Country == address.Country && item.PostAddress == address.PostAddress);

                idA = find_idaddres.IdAddress;

                Passport find_idpassport = passports.Find(item => item.Nationality == passport.Nationality && item.Number == passport.Number && item.Validity == passport.Validity);

                idP = find_idpassport.IdPassport;

                Contact find_idcontact = contacts.Find(item => item.Email == contact.Email && item.PhoneNumber == contact.PhoneNumber);

                idC = find_idcontact.IdContact;


                if (ПолЖ.IsChecked == true)
                {
                    User user = new User(idP, idC, idA, GenerateNumber(), NameU.Text, SurnameU.Text, DateOfBirthU.SelectedDate, "Ж", GeneratePassword(), "Offline");

                    User find_iduser = users.Find(item => item.ParticipantNumber == user.ParticipantNumber);

                    if (find_iduser == null)
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        MessageBox.Show("Вы успешно зарегистрировались");
                        MessageBox.Show("Ваш номер участника: " + user.ParticipantNumber + "\nВаш пароль: " + user.Password);
                    }

                    else
                    {
                        while (find_iduser.ParticipantNumber == user.ParticipantNumber)
                        {
                            user.ParticipantNumber = GenerateNumber();
                        }

                    }

                }
                else if (ПолМ.IsChecked == true)
                {
                    User user = new User(idP, idC, idA, GenerateNumber(), NameU.Text, SurnameU.Text, DateOfBirthU.SelectedDate, "М", GeneratePassword(), "Offline");

                    User find_iduser = users.Find(item => item.ParticipantNumber == user.ParticipantNumber);
                    if (find_iduser == null)
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        MessageBox.Show("Вы успешно зарегистрировались");
                        MessageBox.Show("Ваш номер участника: " + user.ParticipantNumber + "\nВаш пароль: " + user.Password);
                    }
                    else
                    {
                        while (find_iduser.ParticipantNumber == user.ParticipantNumber)
                        {
                            user.ParticipantNumber = GenerateNumber();
                        }
                    }
                }
                else
                {
                    throw new Exception("Укажите пол");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public string GenerateNumber()
        {
            int num_letters2 = 10;

            char[] letters2 = "ABCDEF1234567890".ToCharArray();

            string login = "";
            Random random = new Random();


            for (int j = 1; j <= num_letters2; j++)
            {
                int letter_num = random.Next(0, letters2.Length - 1);

                login += letters2[letter_num];

            }
            return login;
        }
        public string GeneratePassword()
        {
            int num_letters = 10;
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZqazxswedcvfrtgbnhyujmkiolp1234567890!@#$%&".ToCharArray();
            string password = "";
            Random random = new Random();
            for (int j = 1; j <= num_letters; j++)
            {
                int letter_num = random.Next(0, letters.Length - 1);

                password += letters[letter_num];

            }

            return password;
        }

        private void ValidityU_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            datePicker.SelectedDate = DateTime.Now;
            datePicker.DisplayDateStart = DateTime.Now;
            datePicker.DisplayDateEnd = DateTime.Now.AddYears(10);
        }

        private void DateOfBirthU_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DatePicker datePicker = sender as DatePicker;
            datePicker.SelectedDate = DateTime.Now;
            datePicker.DisplayDateStart = DateTime.Now.AddYears(-100);
            datePicker.DisplayDateEnd = DateTime.Now;
        }
    }
}
