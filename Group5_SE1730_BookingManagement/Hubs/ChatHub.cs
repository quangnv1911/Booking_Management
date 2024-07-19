using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Services;
using Group5_SE1730_BookingManagement.Services.Impl;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;
namespace Group5_SE1730_BookingManagement.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IInboxService _inboxService;
        private readonly IMessageService _messageService;

        public ChatHub(IInboxService inboxService,
            IMessageService messageService)
        {
            _inboxService = inboxService;
            _messageService = messageService;
        }
        public async Task SendMessage(string userID, string userReceive, string inboxId)
        {


            await Clients.All.SendAsync("New message");
        }

        public async Task SendUpdateInboxHistory(string userId)
        {
            var inboxList = _inboxService.GetInboxListByGuestId(userId);

            await Clients.All.SendAsync("ReceiveUpdateInboxHistory", inboxList);
        }




    }
}
