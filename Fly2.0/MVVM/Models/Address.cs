using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Fly2_0.MVVM.Model
{
    [Table("Addresses")]
    public class Address : INotifyPropertyChanged
    {
        [Key]
        public int IdAddress { get; set; }

        private string country, city, postAddress, adress;

        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public string PostAddress
        {
            get { return postAddress; }
            set
            {
                postAddress = value;
                OnPropertyChanged(nameof(PostAddress));
            }
        }
        public string Adress
        {
            get { return adress; }
            set
            {
                adress = value;
                OnPropertyChanged(nameof(Adress));
            }
        }

        public Address() { }
        public Address(string country, string city, string postAddress, string adress)
        {
            this.country = country;
            this.city = city;
            this.postAddress = postAddress;
            this.adress = adress;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
