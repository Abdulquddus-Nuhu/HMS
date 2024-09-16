using Alansar.Data;
using Alansar.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alansar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClasses()
        {
            var classes = await _context.Classes.ToListAsync();
            return Ok(classes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] Class classModel)
        {
            _context.Classes.Add(classModel);
            await _context.SaveChangesAsync();
            return Ok(classModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, [FromBody] Class classModel)
        {
            var existingClass = await _context.Classes.FindAsync(id);
            if (existingClass == null)
            {
                return NotFound();
            }

            existingClass.Name = classModel.Name;
            await _context.SaveChangesAsync();
            return Ok(existingClass);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var classModel = await _context.Classes.FindAsync(id);
            if (classModel == null)
            {
                return NotFound();
            }

            _context.Classes.Remove(classModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
