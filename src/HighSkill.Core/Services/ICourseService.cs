using System.Collections.Generic;
using System.Threading.Tasks;
using HighSkill.Core.Models;


namespace HighSkill.Core.Services
{
    public interface ICourseService
    {
        Task<Course?> GetByIdAsync(int id);
        Task<List<Course>> GetAllAsync();
        Task<Course> CreateAsync(Course course);
        Task<bool> UpdateAsync(Course course);
        Task<bool> DeleteAsync(int id);
        Task<List<Student>> GetCourseStudentsAsync(int courseId);
    }
}