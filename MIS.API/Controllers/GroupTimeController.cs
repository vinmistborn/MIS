using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.GroupTime;
using MIS.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    public class GroupTimeController : BaseController
    {
        private readonly IGroupTimeService _groupTimeService;

        public GroupTimeController(IGroupTimeService groupTimeService)
        {
            _groupTimeService = groupTimeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupTimeDTO>>> GetGroupTimes()
        {
            return Ok(await _groupTimeService.GetAllEntitiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupTimeDTO>> GetGroupTime(int id)
        {
            return Ok(await _groupTimeService.GetEntityInfoAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GroupTimeDTO groupTime)
        {
            return Ok(await _groupTimeService.AddEntityAsync(groupTime));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GroupTimeDTO groupTime)
        {
            return Ok(await _groupTimeService.UpdateEntityAsync(id, groupTime));
        }
    }
}
