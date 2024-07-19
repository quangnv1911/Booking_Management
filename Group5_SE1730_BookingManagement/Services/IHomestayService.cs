using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IHomestayService
    {
        //Get Homestay by id
        Task<Homestay?> GetHomeStayByIdAsync(long id);
        Task<decimal?> GetHomeStaySmallestPriceByIdAsync(long id);
        List<Homestay> GetHomestaysByGuest(string guestId);
    }
}
