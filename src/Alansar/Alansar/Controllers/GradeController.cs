using Alansar.Data;
using Alansar.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alansar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GradeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClasses()
        {
            var classes = await _context.Grades.ToListAsync();
            return Ok(classes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] Grade classModel)
        {
            _context.Grades.Add(classModel);
            await _context.SaveChangesAsync();
            return Ok(classModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, [FromBody] Grade classModel)
        {
            var existingClass = await _context.Grades.FindAsync(id);
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
            var classModel = await _context.Grades.FindAsync(id);
            if (classModel == null)
            {
                return NotFound();
            }

            _context.Grades.Remove(classModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
