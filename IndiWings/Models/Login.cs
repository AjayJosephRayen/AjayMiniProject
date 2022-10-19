using System;
using System.Collections.Generic;

namespace IndiWings.Models
{
    public partial class Login
    {
        public string Username { get; set; } = null!;
        public string? Password { get; set; }
    }
}
