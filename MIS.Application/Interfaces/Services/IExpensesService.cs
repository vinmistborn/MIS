using MIS.Application.DTOs.Expenses;
using MIS.Domain.Entities;
using MIS.Shared.Interfaces.Services;
using System.Threading.Tasks;

namespace MIS.Application.Interfaces.Services
{
    public interface IExpensesService : IGenericService<Expenses, ExpensesDTO, ExpensesInfoDTO>
    {
        Task<ExpensesInfoDTO> AddExpenseAsync(ExpensesDTO expensesDTO);
        Task<ExpensesInfoDTO> UpdateExpenseAsync(int id, ExpensesDTO expensesDTO);
    }
}
