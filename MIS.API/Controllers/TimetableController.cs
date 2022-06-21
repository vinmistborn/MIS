using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.Timetable;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.TimetableSpec;
using MIS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class TimetableController : BaseController
    {
        private readonly ITimetableService _timetableService;

        public TimetableController(ITimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        [HttpGet("slots")]
        public async Task<ActionResult<IEnumerable<TimetableInfoDTO>>> GetAllTimetableSlots()
        {
            return Ok(await _timetableService.GetAllEntitiesSpecAsync(new TimetableSpec()));
        }

        [HttpGet("group-timetable/{groupId}")]
        public async Task<ActionResult<IEnumerable<TimetableFullInfoDTO>>> GetGroupTimetable(int groupId)
        {
            return Ok(await _timetableService.GetGroupTimetable(groupId));
        }

        [HttpGet("teacher-timetable/{teacherId}")]
        public async Task<ActionResult<IEnumerable<TimetableFullInfoDTO>>> GetTeacherTimetable(int teacherId)
        {
            return Ok(await _timetableService.GetTeacherTimetable(teacherId));
        }

        [HttpGet("course-timetable/{courseId}")]
        public async Task<ActionResult<IEnumerable<TimetableFullInfoDTO>>> GetCourseTimetable(int courseId)
        {
            return Ok(await _timetableService.GetCourseTimetable(courseId));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<TimetableInfoDTO>>> PostTimetableSlots([FromBody] AddTimetableDTO timetableDTO)
        {
            return Ok(await _timetableService.AddTimetableSlotsAsync(timetableDTO));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateTimetableDTO>> PutTimetableSlot(int id, [FromBody] UpdateTimetableDTO timetableDTO)
        {
            return Ok(await _timetableService.UpdateEntityAsync(id, timetableDTO));
        }

        [HttpPut("add-group")]
        public async Task<ActionResult<TimetableInfoDTO>> PutGroupTimetableSlot([FromBody] UpdateGroupTimetableDTO timetableDTO)
        {
            return Ok(await _timetableService.UpdateGroupTimetableAsync(timetableDTO));
        }
    }
}
