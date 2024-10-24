namespace HotelFlightAPI.Models
{

    public class FlightTicket
    {
        public int Id { get; set; }
        public required string Airline { get; set; }
        public required string FlightNumber { get; set; }
        public required string DepartureCity { get; set; }
        public required string DestinationCity { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public decimal Price { get; set; }
    }
}
