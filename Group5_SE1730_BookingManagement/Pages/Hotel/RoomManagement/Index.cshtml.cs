using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Pages.Hotel.RoomManagement
{
    public class IndexModel : PageModel
    {
        private readonly Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext _context;

        public IndexModel(Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

        public IList<Room> Room { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rooms != null)
            {
                Room = await _context.Rooms
                .Include(r => r.Homestay)
                .Include(r => r.RoomType).ToListAsync();
            }
        }
    }
}
