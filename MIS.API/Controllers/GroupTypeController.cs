using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.GroupType;
using MIS.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    public class GroupTypeController : BaseController
    {
        private readonly IGroupTypeService _groupService;

        public GroupTypeController(IGroupTypeService groupService)
        {
            _groupService = groupService;
        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupTypeDTO>>> GetGroupTypes()
        {
            return Ok(await _groupService.GetAllEntitiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupTypeDTO>> GetGroupType(int id)
        {
            return Ok(await _groupService.GetEntityInfoAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostGroupType([FromBody] GroupTypeDTO groupType)
        {
            return Ok(await _groupService.AddEntityAsync(groupType));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupType(int id, [FromBody] GroupTypeDTO groupType)
        {
            return Ok(await _groupService.UpdateEntityAsync(id, groupType));
        }
    }
}
