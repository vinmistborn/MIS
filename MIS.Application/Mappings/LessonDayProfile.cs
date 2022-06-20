using AutoMapper;
using MIS.Application.DTOs.LessonDays;
using MIS.Domain.Entities;

namespace MIS.Application.Mappings
{
    public class LessonDayProfile : Profile
    {
        public LessonDayProfile()
        {
            CreateMap<LessonDay, LessonDayDTO>().ReverseMap();
            CreateMap<LessonDay, LessonDayInfoDTO>()
                .ForMember(dest => dest.Day,
                           src => src.MapFrom(x => x.DayOfWeek.ToString()));
        }
    }
}
