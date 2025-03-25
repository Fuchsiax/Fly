using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Fly2_0.MVVM.Model
{
    [Table("Flights")]
    public class Flight : INotifyPropertyChanged
    {
        [Key]
        public int IdFlight { get; set; }
        public int IdAircraft { get; set; }

        private string flightNumber, departureAirport, arrivalAirport;
        private DateTime departureDate, arrivalDate;
        private int distance;

        public string FlightNumber
        {
            get { return flightNumber; }
            set
            {
                flightNumber = value;
                OnPropertyChanged(nameof(FlightNumber));
            }
        }

        public string DepartureAirport
        {
            get { return departureAirport; }
            set
            {
                departureAirport = value;
                OnPropertyChanged(nameof(DepartureAirport));
            }
        }

        public string ArrivalAirport
        {
            get { return arrivalAirport; }
            set
            {
                arrivalAirport = value;
                OnPropertyChanged(nameof(ArrivalAirport));
            }
        }

        public DateTime DepartureDate
        {
            get { return departureDate; }
            set
            {
                departureDate = value;
                OnPropertyChanged(nameof(TravelTime));
            }
        }

        public DateTime ArrivalDate
        {
            get { return arrivalDate; }
            set
            {
                arrivalDate = value;
                OnPropertyChanged(nameof(TravelTime));
            }
        }

        public TimeSpan? TravelTime => arrivalDate - departureDate;

        public int Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                OnPropertyChanged(nameof(Distance));
            }
        }

        public Flight()
        {
        }

        public Flight(int Id_Aircraft, string flightNumber, string departureAirport, string arrivalAirport, DateTime departuredate, DateTime arrivaldate, int distance)
        {
            this.IdAircraft = Id_Aircraft;
            this.flightNumber = flightNumber;
            this.departureAirport = departureAirport;
            this.arrivalAirport = arrivalAirport;
            this.departureDate = departuredate;
            this.arrivalDate = arrivaldate;
            this.distance = distance;
        }

        public static Flight ChoosenFlight { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
