using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface IInvoiceRepo
    {
        decimal GetMoneyThisMonth(string guestId);

        decimal GetMoneyThisYear(string guestId);

        int GetTotalCustomerInMonth(string guestId);

        decimal GetMoneyByMonth(string guestId, int month);

        Task UpdateInvoice(Invoice invoice);

    }
}
