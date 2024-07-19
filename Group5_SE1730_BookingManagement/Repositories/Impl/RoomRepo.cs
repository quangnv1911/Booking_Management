using Group5_SE1730_BookingManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Group5_SE1730_BookingManagement.Repositories.Impl
{
    public class RoomRepo : IRoomRepo
    {
        private Group_5_SE1730_BookingManagementContext _context;

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
    }
}
