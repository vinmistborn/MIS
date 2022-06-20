using AutoMapper;
using MIS.Application.DTOs.TotalCashFlow;
using MIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Application.Mappings
{
    public class CashFlowMappingProfile : Profile
    {
        public CashFlowMappingProfile()
        {
            CreateMap<TotalCashFlow, DailyCashFlowDTO>()
                .ForMember(dest => dest.Branch,
                           src => src.MapFrom(x => $"{x.Branch.Address} {x.Branch.District}"));
        }
    }
}
