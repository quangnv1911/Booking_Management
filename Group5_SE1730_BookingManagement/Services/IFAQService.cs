using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IFAQService
    {
        void AddNewFAQ(List<FAQ> listFAQs);
        List<FAQ> GetAllFAQs();
    }
}
