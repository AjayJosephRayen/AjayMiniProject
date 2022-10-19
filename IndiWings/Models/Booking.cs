using System;
using System.Collections.Generic;

namespace IndiWings.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? FlightNumber { get; set; }
        public string? PassangerName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? Pincode { get; set; }
        public string? ContactNumber { get; set; }
        public string? ClassType { get; set; }
    }
}
