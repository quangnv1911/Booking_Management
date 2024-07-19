using Group5_SE1730_BookingManagement.Models;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    public class FAQRepo : IFAQRepo
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public FAQRepo(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }
        public void AddNewFAQ(List<FAQ> listFAQs)
        {

            _context.FAQs.AddRange(listFAQs);
            _context.SaveChanges();
        }

        public List<FAQ> GetAllFAQs()
        {
            return _context.FAQs.ToList();
        }
    }
}
