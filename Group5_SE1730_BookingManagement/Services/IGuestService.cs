using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IGuestService
    {
        List<Guest> GetGuests();

        Task<Guest?> GetGuestById(int guestId);
    }
}
