using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IList<Homestay> Hotels { get; set; }

        public async Task OnGetAsync()
        {
            Hotels = (IList<Homestay>)await _homestayService.GetAllAsync();
        }
    }
}
