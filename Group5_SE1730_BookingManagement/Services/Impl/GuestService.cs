using Group5_SE1730_BookingManagement.Repositories;
using Group5_SE1730_BookingManagement.Models;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepo _guestRepo;

        public GuestService(IGuestRepo guestRepo)
        {
            _guestRepo = guestRepo;
        }

        public List<Guest> GetGuests()
        {
            return _guestRepo.GetGuests();
        }

        public Guest GetGuestById(string id)
        {
            return _guestRepo.GetGuestById(id);
        }

        public void DeleteGuest(string id)
        {
            var guest = _guestRepo.GetGuestById(id);
            if (guest != null)
            {
                _guestRepo.DeleteGuest(guest);
            }
        }
    }
}
