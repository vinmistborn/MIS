using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.Course;
using MIS.Application.Interfaces.Services;
using MIS.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>>  GetCourses()
        {
            return Ok(await _courseService.GetAllEntitiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetCourse(int id)
        {
            return Ok(await _courseService.GetEntityInfoAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<CourseDTO>> PostCourse([FromBody] CourseDTO course)
        {
            return Ok(await _courseService.AddEntityAsync(course));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, [FromBody] CourseDTO course)
        {
            return Ok(await _courseService.UpdateEntityAsync(id, course));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteEntity(id);
            return NoContent();
        }
    }
}
