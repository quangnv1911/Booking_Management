using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group5_SE1730_BookingManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace Group5_SE1730_BookingManagement.Pages.Hotel.BookingManagement
{
    public class IndexModel : PageModel
    {
        private UserManager<Guest> _userManager;
        private Guest CurrentUser { get; set; }
        private readonly Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext _context;

        public IndexModel(Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext context, UserManager<Guest> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Booking> Booking { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Login");
                return;
            }

            CurrentUser = await _userManager.GetUserAsync(User);

            if (CurrentUser == null)
            {
                // Handle case where user is not found
                Response.Redirect("/Login");
                return;
            }

            if (_context.Bookings != null)
            {
                Booking = await _context.Bookings
                    .Include(b => b.Guest)
                    .Include(b => b.Homestay)
                    .Include(b => b.Room)
                    .Where(b => b.GuestId == CurrentUser.Id) // Filter by the current user's ID
                    .ToListAsync();
            }
        }
    }
}
