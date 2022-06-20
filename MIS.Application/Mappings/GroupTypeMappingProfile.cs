using AutoMapper;
using MIS.Application.DTOs.GroupType;
using MIS.Domain.Entities;

namespace MIS.Application.Mappings
{
    public class GroupTypeMappingProfile : Profile
    {
        public GroupTypeMappingProfile()
        {
            CreateMap<GroupType, GroupTypeDTO>()
                .ForMember(dest => dest.FeeIncreaseBy,
                           src => src.MapFrom(x => x.IncreaseFeeBy))
                .ReverseMap();
        }
    }
}
