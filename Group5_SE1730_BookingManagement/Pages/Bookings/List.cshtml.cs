using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group5_SE1730_BookingManagement.Pages.Bookings
{
    public class ListModel : PageModel
    {
        private readonly ILogger<ListModel> _logger;
        private readonly IBookingService bookingService;
        public async Task OnGetAsync()
        {
        }
    }
}
