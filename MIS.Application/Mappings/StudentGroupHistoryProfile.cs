using AutoMapper;
using MIS.Application.DTOs.StudentGroupHistory;
using MIS.Domain.Entities;

namespace MIS.Application.Mappings
{
   public class StudentGroupHistoryProfile : Profile
    {
        public StudentGroupHistoryProfile()
        {
            CreateMap<StudentGroupHistory, StudentGroupHistoryDTO>()
                .ForMember(dest => dest.Student,
                           src => src.MapFrom(x => $"{x.Student.FirstName} {x.Student.LastName}"))
                .ForMember(dest => dest.Group,
                           src => src.MapFrom(x => x.Group.Code))
                .ForMember(dest => dest.FirstLesson,
                           src => src.MapFrom(x => x.FirstLesson.GetValueOrDefault().ToShortDateString()))
                .ForMember(dest => dest.LastLesson,
                           src => src.MapFrom(x => x.LastLesson.GetValueOrDefault().ToShortDateString()));
        }
    }
}
