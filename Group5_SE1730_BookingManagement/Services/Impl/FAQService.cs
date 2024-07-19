using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class FAQService : IFAQService
    {
        private readonly IFAQRepo _fAQRepo;

        public FAQService(IFAQRepo fAQRepo)
        {
            _fAQRepo = fAQRepo;
        }

        public void AddNewFAQ(List<FAQ> listFAQs)
        {
            _fAQRepo.AddNewFAQ(listFAQs);
        }

        public List<FAQ> GetAllFAQs()
        {
            return _fAQRepo.GetAllFAQs();
        }
    }
}
