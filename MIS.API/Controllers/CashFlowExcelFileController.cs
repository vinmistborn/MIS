using Microsoft.AspNetCore.Mvc;
using MIS.API.Helpers;
using MIS.Application.Interfaces.Services.ExcelFileServices;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
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
