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
    [Table("TicketTypes")]
    public class TicketType : INotifyPropertyChanged
    {
        [Key]
        public int Id_TicketType { get; set; }

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
                OnPropertyChanged("Name");
            }
        }        
        public double Сoefficient
        {
            get { return coefficient; }
            set
            {
                coefficient = value;
                OnPropertyChanged("Сoefficient");
            }
        }        
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }       
        public string Bagath
        {
            get { return bagath; }
            set
            {
                bagath = value;
                OnPropertyChanged("Bagath");
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
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
