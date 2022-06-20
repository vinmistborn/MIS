using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.Role;
using MIS.Application.Interfaces.Services;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        private readonly ITeacherService _teacherService;

        public AdminController(IRoleService roleService,
                               IUserService userService,
                               ITeacherService teacherService)
        {
            _roleService = roleService;
            _userService = userService;
            _teacherService = teacherService;
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _roleService.GetRolesAsync());
        }

        [HttpPost("role")]
        public async Task<ActionResult<RoleDTO>> PostRole([FromBody] string role)
        {
            return Ok(await _roleService.AddRoleAsync(role));
        }

        [HttpPut("role/{id}")]
        public async Task<ActionResult<RoleDTO>> PutRole(int id, string role)
        {
            return Ok(await _roleService.UpdateRoleAsync(id, role));
        }

        [HttpDelete("deleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleService.DeleteRoleAsync(id);
            return NoContent();
        }

        [HttpPut("addRoleToUser/{id}")]
        public async Task<IActionResult> AddRoleToUser(int id, string role)
        {
            return Ok(await _userService.AddRoleToUserAsync(id, role));
        }

        [HttpPut("removeRoleFromUser/{id}")]
        public async Task<IActionResult> RemoveRoleFromUser(int id, string role)
        {
            return Ok(await _userService.RemoveUserRoleAsync(id, role));
        }

        [HttpPut("addRoleToTeacher/{id}")]
        public async Task<IActionResult> AddRoleToTeacher(int id, string role)
        {
            return Ok(await _teacherService.AddRoleToUserAsync(id, role));
        }

        [HttpPut("removeRoleFromTeacher/{id}")]
        public async Task<IActionResult> RemoveRoleFromTeacher(int id, string role)
        {
            return Ok(await _teacherService.RemoveUserRoleAsync(id, role));
        }
    }
}
