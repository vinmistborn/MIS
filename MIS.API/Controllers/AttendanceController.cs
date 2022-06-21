using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.Attendance;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.AttendanceSpec;
using MIS.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    [Authorize(Roles = Roles.Teacher)]
    public class AttendanceController : BaseController
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [Authorize(Roles = Roles.Teacher)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceInfoDTO>>> GetAttendanceList()
        {
            return Ok(await _attendanceService.GetAllEntitiesSpecAsync(new AttendanceWithIncludesSpec()));
        }

        [Authorize(Roles = Roles.Teacher)]
        [HttpGet("group-attendance/{groupId}")]
        public async Task<ActionResult<IEnumerable<AttendanceInfoDTO>>> GetGroupAttendance(int groupId)
        {
            return Ok(await _attendanceService.GetGroupAttendance(groupId));
        }

        [Authorize(Roles = Roles.Teacher)]
        [HttpGet("student-attendance/{studentId}")]
        public async Task<ActionResult<IEnumerable<AttendanceInfoDTO>>> GetStudentAttendance(int studentId)
        {
            return Ok(await _attendanceService.GetStudentAttendance(studentId));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<AttendanceInfoDTO>>> PostAttendance(AddAttendanceDTO attendanceDTO)
        {
            return Ok(await _attendanceService.AddAttendanceListAsync(attendanceDTO));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AttendanceDTO>> PutAttendance(int id, UpdateAttendanceDTO attendanceDTO)
        {
            return Ok(await _attendanceService.UpdateStudentAttendanceAsync(id, attendanceDTO));
        }
    }
}
