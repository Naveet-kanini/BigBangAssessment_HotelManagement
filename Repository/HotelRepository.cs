using BigBangAssessment_HotelManagement.Repository1;
using BingBangAssessment_HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssessment_HotelManagement.Repository1
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _dbContext;

        public HotelRepository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddHotel(Hotels hotel)
        {
            _dbContext.Set<Hotels>().Add(hotel);
            _dbContext.SaveChanges();
        }

        public void DeleteHotel(int id)
        {
            var hotel = _dbContext.Set<Hotels>().Find(id);
            _dbContext.Set<Hotels>().Remove(hotel);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Hotels> GetAllHotels()
        {
            return _dbContext.Set<Hotels>().ToList();
        }

        public Hotels GetHotelById(int id)
        {
            return _dbContext.Set<Hotels>().Find(id);
        }

        public void UpdateHotel(Hotels hotel)
        {
            _dbContext.Entry(hotel).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}