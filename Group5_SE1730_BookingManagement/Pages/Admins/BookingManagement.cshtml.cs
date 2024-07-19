using Group5_SE1730_BookingManagement.Services;
using Group5_SE1730_BookingManagement.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Pages.Admins
{
    public class BookingManagementModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public BookingManagementModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IEnumerable<BookingViewModel> Bookings { get; set; }

        public async Task OnGetAsync()
        {
            Bookings = await _bookingService.GetAllBookingsAsync();
        }
    }
}
