using MIS.Application.DTOs.IdentityResponse;
using MIS.Application.DTOs.User;
using MIS.Domain.Entities.Identity;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Services
{
    public interface IAccountService<TEntity, TDto>  where TEntity: User
                                                     where TDto : UserInfoDTO
    {
        Task<AuthenticateResponse> Login(LoginDTO loginDTO);
        Task LogOutAsync();
        Task<AuthorizeResponse<TDto>> RegisterUserAsync(RegisterDTO user);
    }
}
