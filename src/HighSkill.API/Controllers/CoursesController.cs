using System.Collections.Generic;
using System.Threading.Tasks;
using HighSkill.Core.Models;
using HighSkill.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HighSkill.Core.Services;
using Microsoft.Extensions.Logging;

namespace HighSkill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(
            ICourseService courseService,
            ILogger<CoursesController> logger)
        {
            _courseService = courseService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAll()
        {
            return await _courseService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course?>> GetById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            return course != null ? Ok(course) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Course>> Create([FromBody] Course course)
        {
            var createdCourse = await _courseService.CreateAsync(course);
            return CreatedAtAction(nameof(GetById), new { id = createdCourse.Id }, createdCourse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Course course)
        {
            if (id != course.Id) return BadRequest();
            var result = await _courseService.UpdateAsync(course);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _courseService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }

        [HttpGet("{id}/students")]
        public async Task<ActionResult<List<Student>>> GetCourseStudents(int id)
        {
            return await _courseService.GetCourseStudentsAsync(id);
        }
    }
}