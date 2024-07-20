using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Pages.Admins
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IHomestayService _homestayService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(IHomestayService homestayService, IWebHostEnvironment webHostEnvironment)
        {
            _homestayService = homestayService;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Homestay Homestay { get; set; }

        [BindProperty]
        public IFormFile HotelImage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (HotelImage != null)
            {
                if (!Path.GetExtension(HotelImage.FileName).Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                    !Path.GetExtension(HotelImage.FileName).Equals(".png", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("HotelImage", "Only .jpg and .png files are allowed.");
                    return Page();
                }

                var fileName = Path.GetFileNameWithoutExtension(HotelImage.FileName) + "_" + Guid.NewGuid().ToString() + Path.GetExtension(HotelImage.FileName);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

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
                Homestay.HotelImage = fileName;
            }

            await _homestayService.AddAsync(Homestay);

            return RedirectToPage("HotelManagement");
        }
    }
}
