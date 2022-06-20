using MIS.Application.DTOs.AuditLogging;
using MIS.Domain.Entities.AuditLogging;
using MIS.Shared.Interfaces.Services;

namespace MIS.Application.Interfaces.Services
{
    public interface IExpensesLogService : IGenericServiceInfoSpec<ExpensesLog, ExpensesLogInfoDTO>
    {

    }
}
