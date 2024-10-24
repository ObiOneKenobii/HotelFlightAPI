namespace HotelFlightAPI.Models
{
    public class HotelRoom
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public int Nights { get; set; }
    }
}
