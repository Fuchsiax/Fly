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
    [Table("Addresses")]
    class Address : INotifyPropertyChanged
    {
        [Key]
        public int Id_Address { get; set; }

        private string country, city, postAddress , adress;

        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }        
        public string PostAddress
        {
            get { return postAddress; }
            set
            {
                postAddress = value;
                OnPropertyChanged("PostAddress");
            }
        }       
        public string Adress
        {
            get { return adress; }
            set
            {
                adress = value;
                OnPropertyChanged("Adress");
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
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
