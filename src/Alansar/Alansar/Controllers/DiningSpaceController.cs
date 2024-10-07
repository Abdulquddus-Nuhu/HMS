using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alansar.Core.Entities;
using Alansar.Data;

namespace Alansar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiningSpaceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DiningSpaceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetDiningHallCount()
        {
            // Count the number of dining halls in the database
            var diningHallCount = await _context.DiningSpaces.CountAsync();
            return Ok(diningHallCount);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiningSpace>>> GetDiningSpaces()
        {
            return await _context.DiningSpaces
                .OrderByDescending(a => a.Created)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiningSpace>> GetDiningSpace(int id)
        {
            var diningSpace = await _context.DiningSpaces.FindAsync(id);
            if (diningSpace == null)
            {
                return NotFound();
            }

            return diningSpace;
        }

        [HttpPost("create")]
        public async Task<ActionResult<DiningSpace>> CreateDiningSpace(DiningSpace diningSpace)
        {
            _context.DiningSpaces.Add(diningSpace);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDiningSpace), new { id = diningSpace.Id }, diningSpace);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiningSpace(int id, DiningSpace diningSpace)
        {
            if (id != diningSpace.Id)
            {
                return BadRequest();
            }

            _context.Entry(diningSpace).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiningSpace(int id)
        {
            var diningSpace = await _context.DiningSpaces.FindAsync(id);
            if (diningSpace == null)
            {
                return NotFound();
            }

            _context.DiningSpaces.Remove(diningSpace);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
