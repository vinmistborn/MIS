using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.API.Helpers;
using MIS.Application.Interfaces.Services.ExcelFileServices;
using MIS.Shared;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class CashFlowExcelFileController : BaseController
    {
        private readonly ICashFlowExcelFileService _cashFlowExcelFileService;

        public CashFlowExcelFileController(ICashFlowExcelFileService cashFlowExcelFileService)
        {
            _cashFlowExcelFileService = cashFlowExcelFileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDailyCashFlowExcelFile()
        {
            return File(await _cashFlowExcelFileService.CreateCashFlowWorkbook(), FileContentType.Type, "dailyCashFlow.xlsx");
        }
    }
}
