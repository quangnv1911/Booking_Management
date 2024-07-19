using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group5_SE1730_BookingManagement.Models; // Thêm không gian tên này
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Pages.Admins
{
    public class DashboardModel : PageModel
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public DashboardModel(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

        public StatisticsModel Statistics { get; set; }

        public async Task OnGetAsync()
        {
            Statistics = new StatisticsModel
            {
                TotalHotels = await _context.Homestays.CountAsync(),
                TotalBookings = await _context.Bookings.CountAsync(),
                BookingsPerDay = await GetBookingsPerDayAsync()
            };
        }

        private async Task<List<int>> GetBookingsPerDayAsync()
        {
            var today = DateTime.Today;
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7);

            var bookings = await _context.Bookings
                .Where(b => b.BookingDate.HasValue && b.BookingDate.Value >= startOfWeek && b.BookingDate.Value < endOfWeek)
                .ToListAsync();

            var bookingsPerDay = bookings
                .GroupBy(b => b.BookingDate.Value.DayOfWeek)
                .Select(g => new { DayOfWeek = g.Key, Count = g.Count() })
                .ToList();

            var result = new List<int>(new int[7]);

            foreach (var booking in bookingsPerDay)
            {
                result[(int)booking.DayOfWeek] = booking.Count;
            }

            return result;
        }
    }
}
