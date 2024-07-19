using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IBookingService
    {
        List<Booking> GetBookings();
        Task<IEnumerable<BookingViewModel>> GetAllBookingsAsync();
        Task<int> GetTotalBookingsAsync();
        Task<List<int>> GetBookingsPerDayAsync(DateTime startDate);
    }
}
