using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;


namespace Fly2._0.MVVM.Model
{
    [Table("Contacts")]
    public class Contact : INotifyPropertyChanged
    {
        [Key]
        public int Id_Contact { get; set; }

        private string phoneNumber, email;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public Contact() { }
        public Contact(string phoneNumber, string email)
        {
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
