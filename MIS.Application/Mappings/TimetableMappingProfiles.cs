using AutoMapper;
using MIS.Application.DTOs.Timetable;
using MIS.Application.DTOsResolver;
using MIS.Domain.Entities;

namespace MIS.Application.Mappings
{
    public class TimetableMappingProfiles : Profile
    {
        public TimetableMappingProfiles()
        {
            CreateMap<Timetable, UpdateTimetableDTO>().ReverseMap();
            CreateMap<Timetable, TimetableInfoDTO>()
                .ForMember(dest => dest.LessonDay,
                           src => src.MapFrom(x => x.LessonDay.DayOfWeek.ToString()))
                .ForMember(dest => dest.Room,
                           src => src.MapFrom(x => x.Room.Code))
                .ForMember(dest => dest.TimeSlot,
                           src => src.MapFrom(x => x.GroupTime.Time))
                .ForMember(dest => dest.GroupCode,
                           src => src.MapFrom<TimetableGroupCodeResolver>());
            CreateMap<Timetable, TimetableFullInfoDTO>()
                .IncludeBase<Timetable, TimetableInfoDTO>()
                .ForMember(dest => dest.Course,
                           src => src.MapFrom<TimetableGroupCourseResolver>())
                .ForMember(dest => dest.Teacher,
                           src => src.MapFrom<TimetableGroupTeachersResolver>());
        }
    }
}
