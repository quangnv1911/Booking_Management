using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IBookingService
    {
        //Add booking
        Task AddBooking(Booking booking);
        //Get booking by id
        Task<Booking?> GetBookingById(int bookingId);
    }
}
