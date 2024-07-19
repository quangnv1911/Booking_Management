using Group5_SE1730_BookingManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    public class GuestRepo : IGuestRepo
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public GuestRepo(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

        public List<Guest> GetGuests()
        {
            return _context.Guests.ToList();
        }

        public Guest GetGuestById(string id)
        {
            return _context.Guests.Find(id);
        }

        public void DeleteGuest(Guest guest)
        {
            _context.Guests.Remove(guest);
            _context.SaveChanges();
        }
    }
}
