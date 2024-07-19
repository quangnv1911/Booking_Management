using Group5_SE1730_BookingManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    public class BookingRepo : IBookingRepo
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public BookingRepo(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

        public async Task<Booking?> GetBookingById(int bookingId)
        {
            return await _context.Bookings.FindAsync(bookingId);
        }

        public async Task<IEnumerable<Booking?>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task AddBooking(Booking booking)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Bookings.Add(booking);
                    await _context.SaveChangesAsync();

                    var invoice = new Invoice
                    {
                        BookingId = booking.Id,
                        GuestId = booking.GuestId,
                        PaymentDate = DateTime.Now,
                        Status = false
                    };

                    _context.Invoices.Add(invoice);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
