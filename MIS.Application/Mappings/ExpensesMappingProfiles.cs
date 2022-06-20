using AutoMapper;
using MIS.Application.DTOs.Expenses;
using MIS.Domain.Entities;
using MIS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MIS.Application.Mappings
{
    public class ExpensesMappingProfiles : Profile
    {
        public ExpensesMappingProfiles()
        {
            CreateMap<Expenses, ExpensesDTO>().ReverseMap();
            CreateMap<Expenses, ExpensesInfoDTO>()
                .ForMember(dest => dest.Branch,
                           src => src.MapFrom(x => $"{x.Branch.Address} {x.Branch.District}"))
                .ForMember(dest => dest.PaymentType,
                           src => src.MapFrom(x => x.PaymentType.GetAttribute<DisplayAttribute>().Name))
                ;
        }
    }
}
