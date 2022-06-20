using MIS.Application.DTOs.TotalCashFlow;
using System.Collections.Generic;
using System.Threading.Tasks;
using MIS.Domain.Entities;

namespace MIS.Application.Interfaces.Services
{
    public interface ICashFlowService
    {
        Task CalculateDailyCashFlowAsync();     
        Task AddDailyIncomeToCashFlow();
        Task AddDailyExpensesToCashFlow();
        Task<IEnumerable<DailyCashFlowDTO>> GetDailyCashFlowAsync();        
        Task<IEnumerable<MonthlyCashFlowDTO>> GetMonthlyCashFlowAsync();
        Task<IEnumerable<YearlyCashFlowDTO>> GetYearlyCashFlowAsync();
    }
}
