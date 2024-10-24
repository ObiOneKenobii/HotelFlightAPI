using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelFlightAPI.Data;
using HotelFlightAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HotelFlightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightTicketController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FlightTicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FlightTicket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightTicket>>> GetFlightTickets()
        {
            return await _context.FlightTickets.ToListAsync();
        }

        // GET: api/FlightTicket/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightTicket>> GetFlightTicket(int id)
        {
            var flightTicket = await _context.FlightTickets.FindAsync(id);

            if (flightTicket == null)
            {
                return NotFound();
            }

            return flightTicket;
        }

        // POST: api/FlightTicket
        [HttpPost]
        public async Task<ActionResult<FlightTicket>> CreateFlightTicket(FlightTicket flightTicket)
        {
            _context.FlightTickets.Add(flightTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFlightTicket), new { id = flightTicket.Id }, flightTicket);
        }

        // PUT: api/FlightTicket/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlightTicket(int id, FlightTicket flightTicket)
        {
            if (id != flightTicket.Id)
            {
                return BadRequest();
            }

            _context.Entry(flightTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightTicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/FlightTicket/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightTicket(int id)
        {
            var flightTicket = await _context.FlightTickets.FindAsync(id);
            if (flightTicket == null)
            {
                return NotFound();
            }

            _context.FlightTickets.Remove(flightTicket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightTicketExists(int id)
        {
            return _context.FlightTickets.Any(e => e.Id == id);
        }
    }
}
