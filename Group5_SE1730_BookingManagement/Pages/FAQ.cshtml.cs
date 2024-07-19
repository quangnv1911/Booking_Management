using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group5_SE1730_BookingManagement.Pages
{
    public class FAQModel : PageModel
    {
        private readonly ILogger<FAQModel> _logger;
        private readonly IFAQService _fAQService;

        public FAQModel(ILogger<FAQModel> logger,
            IFAQService fAQService)
        {
            _logger = logger;
            _fAQService = fAQService;
        }
        [BindProperty]
        public List<FAQ>? ListFAQ { get; set; }
        public void OnGet()
        {
            ListFAQ = _fAQService.GetAllFAQs();   
        }
    }
}
