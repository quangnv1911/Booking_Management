using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepo _invoiceRepo;

        public InvoiceService(IInvoiceRepo invoiceRepo)
        {
            _invoiceRepo = invoiceRepo;
        }

        public async Task<Invoice> GetInvoiceByBookingId(long id)
        {
            return await _invoiceRepo.GetInvoiceByBookingId(id);
        }

        public string[] GetMoneyByMonth(string guestId)
        {
            string[] moneyPerMonth = new string[12];

            for (int month = 1; month <= 12; month++)
            {
                moneyPerMonth[month - 1] = _invoiceRepo.GetMoneyByMonth(guestId,month).ToString();
            }
            return moneyPerMonth;
        }

        public decimal GetMoneyThisMonth(string guestId)
        {
            return _invoiceRepo.GetMoneyThisMonth(guestId);
        }

        public decimal GetMoneyThisYear(string guestId)
        {
            return _invoiceRepo.GetMoneyThisYear(guestId);
        }

        public int GetTotalCustomerInMonth(string guestId)
        {
            return _invoiceRepo.GetTotalCustomerInMonth(guestId);
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            await _invoiceRepo.UpdateInvoiceAsync(invoice);
        }
    }
}
