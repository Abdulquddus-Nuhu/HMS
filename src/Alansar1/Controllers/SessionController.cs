using Alansar.Data;
using Alansar.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alansar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SessionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSessions()
        {
            var sessions = await _context.Sessions.ToListAsync();
            return Ok(sessions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSession([FromBody] Session session)
        {
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();
            return Ok(session);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(int id, [FromBody] Session session)
        {
            var existingSession = await _context.Sessions.FindAsync(id);
            if (existingSession == null)
            {
                return NotFound();
            }

            existingSession.Year = session.Year;
            existingSession.StartDate = session.StartDate;
            existingSession.EndDate = session.EndDate;
            await _context.SaveChangesAsync();
            return Ok(existingSession);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
