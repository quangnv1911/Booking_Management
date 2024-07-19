using Group5_SE1730_BookingManagement.Hubs;
using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Group5_SE1730_BookingManagement.Services.Impl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Group5_SE1730_BookingManagement.Pages.Chats
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<Guest> _userManager;
        private readonly IInboxService _inboxService;
        private readonly IMessageService _messageService;
        private readonly IGuestService _guestService;
        private readonly IHubContext<ChatHub> _chatHub;
        public IndexModel(ILogger<IndexModel> logger, UserManager<Guest> userManager,
            IGuestService guestService, IHubContext<ChatHub> chatHub, IInboxService service,
            IMessageService messageService)
        {
            _logger = logger;
            _userManager = userManager;
            _guestService = guestService;
            _chatHub = chatHub;
            _inboxService = service;
            _messageService = messageService;
        }

        [BindProperty(SupportsGet = true)]
        public string? UserFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<Guest> UserToList { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<Inbox> Inboxes { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<Message> Messages { get; set; } = null;


        [BindProperty(SupportsGet = true)]
        public Inbox? InboxData { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guest? OppositeUser { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guest? CurrentUser { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? NewMessage { get; set; }

        public async Task OnGet(string? Id)
        {
            if (Id != null)
            {
                Console.WriteLine(Id);
            }
            CurrentUser = await _userManager.GetUserAsync(User);

            Inboxes = _inboxService.GetInboxListByGuestId(CurrentUser?.Id);


            if (Id != null)
            {
                InboxData = _inboxService.GetInboxById(long.Parse(Id));
                if (InboxData?.FirstUserId == CurrentUser?.Id)
                {
                    OppositeUser = InboxData?.SecondUser;
                }
                else
                {
                    OppositeUser = InboxData?.FirstUser;
                }
                Messages = _messageService.GetMessagesByInboxId(long.Parse(Id));
            }


        }

        public async Task<IActionResult> OnPost(string Id)
        {
            Message message = new Message();
            CurrentUser = await _userManager.GetUserAsync(User);

            Inbox inbox = _inboxService.GetInboxById(long.Parse(Id));
            if (inbox.FirstUserId.Equals(CurrentUser.Id))
            {
                _messageService.CreateMessage(NewMessage, CurrentUser?.Id, DateTime.Now, long.Parse(Id));
                await _chatHub.Clients.Users(inbox?.SecondUserId).SendAsync("HaveNewMessage");
            }
            else
            {
                _messageService.CreateMessage(NewMessage, CurrentUser?.Id, DateTime.Now, long.Parse(Id));
                await _chatHub.Clients.Users(inbox?.FirstUserId).SendAsync("HaveNewMessage");
            }


            return RedirectToPage("Index", new { id = Id });
        }


        public IActionResult OnPostSendMessage()
        {
            // Handle the message submission here
            // For example, save the message to a database or send it to connected clients
            _logger.Log(LogLevel.Debug, "dfs", "dfs");
            // Assuming you return JSON data for the client-side JavaScript
            return new JsonResult(new { success = true });
        }




    }
}
