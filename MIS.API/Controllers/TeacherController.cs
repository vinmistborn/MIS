using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.Group;
using MIS.Application.DTOs.Teacher;
using MIS.Application.DTOs.User;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications;
using MIS.Domain.Enums;
using MIS.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class TeacherController : BaseController
    {
        private readonly ITeacherService _teacherService;
        private readonly IGroupService _groupService;

        public TeacherController(ITeacherService teacherService,
                                 IGroupService groupService)
        {
            _teacherService = teacherService;
            _groupService = groupService;
        }

        [Authorize(Roles = Roles.Teacher)]
        [HttpGet("teachers")]
        public async Task<ActionResult<IEnumerable<TeacherInfoDTO>>> GetAllTeachers()
        {
            return Ok(await _teacherService.GetAllEntitiesSpecAsync(new TeacherWithIncludesSpec()));
        }

        [Authorize(Roles = Roles.Teacher)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherInfoDTO>> GetTeacher(int id)
        {
            return Ok(await _teacherService.GetEntityInfoSpecAsync(new TeacherWithIncludesSpec(id)));
        }

        [HttpPut("addGroupToTeacher")]
        public async Task<ActionResult<TeacherInfoDTO>> AddGroupToTeacher(int groupId, int teacherId)
        {
            return Ok(await _teacherService.AddGroupToTeacherAsync(groupId, teacherId));
        }

        [HttpPut("removeGroupFromTeacher")]
        public async Task<ActionResult<TeacherInfoDTO>> RemoveGroupFromTeacher(int groupId, int teacherId)
        {
            return Ok(await _teacherService.RemoveGroupFromTeacherAsync(groupId, teacherId));
        }

        [Authorize(Roles = Roles.Teacher)]
        [HttpGet("teacher-groups/{id}")]
        public async Task<ActionResult<ActionResult<IEnumerable<GroupFullInfoDTO>>>> GetTeacherGroups(int id)
        {
            return Ok(await _groupService.GetTeacherGroups(id));
        }

        [HttpPut("update-teacher/{id}")]
        public async Task<ActionResult<TeacherInfoDTO>> PutAdmin(int id, UserDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            return Ok(await _teacherService.UpdateUserAsync(user));
        }

        [HttpPut("update-teacher-status/{id}")]
        public async Task<ActionResult<TeacherInfoDTO>> PutAdmin(int id, EmployeeStatus employeeStatus)
        {
            return Ok(await _teacherService.UpdateUserStatusAsync(id, employeeStatus));
        }
    }
}
