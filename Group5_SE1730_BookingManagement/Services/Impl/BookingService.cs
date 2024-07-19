using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class BookingService : IBookingService
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public BookingService(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookingViewModel>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Homestay)
                .Select(b => new BookingViewModel
                {
                    Id = b.Id,
                    GuestName = b.Guest.FirstName + " " + b.Guest.LastName,
                    HomestayName = b.Homestay.HotelName,
                    BookingDate = b.BookingDate,
                    CheckInDate = b.CheckInDate,
                    CheckOutDate = b.CheckOutDate,
                    NumAdults = b.NumAdults,
                    NumChildren = b.NumChildren,
                    SpecialReq = b.SpecialReq,
                    Status = b.Status
                }).ToListAsync();
        }
    }
}
