using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories
{
    public interface IFAQRepo
    {
        void AddNewFAQ(List<FAQ> listFAQs);
        List<FAQ> GetAllFAQs();
    }
}
