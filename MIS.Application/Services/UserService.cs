using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MIS.Application.DTOs.User;
using MIS.Domain.Entities.Identity;
using MIS.Application.Interfaces.Services;
using MIS.Shared.Interfaces.Repositories;

namespace MIS.Application.Services
{
    public class UserService : GenericUserService<User, UserInfoDTO>, IUserService
    {
        public UserService(UserManager<User> userManager,
                           IGenericUserRepository<User> userRepo,                        
                           IMapper mapper) : base(userManager, userRepo, mapper)
        {
           
        }       
    }
}
