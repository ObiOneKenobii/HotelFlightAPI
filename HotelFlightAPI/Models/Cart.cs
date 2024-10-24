namespace HotelFlightAPI.Models
{
    
        public class Cart
        {
            public int Id { get; set; }
            public string? UserId { get; set; }
            public FlightTicket? FlightTicket { get; set; }
            public HotelRoom? HotelRoom { get; set; }
            public int NumberOfTickets { get; set; } // Tracks number of flight tickets
            public int NumberOfRooms { get; set; } // Tracks number of hotel rooms
            public decimal TotalPrice => (FlightTicket?.Price ?? 0) * NumberOfTickets
                                       + (HotelRoom?.PricePerNight ?? 0) * NumberOfRooms * (HotelRoom?.Nights ?? 1);
        }


    

}
