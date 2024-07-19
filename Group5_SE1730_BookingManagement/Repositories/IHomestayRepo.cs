using Group5_SE1730_BookingManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface IHomestayRepo
    {
        Task<IEnumerable<Homestay>> GetAllAsync();
        Task<Homestay> GetByIdAsync(long id);
        Task AddAsync(Homestay homestay);
        Task UpdateAsync(Homestay homestay);
        Task DeleteAsync(long id);
    }
}
