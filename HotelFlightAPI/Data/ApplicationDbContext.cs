using HotelFlightAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelFlightAPI.Data
{

    public class ApplicationDbContext: DbContext
    {
        public DbSet<FlightTicket> FlightTickets { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Cart> Carts { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
