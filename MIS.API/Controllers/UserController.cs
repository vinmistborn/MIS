using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.User;
using MIS.Domain.Entities.Identity;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.UserSpec;
using System.Collections.Generic;
using System.Threading.Tasks;
using MIS.Domain.Enums;

namespace MIS.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserInfoDTO>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllEntitiesSpecAsync(new UserWithBranchSpec<User>()));
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<UserInfoDTO>> GetAdmin(int id)
        {
            return Ok(await _userService.GetEntityInfoSpecAsync(new UserWithBranchSpec<User>(id)));
        }

        [HttpGet("admins-on-leave")]
        public async Task<ActionResult<IEnumerable<UserInfoDTO>>> GetAdminsOnLeave()
        {
            return Ok(await _userService.GetUsersOnLeaveAsync());
        }

        [HttpPut("user-update/{id}")]
        public async Task<ActionResult<UserInfoDTO>> PutAdmin(int id, UserDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            return Ok(await _userService.UpdateUserAsync(user));            
        }

        [HttpPut("user-status-update/{id}")]
        public async Task<ActionResult<UserInfoDTO>> PutAdmin(int id, EmployeeStatus employeeStatus)
        {
            return Ok(await _userService.UpdateUserStatusAsync(id, employeeStatus));
        }
    }
}
