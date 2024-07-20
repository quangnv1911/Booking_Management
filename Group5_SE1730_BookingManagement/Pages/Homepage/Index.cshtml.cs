using System.Collections.Generic;
using System.Linq;
using Group5_SE1730_BookingManagement.Hubs;
using Group5_SE1730_BookingManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Group5_SE1730_BookingManagement.Pages.Homepage
{
    public class IndexModel : PageModel
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;
        private readonly IHubContext<ChatHub> _signalRHub;
        public IndexModel(Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext context, IHubContext<ChatHub> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
       
        }

        public IList<Room> Rooms { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string priceFilter { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Room> roomsQuery = _context.Rooms
                .Include(r => r.Homestay)
                .Include(r => r.RoomType);

            if (!string.IsNullOrEmpty(searchString))
            {
                roomsQuery = roomsQuery.Where(r => r.RoomType.Name.Contains(searchString) || r.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(priceFilter))
            {
                var priceRange = priceFilter.Split('-');
                if (priceRange.Length == 2 && decimal.TryParse(priceRange[0], out decimal minPrice) && decimal.TryParse(priceRange[1], out decimal maxPrice))
                {
                    roomsQuery = roomsQuery.Where(r => r.Price >= minPrice && r.Price <= maxPrice);
                }
            }

            Rooms = await roomsQuery.ToListAsync();
        }
    }
}
