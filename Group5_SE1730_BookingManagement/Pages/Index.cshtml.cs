using Group5_SE1730_BookingManagement.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace Group5_SE1730_BookingManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty(SupportsGet = true)]
        [Required(ErrorMessage = "Please enter a destination")]
        public string Destination { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Check-In Date is required")]
        public DateTime CheckInDate { get; set; } = DateTime.Today;

        [BindProperty(SupportsGet = true)]
        [Range(1, int.MaxValue, ErrorMessage = "Nights must be greater than 0")]
        public int Nights { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public DateTime CheckOutDate { get; set; } = DateTime.Today.AddDays(1);

        [BindProperty(SupportsGet = true)]
        [Range(0, int.MaxValue, ErrorMessage = "Guests must be greater than 0")]
        public int Guests { get; set; } = 1;
        //public List<Homestay> Homestays { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            ModelState.Clear();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Search/Index", new { Destination, CheckInDate, Nights, Guests });
        }

        public string GetFormattedDate(DateTime date)
        {
            var dayOfWeek = date.ToString("ddd", new CultureInfo("vi-VN")); // "CN"
            var day = date.Day.ToString("00"); // "07"
            var month = date.ToString("MMM", new CultureInfo("vi-VN")); // "thg 7"
            var year = date.Year; // "2024"

            return $"{dayOfWeek}, {day} {month} {year}";
        }

        public void OnChangeCheckInDate(ChangeEventArgs e)
        {
            CheckOutDate = CheckInDate.AddDays(Nights);
        }
    }
}
