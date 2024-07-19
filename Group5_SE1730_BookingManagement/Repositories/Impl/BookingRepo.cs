using Group5_SE1730_BookingManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    public class BookingRepo : IBookingRepo
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public BookingRepo(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

        public List<Booking> GetBookings()
        {
            return _context.Bookings.Include(b => b.Guest).Include(b => b.Homestay).ToList();
        }
    }
}
