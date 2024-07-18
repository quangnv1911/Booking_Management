using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class HomestayService : IHomestayService
    {
        private readonly IHomestayRepo _homestayRepo;

        public HomestayService(IHomestayRepo homestayRepo)
        {
            _homestayRepo = homestayRepo;
        }
        public List<Homestay> GetHomestaysByGuest(string guestId)
        {
            return _homestayRepo.GetHomestaysByGuest(guestId);
        }
    }
}
