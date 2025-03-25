using Fly2_0.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Fly2_0.MVVM.Model
{
    [Table("Airtickets")]
    public class Airticket : INotifyPropertyChanged
    {
        [Key]
        public int IdAirticket { get; set; }

        public int IdUser { get; set; }
        public int IdTicketType { get; set; }
        public int IdFlight { get; set; }

        private string ticketNumber, seatOnBoard;
        private double price;
        private ApplicationContext db;

        public string TicketNumber
        {
            get { return ticketNumber; }
            set
            {
                ticketNumber = value;
                OnPropertyChanged(nameof(TicketNumber));
            }
        }
        public string SeatOnBoard
        {
            get { return seatOnBoard; }
            set
            {
                seatOnBoard = value;
                OnPropertyChanged(nameof(SeatOnBoard));
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
                        if (value <= 0)
                            throw new Exception("Неверные данные");

                        if (value > 0)
                        {
                            price = value;
                            OnPropertyChanged("Price");
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
        public Airticket(int idUser, int idTicketType, int idFlight, string ticketNumber, string seatOnBoard, double price)
        {
            this.IdUser = idUser;
            this.IdTicketType = idTicketType;
            this.IdFlight = idFlight;
            this.ticketNumber = ticketNumber;
            this.seatOnBoard = seatOnBoard;
            this.price = price;
        }

        public double GetPrice()
        {
            db = new ApplicationContext();
            var flights = db.Flights.ToList();
            var ticketTypes = db.TicketTypes.ToList();

            Flight flight = flights.Find(item => item.IdFlight == IdFlight);
            TicketType ticketType = ticketTypes.Find(item => item.IdTicketType == IdTicketType);

            Price = flight.Distance * ticketType.Сoefficient + 50;
            return Price;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
