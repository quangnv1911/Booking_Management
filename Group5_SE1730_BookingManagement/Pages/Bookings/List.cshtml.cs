using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group5_SE1730_BookingManagement.Pages.Bookings
{
    public class ListModel : PageModel
    {
        private readonly ILogger<ListModel> _logger;
        private readonly IBookingService _bookingService;
        private readonly UserManager<Guest> _userManager;

        public List<Booking?> Bookings { get; set; }
        public ListModel(ILogger<ListModel> logger,IBookingService bookingService, UserManager<Guest> userManager)
        {
            _logger = logger;
            _bookingService = bookingService;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync() {
            if(!User.Identity.IsAuthenticated)
                return Redirect("/Login");
            Guest user = await _userManager.GetUserAsync(User);
            Bookings = (List<Booking>)await _bookingService.GetBookingListByGuestId(user.Id);
            return Page();
        }
    }
}
