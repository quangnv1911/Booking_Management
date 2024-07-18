using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    public class HomestayRepo : IHomestayRepo
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public HomestayRepo(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }
        public List<Homestay> GetHomestaysByGuest(string guestId)
        {
            return _context.Homestays.Where(g => g.GuestId == guestId).ToList();
        }
    }
}
