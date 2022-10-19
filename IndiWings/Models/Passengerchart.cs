using System;
using System.Collections.Generic;

namespace IndiWings.Models
{
    public partial class Passengerchart
    {
        public Passengerchart()
        {
            AirlineDetails = new HashSet<AirlineDetail>();
        }

        public int? Pid { get; set; }
        public string? Fname { get; set; }
        public int Seatno { get; set; }
        public int? Bookingid { get; set; }

        public virtual Registration? PidNavigation { get; set; }
        public virtual ICollection<AirlineDetail> AirlineDetails { get; set; }
    }
}
