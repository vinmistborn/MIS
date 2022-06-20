using AutoMapper;
using MIS.Application.DTOs.User;
using MIS.Application.DTOsResolver;
using MIS.Domain.Entities.Identity;
using MIS.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MIS.Application.Mappings
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<User, UserDTO>().ReverseMap();            
            CreateMap<User, UserInfoDTO>()
                .ForMember(dest => dest.UserName,
                           src => src.MapFrom(x => x.UserName))
                .ForMember(dest => dest.Branch,
                          src => src.MapFrom(x => $"{x.Branch.District} - {x.Branch.Address}"))
                .ForMember(dest => dest.EmployeeStatus,
                           src => src.MapFrom(x => x.EmployeeStatus.GetAttribute<DisplayAttribute>().Name))
                .ForMember(dest => dest.Roles,
                           src => src.MapFrom<GenericUserResolver<User, UserInfoDTO, IEnumerable<string>>>());              
        }
    }
}
