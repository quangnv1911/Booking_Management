using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group5_SE1730_BookingManagement.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly ISiteSettingsService _siteSettingsService;

        public PrivacyModel(ILogger<PrivacyModel> logger,
            ISiteSettingsService siteSettingsService)
        {
            _logger = logger;
            _siteSettingsService = siteSettingsService;
        }

        [BindProperty(SupportsGet = true)]
        public string? Privacy { get; set; }

        public async Task OnGet()
        {
            var siteSetting = await _siteSettingsService.GetSiteSettingsAsync();
            Privacy = siteSetting.PrivacyText;
        }
    }

}
