using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MIS.Application.DTOs.Role;
using MIS.Domain.Entities.Identity;
using MIS.Domain.Exceptions.Identity;
using MIS.Application.Interfaces.Services;
using MIS.Shared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IRepository<Role> _roleRepo;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<Role> roleManager,
                           IRepository<Role> roleRepo,
                           IMapper mapper)
        {
            _roleManager = roleManager;
            _roleRepo = roleRepo;
            _mapper = mapper;
        }

        public async Task<RoleDTO> AddRoleAsync(string role)
        {
            await CheckForDuplicateRole(role);
            var newRole = new Role(role);
            var result = await _roleManager.CreateAsync(newRole);
            return result.Succeeded ? _mapper.Map<RoleDTO>(newRole) : throw new AddRoleFailedException(role);
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(role);
        }

        public async Task<IEnumerable<RoleDTO>> GetRolesAsync()
        {
            return _mapper.Map<IEnumerable<RoleDTO>>(await _roleRepo.ListAsync());
        }

        public async Task<RoleDTO> UpdateRoleAsync(int id, string newRole)
        {
            await CheckForDuplicateRole(newRole);
            var role = await _roleManager.FindByIdAsync(id.ToString());
            role.Name = newRole;
            var result = await _roleManager.UpdateAsync(role);
            return result.Succeeded ? _mapper.Map<RoleDTO>(role) : throw new UpdateRoleFailedException(newRole);
        }

        public async Task CheckForDuplicateRole(string role)
        {
            var existingRole = await _roleManager.FindByNameAsync(role);
            if (existingRole != null)
            {
                throw new DuplicateRoleException(role);
            }
        }
    }
}
