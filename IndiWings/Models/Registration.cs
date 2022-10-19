using System;
using System.Collections.Generic;

namespace IndiWings.Models
{
    public partial class Registration
    {
        public Registration()
        {
            Passengercharts = new HashSet<Passengerchart>();
        }

        public int Pid { get; set; }
        public string Fname { get; set; } = null!;
        public string? Lname { get; set; }
        public string? Username { get; set; }
        public string Password { get; set; } = null!;
        public long Phonenumber { get; set; }
        public string Email { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string? Gender { get; set; }

        public virtual ICollection<Passengerchart> Passengercharts { get; set; }
    }
}
