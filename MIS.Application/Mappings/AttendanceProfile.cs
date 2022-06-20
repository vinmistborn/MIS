using AutoMapper;
using MIS.Application.DTOs.Attendance;
using MIS.Application.DTOsResolver;
using MIS.Domain.Entities;
using MIS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MIS.Application.Mappings
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            CreateMap<Attendance, AttendanceInfoDTO>()
                .ForMember(dest => dest.DateTime,
                           src => src.MapFrom(x => x.DateTime.Date))
                .ForMember(dest => dest.Student,
                           src => src.MapFrom<AttendanceStudentResolver>())
                .ForMember(dest => dest.GroupCode,
                           src => src.MapFrom(x => x.Group.Code));
        }
    }
}
