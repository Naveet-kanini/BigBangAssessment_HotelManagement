using BingBangAssessment_HotelManagement.Models;
using BigBangAssessment_HotelManagement.Repository1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BigBangAssessmentHotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelManagement : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManagement(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            try
            {
                var hotels = _hotelRepository.GetAllHotels();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            try
            {
                var hotel = _hotelRepository.GetHotelById(id);
                if (hotel == null)
                    return NotFound();

                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateHotel([FromBody] Hotels hotel)
        {
            try
            {
                _hotelRepository.AddHotel(hotel);
                return CreatedAtAction(nameof(GetHotelById), new { id = hotel.HotelCode }, hotel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHotel(int id, [FromBody] Hotels hotel)
        {
            try
            {
                if (id != hotel.HotelCode)
                    return BadRequest();

                _hotelRepository.UpdateHotel(hotel);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
    
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            try
            {
                _hotelRepository.DeleteHotel(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}