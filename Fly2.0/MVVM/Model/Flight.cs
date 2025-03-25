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
    [Table("Flights")]
    public class Flight : INotifyPropertyChanged
    {
        [Key]
        public int Id_Flight { get; set; }

        public int Id_Aircraft { get; set; }

        private string flightNumber, departureAirport, arrivalAirport;
        DateTime departureDate, arrivalDate;
        TimeSpan? travelTime;
        private int distance;
        public string FlightNumber
        {
            get { return flightNumber; }
            set
            {
                flightNumber = value;
                OnPropertyChanged("FlightNumber");
            }
        }
        public string DepartureAirport
        {
            get { return departureAirport; }
            set
            {
                departureAirport = value;
                OnPropertyChanged("DepartureAirport");
            }
        }
        public string ArrivalAirport
        {
            get { return arrivalAirport; }
            set
            {
                arrivalAirport = value;
                OnPropertyChanged("ArrivalAirport");
            }        
        }        
        public DateTime DepartureDate
        {
            get { return departureDate; }
            set
            {
                departureDate = value;
                OnPropertyChanged(nameof(TravelTime));
                //OnPropertyChanged("DepartureDate");
            }        
        }       
        public DateTime ArrivalDate
        {
            get { return arrivalDate; }
            set
            {
                arrivalDate = value;
                OnPropertyChanged(nameof(TravelTime));
                //OnPropertyChanged("ArrivalDate");
            }        
        }        
        public TimeSpan? TravelTime
        {
            get { return arrivalDate - departureDate; }
            set
            {
                travelTime = value;
                OnPropertyChanged("TravelTime");
            }
        }        
        
        public int Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }

        public Flight() 
        {
        }

        public Flight(int Id_Aircraft, string flightNumber, string departureAirport, string arrivalAirport, DateTime departuredate, DateTime arrivaldate, TimeSpan? travelTime, int distance)
        {
            this.Id_Flight = Id_Flight;
            this.Id_Aircraft = Id_Aircraft;
            this.flightNumber = flightNumber;
            this.departureAirport = departureAirport;
            this.arrivalAirport = arrivalAirport;
            this.departureDate =departuredate;
            this.arrivalDate = arrivaldate;
            this.travelTime = travelTime;
            this.distance = distance;
        }

        public static Flight ChoosenFlight { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
