using Group5_SE1730_BookingManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group5_SE1730_BookingManagement.Pages
{
    public class FAQModel : PageModel
    {
        [BindProperty]
        public FAQ? Data { get; set; }
        public void OnGet()
        {
            Data = new FAQ(
                "Cau hỏi 1",
                "To change your billing information, please follow these steps:\r\n\r\nGo to our website and sign in to your account.\r\nClick on your profile picture in the top right corner of the page and select \"Account Settings.\"\r\nUnder the \"Billing Information\" section, click on \"Edit.\"\r\nMake your changes and click on \"Save.\"");
        }
    }
}
