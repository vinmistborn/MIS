using AutoMapper;
using MIS.Application.DTOs.Group;
using MIS.Application.DTOsResolver;
using MIS.Domain.Entities;

namespace MIS.Application.Mappings
{
    public class GroupMappingProfiles : Profile
    {
        public GroupMappingProfiles()
        {
            CreateMap<Group, AddGroupDTO>()                  
                .ReverseMap();

            CreateMap<Group, GroupInfoDTO>()
                .ForMember(dest => dest.GroupType,
                           src => src.MapFrom(x => x.GroupType.Type))
                .ForMember(dest => dest.Course,
                           src => src.MapFrom(x => $"{x.Course.Name} - {x.Course.CourseLevel}"));
            CreateMap<Group, GroupFullInfoDTO>()
                .ForMember(dest => dest.GroupType,
                           src => src.MapFrom(x => x.GroupType.Type))
                .ForMember(dest => dest.Course,
                           src => src.MapFrom(x => $"{x.Course.Name} - {x.Course.CourseLevel}"))
                .ForMember(dest => dest.Teachers,
                           src => src.MapFrom<GroupTeacherResolver>())        
                .ForMember(dest => dest.Code,
                           src => src.MapFrom(x => x.Code));
        }
    }
}
