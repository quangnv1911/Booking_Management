using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IBookingService
    {
        //Add booking
        Task AddBooking(Booking booking);
        //Get booking by id
        Task<Booking?> GetBookingByIdAsync(int bookingId);
        List<Booking> GetBookings();
        Task<IEnumerable<BookingViewModel>> GetAllBookingsAsync();
        Task<int> GetTotalBookingsAsync();
        Task<List<int>> GetBookingsPerDayAsync(DateTime startDate);

        Task<IEnumerable<Booking?>> GetBookingListByGuestId(string guestId);

        Task UpdateBookingAsync(Booking booking);
    }
}
