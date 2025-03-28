using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighSkill.Core.Models;
using HighSkill.Core.Repositories;
using HighSkill.Core.Services;

namespace HighSkill.API.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public CourseService(
            ICourseRepository courseRepository,
            IEnrollmentRepository enrollmentRepository)
        {
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course> CreateAsync(Course course)
        {
            return await _courseRepository.CreateAsync(course);
        }

        public async Task<bool> UpdateAsync(Course course)
        {
            return await _courseRepository.UpdateAsync(course);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _courseRepository.DeleteAsync(id);
        }

        public async Task<List<Student>> GetCourseStudentsAsync(int courseId)
        {
            var enrollments = await _enrollmentRepository.GetByCourseIdAsync(courseId);
            return enrollments.Select(e => e.Student!).ToList();
        }
    }
}