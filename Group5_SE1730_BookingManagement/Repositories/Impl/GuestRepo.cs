using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    public class GuestRepo : IGuestRepo
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public GuestRepo(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }
        public List<Guest> GetGuests()
        {
            return _context.Guests.ToList();
        }

        public async Task<Guest?> GetGuestByIdAsync(int guestId)
        {
            return await _context.Guests.FindAsync(guestId);
        }
    }
}
