using BingBangAssessment_HotelManagement.Models;

namespace BigBangAssessment_HotelManagement.Repository1
{
    public interface IRoomRepository
    {
        Rooms GetRoomById(int id);
        IEnumerable<Rooms> GetAllRooms();
        void AddRoom(Rooms room);
        void UpdateRoom(Rooms room);
        void DeleteRoom(int id);
    }
}