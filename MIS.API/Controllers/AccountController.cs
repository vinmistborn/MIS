using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.Teacher;
using MIS.Application.DTOs.User;
using MIS.Domain.Entities;
using MIS.Domain.Entities.Identity;
using MIS.Application.Interfaces.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MIS.Shared;

namespace MIS.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService<User, UserInfoDTO> _userAccountService;
        private readonly IAccountService<Teacher, TeacherInfoDTO> _teacherAccountService;
        public AccountController(IAccountService<User, UserInfoDTO> userAccountService,
                                 IAccountService<Teacher, TeacherInfoDTO> teacherAccountService)
        {
            _userAccountService = userAccountService;
            _teacherAccountService = teacherAccountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var response = await _userAccountService.Login(loginDTO);
            return Ok(response);
        }

        //[Authorize(Roles = Roles.Admin)]
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterDTO registerDTO)
        {
            var user = await _userAccountService.RegisterUserAsync(registerDTO);
            return Ok(user);
        }

        //[Authorize(Roles = Roles.Admin)]
        [HttpPost("register-teacher")]
        public async Task<IActionResult> RegisterTeacher(RegisterDTO registerDTO)
        {
            var user = await _teacherAccountService.RegisterUserAsync(registerDTO);
            return Ok(user);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userAccountService.LogOutAsync();
            return Ok();
        }
    }
}
