using BingBangAssessment_HotelManagement.Models;

namespace BigBangAssessment_HotelManagement.Repository1
{
    public interface IHotelRepository
    {
        Hotels GetHotelById(int id);
        IEnumerable<Hotels> GetAllHotels();
        void AddHotel(Hotels hotel);
        void UpdateHotel(Hotels hotel);
        void DeleteHotel(int id);
    }
}