using Alansar.Core.Entities;
using Alansar.Data;
using Microsoft.EntityFrameworkCore;

namespace Alansar.Services
{
    public class GradeService
    {
        private readonly AppDbContext _context;

        public GradeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Grade>> GetAllClassesAsync()
        {
            return await _context.Grades.ToListAsync();
        }

        public async Task<Grade> CreateClassAsync(Grade classModel)
        {
            _context.Grades.Add(classModel);
            await _context.SaveChangesAsync();
            return classModel;
        }

        public async Task<Grade> UpdateClassAsync(int id, Grade classModel)
        {
            var existingClass = await _context.Grades.FindAsync(id);
            if (existingClass == null)
            {
                return null; // Not found
            }

            existingClass.Name = classModel.Name;
            await _context.SaveChangesAsync();
            return existingClass;
        }

        public async Task<bool> DeleteClassAsync(int id)
        {
            var classModel = await _context.Grades.FindAsync(id);
            if (classModel == null)
            {
                return false; // Not found
            }

            _context.Grades.Remove(classModel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
