using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface IGuestRepo
    {
        List<Guest> GetGuests();

        Task<Guest?> GetGuestByIdAsync(int guestId);
    }
}
