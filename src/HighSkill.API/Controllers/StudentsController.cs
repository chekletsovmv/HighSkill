using System.Collections.Generic;
using System.Threading.Tasks;
using HighSkill.Core.Models;
using HighSkill.API.Data;
using Microsoft.EntityFrameworkCore;
using HighSkill.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace HighSkill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(
            IStudentService studentService,
            ILogger<StudentsController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            return student != null ? Ok(student) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            var createdStudent = await _studentService.CreateAsync(student);
            return CreatedAtAction(nameof(GetById), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Student student)
        {
            if (id != student.Id) return BadRequest();
            var result = await _studentService.UpdateAsync(student);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }

        [HttpGet("{id}/courses")]
        public async Task<IActionResult> GetStudentCourses(int id)
        {
            var courses = await _studentService.GetStudentCoursesAsync(id);
            return Ok(courses);
        }
    }
}
