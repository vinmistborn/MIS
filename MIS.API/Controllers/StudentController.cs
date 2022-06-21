using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.Student;
using MIS.Application.DTOs.StudentGroupHistory;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.StudentSpec;
using MIS.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentInfoDTO>>> GetStudents()
        {
            return Ok(await _studentService.GetAllEntitiesSpecAsync(new StudentWithGroupSpec()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentInfoDTO>> GetStudent(int id)
        {
            return Ok(await _studentService.GetEntityInfoSpecAsync(new StudentWithGroupSpec(id)));
        }


        [HttpGet("for-update/{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudentForUpdate(int id)
        {
            return Ok(await _studentService.GetStudentForUpdate(id));
        }

        [HttpPost]
        public async Task<ActionResult<StudentInfoDTO>> PostStudent([FromBody] StudentDTO student)
        {
            return Ok(await _studentService.AddStudentAsync(student));            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentInfoDTO>> PutStudent(int id, [FromBody] StudentDTO student)
        {
            return Ok(await _studentService.UpdateStudentAsync(id, student));
        }

        [HttpPut("addGroup/{id}")]
        public async Task<ActionResult<StudentInfoDTO>> AddGroupsToStudent(int id, NewStudentGroups groups)
        {
            return Ok(await _studentService.AddGroupsToStudentAsync(id, groups));
        }

        [HttpPut("removeGroup/{id}")]
        public async Task<ActionResult<StudentInfoDTO>> RemoveGroupFromStudent(int id, RemoveGroupDTO group)
        {
            return Ok(await _studentService.RemoveGroupFromStudent(id, group));
        }

        [HttpPut("archiveStudent/{id}")]
        public async Task<ActionResult<StudentInfoDTO>> ArchiveStudent(int id)
        {
            return Ok(await _studentService.ArchiveStudentAsync(id));
        }

        [HttpGet("studentHistory/{id}")]
        public async Task<ActionResult<IEnumerable<StudentGroupHistoryDTO>>> GetStudentGroupHistory(int id)
        {
            return Ok(await _studentService.GetStudentGroupsListAsync(id));
        }
    }
}
