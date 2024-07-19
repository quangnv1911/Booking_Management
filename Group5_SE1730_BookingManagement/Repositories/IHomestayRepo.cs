using Group5_SE1730_BookingManagement.Models;
using System.Collections;

namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface IHomestayRepo
    {
        Task<IEnumerable<Homestay>> GetAllHomestayAsync();
        Task<Homestay?> GetHomestayByIdAsync(long id);
        Task AddAsync (Homestay homestay);
        Task UpdateAsync (Homestay homestay);
        Task DeleteByIdAsync (long id);
        List<Homestay> GetHomestaysByGuest(string guestId);
    }
}
