using System.Collections.Generic;
using System.Threading.Tasks;
using HighSkill.Core.Models;
using HighSkill.Core.Repositories;
using HighSkill.Core.Services;

namespace HighSkill.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public StudentService(
            IStudentRepository studentRepository,
            IEnrollmentRepository enrollmentRepository)
        {
            _studentRepository = studentRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> CreateAsync(Student student)
        {
            return await _studentRepository.CreateAsync(student);
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            return await _studentRepository.UpdateAsync(student);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _studentRepository.DeleteAsync(id);
        }

        public async Task<List<Course>> GetStudentCoursesAsync(int studentId)
        {
            return await _studentRepository.GetCoursesByStudentIdAsync(studentId);
        }
    }
}