using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.Room;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications;
using MIS.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class RoomController : BaseController
    {
        private readonly IRoomService _roomService;        

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet()]     
        public async Task<ActionResult<IEnumerable<RoomInfoDTO>>> GetRooms()
        {
            return Ok(await _roomService.GetAllEntitiesSpecAsync(new RoomWithBranchSpec()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomInfoDTO>> GetRoom(int id)
        {
            return Ok(await _roomService.GetEntityInfoSpecAsync(new RoomWithBranchSpec(id)));
        }

        [HttpGet("for-update/{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoomForUpdate(int id)
        {
            return Ok(await _roomService.GetEntityAsync(id));
        }

        [HttpPost]        
        public async Task<ActionResult<RoomInfoDTO>> Post([FromBody] RoomDTO room)
        {
            return Ok(await _roomService.AddEntityAsync(room));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RoomDTO room)
        {
            return Ok(await _roomService.UpdateEntityAsync(id, room));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomService.DeleteEntity(id);
            return NoContent();
        }
    }
}
