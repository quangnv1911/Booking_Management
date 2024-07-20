using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Group5_SE1730_BookingManagement.Models;
using Microsoft.AspNetCore.SignalR;
using Group5_SE1730_BookingManagement.Hubs;

namespace Group5_SE1730_BookingManagement.Pages.Hotel.RoomManagement
{
    public class CreateModel : PageModel
    {
        private readonly Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext _context;
        private readonly IHubContext<ChatHub> _signalRHub;
        public CreateModel(Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext context, IHubContext<ChatHub> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }

        public IActionResult OnGet()
        {
        ViewData["HomestayId"] = new SelectList(_context.Homestays, "Id", "Id");
        ViewData["RoomTypeId"] = new SelectList(_context.RoomTypes, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Room Room { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Rooms == null || Room == null)
            {
                return Page();
            }

            _context.Rooms.Add(Room);
            await _context.SaveChangesAsync();
            await _signalRHub.Clients.All.SendAsync("LoadFoods");

            return RedirectToPage("/hotel");
        }
    }
}
