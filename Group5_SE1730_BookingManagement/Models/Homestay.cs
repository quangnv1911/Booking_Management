using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Group5_SE1730_BookingManagement.Models
{
    public partial class Homestay
    {
        public Homestay()
        {
            Bookings = new HashSet<Booking>();
            Rooms = new HashSet<Room>();
        }

        public long Id { get; set; }

        [Required(ErrorMessage = "Hotel name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Hotel name cannot contain numbers")]
        public string? HotelName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Address cannot contain numbers")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City cannot contain numbers")]
        public string? City { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Phone number must be between 10 and 15 digits")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        public string? HotelImage { get; set; }

        public bool? Status { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
