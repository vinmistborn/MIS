using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MIS.Application.DTOs.User;
using MIS.Domain.Entities.Identity;
using MIS.Domain.Exceptions.Identity;
using MIS.Application.Interfaces.Services;
using MIS.Shared.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using MIS.Shared.Interfaces.Repositories;
using MIS.Domain.Enums;

namespace MIS.Application.Services
{
    public class GenericUserService<TEntity, TInfoDTO> : GenericServiceInfoSpec<TEntity, TInfoDTO>,
                                                         IGenericUserService<TEntity, TInfoDTO> where TEntity : User
                                                                                                where TInfoDTO : UserInfoDTO
    {
        protected readonly UserManager<TEntity> _userManager;
        protected readonly IGenericUserRepository<TEntity> _userRepo;

        public GenericUserService(UserManager<TEntity> userManager,
                           IGenericUserRepository<TEntity> userRepo,
                           IMapper mapper) : base(userRepo, mapper)
        {
            _userManager = userManager;
            _userRepo = userRepo;
        }

        
        public async Task<TInfoDTO> AddRoleToUserAsync(int userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (await _userManager.IsInRoleAsync(user, roleName))
            {
                throw new UserInRoleException(user.FirstName, roleName);
            }
            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result is null ? throw new AddRoleFailedException(user.FirstName, roleName) : _mapper.Map<TInfoDTO>(user);
        }

        public async Task<IEnumerable<TInfoDTO>> GetUsersOnLeaveAsync()
        {
            return _mapper.Map<IEnumerable<TInfoDTO>>(await _userRepo.GetUsersOnLeaveAsync());
        }

        public async Task<IEnumerable<TInfoDTO>> GetUsersQuitAsync()
        {
            return _mapper.Map<IEnumerable<TInfoDTO>>(await _userRepo.GetUsersQuitAsync());
        }

        public async Task<TInfoDTO> RemoveUserRoleAsync(int userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is null)
            {
                throw new EntityNotFoundException("user", userId);
            }
            await _userManager.RemoveFromRoleAsync(user, roleName);
            return _mapper.Map<TInfoDTO>(user);
        }

        public async Task<TInfoDTO> UpdateUserAsync(UserDTO userDTO)
        {
            var user = await _userManager.FindByIdAsync(userDTO.Id.ToString());
            if (user is null)
            {
                throw new EntityNotFoundException("user", userDTO.Id);
            }
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.UserName = userDTO.UserName;
            user.Email = userDTO.Email;
            user.PhoneNumber = userDTO.PhoneNumber;
            user.EmployeeStatus = EmployeeStatus.Active;
            user.DoB = userDTO.DoB;
            user.BranchId = userDTO.BranchId;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded ? _mapper.Map<TInfoDTO>(user) : throw new UpdateFailedException(user.Id);
        }

        public virtual async Task<TInfoDTO> UpdateUserStatusAsync(int userId, EmployeeStatus employeeStatus)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            user.EmployeeStatus = employeeStatus;

            await _userRepo.SaveChangesAsync();
            return _mapper.Map<TInfoDTO>(user);
        }
    }
}
