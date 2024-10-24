using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelFlightAPI.Data;
using HotelFlightAPI.Models;

namespace HotelFlightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cart/{userId}
        [HttpGet("{userId}")]
        public async Task<ActionResult<Cart>> GetCart(string userId)
        {
            try
            {
                var cart = await _context.Carts
                    .Include(c => c.FlightTicket)  
                    .Include(c => c.HotelRoom)
                    .FirstOrDefaultAsync(c => c.UserId == userId);

                if (cart == null)
                {
                    return NotFound();
                } 

                return cart;
            }
            catch (Exception ex)
            {
                // Log or return detailed error message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        // POST: api/Cart
        [HttpPost]
        public async Task<ActionResult<Cart>> CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { userId = cart.UserId }, cart);
        }

        // PUT: api/Cart/{userId}
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateCart(string userId, Cart cart)
        {
            if (userId != cart.UserId)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(userId))
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

        // DELETE: api/Cart/{userId}
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteCart(string userId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartExists(string userId)
        {
            return _context.Carts.Any(c => c.UserId == userId);
        }
    }
}
