using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MIS.Application.DTOs.IdentityResponse;
using MIS.Application.DTOs.User;
using MIS.Domain.Entities.Identity;
using MIS.Domain.Enums;
using MIS.Domain.Exceptions.Identity;
using MIS.Application.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace MIS.Application.Services
{
    public class AccountService<TEntity, TDto> : IAccountService<TEntity, TDto> where TEntity : User, new()
                                                                                where TDto : UserInfoDTO
    {
        private readonly UserManager<TEntity> _userManager;
        private readonly SignInManager<TEntity> _signInManager;
        private readonly ITokenClaimsService _tokenClaimsService;
        private readonly IMapper _mapper;
        public AccountService(UserManager<TEntity> userManager,
                              SignInManager<TEntity> signInManager,
                              ITokenClaimsService tokenClaimsService,
                              IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenClaimsService = tokenClaimsService;
            _mapper = mapper;
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AuthenticateResponse> Login(LoginDTO loginDTO)
        {            
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user is null)
            {
                throw new InvalidEmailException(loginDTO.Email);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
            if (!result.Succeeded)
            {
                var responseBadRequest = new AuthenticateResponse();
                responseBadRequest.Successful = false;
                responseBadRequest.Error = "Your username or password is invalid";
                throw new InvalidPasswordException(responseBadRequest.Error);
            }
            var response = new AuthenticateResponse();
            response.Successful = true;
            response.Token = await _tokenClaimsService.GetTokenAsync(user);
            return response;
        }

        public async Task<AuthorizeResponse<TDto>> RegisterUserAsync(RegisterDTO registerDTO)
        {
            var response = new AuthorizeResponse<TDto>();
            await CheckForExistingUserAsync(registerDTO);

            var user = new TEntity
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                DoB = registerDTO.DoB,
                PhoneNumber = registerDTO.PhoneNumber,
                EmployeeStatus = EmployeeStatus.Active,
                BranchId = registerDTO.BranchId,
                UserName = registerDTO.UserName,
                Email = registerDTO.Email
            };
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                response.Errors = result.Errors.Select(x => x.Description);
            }
            response.User = _mapper.Map<TDto>(user);
            return response;
        }

        public async Task CheckForExistingUserAsync(RegisterDTO newAccount)
        {
            var existingAccountWithEmail = await _userManager.FindByEmailAsync(newAccount.Email);
            
            if(existingAccountWithEmail is not null)
            {
                throw new ExistingEmailException(newAccount.Email);
            }

            var existingAccountWithUserName = await _userManager.FindByNameAsync(newAccount.UserName);

            if(existingAccountWithUserName is not null)
            {
                throw new ExistingUserNameException(newAccount.UserName);
            }
        }
    }
}
