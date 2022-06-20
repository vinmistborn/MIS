using AutoMapper;
using MIS.Application.DTOs.Role;
using MIS.Domain.Entities.Identity;

namespace MIS.Application.Mappings
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleDTO>()
                .ForMember(dest => dest.Name,
                           src => src.MapFrom(x => x.Name)).ReverseMap();
        }
    }
}
