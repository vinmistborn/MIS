using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.Income;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.IncomeSpec;
using MIS.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class IncomeController : BaseController
    {
        private readonly IIncomeService _incomeService;
        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomeInfoDTO>>> GetIncomes()
        {
            return Ok(await _incomeService.GetAllEntitiesSpecAsync(new IncomeWithIncludesSpec()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeInfoDTO>> GetIncome(int id)
        {
            return Ok(await _incomeService.GetEntityInfoSpecAsync(new IncomeWithIncludesSpec(id)));
        }

        [HttpGet("for-update/{id}")]
        public async Task<ActionResult<IncomeInfoDTO>> GetIncomeForUpdate(int id)
        {
            return Ok(await _incomeService.GetEntityAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<IncomeInfoDTO>> PostIncome(IncomeDTO income)
        {
            return Ok(await _incomeService.AddIncomeAsync(income));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IncomeInfoDTO>> PutIncome(int id, IncomeDTO income)
        {
            return Ok(await _incomeService.UpdateIncomeAsync(id, income));
        }
    }
}
