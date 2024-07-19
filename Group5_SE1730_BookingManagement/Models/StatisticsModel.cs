using System.Collections.Generic;

namespace Group5_SE1730_BookingManagement.Models
{
    public class StatisticsModel
    {
        public int TotalHotels { get; set; }
        public int TotalBookings { get; set; }
        public List<int> BookingsPerDay { get; set; }
    }
}
