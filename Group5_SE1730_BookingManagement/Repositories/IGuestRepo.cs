using Group5_SE1730_BookingManagement.Models;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface IGuestRepo
    {
        List<Guest> GetGuests();

        Task<Guest?> GetGuestByIdAsync(int guestId);
        Guest GetGuestById(string id);
        void DeleteGuest(Guest guest);
    }
}
