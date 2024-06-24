using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Models
{
    public partial class Guest : IdentityUser
    {
        public Guest()
        {
            Bookings = new HashSet<Booking>();
            Reviews = new HashSet<Review>();
        }

        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public bool? Gender { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
