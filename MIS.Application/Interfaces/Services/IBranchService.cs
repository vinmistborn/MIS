using MIS.Application.DTOs.Branch;
using MIS.Domain.Entities;
using MIS.Shared.Interfaces.Services;

namespace MIS.Application.Interfaces.Services
{
    public interface IBranchService : IGenericService<Branch, BranchDTO, BranchInfoDTO>
    {
        
    }
}
