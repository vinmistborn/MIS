using AutoMapper;
using MIS.Application.DTOs.GroupTime;
using MIS.Domain.Entities;

namespace MIS.Application.Mappings
{
    public class GroupTimeProfile : Profile
    {
        public GroupTimeProfile()
        {
            CreateMap<GroupTime, GroupTimeDTO>().ReverseMap();
        }
    }
}
