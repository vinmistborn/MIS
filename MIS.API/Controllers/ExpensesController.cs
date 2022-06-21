using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.Expenses;
using MIS.Application.Interfaces.Services;
using MIS.Application.Specifications.ExpensesSpec;
using MIS.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class ExpensesController : BaseController
    {
        private readonly IExpensesService _expensesService;
        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpensesInfoDTO>>> GetExpenses()
        {
            return Ok(await _expensesService.GetAllEntitiesSpecAsync(new ExpensesWithIncludesSpec()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpensesInfoDTO>> GetExpense(int id)
        {
            return Ok(await _expensesService.GetEntityInfoSpecAsync(new ExpensesWithIncludesSpec(id)));
        }

        [HttpGet("for-update/{id}")]
        public async Task<ActionResult<ExpensesInfoDTO>> GetExpenseForUpdate(int id)
        {
            return Ok(await _expensesService.GetEntityAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<ExpensesInfoDTO>> PostExpense(ExpensesDTO expense)
        {
            return Ok(await _expensesService.AddExpenseAsync(expense));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ExpensesInfoDTO>> PutExpense(int id, ExpensesDTO expense)
        {
            return Ok(await _expensesService.UpdateExpenseAsync(id, expense));
        }
    }
}
