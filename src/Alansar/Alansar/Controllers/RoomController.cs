using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Alansar.Data;
using Alansar.Core.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Alansar.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoomController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetRoomCount()
        {
            // Count the number of rooms in the database
            var roomCount = await _context.Rooms.CountAsync();
            return Ok(roomCount);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                return NotFound();

            return Ok(room);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoom([FromBody] Room newRoom)
        {
            _context.Rooms.Add(newRoom);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoom(int id, [FromBody] Room updatedRoom)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                return NotFound();

            room.RoomNumber = updatedRoom.RoomNumber;
            room.Type = updatedRoom.Type;
            room.Capacity = updatedRoom.Capacity;
            room.Price = updatedRoom.Price;
            room.IsAvailable = updatedRoom.IsAvailable;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                return NotFound();

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("available/{sessionYear}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAvailableRooms(string sessionYear)
        {
            var rooms = await _context.Rooms
                .Include(r => r.Students)
                .Where(r => r.SessionYear == sessionYear && r.IsAvailable)
                .OrderByDescending(a => a.Created)
                .ToListAsync();

            return Ok(rooms);
        }

        [HttpGet("{roomId}/students")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsInRoom(int roomId)
        {
            var room = await _context.Rooms.Include(r => r.Students).FirstOrDefaultAsync(r => r.Id == roomId);
            if (room == null)
            {
                return NotFound("Room not found.");
            }

            return Ok(room.Students);
        }



    }
}
