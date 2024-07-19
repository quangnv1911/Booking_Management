using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Models.VnPay;
using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group5_SE1730_BookingManagement.Pages.Bookings
{
    public class InvoiceModel : PageModel
    {
        private IRoomService _roomService;
        private IHomestayService _homestayService;
        private IBookingService _bookingService;
        private IVnPayService _vnPayService;
        private IGuestService _guestService;

        [BindProperty(SupportsGet = true)]
        public DateTime CheckInDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Nights { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Guests { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FullName { get; set; }

        public InvoiceModel(IRoomService roomService,
            IHomestayService homestayService,
            IBookingService bookingService,
            IVnPayService vnPayService,
            IGuestService guestService)
        {
            this._roomService = roomService;
            _homestayService = homestayService;
            _bookingService = bookingService;
            _vnPayService = vnPayService;
            _guestService = guestService;
        }

        public Room? roomInfo { get; set; }
        public Homestay? homestayInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int roomId, long homestayId)
        {
            roomInfo = await _roomService.GetRoomByIdAsync(roomId);

            homestayInfo = await _homestayService.GetHomeStayByIdAsync(homestayId);

            if (roomInfo == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int roomId, long homestayId) {

            roomInfo = await _roomService.GetRoomByIdAsync(roomId);

            homestayInfo = await _homestayService.GetHomeStayByIdAsync(homestayId);

            Booking newBooking = new Booking{
                BookingDate = DateTime.Now,
                CheckInDate = CheckInDate,
                CheckOutDate = CheckInDate.AddDays(Nights),
                Status = false,
                GuestId = homestayInfo.GuestId,
                HomestayId = homestayInfo.Id,
                RoomId = roomInfo.Id,
                NumAdults = Guests,
                SpecialReq = "None"
            };

            await _bookingService.AddBooking(newBooking);


            PaymentInfoModel paymentInfo = new PaymentInfoModel();
            paymentInfo.Amount = Convert.ToDouble(roomInfo.Price * Nights);
            paymentInfo.OrderType = "other";
            paymentInfo.OrderDescription = "Booking homestay " + homestayInfo.HotelName + " - " + roomInfo.Name;
            paymentInfo.Name = FullName;
            var paymentURL = _vnPayService.CreatePaymentUrl(paymentInfo, HttpContext);
            return Redirect(paymentURL);
        }
    }
}
