using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSkill.Core.Models;
using HighSkill.Core.Repositories;
using HighSkill.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HighSkill.API.Data.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Enrollment?> GetByIdAsync(int id)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Enrollment> CreateAsync(Enrollment enrollment)
        {
            // Проверка на существующую запись
            if (await ExistsAsync(enrollment.StudentId, enrollment.CourseId))
                throw new InvalidOperationException("Student already enrolled in this course");

            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<bool> UpdateAsync(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var enrollment = await GetByIdAsync(id);
            if (enrollment == null) return false;

            _context.Enrollments.Remove(enrollment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Enrollment>> GetByStudentIdAsync(int studentId)
        {
            return await _context.Enrollments
                .Where(e => e.StudentId == studentId)
                .Include(e => e.Course)
                .ToListAsync();
        }

        public async Task<List<Enrollment>> GetByCourseIdAsync(int courseId)
        {
            return await _context.Enrollments
                .Where(e => e.CourseId == courseId)
                .Include(e => e.Student)
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(int studentId, int courseId)
        {
            return await _context.Enrollments
                .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
        }
    }
}