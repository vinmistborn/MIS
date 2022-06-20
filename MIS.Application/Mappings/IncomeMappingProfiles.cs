using AutoMapper;
using MIS.Application.DTOs.Income;
using MIS.Domain.Entities;
using MIS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MIS.Application.Mappings
{
    public class IncomeMappingProfiles : Profile
    {
        public IncomeMappingProfiles()
        {
            CreateMap<Income, IncomeDTO>().ReverseMap();
            CreateMap<Income, IncomeInfoDTO>()
                .ForMember(dest => dest.Branch,
                           src => src.MapFrom(x => $"{x.Branch.Address} {x.Branch.District}"))
                .ForMember(dest => dest.PaymentType,
                           src => src.MapFrom(x => x.PaymentType.GetAttribute<DisplayAttribute>().Name))
                .ForMember(dest => dest.Student,
                           src => src.MapFrom(x => $"{x.Student.FirstName} {x.Student.LastName}"))
                .ForMember(dest => dest.Group,
                           src => src.MapFrom(x => x.Group.Code))
                ;
        }
    }
}
