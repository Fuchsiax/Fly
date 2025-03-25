using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Fly2_0.MVVM.Model
{
    [Table("Passports")]
    public class Passport : INotifyPropertyChanged
    {
        [Key]
        public int IdPassport { get; set; }

        private string nationality, number;
        private DateTime? validity;

        public string Nationality
        {
            get { return nationality; }
            set
            {
                nationality = value;
                OnPropertyChanged(nameof(Nationality));
            }
        }
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }
        public DateTime? Validity
        {
            get { return validity; }
            set
            {
                validity = value;
                OnPropertyChanged(nameof(Validity));
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
