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
    [Table("Passports")]
    public class Passport : INotifyPropertyChanged
    {
        [Key]
        public int Id_Passport { get; set; }

        private string nationality, number;
        private DateTime? validity;

        public string Nationality
        {
            get { return nationality; }
            set
            {
                nationality = value;
                OnPropertyChanged("Nationality");
            }
        }        
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }        
        public DateTime? Validity
        {
            get { return validity; }
            set
            {
                validity = value;
                OnPropertyChanged("Validity");
            }
        }

        public Passport() { }
        public Passport(string nationality, string number, DateTime? validity)
        {
            this.nationality = nationality;
            this.number = number;
            this.validity = validity;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
