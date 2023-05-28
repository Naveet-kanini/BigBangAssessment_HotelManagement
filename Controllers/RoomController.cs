using BingBangAssessment_HotelManagement.Models;
using BigBangAssessment_HotelManagement.Repository1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BigBangAssessmentHotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelManagementR : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public HotelManagementR(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public IActionResult GetAllRooms()
        {
            try
            {
                var rooms = _roomRepository.GetAllRooms();
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            try
            {
                var room = _roomRepository.GetRoomById(id);
                if (room == null)
                    return NotFound();

                return Ok(room);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateRoom([FromBody] Rooms room)
        {
            try
            {
                _roomRepository.AddRoom(room);
                return CreatedAtAction(nameof(GetRoomById), new { id = room.RoomNumber }, room);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRoom(int id, [FromBody] Rooms room)
        {
            try
            {
                if (id != room.RoomNumber)
                    return BadRequest();

                _roomRepository.UpdateRoom(room);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            try
            {
                _roomRepository.DeleteRoom(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}