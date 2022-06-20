using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.Group;
using MIS.Application.DTOs.Timetable;
using MIS.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    public class GroupController : BaseController
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupFullInfoDTO>>> GetGroups()
        {
            return Ok(await _groupService.GetAllGroupsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupFullInfoDTO>> GetGroup(int id)
        {
            return Ok(await _groupService.GetGroupInfoAsync(id));
        }

        [HttpGet("for-update/{id}")]
        public async Task<ActionResult<GroupInfoDTO>> GetGroupForUpdate(int id)
        {
            return Ok(await _groupService.GetGroupForUpdate(id));
        }

        [HttpGet("update/{id}")]
        public async Task<ActionResult<GroupInfoDTO>> GetGroupUpdate(int id)
        {
            return Ok(await _groupService.GetGroupUpdate(id));
        }

        [HttpPost]
        public async Task<ActionResult<GroupInfoDTO>> PostGroup(AddGroupDTO group)
        {
            return Ok(await _groupService.AddGroupAsync(group));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GroupInfoDTO>> PutGroup(int id, UpdateGroupDTO group)
        {
            return Ok(await _groupService.UpdateGroupAsync(id, group));
        }

        [HttpPut("update-group-course/{id}")]
        public async Task<ActionResult<GroupInfoDTO>> PutGroupCourse(int id, GroupCourseUpdate update)
        {
            return Ok(await _groupService.UpdateGroupCourseAsync(id, update));
        }

        [HttpPut("archive-group/{id}")]
        public async Task<ActionResult<GroupInfoDTO>> ArchiveGroup(int id)
        {
            return Ok(await _groupService.ArchiveGroupAsync(id));
        }
    }
}
