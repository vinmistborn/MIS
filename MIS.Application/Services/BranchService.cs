using AutoMapper;
using MIS.Application.DTOs.Branch;
using MIS.Domain.Entities;
using MIS.Application.Interfaces.Services;
using MIS.Shared.Interfaces;

namespace MIS.Application.Services
{
    public class BranchService : GenericService<Branch, BranchDTO, BranchInfoDTO>, IBranchService
    {
        public BranchService(IRepository<Branch> repo,
                             IMapper mapper) : base(repo, mapper)
        {
            
        }
    }
}
