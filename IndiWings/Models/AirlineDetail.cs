using System;
using System.Collections.Generic;

namespace IndiWings.Models
{
    public partial class AirlineDetail
    {
        public int? Maximumseats { get; set; }
        public int? Flightid { get; set; }
        public string Flightname { get; set; } = null!;
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public int? Availableseats { get; set; }
        public int? Seatno { get; set; }

        public virtual Airline? Flight { get; set; }
        public virtual Passengerchart? SeatnoNavigation { get; set; }
    }
}
