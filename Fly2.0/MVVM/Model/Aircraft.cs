using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fly2._0.MVVM.Model
{
    [Table("Aircrafts")]
    public class Aircraft : INotifyPropertyChanged
    {
        [Key]

        public int Id_Aircaraft { get; set; }

        private string name, company;
        int seatOnBoard;
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
                    OnPropertyChanged("Name");
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
                    OnPropertyChanged("Company");
                }

            }
        }
        public int SeatOnBoard
        {
            get { return seatOnBoard; }
            set
            {
                try {

                    if (seatOnBoard == value)
                    {
                        return;
                    }
                    else
                    {
                        if (value < 0)
                        {
                            throw new Exception("Неверные данные");
                        }
                        else if (value > 0)
                        {
                            seatOnBoard = value;
                            OnPropertyChanged("SeatOnBoard");
                        }
                        else
                        {
                            throw new Exception("Неверные данные");
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
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
