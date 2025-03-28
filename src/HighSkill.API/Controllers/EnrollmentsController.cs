using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HighSkill.Core.Dtos;
using HighSkill.Core.Models;
using HighSkill.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HighSkill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly ILogger<EnrollmentsController> _logger;

        public EnrollmentsController(
            IEnrollmentService enrollmentService,
            ILogger<EnrollmentsController> logger)
        {
            _enrollmentService = enrollmentService;
            _logger = logger;
        }

        /// <summary>
        /// Записать студента на курс
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Enrollment>> CreateEnrollment([FromBody] EnrollmentDto dto)
        {
            try
            {
                var enrollment = await _enrollmentService.EnrollStudentAsync(dto.StudentId, dto.CourseId);
                return CreatedAtAction(
                    nameof(GetEnrollmentById), 
                    new { id = enrollment.Id }, 
                    enrollment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error enrolling student");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Получить запись о зачислении по ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> GetEnrollmentById(int id)
        {
            var enrollment = await _enrollmentService.GetByIdAsync(id);
            return enrollment != null ? Ok(enrollment) : NotFound();
        }

        /// <summary>
        /// Завершить обучение по записи
        /// </summary>
        [HttpPost("{id}/complete")]
        public async Task<IActionResult> CompleteEnrollment(int id)
        {
            var result = await _enrollmentService.CompleteEnrollmentAsync(id);
            return result ? NoContent() : NotFound();
        }

        /// <summary>
        /// Отменить запись на курс
        /// </summary>
        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> CancelEnrollment(int id)
        {
            var result = await _enrollmentService.CancelEnrollmentAsync(id);
            return result ? NoContent() : NotFound();
        }

        /// <summary>
        /// Получить все записи студента
        /// </summary>
        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<List<Enrollment>>> GetStudentEnrollments(int studentId)
        {
            var enrollments = await _enrollmentService.GetByStudentIdAsync(studentId);
            return Ok(enrollments);
        }

        /// <summary>
        /// Получить все записи на курс
        /// </summary>
        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<List<Enrollment>>> GetCourseEnrollments(int courseId)
        {
            var enrollments = await _enrollmentService.GetByCourseIdAsync(courseId);
            return Ok(enrollments);
        }
    }
}