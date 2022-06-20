using Microsoft.AspNetCore.Mvc;
using MIS.API.Helpers;
using MIS.Application.Interfaces.Services.ExcelFileServices;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
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
