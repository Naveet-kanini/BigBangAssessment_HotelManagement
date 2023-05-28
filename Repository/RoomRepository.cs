using BigBangAssessment_HotelManagement.Repository1;
using BingBangAssessment_HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssessment_HotelManagement.Repository1
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _dbContext;

        public RoomRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddRoom(Rooms room)
        {
            _dbContext.Set<Rooms>().Add(room);
            _dbContext.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var room = _dbContext.Set<Rooms>().Find(id);
            _dbContext.Set<Rooms>().Remove(room);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Rooms> GetAllRooms()
        {
            return _dbContext.Set<Rooms>().ToList();
        }

        public Rooms GetRoomById(int id)
        {
            return _dbContext.Set<Rooms>().Find(id);
        }

        public void UpdateRoom(Rooms room)
        {
            _dbContext.Entry(room).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}