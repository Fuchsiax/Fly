using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Fly2_0.MVVM.Model
{
    [Table("TicketTypes")]
    public class TicketType : INotifyPropertyChanged
    {
        [Key]
        public int IdTicketType { get; set; }

        private string name;
        private string description;
        private string bagath;
        private double coefficient;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public double Сoefficient
        {
            get { return coefficient; }
            set
            {
                coefficient = value;
                OnPropertyChanged(nameof(Сoefficient));
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public string Bagath
        {
            get { return bagath; }
            set
            {
                bagath = value;
                OnPropertyChanged(nameof(Bagath));
            }
        }

        public TicketType() { }
        public TicketType(string name, double coefficient, string description, string bagath)
        {
            this.name = name;
            this.coefficient = coefficient;
            this.description = description;
            this.bagath = bagath;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
