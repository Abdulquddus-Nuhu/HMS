using Alansar.Core.Entities;
using Alansar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alansar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetStudentCount()
        {
            // Count the number of students in the database
            var studentCount = await _context.Students.CountAsync();
            return Ok(studentCount);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students
                .OrderByDescending(a => a.Created)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> CreateStudent([FromBody] Student newStudent)
        {
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.Email = updatedStudent.Email;
            student.DateOfBirth = updatedStudent.DateOfBirth;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> Register(StudentDto studentDto)
        //{
        //    var student = new Student
        //    {
        //        FullName = studentDto.FullName,
        //        Email = studentDto.Email,
        //        Password = BCrypt.Net.BCrypt.HashPassword(studentDto.Password) // Use hashing
        //    };
        //    _context.Students.Add(student);
        //    await _context.SaveChangesAsync();
        //    return Ok(student);
        //}

        // Additional CRUD methods
    }
}
