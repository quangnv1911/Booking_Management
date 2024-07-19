using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Pages.Admins
{
    public class CreateModel : PageModel
    {
        private readonly IHomestayService _homestayService;

        public CreateModel(IHomestayService homestayService)
        {
            _homestayService = homestayService;
        }

        [BindProperty]
        public Homestay Homestay { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _homestayService.AddAsync(Homestay);

            return RedirectToPage("HotelManagement");
        }
    }
}
