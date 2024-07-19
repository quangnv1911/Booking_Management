namespace Group5_SE1730_BookingManagement.Services
{
    public interface IInvoiceService
    {
        decimal GetMoneyThisMonth(string guestId);

        decimal GetMoneyThisYear(string guestId);

        int GetTotalCustomerInMonth(string guestId);
        string[] GetMoneyByMonth(string guestId);
    }
}
