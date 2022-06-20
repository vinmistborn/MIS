using AutoMapper;
using MIS.Application.DTOs.Room;
using MIS.Domain.Entities;

namespace MIS.Application.Mappings
{
    public class RoomMappingProfiles : Profile
    {
        public RoomMappingProfiles()
        {
            CreateMap<Room, RoomInfoDTO>()                
                .ForMember(dest => dest.Branch,
                           src => src.MapFrom(x => $"{x.Branch.District} - {x.Branch.Address}"));

            CreateMap<Room, RoomDTO>().ReverseMap();
        }        
    }
}
