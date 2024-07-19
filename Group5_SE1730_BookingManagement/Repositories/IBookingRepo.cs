using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface IBookingRepo
    {
        //Get Booking by id
        Task<Booking?> GetBookingById(int bookingId);
        //Get all bookings
        Task<IEnumerable<Booking?>> GetBookingsAsync();
        //Add booking
        Task AddBooking(Booking booking);
        
        List<Booking> GetBookings();
    }
}
