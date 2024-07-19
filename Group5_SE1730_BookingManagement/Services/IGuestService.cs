using Group5_SE1730_BookingManagement.Models;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IGuestService
    {
        List<Guest> GetGuests();

        Task<Guest?> GetGuestById(int guestId);
        Guest GetGuestById(string id);
        void DeleteGuest(string id);
    }
}
