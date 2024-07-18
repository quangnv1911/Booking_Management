using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;
using Group5_SE1730_BookingManagement.Repositories.Impl;
using Group5_SE1730_BookingManagement.Services;
using Group5_SE1730_BookingManagement.Services.Impl;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Group5_SE1730_BookingManagement.Pages.Patners.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IRoomService _roomService;
        private readonly UserManager<Guest> _userManager;
        private readonly IHomestayService _homestayService;
        public IndexModel(IInvoiceService invoiceService, IRoomService roomService, UserManager<Guest> userManager,
            IHomestayService homestayService)
        {
            _invoiceService = invoiceService;
            _roomService = roomService;
            _userManager = userManager;
            _homestayService = homestayService;
        }

        [BindProperty(SupportsGet = true)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public string? EarningMonth { get; set; }

        [BindProperty(SupportsGet = true)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public string? EarningYear { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? TotalRoom { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? TotalBooking { get; set; }

        [BindProperty(SupportsGet = true)]
        public string[] MoneyPerMonth { get; set; }

        [BindProperty(SupportsGet = true)]
        public string[] RoomPerHomestay { get; set; }
        [BindProperty(SupportsGet = true)]
        public string[] HomestayName { get; set; }

        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            string id;
            if (user != null)
            {
                EarningMonth = _invoiceService.GetMoneyThisMonth(user.Id).ToString("N0", new System.Globalization.CultureInfo("vi-VN")) ;
                EarningYear = _invoiceService.GetMoneyThisYear(user.Id).ToString("N0", new System.Globalization.CultureInfo("vi-VN")); ;
                TotalRoom = _roomService.CountTotalRoomOfUser(user.Id).ToString();
                TotalBooking = _invoiceService.GetTotalCustomerInMonth(user.Id).ToString();
                MoneyPerMonth = _invoiceService.GetMoneyByMonth(user.Id);

                var listHomestay = _homestayService.GetHomestaysByGuest(user.Id);
                string[] homestayRooms = new string[listHomestay.Count];
                string[] homestayNames = new string[listHomestay.Count];
                for (int i = 0; i < listHomestay.Count; i++)
                {
                    homestayNames[i] = listHomestay[i].HotelName;
                    homestayRooms[i] = _roomService.CountRoomByHomestayAndGuestId(listHomestay[i].Id, user.Id).ToString();
                }
                RoomPerHomestay = homestayRooms;
                HomestayName = homestayNames;

            }



        }
    }
}
