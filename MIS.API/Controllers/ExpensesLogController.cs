using Microsoft.AspNetCore.Mvc;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.ExpensesLogSpec;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    public class ExpensesLogController : BaseController
    {
        private readonly IExpensesLogService _expensesLogService;

        public ExpensesLogController(IExpensesLogService expensesLogService)
        {
            _expensesLogService = expensesLogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpensesLogs()
        {
            return Ok(await _expensesLogService.GetAllEntitiesSpecAsync(new ExpensesLogWithIncludesSpec()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpensesLog(int id)
        {
            return Ok(await _expensesLogService.GetEntityInfoSpecAsync(new ExpensesLogWithIncludesSpec(id)));
        }
    }
}
