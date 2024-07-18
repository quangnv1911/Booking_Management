using Group5_SE1730_BookingManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    [Authorize("PARTNER")]
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public InvoiceRepo(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

        public decimal GetMoneyByMonth(string guestId, int month)
        {
            decimal money = 0;
            var listHomestay = _context.Homestays.Where(d => d.GuestId == guestId).ToList();
            foreach (var homestay in listHomestay)
            {
                var listInvoice = _context.Invoices.Include(d => d.Booking).ThenInclude(d => d.Homestay).Include(d => d.Booking.Room)
                    .Where(d => d.Booking.HomestayId == homestay.Id && d.PaymentDate.Value.Month == month).ToList();
                foreach (var invoice in listInvoice)
                {
                    var data = invoice.Booking.Room.Price;
                    if (data != null)
                    {
                        money += data ?? 0;
                    }
                }
            }


            return money;
        }

        public decimal GetMoneyThisMonth(string guestId)
        {
            decimal money = 0;
            var listHomestay = _context.Homestays.Where(d => d.GuestId == guestId).ToList();
            foreach (var homestay in listHomestay)
            {
                var listInvoice = _context.Invoices.Include(d => d.Booking).ThenInclude(d => d.Homestay).Include(d => d.Booking.Room)
                    .Where(d => d.Booking.HomestayId == homestay.Id && d.PaymentDate.Value.Month == DateTime.Now.Month).ToList();
                foreach(var invoice in listInvoice)
                {
                    var data = invoice.Booking.Room.Price;
                    if(data != null)
                    {
                        money += data ?? 0;
                    }
                }
            }
            
           
            return money;
        }

        public decimal GetMoneyThisYear(string guestId)
        {
            decimal money = 0;


            var listHomestay = _context.Homestays.Where(d => d.GuestId == guestId).ToList();
            foreach (var homestay in listHomestay)
            {
                var listInvoice = _context.Invoices.Include(d => d.Booking).ThenInclude(d => d.Homestay).Include(d => d.Booking.Room)
                    .Where(d => d.Booking.HomestayId == homestay.Id && d.PaymentDate.Value.Year == DateTime.Now.Year).ToList();
                foreach (var invoice in listInvoice)
                {
                    var data = invoice.Booking.Room.Price;
                    if (data != null)
                    {
                        money += data ?? 0;
                    }
                }
            }
            return money;

        }

        public int GetTotalCustomerInMonth(string guestId)
        {
            int count = 0;
            var listHomestay = _context.Homestays.Include(b => b.Bookings).ThenInclude(b => b.Invoices).Where(d => d.GuestId == guestId).ToList();
            foreach (var homestay in listHomestay)
            {
                count += homestay.Bookings.Where(b => b.Id == b.Invoices.BookingId).GroupBy(d => d.Invoices.GuestId).Count();
            }
            return count;
        }
    }
}
