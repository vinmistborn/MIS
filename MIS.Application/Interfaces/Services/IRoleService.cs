using MIS.Application.DTOs.Role;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Services
{
    public interface IRoleService
    {
        Task<RoleDTO> AddRoleAsync(string role);
        Task<RoleDTO> UpdateRoleAsync(int id, string newRole);
        Task<IEnumerable<RoleDTO>> GetRolesAsync();
        Task DeleteRoleAsync(int id);
    }
}
