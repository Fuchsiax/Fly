using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Fly2_0.MVVM.Model
{
    [Table("Aircrafts")]
    public class Aircraft : INotifyPropertyChanged
    {
        [Key]

        public int IdAircaraft { get; set; }

        private string name, company;
        private int seatOnBoard;

        public string Name
        {
            get { return name; }
            set
            {
                if (name == value)
                {
                    return;
                }
                else
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string Company
        {
            get { return company; }
            set
            {
                if (company == value)
                {
                    return;
                }
                else
                {
                    company = value;
                    OnPropertyChanged(nameof(Company));
                }
            }
        }
        public int SeatOnBoard
        {
            get { return seatOnBoard; }
            set
            {
                try
                {
                    if (seatOnBoard != value)
                    {
                        if (value <= 0)
                            throw new Exception("Неверные данные");
                        
                        if (value > 0)
                        {
                            seatOnBoard = value;
                            OnPropertyChanged(nameof(SeatOnBoard));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public Aircraft() { }
        public Aircraft(string name, string company, int seatOnBoard)
        {
            this.name = name;
            this.company = company;
            this.seatOnBoard = seatOnBoard;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
