using AutoMapper;
using MIS.Application.DTOs.Branch;
using MIS.Domain.Entities;

namespace MIS.Application.Mappings
{
    public class BranchMappingProfiles : Profile
    {
        public BranchMappingProfiles()
        {
            CreateMap<Branch, BranchDTO>().ReverseMap();
            CreateMap<Branch, BranchInfoDTO>();
        }
    }
}
