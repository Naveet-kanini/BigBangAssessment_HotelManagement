using System.ComponentModel.DataAnnotations;

namespace BingBangAssessment_HotelManagement.Models
{
    public class Hotels
    {
        [Key]
        public int HotelCode { get; set; }
        public string? HotelName { get; set; }
        public string? Address { get;set; }
        public string? City { get; set;}
        public string? State { get; set; }
        public string? PostalCode { get; set;}
        public int RoomsCount { get; set; }
        public int PhoneNo { get; set; }
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
        public string? Amenities { get; set; }
        public decimal Ratings { get; set; }
        public string? Description { get; set; }
        public ICollection<Rooms>? Rooms { get; set;}
    }
}
