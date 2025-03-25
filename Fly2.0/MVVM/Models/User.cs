using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Fly2_0.MVVM.Model
{
    [Table("Users")]
    public class User : INotifyPropertyChanged
    {
        [Key]
        public int IdUser { get; set; }
        public int IdAddress { get; set; }
        public int IdContact { get; set; }
        public int IdPassport { get; set; }

        private string name, surname, password, sex, status;
        private DateTime? dateOfBirth;
        private string participantNumber;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                OnPropertyChanged(nameof(Sex));
            }
        }
        public DateTime? DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }
        public string ParticipantNumber
        {
            get { return participantNumber; }
            set
            {
                participantNumber = value;
                OnPropertyChanged(nameof(ParticipantNumber));
            }
        }
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public User()
        {
            Sex = "М";
            Status = "Offline";
        }
        public User(int idPassport, int idContact, int idAddress, string participantNumber, string name, string surname, DateTime? dateOfBirth, string sex, string password, string status)
        {
            this.IdContact = idContact;
            this.IdPassport = idPassport;
            this.IdAddress = idAddress;
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
