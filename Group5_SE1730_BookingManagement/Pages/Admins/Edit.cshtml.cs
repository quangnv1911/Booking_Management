using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Pages.Admins
{
    public class EditModel : PageModel
    {
        private readonly IHomestayService _homestayService;
        private readonly ILogger<EditModel> _logger;

        public EditModel(IHomestayService homestayService, ILogger<EditModel> logger)
        {
            _homestayService = homestayService;
            _logger = logger;
        }

        [BindProperty]
        public Homestay Homestay { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            _logger.LogInformation("OnGetAsync called with id: {Id}", id);
            Homestay = await _homestayService.GetByIdAsync(id);

            if (Homestay == null)
            {
                _logger.LogWarning("Homestay not found with id: {Id}", id);
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {
            _logger.LogInformation("OnPostAsync called with id: {Id}", id);
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is not valid");
                return Page();
            }

            var homestayToUpdate = await _homestayService.GetByIdAsync(id);

            if (homestayToUpdate == null)
            {
                _logger.LogWarning("Homestay not found with id: {Id}", id);
                return NotFound();
            }

            homestayToUpdate.HotelName = Homestay.HotelName;
            homestayToUpdate.Address = Homestay.Address;
            homestayToUpdate.City = Homestay.City;
            homestayToUpdate.Phone = Homestay.Phone;
            homestayToUpdate.Email = Homestay.Email;
            homestayToUpdate.Status = Homestay.Status;

            try
            {
                await _homestayService.UpdateAsync(homestayToUpdate);
                _logger.LogInformation("Homestay updated successfully with id: {Id}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating homestay with id: {Id}", id);
                return StatusCode(500, "Internal server error");
            }

            return RedirectToPage("HotelManagement");
        }
    }
}
