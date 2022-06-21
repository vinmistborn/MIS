using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.API.Helpers;
using MIS.Application.Interfaces.Services.ExcelFileServices;
using MIS.Shared;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class IncomeExcelFileController : BaseController
    {
        private readonly IIncomeExcelFileService _incomeExcelFileService;        

        public IncomeExcelFileController(IIncomeExcelFileService incomeExcelFileService)
        {
            _incomeExcelFileService = incomeExcelFileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetIncomeExcelFile()
        {
            return File(await _incomeExcelFileService.CreateIncomeWorkbook(), FileContentType.Type, "income.xlsx");
        }
    }
}
