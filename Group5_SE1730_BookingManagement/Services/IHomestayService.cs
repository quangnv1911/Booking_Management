using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IHomestayService
    {
        List<Homestay> GetHomestaysByGuest(string guestId);
    }
}
