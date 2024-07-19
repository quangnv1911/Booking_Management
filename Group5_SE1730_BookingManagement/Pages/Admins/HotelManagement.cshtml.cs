using Microsoft.AspNetCore.Mvc.RazorPages;
using Group5_SE1730_BookingManagement.Services;
using Group5_SE1730_BookingManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Pages.Admins
{
    public class HotelManagementModel : PageModel
    {
        private readonly IHomestayService _homestayService;

        public HotelManagementModel(IHomestayService homestayService)
        {
            _homestayService = homestayService;
        }

        public IList<Homestay> Hotels { get; private set; }

        public async Task OnGetAsync()
        {
            var homestays = await _homestayService.GetAllAsync();
            Hotels = homestays.ToList();
        }
    }
}
