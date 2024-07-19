using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;

using Microsoft.AspNetCore.Components.Server;

using System.Collections.Generic;
using System.Threading.Tasks;


namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class HomestayService : IHomestayService
    {
        private readonly IHomestayRepo _homestayRepo;

        private readonly IRoomService _roomService;
        public HomestayService(IHomestayRepo homestayRepo, IRoomService roomService)
        {
            _homestayRepo = homestayRepo;
            _roomService = roomService;
        }

        public async Task<Homestay?> GetHomeStayByIdAsync(long id)
        {
            return await _homestayRepo.GetHomestayByIdAsync(id);
        }

        public async Task<decimal?> GetHomeStaySmallestPriceByIdAsync(long id) {
            var selectedHomestay = await GetHomeStayByIdAsync(id);
            //Check if the selected Homestay is null or not
            if (selectedHomestay != null)
            {
                var roomList = (List<Room?>)await _roomService.GetRoomListByHomestayIdAsync(selectedHomestay.Id);
                //get the smallest price in room list
                return roomList.Count > 0 ? roomList.Min(r => r.Price) : 0;
            }
            else
                return 0;
        }
        
        public List<Homestay> GetHomestaysByGuest(string guestId)
        {
            return _homestayRepo.GetHomestaysByGuest(guestId);
        }
        

        public async Task<IEnumerable<Homestay>> GetAllAsync()
        {
            return await _homestayRepo.GetAllAsync();
        }

        public async Task<Homestay> GetByIdAsync(long id)
        {
            return await _homestayRepo.GetByIdAsync(id);
        }

        public async Task AddAsync(Homestay homestay)
        {
            await _homestayRepo.AddAsync(homestay);
        }

        public async Task UpdateAsync(Homestay homestay)
        {
            await _homestayRepo.UpdateAsync(homestay);
        }

        public async Task DeleteAsync(long id)
        {
            await _homestayRepo.DeleteByIdAsync(id);

        }
    }
}
