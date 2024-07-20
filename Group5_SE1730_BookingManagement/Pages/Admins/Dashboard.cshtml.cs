using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Pages.Admins
{
    [Authorize(Roles = "Admin")]
    public class DashboardModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly IHomestayService _homestayService;

        public DashboardModel(IBookingService bookingService, IHomestayService homestayService)
        {
            _bookingService = bookingService;
            _homestayService = homestayService;
        }

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-7);

        public StatisticsModel Statistics { get; set; }

        public void OnGet()
        {
            LoadData(StartDate);
        }

        public async Task<JsonResult> OnGetChartDataAsync(DateTime startDate)
        {
            var bookingsPerDay = await _bookingService.GetBookingsPerDayAsync(startDate);

            return new JsonResult(bookingsPerDay);
        }

        private void LoadData(DateTime startDate)
        {
            Statistics = new StatisticsModel
            {
                TotalHotels = _homestayService.GetHomestays().Count(),
                TotalBookings = _bookingService.GetBookings().Count(),
                BookingsPerDay = _bookingService.GetBookings()
                    .Where(b => b.BookingDate.HasValue && b.BookingDate.Value.Date >= startDate.Date)
                    .GroupBy(b => b.BookingDate.Value.DayOfWeek)
                    .Select(g => new { Day = g.Key, Count = g.Count() })
                    .ToDictionary(x => x.Day.ToString(), x => x.Count)
            };
        }
    }

    public class StatisticsModel
    {
        public int TotalHotels { get; set; }
        public int TotalBookings { get; set; }
        public Dictionary<string, int> BookingsPerDay { get; set; }
    }
}
