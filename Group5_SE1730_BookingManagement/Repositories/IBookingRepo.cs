using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface IBookingRepo
    {
        List<Booking> GetBookings();
    }
}
