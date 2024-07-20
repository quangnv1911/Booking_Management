using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;
using Group5_SE1730_BookingManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class BookingService : IBookingService
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;
        private readonly IBookingRepo _bookingRepo;

        public BookingService(IBookingRepo bookingRepo, Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
            _bookingRepo = bookingRepo;
        }

        public async Task AddBooking(Booking booking)
        {
            await _bookingRepo.AddBooking(booking);
        }

        public async Task<Booking?> GetBookingByIdAsync(int bookingId)
        {
            return await _bookingRepo.GetBookingById(bookingId);

        }

        public List<Booking> GetBookings()
        {
            return _bookingRepo.GetBookings();
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

        public async Task<int> GetTotalBookingsAsync()
        {
            return await _context.Bookings.CountAsync();
        }

        public async Task<List<int>> GetBookingsPerDayAsync(DateTime startDate)
        {
            var endOfWeek = startDate.AddDays(7);

            var bookings = await _context.Bookings
                .Where(b => b.BookingDate.HasValue && b.BookingDate.Value >= startDate && b.BookingDate.Value < endOfWeek)
                .GroupBy(b => b.BookingDate.Value.DayOfWeek)
                .Select(g => new { DayOfWeek = g.Key, Count = g.Count() })
                .ToListAsync();

            var bookingsPerDay = new List<int>(new int[7]);
            foreach (var booking in bookings)
            {
                bookingsPerDay[(int)booking.DayOfWeek] = booking.Count;
            }

            return bookingsPerDay;
        }

        public async Task<IEnumerable<Booking?>> GetBookingListByGuestId(string guestId)
        {
            return await _bookingRepo.GetBookingsByGuestId(guestId);
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            await _bookingRepo.UpdateBooking(booking);
        }

        public async Task<Booking> GetLastestBookingByGuestId(string guestId)
        {
            return await _context.Bookings
                .Include(b => b.Homestay)
                .Include(b => b.Room)
                .Where(b => b.GuestId == guestId)
                .OrderByDescending(b => b.BookingDate)
                .FirstOrDefaultAsync();
        }
    }
}
