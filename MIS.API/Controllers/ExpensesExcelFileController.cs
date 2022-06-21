using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.API.Helpers;
using MIS.Application.Interfaces.Services.ExcelFileServices;
using MIS.Shared;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class ExpensesExcelFileController : BaseController
    {
        private readonly IExpensesExcelFileService _expensesExcelFileService;        

        public ExpensesExcelFileController(IExpensesExcelFileService expensesExcelFileService)
        {
            _expensesExcelFileService = expensesExcelFileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpensesExcelFile()
        {
            return File(await _expensesExcelFileService.CreateExpensesWorkbook(), FileContentType.Type, "expenses.xlsx");
        }
    }
}
