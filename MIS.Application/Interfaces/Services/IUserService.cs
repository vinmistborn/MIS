using MIS.Application.DTOs.User;
using MIS.Domain.Entities.Identity;

namespace MIS.Application.Interfaces.Services
{
    public interface IUserService : IGenericUserService<User, UserInfoDTO>
    {

    }
}
