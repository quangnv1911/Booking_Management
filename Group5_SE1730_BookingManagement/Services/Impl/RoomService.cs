using Group5_SE1730_BookingManagement.Models;
using Group5_SE1730_BookingManagement.Repositories;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepo _roomRepo;

        public RoomService(IRoomRepo roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public int CountRoomByHomestayAndGuestId(long homestayId, string guestId)
        {
            return _roomRepo.CountRoomByHomestayAndGuestId(homestayId, guestId);
        }

        public int CountRoomRemainOfUser(string guestId)
        {
            return _roomRepo.CountRoomRemainOfUser(guestId);
        }

        public int CountTotalRoomOfUser(string guestId)
        {
            return _roomRepo.CountTotalRoomOfUser(guestId) ; ;
        }
    }
}
