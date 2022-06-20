using MIS.Application.DTOs.Income;
using MIS.Domain.Entities;
using MIS.Shared.Interfaces.Services;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Services
{
    public interface IIncomeService : IGenericService<Income, IncomeDTO, IncomeInfoDTO>
    {
        Task<IncomeInfoDTO> AddIncomeAsync(IncomeDTO incomeDTO);
        Task<IncomeInfoDTO> UpdateIncomeAsync(int id, IncomeDTO incomeDTO);
    }
}
