using Group5_SE1730_BookingManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    public class HomestayRepo : IHomestayRepo
    {
        private Group_5_SE1730_BookingManagementContext _context;

        public HomestayRepo (Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Homestay homestay)
        {
            await _context.Homestays.AddAsync(homestay);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(long id)
        {
            var homestay = await _context.Homestays.FindAsync(id);
            if (homestay != null)
            {
                _context.Homestays.Remove(homestay);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Homestay>> GetAllHomestayAsync()
        {
            return await _context.Homestays.ToListAsync();
        }

        public async Task<Homestay?> GetHomestayByIdAsync(long id)
        {
            return await _context.Homestays.FindAsync(id);
        }

        public async Task UpdateAsync(Homestay homestay)
        {
            var oldHomestay = await _context.Homestays.FindAsync(homestay.Id);
            if (oldHomestay != null)
            {
                _context.Homestays.Update(homestay);
                await _context.SaveChangesAsync();
            }
        }
    }
}
