using AutoMapper;
using MIS.Application.DTOs.Course;
using MIS.Domain.Entities;

namespace MIS.Application.Mappings
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
        }
    }
}
