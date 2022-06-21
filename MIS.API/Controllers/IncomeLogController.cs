using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.IncomeLogSpec;
using MIS.Shared;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class IncomeLogController : BaseController
    {
        private readonly IIncomeLogService _incomeLogService;

        public IncomeLogController(IIncomeLogService incomeLogService)
        {
            _incomeLogService = incomeLogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetIncomeLogs()
        {
            return Ok(await _incomeLogService.GetAllEntitiesSpecAsync(new IncomeLogWithIncludesSpec()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncomeLog(int id)
        {
            return Ok(await _incomeLogService.GetEntityInfoSpecAsync(new IncomeLogWithIncludesSpec(id)));
        }
    }
}
