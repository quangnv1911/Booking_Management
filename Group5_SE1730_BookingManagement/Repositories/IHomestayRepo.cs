using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface IHomestayRepo
    {
        List<Homestay> GetHomestaysByGuest(string guestId);
    }
}
