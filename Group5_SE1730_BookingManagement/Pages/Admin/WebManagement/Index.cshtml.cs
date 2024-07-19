using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group5_SE1730_BookingManagement.Pages.WebManagement
{
    public class IndexModel : PageModel
    {
        private readonly ISiteSettingsService _siteSettingsService;

        public IndexModel(ISiteSettingsService siteSettingsService)
        {
            _siteSettingsService = siteSettingsService;
        }

        [BindProperty]
        public IFormFile? FAQFile { get; set; }

        [BindProperty]
        public SiteSettings? SiteSettings { get; set; }
        public async Task OnGet()
        {
            var siteSettings = await _siteSettingsService.GetSiteSettingsAsync(); 
            if(siteSettings != null)
            {
                SiteSettings = siteSettings;
            }
        }

        public async Task<IActionResult> OnPost(string action)
        {
            if (action == "reset")
            {
                
                await _siteSettingsService.ResetSetting();
                TempData["Message"] = "Settings have been reset successfully.";
                return RedirectToPage();
            }
            else if (action == "save")
            {
                await _siteSettingsService.UpdateNewSetting(SiteSettings);
                TempData["Message"] = "Settings have been saved successfully.";
                return RedirectToPage(); // Redirect to the same page to refresh
            }

            return Page();
        }
    }
}
