using Group5_SE1730_BookingManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Group5_SE1730_BookingManagement.Pages.Hotel
{
    public class IndexModel : PageModel
    {
        private readonly Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext _context;
        private readonly UserManager<Guest> _userManager;

        public IndexModel(Group5_SE1730_BookingManagement.Models.Group_5_SE1730_BookingManagementContext context, UserManager<Guest> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public int TotalPages { get; set; }

        public IList<Homestay> Homestay { get; set; } = default!;
        public IDictionary<Homestay, IList<Room>> HomestayRooms { get; set; } = new Dictionary<Homestay, IList<Room>>();

        public async Task OnGetAsync()
        {
            // L?y thông tin ng??i dùng hi?n t?i
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            var homestays = _context.Homestays
                .Where(h => h.GuestId == user.Id) // L?c theo ng??i dùng hi?n t?i
                .Include(h => h.Rooms) // Bao g?m thông tin v? phòng
                .AsQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                homestays = homestays.Where(h => h.HotelName.Contains(SearchTerm));
            }

            Homestay = await homestays.ToListAsync();

            // L?u tr? phòng c?a t?ng homestay
            foreach (var homestay in Homestay)
            {
                HomestayRooms[homestay] = homestay.Rooms.ToList();
            }
        }

        public async Task<IActionResult> OnPost(string id)
        {
            var homestay = await _context.Homestays.FirstOrDefaultAsync(h => h.Id == long.Parse(id));
            if (homestay != null)
            {
                _context.Homestays.Remove(homestay);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
