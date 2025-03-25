using Fly2._0.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Fly2._0.MVVM.Model
{
    [Table("Airtickets")]
    public class Airticket :  INotifyPropertyChanged
    {
        [Key]
        public int Id_Airticket { get; set; }

        public int Id_User { get; set; }
        public int Id_TicketType { get; set; }
        public int Id_Flight { get; set; } 

        private string ticketNumber, seatOnBoard;
        double price;
        ApplicationContext db;

        public string TicketNumber
        {
            get { return ticketNumber; }
            set
            {
                ticketNumber = value;
                OnPropertyChanged("TicketNumber");
            }
        }
        public string SeatOnBoard
        {
            get { return seatOnBoard; }
            set
            {
                seatOnBoard = value;
                OnPropertyChanged("SeatOnBoard");
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                try
                {
                    if (price != value)
                    {
                        if (value < 0)
                        {
                            throw new Exception("Неверные данные");
                        }
                        else if (value > 0)
                        {
                            price = value;
                            OnPropertyChanged("Price");
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

        public Airticket() { }
        public Airticket(int Id_User , int Id_TicketType, int Id_Flight,  string ticketNumber, string seatOnBoard, double price)
        {
            this.Id_User = Id_User;
            this.Id_TicketType = Id_TicketType;
            this.Id_Flight = Id_Flight;
            this.ticketNumber = ticketNumber;
            this.seatOnBoard = seatOnBoard;
            this.price = price;
        }


        public double GetPrice()
        {
            db = new ApplicationContext();
            List<Flight> flights = db.Flights.ToList();
            List<TicketType> ticketTypes = db.TicketTypes.ToList();

            Flight flight = flights.Find(item => item.Id_Flight == Id_Flight);
            TicketType ticketType = ticketTypes.Find(item => item.Id_TicketType ==Id_TicketType);
            
            Price = flight.Distance * ticketType.Сoefficient + 50;
            return Price;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
