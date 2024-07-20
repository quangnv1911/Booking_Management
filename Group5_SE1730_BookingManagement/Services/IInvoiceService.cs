using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IInvoiceService
    {
        decimal GetMoneyThisMonth(string guestId);

        decimal GetMoneyThisYear(string guestId);

        int GetTotalCustomerInMonth(string guestId);
        string[] GetMoneyByMonth(string guestId);

        Task<Invoice> GetInvoiceByBookingId(long id);

        Task UpdateInvoiceAsync(Invoice invoice);
    }
}
