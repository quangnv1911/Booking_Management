using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _bookingRepo;

        public BookingService(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public async Task AddBooking(Booking booking)
        {
            await _bookingRepo.AddBooking(booking);
        }

        public async Task<Booking?> GetBookingById(int bookingId)
        {
            return await _bookingRepo.GetBookingById(bookingId);
        }
    }
}
