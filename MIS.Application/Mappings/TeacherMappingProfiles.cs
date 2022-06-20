using AutoMapper;
using MIS.Application.DTOs.Teacher;
using MIS.Application.DTOsResolver;
using MIS.Domain.Entities;
using MIS.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MIS.Application.Mappings
{
    public class TeacherMappingProfiles : Profile
    {
        public TeacherMappingProfiles()
        {
            CreateMap<Teacher, TeacherInfoDTO>()
                .ForMember(dest => dest.EmployeeStatus,
                           src => src.MapFrom(x => x.EmployeeStatus.GetAttribute<DisplayAttribute>().Name))
                .ForMember(dest => dest.Branch,
                          src => src.MapFrom(x => $"{x.Branch.District} - {x.Branch.Address}"))
                .ForMember(dest => dest.Roles,
                           src => src.MapFrom<GenericUserResolver<Teacher, TeacherInfoDTO, IEnumerable<string>>>())
                .ForMember(dest => dest.Groups,
                           src => src.MapFrom<TeacherGroupCodeResolver>());
            CreateMap<Teacher, TeacherDTO>().ReverseMap();  
        }
    }
}
