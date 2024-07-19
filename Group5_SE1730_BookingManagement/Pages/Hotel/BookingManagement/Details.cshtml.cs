using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Pages.Hotel.BookingManagement
{
    public class DetailsModel : PageModel
    {
        private readonly Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext _context;

        public DetailsModel(Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

      public Booking Booking { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }
            else 
            {
                Booking = booking;
            }
            return Page();
        }
    }
}
