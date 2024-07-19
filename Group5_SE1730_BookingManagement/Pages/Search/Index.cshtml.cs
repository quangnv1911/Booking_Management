using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Group5_SE1730_BookingManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Group5_SE1730_BookingManagement.Services;

namespace Group5_SE1730_BookingManagement.Pages.Search
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //Context
        private readonly Group_5_SE1730_BookingManagementContext _context;
        private readonly IHomestayService _homestayService;

        public IndexModel(ILogger<IndexModel> logger,Group_5_SE1730_BookingManagementContext context, IHomestayService homestayService) {
            _logger = logger;
            _context = context;
            _homestayService = homestayService;
        }

        [BindProperty(SupportsGet = true)]
        public string Destination { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime CheckInDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Nights { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Guests { get; set; }

        public List<Homestay> Homestays { get; set; }

        public List<decimal?> HomestayMinPriceList;

        //public void OnGet()
        //{
        //}

        //public void OnPost(DateTime checkInDate, string destination, int guests, int nights) {

        //}

        public async Task<IActionResult> OnGetAsync()
        {
            IQueryable<Homestay> homestays = from h in _context.Homestays select h;

            if (!string.IsNullOrEmpty(Destination))
            {
                homestays = homestays
                    .Where(h => h.HotelName.Contains(Destination) || h.Address.Contains(Destination) || h.City.Contains(Destination));
            }
            //else {
            //    Homestays = new List<Homestay>();
            //    return Page();
            //}

            if (CheckInDate >= DateTime.Today)
            {
                homestays = homestays.Include(r => r.Rooms)
                    .ThenInclude(b => b.Bookings)
                    .Where(h => h.Rooms.Any(r =>
                    !r.Bookings.Any(b => b.CheckInDate < CheckInDate.AddDays(Nights) && b.CheckOutDate > CheckInDate)));
            }
            //else {
            //    Homestays = new List<Homestay>();
            //    return Page();
            //}

            if (Guests > 0)
            {
                homestays = homestays.Include(r => r.Rooms)
                    .Where(h => h.Rooms.Any(r => r.MaxGuests >= Guests));
            }
            //else
            //{
            //    Homestays = new List<Homestay>();
            //    return Page();
            //}

            Homestays = await homestays.ToListAsync();
            HomestayMinPriceList = new List<decimal?>();
            foreach(var homestay in Homestays)
            {
                HomestayMinPriceList.Add(await _homestayService.GetHomeStaySmallestPriceByIdAsync(homestay.Id));
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            return Page();
        }

        public string GetFormattedDate(DateTime date)
        {
            //var dayOfWeek = date.ToString("ddd", new CultureInfo("vi-VN")); // "CN"
            var day = date.Day.ToString("00"); // "07"
            var month = date.ToString("MMM", new CultureInfo("vi-VN")); // "thg 7"
            var year = date.Year; // "2024"

            return $"{day}/{month}/{year}";
        }
    }
}
