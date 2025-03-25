using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fly2._0.MVVM.Model
{
    [Table("Users")]
    public class User : INotifyPropertyChanged
    {
        [Key]
        public int Id_User { get; set; }
        public int Id_Address { get; set; }
        public int Id_Contact { get; set; }
        public int Id_Passport { get; set; }

        private string name, surname, password ,sex , status;
        private DateTime? dateOfBirth;
        private string participantNumber;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public string Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                OnPropertyChanged("Sex");
            }
        }
        public DateTime? DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }       
        public string ParticipantNumber
        {
            get { return participantNumber; }
            set
            {
                participantNumber = value;
                OnPropertyChanged("ParticipantNumber");
            }
        }
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public User()
        {
            Sex = "М";
            Status = "Offline";
        }
        public User( int id_passport,int id_contact,int id_address, string participantNumber, string name, string surname, DateTime? dateOfBirth, string sex, string password , string status)
        {
            this.Id_Contact = id_contact;
            this.Id_Passport = id_passport;
            this.Id_Address = id_address;
            this.participantNumber = participantNumber;
            this.name = name;
            this.surname = surname;
            this.dateOfBirth = dateOfBirth;
            this.sex = sex;
            this.password = password;
            this.status = status;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
