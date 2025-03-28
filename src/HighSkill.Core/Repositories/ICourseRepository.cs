using System.Collections.Generic;
using System.Threading.Tasks;
using HighSkill.Core.Models;

namespace HighSkill.Core.Repositories
{
    public interface ICourseRepository
    {
        Task<Course?> GetByIdAsync(int id);
        Task<List<Course>> GetAllAsync();
        Task<Course> CreateAsync(Course course);
        Task<bool> UpdateAsync(Course course);
        Task<bool> DeleteAsync(int id);
    }
}