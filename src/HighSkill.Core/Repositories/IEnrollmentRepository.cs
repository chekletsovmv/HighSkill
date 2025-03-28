
using System.Collections.Generic;
using System.Threading.Tasks;
using HighSkill.Core.Models;

namespace HighSkill.Core.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment?> GetByIdAsync(int id);
        Task<Enrollment> CreateAsync(Enrollment enrollment);
        Task<bool> UpdateAsync(Enrollment enrollment);
        Task<bool> DeleteAsync(int id);
        Task<List<Enrollment>> GetByStudentIdAsync(int studentId);
        Task<List<Enrollment>> GetByCourseIdAsync(int courseId);
        Task<bool> ExistsAsync(int studentId, int courseId);
    }
}