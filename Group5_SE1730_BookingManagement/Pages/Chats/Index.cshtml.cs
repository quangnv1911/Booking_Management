using Group5_SE1730_BookingManagement.Hubs;
using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Group5_SE1730_BookingManagement.Services.Impl;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Group5_SE1730_BookingManagement.Pages.Chats
{
   
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<Guest> _userManager;
        private readonly IGuestService _guestService;
        private readonly IHubContext<ChatHub> _chatHub;
        public IndexModel(ILogger<IndexModel> logger, UserManager<Guest> userManager,
            IGuestService guestService, IHubContext<ChatHub> chatHub)
        {
            _logger = logger;
            _userManager = userManager;
            _guestService = guestService;
            _chatHub = chatHub;
        }

        [BindProperty(SupportsGet = true)]
        public string? UserFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<Guest> UserToList { get; set; }


        public async Task OnGet()
        {

            var user = await _userManager.GetUserAsync(User);
            await _chatHub.Clients.All.SendAsync("NeedUpdateInboxHistory", user?.Id);
         
        }



    }
}
