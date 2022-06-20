using AutoMapper;
using MIS.Application.DTOs.AuditLogging;
using MIS.Application.Interfaces.Services;
using MIS.Domain.Entities.AuditLogging;
using MIS.Shared.Interfaces;

namespace MIS.Application.Services
{
    public class ExpensesLogService : GenericServiceInfoSpec<ExpensesLog, ExpensesLogInfoDTO>, IExpensesLogService
    {
        public ExpensesLogService(IRepository<ExpensesLog> repo,
                                  IMapper mapper) : base(repo, mapper)
        {

        }
    }
}
