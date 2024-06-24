using System;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Models
{
    public partial class Invoice
    {
        public long Id { get; set; }
        public long? BookingId { get; set; }
        public string? GuestId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? Notify { get; set; }
        public bool? Status { get; set; }
        public long? DiscountId { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Discount? Discount { get; set; }
    }
}
