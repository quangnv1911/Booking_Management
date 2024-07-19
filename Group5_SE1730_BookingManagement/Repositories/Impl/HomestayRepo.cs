using Group5_SE1730_BookingManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    public class HomestayRepo : IHomestayRepo
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public HomestayRepo(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Homestay>> GetAllAsync()
        {
            return await _context.Homestays.ToListAsync();
        }

        public async Task<Homestay> GetByIdAsync(long id)
        {
            return await _context.Homestays.FindAsync(id);
        }

        public async Task AddAsync(Homestay homestay)
        {
            await _context.Homestays.AddAsync(homestay);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Homestay homestay)
        {
            _context.Homestays.Update(homestay);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var homestay = await _context.Homestays.FindAsync(id);
            if (homestay != null)
            {
                _context.Homestays.Remove(homestay);
                await _context.SaveChangesAsync();
            }
        }
    }
}
