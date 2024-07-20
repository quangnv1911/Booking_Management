using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Pages.Admins
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly IHomestayService _homestayService;

        public DeleteModel(IHomestayService homestayService)
        {
            _homestayService = homestayService;
        }

        [BindProperty]
        public Homestay Homestay { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            Homestay = await _homestayService.GetByIdAsync(id);

            if (Homestay == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {
            await _homestayService.DeleteAsync(id);

            return RedirectToPage("HotelManagement");
        }
    }
}
