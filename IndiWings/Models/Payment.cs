using System;
using System.Collections.Generic;

namespace IndiWings.Models
{
    public partial class Payment
    {
        public long? CardNo { get; set; }
        public DateTime? Expirydate { get; set; }
        public int? Cvv { get; set; }
        public int? Seats { get; set; }
        public int? Pid { get; set; }
        public int Bookingid { get; set; }
        public double? Price { get; set; }
    }
}
