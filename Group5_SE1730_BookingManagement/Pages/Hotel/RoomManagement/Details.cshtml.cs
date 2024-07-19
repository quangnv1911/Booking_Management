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
    public class DetailsModel : PageModel
    {
        private readonly Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext _context;

        public DetailsModel(Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

      public Room Room { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }
            else 
            {
                Room = room;
            }
            return Page();
        }
    }
}
