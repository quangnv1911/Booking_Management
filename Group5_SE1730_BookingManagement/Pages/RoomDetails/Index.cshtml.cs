// RoomDetails.cshtml.cs
using System.Threading.Tasks;
using Group5_SE1730_BookingManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Group5_SE1730_BookingManagement.Pages.RoomDetails
{
    public class IndexModel : PageModel
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public IndexModel(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

        public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await _context.Rooms
                .Include(r => r.Homestay)
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Room == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
