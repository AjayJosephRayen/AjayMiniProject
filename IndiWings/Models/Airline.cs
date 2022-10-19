using System;
using System.Collections.Generic;

namespace IndiWings.Models
{
    public partial class Airline
    {
        public Airline()
        {
            AirlineDetails = new HashSet<AirlineDetail>();
        }

        public int Cid { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public DateTime? AvailableDates { get; set; }
        public string? FlightTimings { get; set; }
        public int Flightid { get; set; }
        public string? Departurecode { get; set; }
        public string? ArrivalCode { get; set; }
        public double? Price { get; set; }
        public int? AvailableSeats { get; set; }
        public bool? Stat { get; set; }

        public virtual ICollection<AirlineDetail> AirlineDetails { get; set; }
    }
}
