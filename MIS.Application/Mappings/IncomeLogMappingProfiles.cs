using AutoMapper;
using MIS.Application.DTOs.AuditLogging;
using MIS.Application.DTOs.Income;
using MIS.Domain.Entities.AuditLogging;
using MIS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MIS.Application.Mappings
{
    public class IncomeLogMappingProfiles : Profile
    {
        public IncomeLogMappingProfiles()
        {
            CreateMap<IncomeLog, IncomeDTO>().ReverseMap();
            CreateMap<IncomeLog, IncomeLogInfoDTO>()
                .ForMember(dest => dest.Branch,
                           src => src.MapFrom(x => $"{x.Branch.Address} {x.Branch.District}"))
                .ForMember(dest => dest.PaymentType,
                           src => src.MapFrom(x => x.PaymentType.GetAttribute<DisplayAttribute>().Name))
                .ForMember(dest => dest.Student,
                           src => src.MapFrom(x => $"{x.Student.FirstName} {x.Student.LastName}"))
                .ForMember(dest => dest.Group,
                           src => src.MapFrom(x => x.Group.Code))
                .ForMember(dest => dest.OperationType,
                           src => src.MapFrom(x => x.OperationType.ToString()))
                ;
        }
    }
}
