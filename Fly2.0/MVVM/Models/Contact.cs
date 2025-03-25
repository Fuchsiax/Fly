using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;


namespace Fly2_0.MVVM.Model
{
    [Table("Contacts")]
    public class Contact : INotifyPropertyChanged
    {
        [Key]
        public int IdContact { get; set; }

        private string phoneNumber, email;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
