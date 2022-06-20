using AutoMapper;
using MIS.Application.DTOs.AuditLogging;
using MIS.Application.DTOs.Expenses;
using MIS.Domain.Entities.AuditLogging;
using MIS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MIS.Application.Mappings
{
    public class ExpensesLogMappingProfiles : Profile
    {
        public ExpensesLogMappingProfiles()
        {
            CreateMap<ExpensesLog, ExpensesDTO>().ReverseMap();
            CreateMap<ExpensesLog, ExpensesLogInfoDTO>()
                .ForMember(dest => dest.Branch,
                           src => src.MapFrom(x => $"{x.Branch.Address} {x.Branch.District}"))
                .ForMember(dest => dest.PaymentType,
                           src => src.MapFrom(x => x.PaymentType.GetAttribute<DisplayAttribute>().Name))                
                .ForMember(dest => dest.OperationType,
                           src => src.MapFrom(x => x.OperationType.ToString()))
                ;
        }
    }
}
