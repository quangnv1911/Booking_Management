using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class HomestayService : IHomestayService
    {
        private readonly IHomestayRepo _homestayRepo;

        public HomestayService(IHomestayRepo homestayRepo)
        {
            _homestayRepo = homestayRepo;
        }

        public async Task<IEnumerable<Homestay>> GetAllAsync()
        {
            return await _homestayRepo.GetAllAsync();
        }

        public async Task<Homestay> GetByIdAsync(long id)
        {
            return await _homestayRepo.GetByIdAsync(id);
        }

        public async Task AddAsync(Homestay homestay)
        {
            await _homestayRepo.AddAsync(homestay);
        }

        public async Task UpdateAsync(Homestay homestay)
        {
            await _homestayRepo.UpdateAsync(homestay);
        }

        public async Task DeleteAsync(long id)
        {
            await _homestayRepo.DeleteAsync(id);
        }
    }
}
