using Alansar.Data;
using Alansar.Core.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Alansar.Controllers
{
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("book")]
        public async Task<ActionResult> BookRoom([FromBody] BookingRequest bookingRequest)
        {
            var room = await _context.Rooms.Include(r => r.Students).FirstOrDefaultAsync(r => r.Id == bookingRequest.RoomId);
            if (room == null || !room.IsAvailable || room.SessionYear != bookingRequest.SessionYear)
            {
                return BadRequest("Room is not available for the selected session/year.");
            }

            if (room.Students.Count >= room.Capacity)
            {
                return BadRequest("Room is already full.");
            }

            var student = await _context.Students.FindAsync(bookingRequest.StudentId);
            if (student == null)
            {
                return BadRequest("Student not found.");
            }

            room.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Get the booking history of a specific student
        [HttpGet("history/{studentId}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingHistory(int studentId)
        {
            var bookings = await _context.Bookings
                .Include(b => b.Room)
                .Include(b => b.Student)
                .Where(b => b.StudentId == studentId)
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync();

            if (!bookings.Any())
            {
                return NotFound("No bookings found for this student.");
            }

            return Ok(bookings);
        }

        // Create a new booking
        [HttpPost("create")]
        public async Task<ActionResult> CreateBooking([FromBody] Booking newBooking)
        {
            var room = await _context.Rooms.FindAsync(newBooking.RoomId);
            if (room == null || !room.IsAvailable || room.SessionYear != newBooking.SessionYear)
            {
                return BadRequest("Room is not available for the selected session/year.");
            }

            var student = await _context.Students.FindAsync(newBooking.StudentId);
            if (student == null)
            {
                return BadRequest("Student not found.");
            }

            newBooking.BookingDate = DateTime.UtcNow;

            room.Bookings.Add(newBooking);
            student.Bookings.Add(newBooking);

            _context.Bookings.Add(newBooking);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    public record BookingRequest(int StudentId, int RoomId, string SessionYear);

}
