using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;

namespace Group5_SE1730_BookingManagement.Pages.Admins
{
    public class ContentManagementModel : PageModel
    {
        private readonly ISiteSettingsService _siteSettingsService;
        private readonly IFAQService _fAQService;

        public ContentManagementModel(ISiteSettingsService siteSettingsService,
            IFAQService fAQService)
        {
            _siteSettingsService = siteSettingsService;
            _fAQService = fAQService;
        }

        [BindProperty]
        public IFormFile? FAQFile { get; set; }

        [BindProperty]
        public SiteSettings? SiteSettings { get; set; }
        public async Task OnGet()
        {
            var siteSettings = await _siteSettingsService.GetSiteSettingsAsync();
            if (siteSettings != null)
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

            using (var stream = new MemoryStream())
            {
                await FAQFile.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    List<FAQ> listFAQs = new List<FAQ>();

                    for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                    {
                        var question = worksheet.Cells[row, 1].Text;
                        var answer = worksheet.Cells[row, 2].Text;
                        listFAQs.Add(new FAQ { Question = question, Answer = answer });
                    }
                    _fAQService.AddNewFAQ(listFAQs);

                }
            }


            return Page();
        }
    }
}
