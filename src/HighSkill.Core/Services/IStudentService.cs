using System.Collections.Generic;
using System.Threading.Tasks;
using HighSkill.Core.Models;

namespace HighSkill.Core.Services
{
    public interface IStudentService
    {
        Task<Student?> GetByIdAsync(int id);
        Task<List<Student>> GetAllAsync();
        Task<Student> CreateAsync(Student student);
        Task<bool> UpdateAsync(Student student);
        Task<bool> DeleteAsync(int id);
        Task<List<Course>> GetStudentCoursesAsync(int studentId);
    }
}