using AutoMapper;
using MIS.Application.DTOs.Student;
using MIS.Application.DTOsResolver;
using MIS.Domain.Entities;

namespace MIS.Application.Mappings
{
    public class StudentMappingProfiles : Profile
    {
        public StudentMappingProfiles()
        {
            CreateMap<Student, StudentInfoDTO>()
                .ForMember(dest => dest.DoB,
                           src => src.MapFrom(x => x.DoB.ToShortDateString()))
                .ForMember(dest => dest.Groups,
                           src => src.MapFrom<StudentGroupCodeResolver>());
            CreateMap<Student, StudentDTO>()                
                .ReverseMap()
                .ForMember(dest => dest.IsActive,
                           src => src.Ignore());
        }
    }
}
