using MIS.Application.DTOs.User;
using MIS.Domain.Enums;
using MIS.Shared.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Services
{
    public interface IGenericUserService<TEntity, TInfoDTO> :
                     IGenericServiceInfoSpec<TEntity, TInfoDTO> where TEntity : class
                                                                where TInfoDTO : class
    {
        Task<TInfoDTO> AddRoleToUserAsync(int userId, string roleName);
        Task<TInfoDTO> RemoveUserRoleAsync(int userId, string roleName);
        Task<IEnumerable<TInfoDTO>> GetUsersOnLeaveAsync();
        Task<IEnumerable<TInfoDTO>> GetUsersQuitAsync();
        Task<TInfoDTO> UpdateUserAsync(UserDTO userDTO);
        Task<TInfoDTO> UpdateUserStatusAsync(int userId, EmployeeStatus employeeStatus);
    }
}
