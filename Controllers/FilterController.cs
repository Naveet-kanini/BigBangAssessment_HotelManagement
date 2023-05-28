using BingBangAssessment_HotelManagement.Models;
using BigBangAssessment_HotelManagement.Repository1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBangAssessmentHotelManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly HotelDbContext dbContext; // Replace YourDbContext with the actual name of your database context

        public HotelsController(HotelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET api/hotels
        [HttpGet]
        public ActionResult<IEnumerable<Hotels>> GetHotels(
            string? location, decimal? minPrice, decimal? maxPrice, string? Amenities)
        {
            try
            {
                // Retrieve the values of the filtering criteria from the query parameters

                // Construct the base query to retrieve hotels
                IQueryable<Hotels> query = dbContext.Hotels;

                // Apply filters based on the provided criteria
                if (!string.IsNullOrEmpty(location))
                {
                    query = query.Where(h => h.City == location);
                }

                if (minPrice.HasValue)
                {
                    query = query.Where(h => h.PriceMin >= minPrice.Value);
                }

                if (maxPrice.HasValue)
                {
                    query = query.Where(h => h.PriceMax <= maxPrice.Value);
                }

                if (!string.IsNullOrEmpty(Amenities))
                {
                    query = query.Where(h => h.Amenities.Contains(Amenities));
                }

                // Execute the query and retrieve the filtered hotels
                List<Hotels> filteredHotels = query.ToList();

                // Return the filtered hotels as a response
                return Ok(filteredHotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{hotelId}/available-rooms/count")]
        public ActionResult<int> GetAvailableRoomsCount(int hotelId)
        {
            try
            {
                // Retrieve the hotel by ID
                Hotels hotel = dbContext.Hotels.FirstOrDefault(h => h.HotelCode == hotelId);

                if (hotel == null)
                {
                    return NotFound(); // Hotel not found
                }

                // Count the available rooms in the hotel
                int availableRoomsCount = dbContext.Rooms.Count(r => r.HID == hotelId && r.Occupancy == "Available");

                return Ok(availableRoomsCount);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}