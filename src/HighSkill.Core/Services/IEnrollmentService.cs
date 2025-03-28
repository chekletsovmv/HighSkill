using System.Collections.Generic;
using System.Threading.Tasks;
using HighSkill.Core.Dtos;
using HighSkill.Core.Models;

namespace HighSkill.Core.Services
{
    public interface IEnrollmentService
    {
        Task<Enrollment> EnrollStudentAsync(int studentId, int courseId);
        Task<bool> CompleteEnrollmentAsync(int enrollmentId);
        Task<bool> CancelEnrollmentAsync(int enrollmentId);
        Task<Enrollment?> GetByIdAsync(int id);
        Task<List<Enrollment>> GetByStudentIdAsync(int studentId);
        Task<List<Enrollment>> GetByCourseIdAsync(int courseId);
    }
}