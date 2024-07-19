using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Group5_SE1730_BookingManagement.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group5_SE1730_BookingManagement.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IHomestayService _homestayService;

        private readonly IRoomService _roomService;

        public Homestay? homestay { get; set; }

        public List<Room?> roomList { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? minValue { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime CheckInDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Nights { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Guests { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHomestayService homestayService, IRoomService roomService) {
            _logger = logger;
            _homestayService = homestayService;
            _roomService = roomService;
        }
        
        public async Task OnGetAsync(long homestayId)
        {
            homestay = await _homestayService.GetHomeStayByIdAsync(homestayId);

            roomList = (List<Room?>)await _roomService.GetRoomListByHomestayIdAsync(homestayId);

            minValue = await _homestayService.GetHomeStaySmallestPriceByIdAsync(homestayId);
        }
    }
}
