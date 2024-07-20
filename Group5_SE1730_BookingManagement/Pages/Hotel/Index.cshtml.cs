using Group5_SE1730_BookingManagement.Hubs;
using Group5_SE1730_BookingManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Group5_SE1730_BookingManagement.Pages.Hotel
{
    public class IndexModel : PageModel
    {

        private readonly Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext _context;
        private readonly IHubContext<ChatHub> _signalRHub;
        public IndexModel(Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext context, IHubContext<ChatHub> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public int TotalPages { get; set; }

        public IList<Room> Room { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // int pageSize = 3;
            var query = _context.Rooms.Include(r => r.Homestay)
                .Include(r => r.RoomType).AsQueryable();


            if (!string.IsNullOrEmpty(SearchTerm))
            {
                query = query.Where(r => r.Name.Contains(SearchTerm));
            }
            // TotalPages = query.ToList().Count()/pageSize;
            Room = query.ToList();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            // Fetch the room with related entities
            var room = await _context.Rooms
                .Include(r => r.Bookings)
                .Include(r => r.Reviews)
                .Include(r => r.Discounts)
                .FirstOrDefaultAsync(r => r.Id == id);

            // Check if the room exists
            if (room == null)
            {
                return NotFound(); // Room was not found
            }

            // Fetch related entities
            var reviews = await _context.Reviews.Where(r => r.RoomId == id).ToListAsync();
            var bookings = await _context.Bookings.Where(b => b.RoomId == id).ToListAsync();
            var discounts = await _context.Discounts
                .Include(d => d.Rooms)
                .Where(d => d.Rooms.Any(r => r.Id == id))
                .ToListAsync();

            // Get the list of booking IDs (non-nullable)
            var bookingIds = bookings.Select(b => b.Id).ToList();

            // Fetch invoices related to the bookings
            var invoices = await _context.Invoices
                .Where(i => i.BookingId.HasValue && bookingIds.Contains(i.BookingId.Value))
                .ToListAsync();

            // Remove room from each discount's Rooms collection
            foreach (var discount in discounts)
            {
                discount.Rooms.Remove(room);
            }

            // Remove invoices first
            _context.Invoices.RemoveRange(invoices);

            // Remove related entities
            _context.Reviews.RemoveRange(reviews);
            _context.Bookings.RemoveRange(bookings);
            _context.Rooms.Remove(room);

            await _context.SaveChangesAsync();
            await _signalRHub.Clients.All.SendAsync("LoadFoods");

            // Redirect to the same page or a different page after deletion
            return RedirectToPage("./Index");
        }

    }
}