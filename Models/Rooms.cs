using System.ComponentModel.DataAnnotations;

namespace BingBangAssessment_HotelManagement.Models
{
    public class Rooms
    {
        [Key]
        public int RoomNumber { get; set; }
        public string? RoomType { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public string? Occupancy { get; set; }
        public int HID { get; set; }
        public Hotels? Hotels { get; set; }
    }
}
