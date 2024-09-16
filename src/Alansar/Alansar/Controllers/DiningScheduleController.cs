using Alansar.Data;
using Alansar.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alansar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiningScheduleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DiningScheduleController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("space/{diningSpaceId}")]
        public async Task<ActionResult<IEnumerable<DiningAssignment>>> GetAssignmentsForDiningSpace(int diningSpaceId)
        {
            return await _context.DiningAssignments
                                 .Where(da => da.DiningSpaceId == diningSpaceId)
                                 .Include(da => da.Student)
                                 .ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiningSchedule>>> GetDiningSchedules()
        {
            return await _context.DiningSchedules
                                 .Include(ds => ds.DiningSpace)
                                 .Include(ds => ds.Student)
                                 .ToListAsync();
        }

        // Assign students to a dining space on a specific date
        [HttpPost("assign")]
        public async Task<IActionResult> AssignStudents([FromBody] List<DiningAssignment> assignments)
        {
            _context.DiningAssignments.AddRange(assignments);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //// Get all assignments for a specific dining space
        //[HttpGet("space/{diningSpaceId}")]
        //public async Task<ActionResult<IEnumerable<DiningAssignment>>> GetAssignmentsForDiningSpace(int diningSpaceId)
        //{
        //    return await _context.DiningAssignments
        //                         .Where(da => da.DiningSpaceId == diningSpaceId)
        //                         .Include(da => da.Student)
        //                         .ToListAsync();
        //}

        [HttpGet("assignments")]
        public async Task<ActionResult<IEnumerable<DiningAssignment>>> GetAssignments()
        {
            var assignments = await _context.DiningAssignments
                                            .Include(a => a.Student)
                                            .Include(a => a.DiningSpace)
                                            .OrderByDescending(a => a.Created)
                                            .ToListAsync();
            return Ok(assignments);
        }

        // Get all assignments for a specific student
        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<IEnumerable<DiningAssignment>>> GetAssignmentsForStudent(int studentId)
        {
            return await _context.DiningAssignments
                                 .Where(da => da.StudentId == studentId)
                                 .Include(da => da.DiningSpace)
                                 .ToListAsync();
        }

        [HttpGet("student/{studentId}/next-two-weeks")]
        public async Task<ActionResult<IEnumerable<DiningSchedule>>> GetDiningSchedulesForStudent(int studentId)
        {
            var twoWeeksFromNow = DateTime.Today.AddDays(14);
            return await _context.DiningSchedules
                                 .Where(ds => ds.StudentId == studentId && ds.ScheduledDate <= twoWeeksFromNow)
                                 .Include(ds => ds.DiningSpace)
                                 .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CreateDiningSchedule([FromBody] DiningSchedule schedule)
        {
            _context.DiningSchedules.Add(schedule);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDiningSchedule(int id, [FromBody] DiningSchedule updatedSchedule)
        {
            var schedule = await _context.DiningSchedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            schedule.ScheduledDate = updatedSchedule.ScheduledDate;
            schedule.DiningSpaceId = updatedSchedule.DiningSpaceId;

            _context.DiningSchedules.Update(schedule);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDiningSchedule(int id)
        {
            var schedule = await _context.DiningSchedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _context.DiningSchedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
