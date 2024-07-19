using Group5_SE1730_BookingManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    public class RoomRepo : IRoomRepo
    {
        private readonly Group_5_SE1730_BookingManagementContext _context;

        public RoomRepo(Group_5_SE1730_BookingManagementContext context)
        {
            _context = context;
        }

        public async Task AddRoomAsync(Room room)
        {
            await _context.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomAsyncById(long id)
        {
            //Check if the room is null or not
            if(await GetRoomByIdAsync(id) != null)
            {
                _context.Remove(await GetRoomByIdAsync(id));
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Room not found");
            }
        }

        public async Task<Room?> GetRoomByIdAsync(long id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<IEnumerable<Room?>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task UpdateRoomAsync(Room room)
        {
            _context.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room?>> GetRoomListByHomestayIdAsync(long homestayId) {
            return await _context.Rooms.Where(r => r.HomestayId == homestayId).ToListAsync();
        }

        public int CountRoomByHomestayAndGuestId(long homestayId, string guestId)
        {
            return _context.Rooms.Where(r => r.HomestayId == homestayId).ToList().Count();
            
        }

        public int CountRoomRemainOfUser(string guestId)
        {
            int count = 0;
            var listHomestay = _context.Homestays.Include(d => d.Rooms).Where(d => d.GuestId == guestId).ToList();
            foreach (var homestay in listHomestay)
            {
                var listRoom = homestay.Rooms.Where(d => d.HomestayId == homestay.Id && d.Status == false).ToList();
                count += listRoom.Count();
            }
            return count;
        }

        public int CountTotalRoomOfUser(string guestId)
        {
            int count = 0;
            var listHomestay = _context.Homestays.Include(d => d.Rooms).Where(d => d.GuestId == guestId).ToList();
            foreach(var homestay in listHomestay)
            {
                var listRoom = homestay.Rooms.Where(d => d.HomestayId == homestay.Id).ToList();
                count += listRoom.Count();
            }
            return count;
        }
    }
}
