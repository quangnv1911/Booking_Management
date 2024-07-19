using Group5_SE1730_BookingManagement.Repositories.Impl;
using Group5_SE1730_BookingManagement.Repositories;
using Group5_SE1730_BookingManagement.Models;

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

        public async Task<Guest?> GetGuestById(int guestId) {
            return await _guestRepo.GetGuestByIdAsync(guestId);
        }
    }
}
