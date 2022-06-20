using AutoMapper;
using MIS.Application.DTOs.AuditLogging;
using MIS.Application.Interfaces.Services;
using MIS.Domain.Entities.AuditLogging;
using MIS.Shared.Interfaces;

namespace MIS.Application.Services
{
    public class IncomeLogService : GenericServiceInfoSpec<IncomeLog, IncomeLogInfoDTO>, IIncomeLogService
    {
        public IncomeLogService(IRepository<IncomeLog> repo,
                                IMapper mapper) : base(repo, mapper)
        {

        }
    }
}
