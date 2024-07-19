using Group5_SE1730_BookingManagement.Models;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IGuestService
    {
        List<Guest> GetGuests();
        Guest GetGuestById(string id);
        void DeleteGuest(string id);
    }
}
