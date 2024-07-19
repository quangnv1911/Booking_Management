using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Pages.Admins
{
    public class EditModel : PageModel
    {
        private readonly IHomestayService _homestayService;
        private readonly ILogger<EditModel> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IHomestayService homestayService, ILogger<EditModel> logger)
        {
            _homestayService = homestayService;
            _logger = logger;
        }

        [BindProperty]
        public Homestay Homestay { get; set; }

        [BindProperty]
        public IFormFile HotelImage { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            _logger.LogInformation($"Fetching homestay with id {id}");
            Homestay = await _homestayService.GetByIdAsync(id);
            if (Homestay == null)
            {
                _logger.LogWarning($"Homestay with id {id} not found");
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {
            _logger.LogInformation($"Updating homestay with id {id}");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var homestayToUpdate = await _homestayService.GetByIdAsync(id);
            if (homestayToUpdate == null)
            {
                _logger.LogWarning($"Homestay with id {id} not found");
                return NotFound();
            }

            if (HotelImage != null)
            {
                if (!Path.GetExtension(HotelImage.FileName).Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                    !Path.GetExtension(HotelImage.FileName).Equals(".png", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("HotelImage", "Only .jpg and .png files are allowed.");
                    return Page();
                }

                var fileName = Path.GetFileNameWithoutExtension(HotelImage.FileName) + "_" + id + Path.GetExtension(HotelImage.FileName);
                var filePath = Path.Combine("wwwroot", "images", fileName);

                // Ensure the directory exists
                var directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await HotelImage.CopyToAsync(stream);
                }
                homestayToUpdate.Img = fileName;
            }

            homestayToUpdate.HotelName = Homestay.HotelName;
            homestayToUpdate.Address = Homestay.Address;
            homestayToUpdate.City = Homestay.City;
            homestayToUpdate.Phone = Homestay.Phone;
            homestayToUpdate.Email = Homestay.Email;
            homestayToUpdate.Status = Homestay.Status;

            await _homestayService.UpdateAsync(homestayToUpdate);

            return RedirectToPage("HotelManagement");
        }

    }
}
